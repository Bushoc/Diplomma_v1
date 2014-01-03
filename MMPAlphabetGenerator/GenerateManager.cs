using DomainDiploma_v1.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMPAlphabetGenerator
{
    public class GenerateManager
    {
        public CodingAlfavit Result;
        public int CodeLength { get; private set; }
        public int NumberOfCodes { get; private set; }
        public int MinimalCodingDistance { get; private set; }

        public bool ResultOfGenerating { get; set; }

        private uint maxCode = (uint)Math.Pow(2, 15);
        public Random r = new Random();
        private uint[] currPos;        
        private CodingAlfavit CurrResult;

        public GenerateManager(int codeLength, int numberOfCodes, int minimalCodingDistance)
        {
            CodeLength = codeLength;
            NumberOfCodes = numberOfCodes;
            MinimalCodingDistance = minimalCodingDistance;
            //Results = new List<CodingAlfavit>();

            currPos = new uint[64];
            currPos[0] = 1;
            CurrResult = new CodingAlfavit(codeLength, numberOfCodes);
        }

        public void WorkOnLevel(int level)
        {
            if (!ResultOfGenerating)
            {
                uint lastPosition = Math.Max(currPos[level - 1], currPos[level]);
                for (uint i = lastPosition; i <= maxCode && !ResultOfGenerating; i++)
                {
                    CurrResult.alfavit[level] = new CodingSequence(i, 16);
                    if (CurrResult.CheckOnDistance(level, this.MinimalCodingDistance))
                    {
                        currPos[level] = i;
                        if (level < (NumberOfCodes - 1))
                            WorkOnLevel(level + 1);
                        else
                        {
                            Result = new CodingAlfavit(CurrResult);                            
                            ResultOfGenerating = true;
                            currPos[level]++;                                                     
                            break;
                        }
                    }
                }
            }
        }

        public void WorkOnLevel0()
        {
            ResultOfGenerating = false;
            for (uint i = currPos[0]; i < maxCode && !ResultOfGenerating; i++)
            {
                currPos[0] = i;
                CurrResult.alfavit[0] = new CodingSequence(i, CodeLength);
                WorkOnLevel(1);
            }
        }

    }
}
