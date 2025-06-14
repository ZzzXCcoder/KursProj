﻿using KursProj.Dtos;
using KursProj.IServices;
using KursProj.IServices.IAdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminCourseController : ControllerBase
    {
        private readonly IAdminCourseService _adminCourseService;
        private readonly IUserContextService _userContextService;
        public AdminCourseController(IAdminCourseService adminCourseService, IUserContextService userContextService)
        {
            _adminCourseService = adminCourseService;
            _userContextService = userContextService;
        }

        [HttpPost("createcourse")]
        public async Task<IActionResult> CreateCourse([FromForm] CreateCourseRequest request)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = _userContextService.GetUserId();
            var result = await _adminCourseService.CreateCourse(request, userId);

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok("Курс успешно создан");
        }
        [HttpPatch("updatedescription/{id}")]
        public async Task<IActionResult> UpdateDescription(Guid id, [FromBody] UpdateDescriptionDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Description))
            {
                return BadRequest("Description cannot be empty.");
            }

            bool updated = await _adminCourseService.UpdateCourseDescriptionAsync(id, dto.Description);

            if (!updated)
            {
                return NotFound($"Course with id {id} not found.");
            }

            return Ok();
        }
    }
}
