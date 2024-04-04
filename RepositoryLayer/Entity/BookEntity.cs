using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Book_Image { get; set; }
        public int Price { get; set; }
        public int Discount_Price { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
