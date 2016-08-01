using System.ComponentModel.DataAnnotations;

namespace BlueInvoicer.Models
{
    public class RateType
    {
        public int Id { get; set; }

        [StringLength(12)]
        public string Rate { get; set; }
    }
}