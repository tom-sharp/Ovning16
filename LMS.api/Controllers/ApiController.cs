using LMS.core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.api.Controllers
{
	[Route("/api")]
	[ApiController]
	public class ApiController : ControllerBase
	{
		IUOW uow;
		public ApiController(IUOW uow)
		{
			this.uow = uow;
		}

//		[HttpPost("")]


	}



}
