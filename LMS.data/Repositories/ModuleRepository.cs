using LMS.core.Models;
using LMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LMS.data.Repositories
{
	public class ModuleRepository : IModuleRepository
	{
		LMSDbContext db;
		public ModuleRepository(LMSDbContext context)
		{
			this.db = context;
		}

		public void Add(Module module)
		{
			if ((module == null) || (module.Id != 0)) return;
			this.db.Modules.Add(module);
		}
		public void Remove(Module module)
		{
			if ((module == null) || (module.Id == 0)) return;
			this.db.Modules.Remove(module);
		}

		public void Update(Module module)
		{
			if ((module == null) || (module.Id == 0)) return;
			this.db.Modules.Update(module);
		}

		public async Task<bool> AnyAsync(int? id)
		{
			if ((id == null) || (id == 0)) return await this.db.Modules.AnyAsync();
			return await this.db.Modules.AnyAsync(m => m.Id == id);
		}

		public async Task<Module> FindAsync(int? id)
		{
			if ((id == null) || (id == 0)) return null;
			return await this.db.Modules.FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<Module> GetModule(int? id)
		{
			if ((id == null) || (id == 0)) return null;
			return await this.db.Modules.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<IEnumerable<Module>> GetAllModules()
		{
			return await this.db.Modules.ToListAsync();
		}
		public async Task<int> SaveChangesAsync()
		{
			return await this.db.SaveChangesAsync();
		}


	}
}
