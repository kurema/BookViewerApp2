using System;
using System.Collections.Generic;

using System.Linq;

namespace BookViewerApp2.Helper.Order
{
    public class OrderReversed<T> : IOrder<T>
    {
        public OrderReversed(IOrder<T> content)
        {
            if (Content == null) throw new ArgumentNullException(nameof(content));
            if (Content is OrderReversed<T> rev)
            {
                Content = rev.Content;
                Reverse = !rev.Reverse;
            }
            else { Content = content; }
        }

        public IOrder<T> Content { get; private set; }
        public bool Reverse { get; private set; }

        public string NameKey => Content.NameKey + (Reverse ? "_Reverse" : "");

        public IEnumerable<T> Sort(IEnumerable<T> item)
        {
            return Reverse ? Content.Sort(item).Reverse() : Content.Sort(item);
        }
    }
}
