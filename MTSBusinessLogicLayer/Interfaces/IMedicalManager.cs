using System;
using System.Collections.Generic;
using System.Text;
using MTSDataAccessLayer.EntityModels;
using Newtonsoft.Json.Linq;
using ViewModels;

namespace MTSBusinessLogicLayer.Interfaces
{
    public interface IMedicalManager
    {
        public List<MedicineViewModel> getMedicines();
        void updateMedicines(MedicineViewModel medicine);
        void addMedicine(MedicineViewModel medicine);
    }
}
