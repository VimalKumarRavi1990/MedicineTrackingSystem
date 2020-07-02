using System;
using System.Collections.Generic;
using System.Text;
using MTSDataAccessLayer.EntityModels;
using Newtonsoft.Json.Linq;

namespace MTSDataAccessLayer.Interfaces
{
    public interface IMedicalRepository
    {
        public List<MedicineModel> getMedicines();
        void updateMedicines(MedicineModel medicine);
        void addMedicine(MedicineModel medicine);
    }
}
