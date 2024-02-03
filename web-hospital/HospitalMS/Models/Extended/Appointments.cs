using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalMS.Models
{

    [MetadataType(typeof(AppointmentsMetaData))]
    public partial class Appointments
    {
       
    }

    public class AppointmentsMetaData
    {
        [Key]
        public int AppointmentID { get; set; }

        [ForeignKey("Doctor")] 
        public int DoctorID { get; set; }

        [ForeignKey("MedicalUnit")] 
        public int MedicalUnitID { get; set; }

        [Required]
        [Display(Name = "Date for Appointment")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime AppointmentDate { get; set; }

        [DataType(DataType.Time)]
        public System.TimeSpan AppointmentTime { get; set; }

        [Display(Name = "Additional message")]
        [DataType(DataType.Text)]
        public string Message { get; set; }

        public virtual Doctors Doctor { get; set; } 
        public virtual MedicalUnits MedicalUnit { get; set; }
    }
}