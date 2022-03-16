using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Viziner
    {
        char[] alf = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я',
                                  'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я',
                                  'A','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                                  'a','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                                  ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
        public string Code(string input, string keyword, string case1)
        {
            int N = alf.Length;
            int k = -1;
            int j = 0;

            if (case1 == "1")// если расшифровка
            {
                j = N;
                k = 1;
            }
            
            string result = "";
            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(alf, symbol) + j - (k * Array.IndexOf(alf, keyword[keyword_index]))) % N;
                result += alf[c];
                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }
               
    }
}
