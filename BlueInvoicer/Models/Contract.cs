using System;

namespace BlueInvoicer.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Client Client { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Rate { get; set; }

        public decimal OvertimeRate { get; set; }

        public enum RateType
        {
            Hourly = 0,
            Daily,
            Weekly,
            Monthly
        }
    }
}