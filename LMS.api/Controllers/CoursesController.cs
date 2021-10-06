using LMS.api.Dtos;
using LMS.core.Models;
using LMS.core.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.api.Controllers
{
	[Route("api/Courses")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		IUOW uow;
		public CoursesController(IUOW uow)
		{
			this.uow = uow;
		}

		[HttpGet(Name = "GetCourses")]
		[HttpHead]
		public async Task<ActionResult<IEnumerable<CourseDto>>>  GetCourses()
		{
			var model = (await this.uow.CourseRepository.GetAllCourses()).Select(c => new CourseDto(c));
			return Ok(model);
		}


		[HttpPost()]
		public async Task<ActionResult<CourseDto>> AddCourse([FromBody] AddCourseDto addCourse)
		{
			var entity = addCourse.ProjectTo(new Course());
			if (entity.Id != 0) return BadRequest();
			this.uow.CourseRepository.Add(entity);
			if (!await this.uow.CompleteAsync()) return StatusCode(500);
			return CreatedAtRoute("GetCourse", new { id = entity.Id }, new CourseDto(entity));
		}


		[HttpGet("{id}",  Name = "GetCourse")]
		[HttpHead("{id}")]
		public async Task<ActionResult<CourseDto>> GetCourse(int id)
		{
			var course = await this.uow.CourseRepository.GetCourse(id);
			if (course != null) return Ok(new CourseDto(course));
			return NotFound();
		}


		[HttpPut("{id}")]
		public async Task <ActionResult> Put([FromRoute]int id, [FromBody] UpdateCourseDto updateCourse)
		{
			var entity = await this.uow.CourseRepository.FindAsync(id);
			if (entity == null) return NotFound();
			updateCourse.ProjectTo(entity);
			if (!await this.uow.CompleteAsync()) return StatusCode(500);
			return NoContent();
		}


		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCourse(int id)
		{
			var course = await uow.CourseRepository.GetCourse(id);
			if (course == null) return NotFound();
			uow.CourseRepository.Remove(course);
			if (!await this.uow.CompleteAsync()) return StatusCode(500);
			return NoContent();
		}

		[HttpPatch("{id}")]
		public async Task<ActionResult> PatchCourse([FromRoute]int id, [FromBody] JsonPatchDocument<UpdateCourseDto> jsonpd)
		{
			var entity = await uow.CourseRepository.FindAsync(id);
			if (entity == null) return NotFound();
			var patchItem = new UpdateCourseDto(entity);
			jsonpd.ApplyTo(patchItem);
			if (!TryValidateModel(patchItem)) {
				return ValidationProblem(ModelState);
			}
			patchItem.ProjectTo(entity);
			if (!await this.uow.CompleteAsync()) return StatusCode(500);
			return NoContent();
		}

	}
}
