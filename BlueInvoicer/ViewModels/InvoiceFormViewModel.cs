using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlueInvoicer.Models;

namespace BlueInvoicer.ViewModels
{
    public class InvoiceFormViewModel
    {
        public int ClientId { get; set; }

        [Required]
        public IEnumerable<Client> Clients { get; set; }
    }
}