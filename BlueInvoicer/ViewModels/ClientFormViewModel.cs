using System.ComponentModel.DataAnnotations;

namespace BlueInvoicer.ViewModels
{
    public class ClientFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string InvoiceEmail { get; set; }
    }
}