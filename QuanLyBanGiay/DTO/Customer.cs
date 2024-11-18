using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int LoyaltyPoints { get; set; }
        public double Spending { get; set; }
        public int ProductsPurchased { get; set; }

        public Customer(string name, int age, int loyaltyPoints, double spending, int productsPurchased)
        {
            Name = name;
            Age = age;
            LoyaltyPoints = loyaltyPoints;
            Spending = spending;
            ProductsPurchased = productsPurchased;
        }
    }
}
