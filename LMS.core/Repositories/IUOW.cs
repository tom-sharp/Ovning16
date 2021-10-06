using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.core.Repositories
{
	public interface IUOW
	{
		/// <summary>
		/// Courses Repository
		/// </summary>
		public ICourseRepository CourseRepository { get; }

		/// <summary>
		/// Modules repository
		/// </summary>
		public IModuleRepository ModuleRepository { get; }

		/// <summary>
		/// Save Changes
		/// </summary>
		/// <returns></returns>
		Task<bool> CompleteAsync();
	}
}
