using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   public static  class Helper
    {
        public static bool CheckNameandSurname(this string s)
        {
            return s.Length>=3 && s.Split(" ").Length==1 && char.IsUpper(s[0]);
        }
        public static bool CheckClassRoomName(this string s)
        {
            if(s.Length!=5) return false;
            return char.IsUpper(s[0]) && char.IsUpper(s[1]) && char.IsDigit(s[2]) && char.IsDigit(s[3]) && char.IsDigit(s[4]);
        }
    }
}
