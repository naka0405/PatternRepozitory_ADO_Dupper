using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Models
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(int id, string name, int tel, int city, int segment)
        {
            Customer_Id = id;
            Customer_Name = name;
            Customer_Tel = tel;
            City_Id = city;
            Segment_Id = segment;
        }
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public int Customer_Tel { get; set; }
        public int City_Id { get; set; }
        public int Segment_Id { get; set; }

        public override string ToString()
        {
            return $"#{Customer_Id}| {Customer_Name} |tel: {Customer_Tel} |city: {City_Id} |segment: {Segment_Id}";
        }
    }
}
