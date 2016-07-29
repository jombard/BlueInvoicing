using System;
using System.ComponentModel.DataAnnotations;

namespace BlueInvoicer.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string InvoiceNumber { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public int Amount { get; set; }

        [StringLength(10)]
        public string PurchaseOrder { get; set; }

        public bool Raised { get; set; }

        public bool Paid { get; set; }

        public DateTime DateRemittanceReceived { get; set; }

        [StringLength(1024)]
        public string Notes { get; set; }
    }

}