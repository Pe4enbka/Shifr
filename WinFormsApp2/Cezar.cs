using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Cez
    {
        string le;
        public Cez(string m)
        {
            le = m;
        }
        public string Repl(string m, int key) //замена символа m на символ со смещением
        {
            int pos = le.IndexOf(m);
            if (pos == -1) return ""; //символ в этой ленте не найден
            pos = (pos + key) % le.Length; //если смещение больше одного круга
            if (pos < 0) pos += le.Length;
            return le.Substring(pos, 1);
        }
    }

    public class Cezar : System.Collections.Generic.List<Cez>
    {
        public Cezar()
        { //в конструкторе формирую коллекцию лент
            this.Add(new Cez("abcdefghijklmnopqrstuvwxyz"));
            this.Add(new Cez("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            this.Add(new Cez("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"));
            this.Add(new Cez("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"));
            this.Add(new Cez("0123456789"));
            this.Add(new Cez("!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}"));
        }
        public string Code(string m, int key) //кодирование и декодирование в зависимости от знака ключа
        {
            string res = "", tmp = "";
            for (int i = 0; i < m.Length; i++)
            {
                foreach (Cez v in this)
                {
                    tmp = v.Repl(m.Substring(i, 1), key);
                    if (tmp != "") //нужная лента найдена, замена символу определена
                    {
                        res += tmp;
                        break; // прерывается foreach (перебор лент)
                    }
                }
                if (tmp == "") res += m.Substring(i, 1); //незнакомый символ оставляю без изменений
            }
            return res;
        }
    }

}

