using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookStore.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int BookId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Author { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Publishing { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Series { get; set; }


        public string Binding { get; set; }

        [Range(0, 999999)]
        public int NumberOfPages { get; set; }

        [Range(0, 999999)]
        public double Price { get; set; }

        [Range(0, 999999)]
        public double DiscountPrice { get; set; }

        [Range(0, 999999999999999999)]
        public int Quantity { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Category { get; set; }
    }
}