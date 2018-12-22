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

        #region Post Method

        [HttpPost]
        public ActionResult Index(DocumentFilter documentFilters)
        {            
            //Get the supplier documents
            documentFilters.DocumentsList = GetSupplierDocuments(documentFilters);

            /* Rebind the dropdowns */
            var filter = GetDropDownFilterItems();

            documentFilters.SupplyingRegions = filter.SupplyingRegions;
            documentFilters.SupplyingCountries= filter.SupplyingCountries;
            documentFilters.SupplierLocations = filter.SupplierLocations;
            documentFilters.SupplierTypes = filter.SupplierTypes;
            /* Ends */

            return View(documentFilters);
        }

        #endregion

        #region Get Method

        [HttpGet]
        public ActionResult Index()
        {
            //Clear the session
            Session["Filters"] = null;

            /* Get the viewmodel required to fill the search fiels */
            supplierBAL = new SupplierBAL();

            var documentFilters = supplierBAL.GetDocumentSearchFilters();
            /* Ends */

            //Fill the dropdown filters into the session
            Session["Filters"] = documentFilters;

            return View(documentFilters);
        }

        #endregion

        #region Get Supplier Documents

        private List<SupplierMandatoryDocument> GetSupplierDocuments(DocumentFilter filters)
        {
            var documents = new List<SupplierMandatoryDocument>();

            try
            {
                if (filters != null)
                {
                    supplierBAL = new SupplierBAL();

                    documents = supplierBAL.GetSupplierDocuments(filters);
                }
            }
            catch
            {
                throw;
            }

            return documents;
        }

        #endregion

        #region Get Dropdown Filters

        private DocumentFilter GetDropDownFilterItems()
        {
            var documentFilters = new DocumentFilter();
            
            if (Session["Filters"] != null)
            {
                documentFilters = Session["Filters"] as DocumentFilter;
            }
            else
            {
                /* Get the viewmodel required to fill the search fiels */
                supplierBAL = new SupplierBAL();

                documentFilters = supplierBAL.GetDocumentSearchFilters();
                /* Ends */

                //Keep the filters in session for rebinding
                Session["Filters"] = documentFilters;
            }

            return documentFilters;
        }

        #endregion
    }
}