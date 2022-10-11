﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IntroSQL
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public double Price { get; set; }
        public double StockLevel { get; set; }
        public int OnSale { get; set; }

    }
}
