using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using DelegateDecompiler;
using Newtonsoft.Json;

namespace BlueInvoicer.Models
{
    public class InvoiceEntry
    {
        public int Id { get; set; }

        public Invoice Invoice { get; set; }

        [Required, StringLength(1024)]
        public string Description { get; set; }

        public RateType RateType { get; set; }

        public int Quantity { get; set; }

        public int Rate { get; set; }

        [Computed]
        [ScriptIgnore]
        [JsonIgnore]
        public int Amount => Rate*Quantity;
    }
}