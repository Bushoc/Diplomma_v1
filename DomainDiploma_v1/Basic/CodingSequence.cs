using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainDiploma_v1.Basic
{
	public class CodingSequence
	{
		#region Constructors
		/// <summary>
		/// Constructor for CodingSequence
		/// </summary>
		/// <param name="variable">Numerical form of sequence</param>
		/// <param name="length">Length of text form of sequence</param>
		public CodingSequence(int variable, int length)             //конструктор число, длина
		{
			code = (uint)variable;
			pLength = length;
		}

		/// <summary>
		/// Constructor for CodingSequence
		/// </summary>
		/// <param name="variable">Numerical form of sequence</param>
		/// <param name="length">Length of text form of sequence</param>
		public CodingSequence(uint variable, int length)            //конструктор число, длина
		{
			code = variable;
			pLength = length;
		}

		/// <summary>
		/// Constructor for CodingSequence
		/// </summary>
		/// <param name="variable">Numerical form of sequence, length will set automaticaly</param>
		public CodingSequence(uint variable)                        //конструктор число, длина автоматом
		{
			code = variable;
			for (int i = 0; i < 32; i++)
			{
				if (code < (uint)Math.Pow(2, i))
				{
					pLength = i;
					break;
				}
			}
		}

		/// <summary>
		/// Constructor for CodingSequence
		/// </summary>
		/// <param name="variable">Numerical form of sequence, length will set automaticaly</param>
		public CodingSequence(int variable)                         //конструктор число, длина автоматом
		{
			code = (uint)variable;
			for (int i = 0; i < 32; i++)
			{
				if (code < (uint)Math.Pow(2, i))
				{
					pLength = i;
					break;
				}
			}
		}

		/// <summary>
		/// Constructor for copying
		/// </summary>
		/// <param name="var">Source object</param>
		public CodingSequence(CodingSequence var)                   //конструктор копирования
		{
			code = var.code;
			pLength = var.Length;
		}

		/// <summary>
		/// Constructor for text form of sequence
		/// </summary>
		/// <param name="variable">Text form of sequence</param>
		public CodingSequence(string variable)                      //основной конструктор для строчного обозначения
		{
			pLength = variable.Length;
			code = 0;
			for (int i = 0; i < pLength; i++)
			{
				code += ((variable[pLength - i - 1] == '1') ? (uint)1 : (uint)0) * ((uint)Math.Pow(2, (i)));
			}
		}
		#endregion //Consctructors

		public static CodingSequence GeneratorOfNoise(double chance, int length)
		{
			CodingSequence result = new CodingSequence(0, length);
			Random rand = new Random();
			for (int i = 0; i < length; i++)
			{
				if (rand.NextDouble() < chance) result[i] = 1;
			}
			return result;
		}

		private uint code;                                          //32 розрядное хранилище для битов кодовой последовательности                      
		private int pLength;                                        //длина кодовой последовательности    

		/// <summary>
		/// Access to bits of sequence by their indexes
		/// </summary>
		/// <param name="index">Index of the bit</param>
		/// <returns>Value of the bit</returns>
		public int this[int index]                                  //индексатор для доступа к битам последовательности
		{
			get
			{
				if (index < pLength)
				{
					uint temp = (uint)Math.Pow(2, index);
					if ((code & temp) != 0)
						return 1;
					else
						return 0;
				}
				else
					return 2;
			}
			set
			{
				if (this[index] == value)
				{
				}
				else if (value == 0)
				{
					code -= (uint)Math.Pow(2, index);
				}
				else
				{
					code += (uint)Math.Pow(2, index);
				}
			}
		}

		/// <summary>
		/// Gets length text form of the sequence
		/// </summary>
		public int Length
		{
			get
			{
				return pLength;
			}
			private set
			{
			}
		}

		/// <summary>
		/// Gets numerical form of the sequence
		/// </summary>
		public uint Code
		{
			get { return code; }
		}

		/// <summary>
		/// Gets number of '1' in text form of the sequence(utility for operations with noise sequence)
		/// </summary>
		/// <returns>Count of '1' in text form of the sequence</returns>
		public int GetNumberOf1()
		{
			int result = 0;
			for (int i = 0; i < pLength; i++)
			{
				result += (this[i] == 1) ? 1 : 0;
			}
			return result;
		}

		/// <summary>
		/// Forms text form from numerical and returns it
		/// </summary>
		/// <returns>Text form of the sequence</returns>
		public override string ToString()
		{
			StringBuilder sbResult = new StringBuilder(32);
			for (int i = pLength - 1; i >= 0; i--)
			{
				sbResult.Append(this[i].ToString());
			}
			return sbResult.ToString();
		}
		public static CodingSequence operator +(CodingSequence op1, CodingSequence op2)     //операция сложения по модулю 2
		{
			uint temp = op1.Code ^ op2.Code;
			CodingSequence result = new CodingSequence(temp, (op1.Length > op2.Length ? op1.Length : op2.Length));
			return result;
		}
		public static CodingSequence operator *(CodingSequence op1, CodingSequence op2)     //операция умножения по модулю 2
		{
			uint code1 = op1.Code;
			uint code2 = op2.Code;
			CodingSequence result = new CodingSequence("0");

			for (int i = op2.Length; i > 0; i--)
			{
				result = result + new CodingSequence(code1 * (uint)op2[i - 1] * (uint)Math.Pow(2, i - 1), op1.Length + i - 1);
			}
			return result;

		}
		public static CodingSequence operator /(CodingSequence op1, CodingSequence op2)     //операция деления по модулю 2(правильно работает только для делителей начинающихся с 1, 1100, например)
		{
			if (op1.Length >= op2.Length)
			{
				CodingSequence temp = new CodingSequence(op1);
				CodingSequence result = new CodingSequence(0, op1.Length - op2.Length + 1);
				for (int i = op1.Length - op2.Length; i >= 0; i--)
				{
					if (temp[op2.Length + i - 1] == op2[op2.Length - 1] || temp[op2.Length + i - 1] == 1)
					{
						CodingSequence temp2 = new CodingSequence(op2.Code * (uint)Math.Pow(2, i));
						temp = temp + temp2;
						result[i] = 1;
					}
				}
				return result;
			}
			else
				return new CodingSequence(0);
		}
		public static CodingSequence operator %(CodingSequence op1, CodingSequence op2)     //операция остаток от деления по модулю 2(правильно работает см. выше)
		{
			if (op1.Length >= op2.Length)
			{
				CodingSequence temp = new CodingSequence(op1);
				CodingSequence result = new CodingSequence(0, op1.Length - op2.Length + 1);
				for (int i = op1.Length - op2.Length; i >= 0; i--)
				{
					if (temp[op2.Length + i - 1] == op2[op2.Length - 1] || temp[op2.Length + i - 1] == 1)
					{
						CodingSequence temp2 = new CodingSequence(op2.Code * (uint)Math.Pow(2, i));
						temp = temp + temp2;
						result[i] = 1;
					}
				}
				return new CodingSequence(temp.Code);
			}
			else
				return new CodingSequence(op1.Code);
		}
		public static int operator |(CodingSequence op1, CodingSequence op2)                //операция расчета кодового расстояния между оп1 и оп2
		{
			return (op1 + op2).GetNumberOf1();
		}
		public static bool operator ==(CodingSequence op1, CodingSequence op2)              //операция сравнения
		{
			if ((op1 | op2) == 0) return true;
			else return false;
		}
		public static bool operator !=(CodingSequence op1, CodingSequence op2)              //операция сравнения
		{
			return !(op1 == op2);
		}
	}
}
