using DomainDiploma_v1.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMPAlphabetGenerator
{
    public class CodingAlfavit
    {
        public int CodeLength { get; private set; }
        public int NumberOfCodes { get; private set; }
        
        private int minLength;
        private double midLength;
        private int allLength;

        public CodingSequence[] alfavit;
        public int[,] codingLengths;

        public CodingAlfavit(int codeLength, int numberOfCodes)
        {
            CodeLength = codeLength;
            NumberOfCodes = numberOfCodes;

            minLength = Int32.MaxValue;
            midLength = 0;
            allLength = 0;
            alfavit = new CodingSequence[numberOfCodes];
            codingLengths = new int[numberOfCodes, numberOfCodes];
        }

        public CodingAlfavit(CodingAlfavit obj)
        {
            CodeLength = obj.CodeLength;
            NumberOfCodes = obj.NumberOfCodes;

            minLength = Int32.MaxValue;
            midLength = 0;
            allLength = 0;
            alfavit = new CodingSequence[NumberOfCodes];
            alfavit = (CodingSequence[]) obj.alfavit.Clone();
            codingLengths = new int[this.NumberOfCodes, this.NumberOfCodes];
            CalculateLengths();
        }

        public void DeleteItem(int i)
        {
            alfavit[i] = null;
        }

        public bool CheckOnDistance(int count, int distance)
        {
            for (int i = 0; i < count; i++)
                if ((alfavit[i] | alfavit[count]) < distance)
                    return false;
            return true;
        }

        public override string ToString()
        {
            return String.Format("minLengh = {0}, midLenght = {1:f3} ", minLength, midLength);
        }

        private void CalculateLengths()
        {
            minLength = Int32.MaxValue;
            midLength = 0;
            allLength = 0;
            for (int i = 0; i < NumberOfCodes; i++)
                for (int j = 0; j < NumberOfCodes; j++)
                {
                    codingLengths[i, j] = alfavit[i] | alfavit[j];
                    allLength += codingLengths[i, j];
                    if ((codingLengths[i, j] < minLength) && i != j) minLength = codingLengths[i, j];
                }
            midLength = (double)allLength / (NumberOfCodes * (NumberOfCodes-1));
        }

        public string StringForSave()
        {
            CalculateLengths();
            StringBuilder sb = new StringBuilder();
            for (int i = 0, j = 0; i < NumberOfCodes; i++, j++)
            {
                if (j % 5 == 0 && j!=0) sb.Append(Environment.NewLine);
                sb.Append(alfavit[i].ToString() + " ");
            }
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            for (int i = 0; i < NumberOfCodes; i++)
            {
                for (int j = 0; j < NumberOfCodes; j++)
                    sb.Append(String.Format("{0:D2} ", codingLengths[i, j]));
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
