using System.Collections.Generic;

namespace BlueInvoicer.ViewModels
{
    public class InvoiceListModel
    {
        public List<InvoiceFormViewModel> InvoiceEntries { get; set; }

        public void AddInvoiceEntry()
        {
            InvoiceEntries.Add(new InvoiceFormViewModel());
        }

        public void RemoveInvoiceEntry(int index)
        {
            InvoiceEntries.RemoveAt(index);
        }
    }

    public class InvoiceModelsModel
    {
        public InvoiceListModel InvoiceListModel { get; set; }
        public InvoiceFormViewModel InvoiceFormViewModel { get; set; }
    }
}