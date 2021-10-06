using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LMS.api
{
	// Json Format:
	//		opend and close  []
	//		object open and close { }
	//		object property "name":
	//		object property value as "string" or value
	//		next object property: , 
	//	[ {"MyInt":2, "MyString":"Hello"}, {"MyInt":4, "MyString":"X"},{"MyInt":1, "MyString":"Y"} ]
	//
	//	Json Format with child array:
	//	[ {"MyInt":5, "MyChild":[ {"Mystr":"Hello", "Val": 1}, {"Mystr":"World", "Val": 2} ] } ]
	//

	class Data1 {
		public int MyInt { get; set; }
		public string MyString { get; set; }
		public int MyOtherInt { get; set; }
	}

	class Data2
	{
		public int MyInt { get; set; }
		public string MyString { get; set; }
		public int MySecondInt { get; set; }

	}

	public static class TestMapper {
		public static void Go() {
			var x = new Data1() { MyInt = 5, MyString = "Hello", MyOtherInt = 4 };
//			var y = new Data2() { MyInt = 0, MyString = "World", MySecondInt = 8 };
			var y = Mapper<Data1, Data2>.Map(x);
		}
	}

	public class Mapper<Tsrc,Tdest>  where Tsrc : class where Tdest : new()
	{
		public static Tdest Map(Tsrc src) {
			var dest = new Tdest();
			PropertyInfo[] source =  src.GetType().GetProperties();
			PropertyInfo[] destination =  src.GetType().GetProperties();
			foreach (var sprop in source) {
				foreach (var dprop in destination) {
					if (sprop.Name == dprop.Name) {
						if (sprop.PropertyType == dprop.PropertyType) {
							var x1 = sprop.GetGetMethod()?.Invoke(src,null);
							var x2 = dprop.GetSetMethod();
							if ((x1 != null) && (x2 != null)) {
								Console.Write($"src  {src.ToString()} {sprop.Name} -> ");
								Console.WriteLine($"dest {dest.ToString()} {dprop.Name}");
								Console.WriteLine(x1);
							}
						}
						break;
					}
				}
			}
			return dest;
		}
	}
}
