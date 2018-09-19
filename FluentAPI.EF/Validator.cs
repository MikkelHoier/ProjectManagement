using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EF
{
    public static class Validator
    {
        public static bool NameIsValid(string s)
        {            
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }            
            else if(s.Length > 100)
            {
                return false;
            }
            else
            {
                foreach (char c in s)
                {
                    if (char.IsNumber(c))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Validates a nullable Datetime.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool DateIsValid(DateTime? d)
        {
            if(d == null)
            {
                return false;
            }
            if(d > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
