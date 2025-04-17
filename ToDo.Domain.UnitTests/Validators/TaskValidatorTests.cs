﻿using System.Linq.Expressions;
using Moq;
using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Validators;
using TaskModel = ToDo.Domain.Models.Task;

namespace ToDo.Domain.UnitTests.Validators;

public class TaskValidatorTests
{
    private readonly ITaskValidator _validator;
    private readonly Mock<IRepository<TaskModel>> _repository;

    public TaskValidatorTests()
    {
        _repository = new Mock<IRepository<TaskModel>>();
        _validator = new TaskValidator(_repository.Object);
    }

    [Fact]
    public async Task ShouldThrow_ValidationException_WhenNameIsNullOrEmpty()
    {
        var model = new TaskModel
        {
            Name = string.Empty,
            Description = string.Empty,
            IsDone = false,
        };

        await Assert.ThrowsAsync<ValidationException>(
            () => _validator.Validate(Operation.Create, model)
        );
    }

    [Fact]
    public async Task ShouldThrow_ValidationException_WhenNameAlreadyExists()
    {
        var model = new TaskModel
        {
            Name = "Foo",
            Description = string.Empty,
            IsDone = false,
        };

        _repository
            .Setup(it => it.ReadAsync(It.IsAny<Expression<Func<TaskModel, bool>>>()))
            .ReturnsAsync([model]);

        var ex = await Record.ExceptionAsync(() => _validator.Validate(Operation.Create, model));

        Assert.IsType<ValidationException>(ex);
        Assert.Equal("This name is already in use.", ex.Message);
    }
}
