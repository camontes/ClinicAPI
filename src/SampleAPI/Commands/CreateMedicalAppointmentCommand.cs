using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class CreateMedicalAppointmentCommand
    {
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Username { get; set; }
        public int TypeMedicalAppointmentId { get; set; }
    }
}
