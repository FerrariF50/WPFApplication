using BlankApp1.Models;
using System.Collections.Generic;

namespace BlankApp1.Dto
{
    public class Response
    {
        //public class Body
        //{
        //    public int CustomerId { get; set; }
        //    public string Name { get; set; }
        //    public string CompanyName { get; set; }
        //    public string Phone { get; set; }
        //    public string Email { get; set; }
        //}

        public List<Customer> Body { get; set; }
        public bool HasError { get; set; }
        public object Error { get; set; }
    }
}
