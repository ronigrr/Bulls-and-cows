using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.GameLogic
{
    public class GameLogic
    {
        private List<int> m_TargetAsciiCodes;
        private const bool k_IsDebug = false;
        public List<int> TargetAsciiCodes
        {
            get
            {
                return m_TargetAsciiCodes;
            }
        }

        public void GenerateTargetString()
        {
            int randomAsciiCode;
            Random random = new Random();
            List<int> resultArray = new List<int>(4);
            for (int i = 0; i < 4; i++)
            {
                randomAsciiCode = random.Next(65, 72);
                while (resultArray.Contains(randomAsciiCode))
                {
                    randomAsciiCode = random.Next(65, 72);
                }

                resultArray.Add(randomAsciiCode);
            }

            /*for A B C D patteren, set to TRUE*/
            if (k_IsDebug)
            {
                m_TargetAsciiCodes = new List<int>(4);
                m_TargetAsciiCodes.Add(65);
                m_TargetAsciiCodes.Add(66);
                m_TargetAsciiCodes.Add(67);
                m_TargetAsciiCodes.Add(68);
            }
            else
            {
                m_TargetAsciiCodes = resultArray.ToList();
            }
        }

        public bool CheckIsWin(string i_UserInputString, out int o_NumOfCorrectAnswers, out int o_NumOfIncorrectAnswers)
        {
            o_NumOfIncorrectAnswers = 0;
            o_NumOfCorrectAnswers = 0;
            bool isWin = true;

            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if (m_TargetAsciiCodes[i] != i_UserInputString[i])
                {
                    isWin = false;
                    if (m_TargetAsciiCodes.Contains(i_UserInputString[i]))
                    {
                        o_NumOfIncorrectAnswers++;
                    }
                }
                else if (m_TargetAsciiCodes[i] == i_UserInputString[i])
                {
                    o_NumOfCorrectAnswers++;
                }
            }

            return isWin;
        }
    }
}