using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierDocuments.Entities.ViewModels
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public SupplierTypes SupplierType { get; set; }
    }

    public enum SupplierTypes
    {
        Manufacturer = 1,
        Distributors,
        Franchisors
    }
}
