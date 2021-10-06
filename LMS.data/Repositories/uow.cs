using LMS.core.Repositories;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LMS.data.Repositories
{
	public class uow : IUOW
	{
		ICourseRepository courses = null;
		IModuleRepository modules = null;
		LMSDbContext db = null;
		public uow(LMSDbContext context)
		{
			this.courses = new CourseRepository(context);
			this.modules = new ModuleRepository(context);
			this.db = context;
		}
		public ICourseRepository CourseRepository { get { return this.courses; } }
		public IModuleRepository ModuleRepository { get { return this.modules; } }

		public async Task<bool> CompleteAsync()
		{
			try
			{
				await this.db.SaveChangesAsync();
			}
			catch (DbUpdateException) {
				return false;
			}
			return true;
		}
	}
}
