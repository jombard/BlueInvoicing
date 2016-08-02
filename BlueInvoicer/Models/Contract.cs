using System;
using System.ComponentModel.DataAnnotations;

namespace BlueInvoicer.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        public Client Client { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal Rate { get; set; }

        public decimal OvertimeRate { get; set; }

        public RateType RateType { get; set; }

        [Required]
        public int RateTypeId { get; set; }

        public RateType OvertimeRateType { get; set; }

        [Required]
        public int OvertimeRateTypeId { get; set; }
    }
}