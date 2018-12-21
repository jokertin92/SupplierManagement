using SupplierDocuments.Business;
using System.Web.Mvc;

namespace SupplierDocuments.Controllers
{
    //Inheriting from Base Controller
    public class SupplierController : BaseController
    {
        #region Variable Declarations

        private SupplierBAL supplierBAL { get; set; }

        #endregion

        public ActionResult Index1(int regionID, int supplyingCountryID, int supplierTypeID, int supplierLocationID)
        {
            supplierBAL = new SupplierBAL();

            var documents = supplierBAL.GetSupplierDocuments(regionID, supplyingCountryID, supplierTypeID, supplierLocationID);

            return View(documents);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Index()
        {
            /* Get the viewmodel required to fill the search fiels */
            supplierBAL = new SupplierBAL();

            var documentFilters = supplierBAL.GetDocumentSearchFilters();
            /* Ends */

            return View(documentFilters);
        }
    }
}