using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlueInvoicer.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string InvoiceNumber { get; set; }

        [Required]
        public Client Client { get; set; }

        public bool Raised { get; set; }

        public bool Paid { get; set; }
    }
}