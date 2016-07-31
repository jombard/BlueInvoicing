using BlueInvoicer.Controllers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace BlueInvoicer.ViewModels
{
    public class ClientFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        public string InvoiceEmail { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<ClientsController, ActionResult>> update = c => c.Update(this);
                Expression<Func<ClientsController, ActionResult>> create = c => c.Create(this);

                var action = Id != 0 ? update : create;
                return (action.Body as MethodCallExpression)?.Method.Name;
            }
        }
    }
}