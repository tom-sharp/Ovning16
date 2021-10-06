using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.core.Models;
using LMS.core.Repositories;
using LMS.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.data.Repositories
{
	public class CourseRepository : ICourseRepository
	{
		LMSDbContext db;
		public CourseRepository(LMSDbContext context)
		{
			this.db = context;
		}
		public void Add(Course course)
		{
			if ((course == null) || (course.Id != 0)) return;
			this.db.Courses.Add(course);
		}
		public void Remove(Course course)
		{
			if ((course == null) || (course.Id == 0)) return;
			this.db.Courses.Remove(course);
		}

		public void Update(Course course)
		{
			if ((course == null) || (course.Id == 0)) return;
			this.db.Courses.Update(course);
		}

		public async Task<bool> AnyAsync(int? id)
		{
			if ((id == null) || (id == 0)) return await this.db.Courses.AnyAsync();
			return await this.db.Courses.AnyAsync(c => c.Id == id);
		}

		public async Task<Course> FindAsync(int? id)
		{
			if ((id == null) || (id == 0)) return null;
			return await this.db.Courses.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<Course> GetCourse(int? id)
		{
			if ((id == null) || (id == 0)) return null;
			return await this.db.Courses.Include(c => c.Modules).FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<IEnumerable<Course>> GetAllCourses()
		{
			return await this.db.Courses.Include(c => c.Modules).ToListAsync();
		}

		public async Task<int> SaveChangesAsync() {
			return await this.db.SaveChangesAsync();
		}


	}
}
