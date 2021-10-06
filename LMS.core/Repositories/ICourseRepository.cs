using LMS.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.core.Repositories
{
	public interface ICourseRepository
	{
		/// <summary>
		/// Add a new Course
		/// </summary>
		/// <param name="course"></param>
		void Add(Course course);

		/// <summary>
		/// Remove a course
		/// </summary>
		/// <param name="course"></param>
		void Remove(Course course);

		/// <summary>
		/// Update a Course
		/// </summary>
		/// <param name="course"></param>
		void Update(Course course);

		/// <summary>
		/// return true if course with id exist or if id == null
		/// return true if any course exist
		/// else false is returned
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> AnyAsync(int? id);

		/// <summary>
		/// returns Course with Id or null if not found
		/// Modules are not included
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Course> FindAsync(int? id);    // get a course without modules

		/// <summary>
		/// Return Course, including Modules with Id or null if not found
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Course> GetCourse(int? id);

		/// <summary>
		/// Return an IEnumerable with courses if includemodul3es id true modules are included
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Course>> GetAllCourses();  // get all courses

		/// <summary>
		/// Save Changes
		/// </summary>
		/// <returns></returns>
		Task<int> SaveChangesAsync();					// Save changes


	}
}
