using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SupplierDocuments.Entities.ViewModels
{
    public class DocumentFilter
    {
        public int SupplyingRegionID { get; set; }
        public int SupplyingCountryID { get; set; }
        public int SupplierLocationID { get; set; }
        public int SupplierTypeID { get; set; }

        [Display(Name = "Supplying Region")]
        public List<SupplyingRegion> SupplyingRegions { get; set; }

        [Display(Name = "Supplying Country")]
        public List<SupplyingCountry> SupplyingCountrys { get; set; }

        [Display(Name = "Supplier Location")]
        public List<SupplierLocation> SupplierLocations { get; set; }

        [Display(Name = "Supplier Type")]
        public List<SupplierType> SupplierTypes { get; set; }
    }
}