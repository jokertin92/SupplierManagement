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
        /* Properties that hold dropdown's selected value */
        public int SupplyingRegionID { get; set; }
        public int SupplyingCountryID { get; set; }
        public int SupplierLocationID { get; set; }
        public int SupplierTypeID { get; set; }
        /* End */

        [DisplayName("Supplying Region")]
        public List<Region> SupplyingRegions { get; set; }

        [DisplayName("Supplying Country")]
        public List<Country> SupplyingCountries { get; set; }

        [DisplayName("Supplier Location")]
        public List<Country> SupplierLocations { get; set; }

        [DisplayName("Supplier Type")]
        public List<SupplierType> SupplierTypes { get; set; }

        public List<SupplierMandatoryDocument> DocumentsList { get; set; }
    }
}