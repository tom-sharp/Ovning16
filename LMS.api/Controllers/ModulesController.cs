using LMS.api.Dtos;
using LMS.core.Models;
using LMS.core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.api.Controllers
{
	[Route("api/Courses/{CourseId}/Modules")]
	[ApiController]
	public class ModulesController : ControllerBase
	{

		IUOW uow;
		public ModulesController(IUOW uow)
		{
			this.uow = uow;
		}

		[HttpGet()]
		[HttpHead]
		public async Task<ActionResult<IEnumerable<Module>>> GetModules(int CourseId)
		{
			var course = await this.uow.CourseRepository.GetCourse(CourseId);
			if (course != null) return Ok(course.Modules.Select(m => new ModuleDto(m)));
			return NotFound();
		}

		[HttpPost]
		public async Task<ActionResult<ModuleDto>> AddCourseModule([FromRoute] int CourseId, [FromBody] AddModuleDto addModule)
		{
			var entity = addModule.ProjectTo(new Module() { CourseId = CourseId });
			if (await this.uow.CourseRepository.GetCourse(entity.CourseId) == null) return NotFound();
			this.uow.ModuleRepository.Add(entity);
			if (!await this.uow.CompleteAsync()) return StatusCode(500);
			return CreatedAtRoute("GetModule", new { Id = entity.Id, CourseId = entity.CourseId }, new ModuleDto(entity));
		}

		[HttpGet("{Id}", Name ="GetModule")]
		[HttpHead("{Id}")]
		public async Task<ActionResult<Module>> GetModule(int Id, int CourseId)
		{
			var module = await this.uow.ModuleRepository.GetModule(Id);
			if (module == null) return NotFound();
			if (module.CourseId == CourseId) return Ok(new ModuleDto(module));
			return NotFound();
		}


		[HttpPut("{Id}")]
		public async Task<ActionResult> UpdateCourseModule([FromRoute] int CourseId, int Id, [FromBody] UpdateModuleDto updateModule)
		{
			var course = await this.uow.CourseRepository.GetCourse(CourseId);
			if (course == null) return NotFound();
			var entity = course.Modules.FirstOrDefault(m => m.Id == Id);
			if (entity == null) return NotFound();
			updateModule.ProjectTo(entity);
			if (!await this.uow.CompleteAsync()) return StatusCode(500);
			return NoContent();
		}


		[HttpDelete("{Id}")]
		public async Task<ActionResult> DeleteModule(int CourseId, int Id)
		{
			var course = await this.uow.CourseRepository.GetCourse(CourseId);
			if (course == null) return NotFound();
			var entity = course.Modules.FirstOrDefault(m => m.Id == Id);
			if (entity == null) return NotFound();
			uow.ModuleRepository.Remove(entity);
			if (!await this.uow.CompleteAsync()) return StatusCode(500);
			return NoContent();
		}

	}
}
