﻿namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Product p)
            {
                return Name == p.Name && Price == p.Price;
            }

            return false;
        }
    }
}
