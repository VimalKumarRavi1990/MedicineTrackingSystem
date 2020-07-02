using MTSBusinessLogicLayer.Interfaces;
using MTSDataAccessLayer.Interfaces;
using System;
using Newtonsoft.Json.Linq;
using MTSDataAccessLayer.EntityModels;
using System.Collections.Generic;
using ViewModels;
using AutoMapper;
using System.Linq;

namespace MTSBusinessLogicLayer
{
    public class MedicalManager : IMedicalManager
    {
        IMedicalRepository _medicalRepository;
        public MedicalManager(IMedicalRepository medicalRepository)
        {
            _medicalRepository = medicalRepository;
        }
        public List<MedicineViewModel> getMedicines()
        {
            List<MedicineViewModel> medicineList = new List<MedicineViewModel>();
            medicineList = (from medicines in _medicalRepository.getMedicines()
                            select new MedicineViewModel
                            {
                                fullName = medicines.fullName,
                                brand = medicines.brand,
                                quantity = medicines.quantity,
                                price = medicines.price,
                                expiryDate = medicines.expiryDate
                            }).ToList();

            return medicineList;
        }

        public void updateMedicines(MedicineViewModel medicine)
        {
            MedicineModel medicineModel = new MedicineModel();

            medicineModel.id = medicine.id;
            medicineModel.fullName = medicine.fullName;
            medicineModel.brand = medicine.brand;
            medicineModel.quantity = medicine.quantity;
            medicineModel.price = medicine.price;
            medicineModel.quantity = medicine.quantity;

            _medicalRepository.updateMedicines(medicineModel);
        }

        public void addMedicine(MedicineViewModel medicine)
        {
            MedicineModel medicineModel = new MedicineModel();

            medicineModel.id = medicine.id;
            medicineModel.fullName = medicine.fullName;
            medicineModel.brand = medicine.brand;
            medicineModel.quantity = medicine.quantity;
            medicineModel.price = medicine.price;
            medicineModel.quantity = medicine.quantity;
            medicineModel.notes = medicine.notes;
            medicineModel.expiryDate = medicine.expiryDate;
            _medicalRepository.addMedicine(medicineModel);
        }
    }
}
