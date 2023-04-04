using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SwaggerApi.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// ürün fiyatı
        /// </summary>
        [Required]
        public decimal Price { get; set; }
        /// <summary>
        /// ürün eklenme tarihi
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// ürün kategorisi
        /// </summary>
        public string Category { get; set; }
    }
}
