using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DomainDiploma_v1.Basic;

namespace Diploma_v1.Controllers.WebAPI
{
	public class SimpleSequenceOperationController : ApiController
	{
		[System.Web.Mvc.HttpPost]
		public string Addition(string op1, string op2)
		{
			return (new CodingSequence(op1) + new CodingSequence(op2)).ToString();
		}

		[System.Web.Mvc.HttpPost]
		public string Multiplication(string op1, string op2)
		{
			return (new CodingSequence(op1) * new CodingSequence(op2)).ToString();
		}

		[System.Web.Mvc.HttpPost]
		public string Division(string op1, string op2)
		{
			return (new CodingSequence(op1) / new CodingSequence(op2)).ToString();
		}

		[System.Web.Mvc.HttpPost]
		public string Modulo(string op1, string op2)
		{
			return (new CodingSequence(op1) % new CodingSequence(op2)).ToString();
		}

		[System.Web.Mvc.HttpPost]
		public int CodingDistance(string op1, string op2)
		{
			return new CodingSequence(op1) | new CodingSequence(op2);
		}

		[System.Web.Mvc.HttpPost]
		public bool Restoring(string op1, string op2)
		{
			return new CodingSequence(op1) == (((new CodingSequence(op1)/new CodingSequence(op2))*new CodingSequence(op2)) + (new CodingSequence(op1)%new CodingSequence(op2)));
		}
	}
}
