using System;
using System.Collections.Generic;

namespace BookViewerApp2.Helper.Order
{
    public class OrderFunc<T> : IOrder<T>
    {
        public OrderFunc(string nameKey, Func<IEnumerable<T>, IEnumerable<T>> func)
        {
            NameKey = nameKey ?? throw new ArgumentNullException(nameof(nameKey));
            Func = func ?? throw new ArgumentNullException(nameof(func));
        }

        public string NameKey { get; private set; }
        public Func<IEnumerable<T>, IEnumerable<T>> Func { get; private set; }

        public IEnumerable<T> Sort(IEnumerable<T> item) => Func(item);
    }

    public class OrderKeep<T> : IOrder<T>
    {
        public string NameKey => "";

        public IEnumerable<T> Sort(IEnumerable<T> item) => item;
    }

}
