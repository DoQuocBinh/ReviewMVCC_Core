using System;
using System.Collections.Generic;

#nullable disable

namespace ReviewMVCC_Core.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
