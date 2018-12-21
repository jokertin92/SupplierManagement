using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SupplierDocuments.Entities.ViewModels
{
    public class SupplierMandatoryDocument
    {
        public int SupplierDocumentID { get; set; }

        [DisplayName("Supplying Region")]
        public string SupplyingRegion { get; set; }

        [DisplayName("Supplying Country")]
        public string SupplyingCountry { get; set; }

        [DisplayName("Supplier Location")]
        public string SupplierLocation { get; set; }

        [DisplayName("Supplier Type")]
        public string SupplierType { get; set; }

        [DisplayName("Document Name")]
        public string DocumentName { get; set; }
    }
}
