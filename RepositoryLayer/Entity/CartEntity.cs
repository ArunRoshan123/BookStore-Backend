using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class CartEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cart_Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual UserEntity User { get; set; }
        [ForeignKey("Book")]
        public int Book_Id { get; set; }
        [JsonIgnore]
        public virtual BookEntity Book { get; set; }
        public int Cart_Quantity { get; set; }
        public bool IsPurchase { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
