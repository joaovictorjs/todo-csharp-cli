namespace ToDo.Domain.Extensions;

public static class ListExtensions
{
    public static void Add<T>(this IList<T> source, bool predicate, T item)
    {
        if (predicate)
            source.Add(item);
    }
}
