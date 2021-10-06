using LMS.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.api.Dtos
{
	public class ModuleDto
	{
		public ModuleDto() { }
		public ModuleDto(Module module)
		{
			this.Id = module.Id;
			this.Title = module.Title;
			this.StartDate = module.StartDate;
			this.CourseId = module.CourseId;

		}
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime StartDate { get; set; }
		public int CourseId { get; set; }
	}
}
