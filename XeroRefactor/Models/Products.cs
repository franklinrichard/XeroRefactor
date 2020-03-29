using System;
using System.Collections.Generic;

namespace XeroRefactor
{
    public partial class Products
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Price { get; set; }
        public byte[] DeliveryPrice { get; set; }
    }
}
