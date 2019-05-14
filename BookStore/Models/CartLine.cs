using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CartLine
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}