using LMS.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.api.Dtos
{
	public class AddCourseDto
	{
		public AddCourseDto()
		{
			this.Modules = new List<AddModuleDto>();
		}

		public Course ProjectTo(Course course) {
			if (course != null) {
				course.Title = this.Title;
				course.StartDate = this.StartDate;
				if ((this.Modules != null) && (this.Modules.Count > 0)) {
					if (course.Modules == null) course.Modules = new List<Module>();
					foreach (var m in this.Modules) {
						course.Modules.Add(new Module() { Title = m.Title, StartDate = m.StartDate });
					}
				}
			}
			return course;
		}
		public string Title { get; set; }
		public DateTime StartDate { get; set; }
		public ICollection<AddModuleDto> Modules { get; set; }

	}
}
