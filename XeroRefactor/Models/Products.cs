﻿using System;
using System.Collections.Generic;

namespace XeroRefactor
{
    public partial class Products
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
