using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace important_information_store.Methods
{
    public class RSA
    {
        public class Variables
        {
            public const int level = 225;
            public static long e, d, n, functionEuler;

            public static char[] symbols = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н',
                                                    'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь',
                                                    'Э', 'Ю', 'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к',
                                                    'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ',
                                                    'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                                                    'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                                                    'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                                    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2',
                                                    '3', '4', '5', '6', '7', '8', '9', '0', ' ', '!', '@', '#', '$', '%', '^',
                                                    '&', '*', '(', ')', '_', '+', '-', '=', '}', '{', ']', '[', ':', '"', '|',
                                                    '\\', ',', '\'', ';', '<', '>', '?', '.', '/', '\0'
                                                  };
        }

        public class Calculation
        {
            public static void Calculate()
            {
                var rand = new Random();

                var p = rand.Next((int)(Math.Sqrt(Variables.level)) + 1, Variables.level);
                var q = rand.Next((int)(Math.Sqrt(Variables.level)) + 1, Variables.level);

                while (SimpleNumber(p) == false || SimpleNumber(q) == false || (p == q))
                {
                    p = rand.Next((int)(Math.Sqrt(Variables.level)) + 1, Variables.level);
                    q = rand.Next((int)(Math.Sqrt(Variables.level)) + 1, Variables.level);
                }

                Variables.n = Convert.ToUInt32(p * q);
                Variables.functionEuler = Convert.ToUInt32((p - 1) * (q - 1));
            }

            public static void Calculate_d()
            {
                Variables.d = Variables.functionEuler - 1;

                for (long i = 2; i <= Variables.functionEuler; i++)
                    if ((Variables.functionEuler % i == 0) && (Variables.d % i == 0))
                    {
                        Variables.d--;
                        i = 1;
                    }
            }

            public static bool SimpleNumber(long n)
            {
                if (n < 2)
                    return false;
                else if (n == 2)
                    return true;
                for (long i = 2; i < n; i++)
                    if (n % i == 0)
                        return false;

                return true;
            }

            public static void Calculate_e()
            {
                Variables.e = Convert.ToUInt32(Variables.level);
                while (true)
                {
                    if ((Variables.e * Variables.d) % Variables.functionEuler == 1)
                        break;
                    else
                        Variables.e++;
                }
            }
        }

        public void Method(string text, string path)                         //Encrypting method
        {
            try
            {

            }
            catch
            {
                var msg = MessageBox.Show("Error at stage of encrypting by 1st method");
            }
        }

        public void Method(string text, int secretCode, string path)         //Decrypting method
        {
            try
            {
                string answer = RSA_Decrypt(text);
                File.WriteAllText(path, answer);
            }
            catch
            {
                var msg = MessageBox.Show("Error at stage of decrypting by 1st method");
            }
        }

        public static string RSA_Decrypt(string text)
        {
            string answer = "";

            long tmp;

            for (int item = 0; item < text.Length; item++)
            {
                tmp = Convert.ToInt64(item);
                tmp = (long)Math.Pow(tmp, Variables.d);

                long n_Upper = Variables.n;

                tmp = tmp % n_Upper;

                int index = Convert.ToInt32(tmp.ToString());

                answer += Variables.symbols[index].ToString();
            }

            return answer;
        }

        public static string RSA_Encrypt(string text)
        {
            string answer = "";

            long tmp;

            for (int i = 0; i < text.Length; i++)
            {
                int index = Array.IndexOf(Variables.symbols, text[i]);

                tmp = index;
                tmp = (long)Math.Pow(tmp, Variables.e);

                long n_Upper = Variables.n;

                tmp = tmp % n_Upper;

                answer += tmp;
            }
            return answer;
        }
    }
}
