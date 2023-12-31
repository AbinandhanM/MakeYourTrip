﻿using Microsoft.AspNetCore.Mvc;
using TravelPackage.Models;
using TravelPackage.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TravelPackage.Exceptions;
using System;
using Microsoft.AspNetCore.Cors;

namespace TravelPackage.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("ReactCors")]

    [ApiController]
    public class TourExclusionsController : ControllerBase
    {
        private readonly IRepo<TourExclusion, int> _tourExclusionsRepository;

        public TourExclusionsController(IRepo<TourExclusion, int> tourExclusionsRepository)
        {
            _tourExclusionsRepository = tourExclusionsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<TourExclusion>>> GetAllTourExclusions()
        {
            try
            {
                var tourExclusions = await _tourExclusionsRepository.GetAll();
                return Ok(tourExclusions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving tour exclusions.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourExclusion>> GetTourExclusionById(int id)
        {
            try
            {
                var tourExclusion = await _tourExclusionsRepository.Get(id);
                if (tourExclusion == null)
                {
                    return NotFound();
                }

                return Ok(tourExclusion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving tour exclusion.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TourExclusion>> AddTourExclusion(TourExclusion tourExclusion)
        {
            try
            {
                var addedTourExclusion = await _tourExclusionsRepository.Add(tourExclusion);
                if (addedTourExclusion != null)
                {
                    return Ok(addedTourExclusion);
                }
                return BadRequest("Cannot add tour exclusion now");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding tour exclusion.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TourExclusion>> UpdateTourExclusion(TourExclusion tourExclusion)
        {
            try
            {
                

                var existingTourExclusion = await _tourExclusionsRepository.Get(tourExclusion.ExclusionId);
                if (existingTourExclusion == null)
                {
                    return NotFound();
                }

                var updatedTourExclusion = await _tourExclusionsRepository.Update(tourExclusion);
                return Ok(updatedTourExclusion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating tour exclusion.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TourExclusion>> DeleteTourExclusion(int id)
        {
            try
            {
                var result = await _tourExclusionsRepository.Delete(id);
                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting tour exclusion.");
            }
        }
    }
}
