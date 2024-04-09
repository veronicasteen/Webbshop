﻿namespace Webbshop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public int? AccountID { get; set; }
        public Account Account { get; set; }
    }
}
