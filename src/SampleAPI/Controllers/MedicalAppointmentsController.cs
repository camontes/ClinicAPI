﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Commands;
using SampleAPI.Domain.Behaviors;
using SampleAPI.Domain.Models;
using SampleAPI.Queries;
using SampleAPI.ViewModels;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAppointmentsController : ControllerBase
    {
        private readonly IMedicalAppointmentQueries _queries;

        private readonly IMedicalAppointmentBehavior _behavior;

        private readonly IUserQueries _userQueries;

        private readonly IMapper _mapper;

        public MedicalAppointmentsController(IMedicalAppointmentQueries queries, IUserQueries userQueries, IMedicalAppointmentBehavior behavior, IMapper mapper)
        {
            _queries = queries;
            _mapper = mapper;
            _userQueries = userQueries;
            _behavior = behavior;
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

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MedicalAppointmentViewModel>> CreateMedicalAppointmentAsync(CreateMedicalAppointmentCommand createMedicalAppointmentCommand)
        {

            var existingUser = await _userQueries.FindByUsernameAsync(createMedicalAppointmentCommand.Username);

            if (existingUser == null) return NotFound();

            var existingMedicalAppointment = await _queries.FindByCreatedAtUsernameAsync(createMedicalAppointmentCommand.CreatedAt, createMedicalAppointmentCommand.Username);

            if (existingMedicalAppointment != null) return Conflict();

            var medicalAppointment = _mapper.Map<MedicalAppointment>(createMedicalAppointmentCommand);
            await _behavior.CreateMedicalAppointmentAsync(medicalAppointment);

            var medicalAppointmentViewModel = await _queries.FindByIdAsync(medicalAppointment.Id);
            return medicalAppointmentViewModel;
        }

    }
}
