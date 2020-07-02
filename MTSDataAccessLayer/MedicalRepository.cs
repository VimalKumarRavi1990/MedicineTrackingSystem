using MTSDataAccessLayer.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MTSDataAccessLayer.EntityModels;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MTSDataAccessLayer
{
    public class MedicalRepository : IMedicalRepository
    {
        IHostingEnvironment _hostingEnvironment;
        public MedicalRepository(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;

        }

        public List<MedicineModel> getMedicines()
        {
            List<MedicineModel> medicineList = new List<MedicineModel>();
            try
            {
                var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, $"wwwroot\\{"JsonFiles\\medicines.json"}");
                var json = File.ReadAllText(filePath);

                medicineList = JsonConvert.DeserializeObject<List<MedicineModel>>(json);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return medicineList;
        }

        public void updateMedicines(MedicineModel medicine)
        {
            List<MedicineModel> medicineList = new List<MedicineModel>();

            try
            {
                var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, $"wwwroot\\{"JsonFiles\\medicines.json"}");
                var json = File.ReadAllText(filePath);

                medicineList = JsonConvert.DeserializeObject<List<MedicineModel>>(json);

                medicineList.ForEach((x) =>
                {
                    if (x.id == medicine.id)
                    {
                        x.fullName = medicine.fullName;
                        x.price = medicine.price;
                        x.quantity = medicine.quantity;
                        x.expiryDate = medicine.expiryDate;
                        x.brand = medicine.brand;
                    };
                });

                string output = JsonConvert.SerializeObject(medicineList, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, output);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void addMedicine(MedicineModel medicine)
        {
            List<MedicineModel> medicineList = new List<MedicineModel>();

            try
            {
                var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, $"wwwroot\\{"JsonFiles\\medicines.json"}");
                var json = File.ReadAllText(filePath);

                medicineList = JsonConvert.DeserializeObject<List<MedicineModel>>(json);

                int maxId = medicineList.Select(x => x.id).Max();

                medicine.id = maxId + 1;
                medicineList.Add(medicine);

                string output = JsonConvert.SerializeObject(medicineList, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, output);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
