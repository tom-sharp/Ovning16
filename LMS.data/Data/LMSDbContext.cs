using LMS.core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Data
{
	public class LMSDbContext : DbContext
	{
		public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
		{

		}
		public DbSet<Course> Courses { get; set; }
		public DbSet<Module> Modules { get; set; }

	}
}
