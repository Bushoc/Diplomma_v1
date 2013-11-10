using System;
using System.Text;
using System.Collections.Generic;
using Diploma_v1.Controllers.WebAPI;
using DomainDiploma_v1.Basic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Diploma_v1.Tests.Basic
{
	/// <summary>
	/// Summary description for CodingSequenceTests
	/// </summary>
	[TestClass]
	public class SimpleSequenceOperationTests
	{
		#region AdditionTesting

		[TestMethod]
		public void AdditionTesting()
		{
			// Pattern : ( "op1", "op2", "expected" )
			// result : expected == op1 + op2

			AdditionTestForTrue("101", "010", "111");
			AdditionTestForTrue("1010", "010", "1000");

			AdditionTestForFalse("101", "01", "111");

			AdditionTestForTrue("0", "0", "0");
			AdditionTestForTrue("1", "1", "0");

			AdditionTestForTrue("11", "00000010", "00000001");
		}

		private void AdditionTestForTrue(string strOp1, string strOp2, string strExpected)
		{
			var op1 = new CodingSequence(strOp1);
			var op2 = new CodingSequence(strOp2);
			var expected = new CodingSequence(strExpected);
			var actual = op1 + op2;
			Assert.IsTrue(expected == actual);
		}

		private void AdditionTestForFalse(string strOp1, string strOp2, string strExpected)
		{
			var op1 = new CodingSequence(strOp1);
			var op2 = new CodingSequence(strOp2);
			var expected = new CodingSequence(strExpected);
			var actual = op1 + op2;
			Assert.IsFalse(expected == actual);
		}

		#endregion

		#region DivisionTesting

		[TestMethod]
		public void DivisionTesting()
		{
			// Pattern : ( "op1", "op2", "expected" )
			// result : expected == op1 / op2

			DivisionTestForTrue("111", "1", "111");
			DivisionTestForTrue("111", "11", "10");
			DivisionTestForFalse("111", "11", "11");
		}

		private void DivisionTestForTrue(string strOp1, string strOp2, string strExpected)
		{
			var op1 = new CodingSequence(strOp1);
			var op2 = new CodingSequence(strOp2);
			var expected = new CodingSequence(strExpected);
			var actual = op1 / op2;
			Assert.IsTrue(expected == actual);
		}

		private void DivisionTestForFalse(string strOp1, string strOp2, string strExpected)
		{
			var op1 = new CodingSequence(strOp1);
			var op2 = new CodingSequence(strOp2);
			var expected = new CodingSequence(strExpected);
			var actual = op1 / op2;
			Assert.IsFalse(expected == actual);
		}

		#endregion

		#region ModuloTesting

		[TestMethod]
		public void ModuloTesting()
		{
			// Pattern : ( "op1", "op2", "expected" )
			// result : expected == op1 % op2

			ModuloTestForTrue("111", "1", "0");
			ModuloTestForTrue("111", "11", "1");
			ModuloTestForFalse("111", "11", "0");
		}

		private void ModuloTestForTrue(string strOp1, string strOp2, string strExpected)
		{
			var op1 = new CodingSequence(strOp1);
			var op2 = new CodingSequence(strOp2);
			var expected = new CodingSequence(strExpected);
			var actual = op1 % op2;
			Assert.IsTrue(expected == actual);
		}

		private void ModuloTestForFalse(string strOp1, string strOp2, string strExpected)
		{
			var op1 = new CodingSequence(strOp1);
			var op2 = new CodingSequence(strOp2);
			var expected = new CodingSequence(strExpected);
			var actual = op1 % op2;
			Assert.IsFalse(expected == actual);
		}

		#endregion

		#region RestoreTesting

		[TestMethod]
		public void RestoreTesting()
		{
			// Pattern : ( "op1", "op2" )
			// result : op1 == (op1 / op2)*op2 + (op1 % op2)

			RestoreTest("101010111", "11001");
		}

		private void RestoreTest(string strOp1, string strOp2)
		{
			var op1 = new CodingSequence(strOp1);
			var op2 = new CodingSequence(strOp2);
			var resultDivision = op1 / op2;
			var modulo = op1 % op2;
			Assert.IsTrue(op1 == resultDivision * op2 + modulo);
		}

		#endregion

		#region MultiplicationTesting

		[TestMethod]
		public void MultiplicationTesting()
		{
			// Pattern : ( "op1", "op2", "expected" )
			// result : expected == op1 * op2

			MultiplicationTestForTrue("111", "1", "111");
			MultiplicationTestForTrue("111", "0", "000");
			MultiplicationTestForTrue("111", "10", "1110");
			MultiplicationTestForTrue("111", "101", (new CodingSequence("11100") + new CodingSequence("111")).ToString());

			MultiplicationTestForFalse("111", "0", "111");
		}

		private void MultiplicationTestForTrue(string strOp1, string strOp2, string strExpected)
		{
			var op1 = new CodingSequence(strOp1);
			var op2 = new CodingSequence(strOp2);
			var expected = new CodingSequence(strExpected);
			var actual = op1 * op2;
			Assert.IsTrue(expected == actual);
		}

		private void MultiplicationTestForFalse(string strOp1, string strOp2, string strExpected)
		{
			var op1 = new CodingSequence(strOp1);
			var op2 = new CodingSequence(strOp2);
			var expected = new CodingSequence(strExpected);
			var actual = op1 * op2;
			Assert.IsFalse(expected == actual);
		}

		#endregion
	}
}
