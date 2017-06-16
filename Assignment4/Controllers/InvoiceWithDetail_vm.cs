using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Assignment4.Controllers
{
    public class InvoiceWithDetail : InvoiceBase
    {
        public InvoiceWithDetail()
        {

            InvoiceLines = new List<InvoiceLineWithDetail>();

        }

        public IEnumerable<InvoiceLineWithDetail> InvoiceLines { get; set; }
        [DisplayName("Customer First Name")]
        public string CustomerFirstName { get; set; }

        [DisplayName("Customer Last Name")]
        public string CustomerLastName { get; set; }

        [DisplayName("Billing City")]
        public string CustomerCity { get; set; }

        [DisplayName("Billing State")]
        public string CustomerState { get; set; }

        [DisplayName("Sales Representative First Name")]
        public string CustomerEmployeeFirstName { get; set; }

        [DisplayName("Sales Representative Last Name")]
        public string CustomerEmployeeLastName { get; set; }
    }
}