using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok;
            string first;
            List<byte> list = new List<byte>();
                ok = true;
            Console.WriteLine("Введите сообщение");
                first = Console.ReadLine();
                //проверка на правильность ввода
                foreach (var right in first)
                {
                    if ("01".Contains(right) == false)
                    {
                        throw new ArgumentException("ввод содержит что-то кроме 0 и 1");
                    }
                }
                foreach (char y in first)
                {
                    string y1 = Convert.ToString(y);
                    byte t = Convert.ToByte(y1);
                    //if (t < 0 && t > 1) { Console.WriteLine("Неверный формат кода"); ok = false; break; }
                    list.Add(t);
                }
            int Step = 2;
            List<byte> End = new List<byte>();
            End.Add(0);
            int c = 2;
            //на степени двойки ставим нули, в оставшиеся записываем слово последовательно
            for (int i = 0; i < list.Count; i++)
            {
                if (c++ == Step) { End.Add(0); Step *= 2; c++; }
                End.Add(list[i]);
            }
            //заполняем контрольные биты
            for (int i = 1; i < Step; i *= 2)
            {
                int temp = 0;
                int g = i - 1;
                while (g < End.Count)
                {
                    for (int t = 0; t < i; t++)
                        if (g + t < End.Count)
                            temp += End[g + t];
                        else break;
                    g += i * 2;
                }
                if (temp % 2 == 1) End[i - 1] = 1;
            }
            foreach (byte s in End)
                Console.Write(s);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
