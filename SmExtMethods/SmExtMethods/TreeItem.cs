using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmExtentionsMethods
{

    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }
}
