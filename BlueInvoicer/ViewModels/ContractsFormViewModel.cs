using BlueInvoicer.Controllers;
using BlueInvoicer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BlueInvoicer.ViewModels
{
    public class ContractsFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ClientId { get; set; }

        public string Client { get; set; }

        [Required, Display(Name = "Contract Start Date")]
        public string StartDate { get; set; }

        [Required, Display(Name = "Contract End Date")]
        public string EndDate { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required, Display(Name = "Rate Type")]
        public int RateType { get; set; }

        public decimal OvertimeRate { get; set; }

        public IEnumerable<RateType> RateTypes { get; set; }

        [Display(Name = "Overtime Rate Type")]
        public int OvertimeRateType { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<ContractsController, ActionResult>> update = c => c.Update(this);
                Expression<Func<ContractsController, ActionResult>> create = c => c.Create(this);

                var action = Id != 0 ? update : create;
                return (action.Body as MethodCallExpression)?.Method.Name;
            }
        }
    }
}