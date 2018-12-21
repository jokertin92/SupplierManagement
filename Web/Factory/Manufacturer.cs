using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupplierDocuments.Entities.ViewModels;

namespace SupplierDocuments.Factories
{
    public class Manufacturer : Supplier, ISupplier
    {
        public void GetMandatoryDocuments()
        {
            
        }

        public void GetSupplierCost()
        {
            //Do Custom Calculation
        }
    }
}