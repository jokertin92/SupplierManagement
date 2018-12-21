using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using SupplierDocuments.Entities.ViewModels;
using SupplierDocuments.Entities;

namespace Data
{
    public class SupplierDAL
    {
        #region Variable Declarations

        private DataContext dataContext { get; set; }

        #endregion

        #region Get Mandatory Documents

        public List<SupplierMandatoryDocument> GetSupplierDocuments(int regionID, int supplyingCountryID, int supplierTypeID, int supplierLocationID)
        {
            List<SupplierMandatoryDocument> documents = null;

            try
            {
                using (dataContext = new DataContext())
                {
                    documents = (from sd in dataContext.SupplierDocuments
                                 join sr in dataContext.SupplyingRegions on sd.SupplyingRegionID equals sr.RegionID
                                 join sc in dataContext.SupplyingCountries on sd.SupplyingCountryID equals sc.SupplyingCountryID
                                 join sl in dataContext.SupplierLocations on sd.SupplierLocationID equals sl.CountryID
                                 join st in dataContext.SupplierTypes on sd.SupplierTypeID equals st.SupplierTypeID
                                 join d in dataContext.Documents on sd.DocumentID equals d.DocumentID
                                 where sr.RegionID == regionID && sc.SupplyingCountryID == supplyingCountryID &&
                                       st.SupplierTypeID == supplierTypeID && sl.CountryID == supplierLocationID

                                 select new SupplierMandatoryDocument
                                 {
                                     SupplierDocumentID = d.DocumentID,
                                     SupplyingRegion = sr.RegionName,
                                     DocumentName = d.DocumentName,
                                     SupplyingCountry = sc.CountryName,
                                     SupplierLocation = sl.CountryName,
                                     SupplierType = st.TypeName
                                 }).ToList();
                }
            }
            catch
            {
                throw;
            }

            return documents;
        }

        #endregion

        #region Get Document Filters

        public DocumentFilter GetDocumentSearchFilters()
        {
            DocumentFilter documentFilter = null;

            try
            {
                using (dataContext = new DataContext())
                {
                    documentFilter = new DocumentFilter();

                    //Fill the supplying regions
                    documentFilter.SupplyingRegions = dataContext.SupplyingRegions.ToList();

                    //Fill the supplying countries
                    documentFilter.SupplyingCountrys = dataContext.SupplyingCountries.ToList();

                    //Fill the supplier locations
                    documentFilter.SupplierLocations = dataContext.SupplierLocations.ToList();

                    //Fill the supplier types
                    documentFilter.SupplierTypes = dataContext.SupplierTypes.ToList();
                }
            }
            catch
            {
                throw;
            }

            return documentFilter;
        }

        #endregion
    }
}
