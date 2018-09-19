using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordTest
{
    class Student
    {
        #region Variables
        private string id;
        private string name;
        private decimal englishScore;
        private decimal mathScore;
        private decimal scienceScore;
        #endregion

        #region Constructer
        public Student(string id, string name, decimal englishScore, decimal mathScore, decimal scienceScore)
        {
            Id = id;
            Name = name;
            EnglishScore = englishScore;
            MathScore = mathScore;
            ScienceScore = scienceScore;
        }
        #endregion

        #region Properties
        private string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        private string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private decimal EnglishScore
        {
            get
            {
                return englishScore;
            }
            set
            {
                if (value > 0.0m)
                {
                    englishScore = value;
                }
            }
        }
        private decimal MathScore
        {
            get
            {
                return mathScore;
            }
            set
            {
                if (value > 0.0m)
                {
                    mathScore = value;
                }
            }
        }
        private decimal ScienceScore
        {
            get
            {
                return scienceScore;
            }
            set
            {
                if (value > 0.0m)
                {
                    scienceScore = value;
                }
            }
        } 
        #endregion

        public decimal GetAggregate()
        {
            decimal sum = EnglishScore + MathScore + ScienceScore;
            return sum;
        }

        public decimal GetPercentage()
        {
            decimal sum = EnglishScore + MathScore + ScienceScore / 50 * 100;
            return sum;
        }
    }
}
