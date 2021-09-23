using System;

public static class ImprovedLinq
{
    public static TSource FirstOrDefault<TSource>(this TSource[] source, Func<TSource, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        foreach (TSource element in source)
        {
            if (predicate(element)) return element;
        }

        return default(TSource);
    }
}