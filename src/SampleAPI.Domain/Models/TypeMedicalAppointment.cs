using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleAPI.Domain.Models
{
    public class TypeMedicalAppointment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<MedicalAppointment> MedicalAppointment { get; set; }
    }
}
