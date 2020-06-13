using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleAPI.Domain.Models
{
    public class MedicalAppointment
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
        [ForeignKey("Username")]
        public virtual User User { get; set; }
        public int TypeMedicalAppointmentId { get; set; }
        [ForeignKey("TypeMedicalAppointmentId")]
        public virtual TypeMedicalAppointment TypeMedicalAppointment { get; set; }
    }
}
