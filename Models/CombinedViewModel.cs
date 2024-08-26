using System.Collections.Generic;

namespace DoQuocHuy0352.Context
{
    public class CombinedViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
