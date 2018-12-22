using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupplierDocuments.Entities.ViewModels;
using Data;

namespace SupplierDocuments.Business
{
    public class SupplierBAL
    {
        #region Variable Declarations

        private SupplierDAL supplierDAL { get; set; }

        #endregion

        #region Get Mandatory Documents

        public List<SupplierMandatoryDocument> GetSupplierDocuments(DocumentFilter documentFilter)
        {
            List<SupplierMandatoryDocument> documents = null;

            try
            {
                supplierDAL = new SupplierDAL();

                documents = supplierDAL.GetSupplierDocuments(documentFilter);
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
                supplierDAL = new SupplierDAL();

                documentFilter = supplierDAL.GetDocumentSearchFilters();
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
