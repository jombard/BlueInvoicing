﻿using System;
using BlueInvoicer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlueInvoicer.ViewModels
{
    public class InvoiceFormViewModel
    {
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        [Required]
        public IEnumerable<Contract> Contracts { get; set; }

        [Display(Name = "Rate Type")]
        public IEnumerable<RateType> RateType { get; set; }

        public string SelectedRateType { get; set; }

        public string Rate { get; set; }

        [Display(Name = "Out of Hours Rate Type")]
        public IEnumerable<RateType> OvertimeRateType { get; set; }

        [Display(Name = "Out of Hours Rate")]
        public string OvertimeRate { get; set; }

        public List<InvoiceEntry> InvoiceEntries { get; set; }

        public void AddInvoiceEntry(InvoiceFormViewModel viewModel)
        {
            InvoiceEntries.Add(new InvoiceEntry
            {
                Description = "1"
            });
        }

        public void RemoveInvoiceEntry(int index)
        {
            InvoiceEntries.RemoveAt(index);
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}