using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class UpdateUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
    }
}
