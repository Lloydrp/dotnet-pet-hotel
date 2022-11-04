using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public class Transaction
    {
        public int id { get; set; }

        [Required]
        public string description { get; set; }

        public DateTime timestamp { get; set; }

        // breaks the server
        // public Transaction(string note)
        // {
        //     this.description = note;
        //     this.timestamp = DateTime.Now;
        // }
    }
}
