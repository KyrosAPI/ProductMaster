using System.Collections.Generic;

namespace Kyros.ProductMaster.BusinessModel.Collections
{
    public class BaseCollection<T>
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<T> Items { get; set; }
    }
}
