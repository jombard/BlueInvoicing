using System.ComponentModel.DataAnnotations;

namespace BlueInvoicer.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        [StringLength(255)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string InvoiceEmail { get; set; }
    }
}