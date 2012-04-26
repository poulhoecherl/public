using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CatEnum
{
    
    public class Item
    {
        public Item(String thisProductId, String thisProductName, String thisCategory)
        {
            this.ProductId = thisProductId;
            this.ProductName = thisProductName;
            this.Category = thisCategory;
        }

        public String ProductId { get; set; }
        
        public String ProductName { get; set; }
        
        public String Category { get; set; }
    }
}
