using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTSBusinessLogicLayer.Interfaces;
using Newtonsoft.Json.Linq;
using ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicineTrackingSystem.Controllers
{
    [Route("api/medicaltracking")]
    [ApiController]
    public class MedicalTrackingController : ControllerBase
    {
        IMedicalManager _medicalManager;

        public MedicalTrackingController(IMedicalManager medicalManager)
        {
            _medicalManager = medicalManager;
        }
        // GET: api/<MedicalTrackingController>
        [HttpGet("getmedicines")]
        public IActionResult GetMedicines()
        {
            List<MedicineViewModel> medicineList = new List<MedicineViewModel>();
            try
            {
                medicineList = _medicalManager.getMedicines();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(medicineList);
        }

        [HttpPost]
        [Route("updatemedicine")]
        public void updateMedicine([FromBody] MedicineViewModel medicine)
        {         
            try
            {
                _medicalManager.updateMedicines(medicine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<MedicalTrackingController>/5
        [HttpPost]
        [Route("addmedicine")]
        public void addMedicine([FromBody] MedicineViewModel medicine)
        {
            try
            {
                _medicalManager.addMedicine(medicine);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
    }
}
