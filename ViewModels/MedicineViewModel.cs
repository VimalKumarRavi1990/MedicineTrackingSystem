using System;

namespace ViewModels
{
    public class MedicineViewModel
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string brand { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string expiryDate { get; set; }
        public string notes { get; set; }
    }
}
