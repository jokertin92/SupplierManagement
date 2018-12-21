using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierDocuments.Factories
{
    public interface ISupplier
    {
        void GetMandatoryDocuments();

        //Not required, just for demo purpose
        void GetSupplierCost();
    }
}
