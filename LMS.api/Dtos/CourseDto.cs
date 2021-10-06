using LMS.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.api.Dtos
{
	public class CourseDto
	{
		public CourseDto() { }
		public CourseDto(Course course)
		{
			this.Id = course.Id;
			this.Title = course.Title;
			this.StartDate = course.StartDate;
			this.Modules = 0;
			if (course.Modules != null) this.Modules = course.Modules.Count;
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime StartDate { get; set; }
		public int Modules { get; set; }

	}
}
