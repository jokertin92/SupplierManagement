using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierDocuments.Entities.ViewModels
{
    public class SupplierMandatoryDocument
    {
        public int SupplierDocumentID { get; set; }
        public string SupplyingRegion { get; set; }
        public string SupplyingCountry { get; set; }
        public string SupplierLocation { get; set; }
        public string SupplierType { get; set; }
        public string DocumentName { get; set; }
    }
}
