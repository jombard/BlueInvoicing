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

        [Required]
        public IEnumerable<Client> Clients { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Rate { get; set; }

        public decimal OvertimeRate { get; set; }

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