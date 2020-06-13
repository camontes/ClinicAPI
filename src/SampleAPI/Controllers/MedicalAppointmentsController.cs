using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Queries;
using SampleAPI.ViewModels;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAppointmentsController : ControllerBase
    {
        private readonly IMedicalAppointmentQueries _queries;

        private readonly IUserQueries _userQueries;

        private readonly IMapper _mapper;

        public MedicalAppointmentsController(IMedicalAppointmentQueries queries, IUserQueries userQueries, IMapper mapper)
        {
            _queries = queries;
            _mapper = mapper;
            _userQueries = userQueries;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<MedicalAppointmentViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [Route("ByUsername/{username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<MedicalAppointmentViewModel>>> GetAllByUsernameAsync(string username)
        {
            var existingUser = await _userQueries.FindByUsernameAsync(username);

            if (existingUser == null)
            {
                return NotFound();
            }
            return await _queries.FindByUsernameAsync(username);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MedicalAppointmentViewModel>> GetByIdAsync(int id)
        {
            var existingMedicalAppointment = await _queries.FindByIdAsync(id);
            if (existingMedicalAppointment == null)
            {
                return NotFound();
            }
            return existingMedicalAppointment;
        }

    }
}
