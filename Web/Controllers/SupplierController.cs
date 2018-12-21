using SupplierDocuments.Business;
using SupplierDocuments.Entities.ViewModels;
using System.Web.Mvc;
using System.Collections.Generic;

namespace SupplierDocuments.Controllers
{
    //Inheriting from Base Controller
    public class SupplierController : BaseController
    {
        #region Variable Declarations

        private SupplierBAL supplierBAL { get; set; }

        #endregion

        public ActionResult Search(List<SupplierMandatoryDocument> documents)
        {
            //var documents = new List<SupplierMandatoryDocument>();

            //if (filters != null)
            //{
            //    int regionID = filters.SupplyingRegionID;
            //    int supplyingCountryID = filters.SupplyingCountryID;
            //    int supplierTypeID = filters.SupplierTypeID;
            //    int supplierLocationID = filters.SupplierLocationID;

            //    supplierBAL = new SupplierBAL();

            //    documents = supplierBAL.GetSupplierDocuments(regionID, supplyingCountryID, supplierTypeID, supplierLocationID);

            //    filters.DocumentsList = documents;
            //}

            return PartialView("Search", documents);
        }

        [HttpPost]
        public ActionResult Index(DocumentFilter documentFilters)
        {
            
            supplierBAL = new SupplierBAL();

            documentFilters = supplierBAL.GetDocumentSearchFilters();

            //Get the supplier documents
            documentFilters.DocumentsList = GetSupplierDocuments(documentFilters);

            return View(documentFilters);
        }

        public ActionResult Index()
        {
            /* Get the viewmodel required to fill the search fiels */
            supplierBAL = new SupplierBAL();

            var documentFilters = supplierBAL.GetDocumentSearchFilters();
            /* Ends */

            

            return View(documentFilters);
        }

        private List<SupplierMandatoryDocument> GetSupplierDocuments(DocumentFilter filters)
        {
            var documents = new List<SupplierMandatoryDocument>();

            try
            {
                if (filters != null)
                {
                    int regionID = filters.SupplyingRegionID1;
                    int supplyingCountryID = filters.SupplyingCountryID1;
                    int supplierTypeID = filters.SupplierTypeID1;
                    int supplierLocationID = filters.SupplierLocationID1;

                    supplierBAL = new SupplierBAL();

                    documents = supplierBAL.GetSupplierDocuments(regionID, supplyingCountryID, supplierTypeID, supplierLocationID);

                    filters.DocumentsList = documents;
                }
            }
            catch
            {
                throw;
            }

            return documents;
        }
    }
}