using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Util
    {
        public static string GetTitle(string text)
        {
            var defaultFliter = "\r\n，。☆、：…,.?？!！";
            var charArray = text.ToArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (defaultFliter.Contains(charArray[i]))
                {
                    return text.Substring(0, i);
                }
            }
            return text;
        }
    }
}
