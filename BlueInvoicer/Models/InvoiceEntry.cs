using System.ComponentModel.DataAnnotations;

namespace BlueInvoicer.Models
{
    public class InvoiceEntry
    {
        public int Id { get; set; }

        public Invoice Invoice { get; set; }

        [Required, StringLength(1024)]
        public string Description { get; set; }

        public RateType RateType { get; set; }

        public int Amount { get; set; }

        public string Rate { get; set; }

        public int Quantity { get; set; }
    }
}