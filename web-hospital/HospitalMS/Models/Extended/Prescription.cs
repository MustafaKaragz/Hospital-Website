using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HospitalMS.Models
{
    [MetadataType(typeof(PrescriptionMetaData))]
    public partial class Prescription
    {
        
    }


    public class PrescriptionMetaData   
    {

        [Display(Name = "Patient Name")]
        public string PatientsName { get; set; }

        [Display(Name = "Prescription Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime PrescriptionDate { get; set; }

        [Display(Name = "Dosage")]
        public string Dosage { get; set; }

        [Display(Name = "Medication")]
        public string Medicine { get; set; }

        [Display(Name = "Frequency of Use")]
        public string FrequencyOfUse { get; set; }
        
        [Display(Name = "Doctor")]
        public string DoktorName { get; set; }

        [Display(Name = "Additional Message")]
        [DataType(DataType.Text)]
        public string AdditionalMessage { get; set; }
    }
}