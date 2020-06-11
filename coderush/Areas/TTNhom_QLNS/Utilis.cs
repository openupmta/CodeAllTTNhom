using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.TTNhom_QLNS
{
    public class Utilis
    {
        public static string CreateCodeByCode(string code, string code_input, int lenght)
        {
            string res = "";
            int length_code = code.Length;
            string number = code_input.Substring(length_code);
            int count = Convert.ToInt32(number);
            int temp_id = count + 1;
            int id_lenght = 0;
            while (count >= 10)
            {
                count /= 10; // hay n = n /10;
                id_lenght++;
            }
            int code_lenght = code.Length;
            int add_lenght = lenght - code_lenght - id_lenght;
            if (add_lenght > 0)
            {
                string add = "";
                for (int i = 1; i < add_lenght; i++)
                {
                    add = String.Concat(add, '0');
                }
                res = String.Concat(code, add, temp_id);
            }
            return res;
        }
    }
}