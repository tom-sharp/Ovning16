using LMS.core.Models;
using LMS.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Syslib;
using System.Collections.Concurrent;

namespace LMS.api
{
	public class App
	{

		static App instance = null;
		ConcurrentQueue<string> LogList;
		
		private App()
		{
			instance = this;
			this.LogList = new ConcurrentQueue<string>();
			this.Name = "RESTful API test";
			this.Version = 1;
			this.Development = true;
		}

		public static App  SetUp { get { if (instance == null) instance = new App(); return instance; }  }

		public async Task<bool> SeedDataAsync(IServiceProvider services) {
			this.Log("SeedData.Start");
			var uow = services.GetService<IUOW>();
			if (!await uow.CourseRepository.AnyAsync(null))
			{
				int itemsneeded = 10;
				int count = 0;
				Course newCourse;
				while (count++ < itemsneeded)
				{
					newCourse = new Course() { Title = $"Student course {count}", StartDate = DateTime.Now };
					newCourse.Modules = new List<Module>() { new Module() { 
							Title = "Introduction",
							StartDate = newCourse.StartDate,
					}};
					uow.CourseRepository.Add(newCourse);
				}
				if (!await uow.CompleteAsync()) return false;
			}
			this.Log("SeedData.End");
			return true;
		}

		public void Log(string msg) {
			this.LogList.Enqueue($"{new CDateTime().DateTimeStr()} {msg}");
			LogMsg();
		}

		void LogMsg() {
			while(!this.LogList.IsEmpty) {
				if (this.LogList.TryDequeue(out string msg)) Console.WriteLine(msg);
			}
		}


		public string Name { get; private set; }
		public int Version { get; private set; }
		public bool Development { get; private set; }

	}

}
