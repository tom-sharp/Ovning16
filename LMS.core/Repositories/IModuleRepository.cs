using LMS.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.core.Repositories
{
	public interface IModuleRepository
	{
		void Add(Module module);		// add a new module
		void Remove(Module module);		// remove a module
		void Update(Module module);		// update a module
		Task<bool> AnyAsync(int? id);   // any module exist ? or id
		Task<Module> FindAsync(int? id);	// not needed ? - same as getmodule
		Task<Module> GetModule(int? id);	// det module
		Task<IEnumerable<Module>> GetAllModules();  // get all modules

		Task<int> SaveChangesAsync();                 // Save changes

	}
}
