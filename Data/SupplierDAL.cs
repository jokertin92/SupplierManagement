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

        public List<SupplierMandatoryDocument> GetSupplierDocuments(DocumentFilter documentFilter)
        {
            List<SupplierMandatoryDocument> documents = null;

            try
            {
                using (dataContext = new DataContext())
                {
                    int regionID = documentFilter.SupplyingRegionID;
                    int supplyingCountryID = documentFilter.SupplyingCountryID;
                    int supplierTypeID = documentFilter.SupplierTypeID;
                    int supplierLocationID = documentFilter.SupplierLocationID;

                    documents = (from sd in dataContext.SupplierDocuments
                                 join sr in dataContext.Regions on sd.SupplyingRegionID equals sr.RegionID
                                 join sc in dataContext.Countries on sd.SupplyingCountryID equals sc.CountryID
                                 join sl in dataContext.Countries on sd.SupplierLocationID equals sl.CountryID
                                 join st in dataContext.SupplierTypes on sd.SupplierTypeID equals st.SupplierTypeID
                                 join d in dataContext.Documents on sd.DocumentID equals d.DocumentID
                                 where sr.RegionID == regionID && sc.CountryID == supplyingCountryID &&
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

                    //Fill the supplying regions (Filter with StatusID)
                    documentFilter.SupplyingRegions = dataContext.Regions.Where(r=>r.StatusID == 1).OrderBy(r => r.RegionName).ToList();

                    //Fill the supplying countries
                    documentFilter.SupplyingCountries = dataContext.Countries.OrderBy(c=>c.CountryName).ToList();

                    //Fill the supplier locations
                    documentFilter.SupplierLocations = dataContext.Countries.OrderBy(c=>c.CountryName).ToList();

                    //Fill the supplier types
                    documentFilter.SupplierTypes = dataContext.SupplierTypes.OrderBy(t=>t.TypeName).ToList();

                    //Fill the document list with empty list
                    documentFilter.DocumentsList = new List<SupplierMandatoryDocument>();
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
