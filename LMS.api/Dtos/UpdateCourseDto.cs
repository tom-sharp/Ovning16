using LMS.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.api.Dtos
{
	public class UpdateCourseDto
	{
		public UpdateCourseDto(Course course)
		{
			this.Title = course.Title;
			this.StartDate = course.StartDate;
		}
		public Course ProjectTo(Course course)
		{
			if (course != null)
			{
				course.Title = this.Title;
				course.StartDate = this.StartDate;
			}
			return course;
		}
		public string Title { get; set; }
		public DateTime StartDate { get; set; }

	}
}
