using LMS.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.api.Dtos
{
	public class UpdateModuleDto
	{
		public Module ProjectTo(Module module)
		{
			if (module != null)
			{
				module.Title = this.Title;
				module.StartDate = this.StartDate;
			}
			return module;
		}
		public string Title { get; set; }
		public DateTime StartDate { get; set; }
	}
}
