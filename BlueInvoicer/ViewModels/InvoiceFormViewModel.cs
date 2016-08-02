using BlueInvoicer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlueInvoicer.ViewModels
{
    public class InvoiceFormViewModel
    {
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Required]
        public IEnumerable<Client> Clients { get; set; }
    }
}