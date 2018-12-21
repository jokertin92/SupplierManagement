using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierDocuments.Factories
{
    public class ManufacturerFactory : ISupplierFactory
    {
        public ISupplier GetSupplier()
        {
            return new Manufacturer();
        }
    }
}
