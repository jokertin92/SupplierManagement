using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace SupplierDocuments.Entities.ViewModels
{
    public class DocumentFilter
    {
        public int SupplyingRegionID1 { get; set; }
        public int SupplyingCountryID1 { get; set; }
        public int SupplierLocationID1 { get; set; }
        public int SupplierTypeID1 { get; set; }

        [DisplayName("Supplying Region")]
        public List<SupplyingRegion> SupplyingRegions { get; set; }

        [DisplayName("Supplying Country")]
        public List<SupplyingCountry> SupplyingCountries { get; set; }

        [DisplayName("Supplier Location")]
        public List<SupplierLocation> SupplierLocations { get; set; }

        [DisplayName("Supplier Type")]
        public List<SupplierType> SupplierTypes { get; set; }

        public List<SupplierMandatoryDocument> DocumentsList { get; set; }
    }
}