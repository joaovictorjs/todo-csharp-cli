using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ToDo.Infra.Contexts;

public class SqliteContext(DbContextOptions<SqliteContext> options) : DbContext(options) { }
