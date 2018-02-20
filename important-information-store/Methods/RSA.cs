using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace important_information_store.Methods
{
    public class Variables
    {
        public const int level = 1024;
        public static ulong e, d, n, functionEuler;

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

            Variables.e = (ulong)rand.Next(2, 6);
            Variables.e = (ulong)Math.Pow(2, Math.Pow(2, Variables.e)) + 1;

            Variables.n = (ulong)p * (ulong)q;
            Variables.functionEuler = (ulong)(p - 1) * (ulong)(q - 1);

            Calculate_d();
        }

        private static List<int> ConvertToBinary(ulong number)
        {
            List<int> answer = new List<int>();

            for (int i = 0; number > 0; i++)
            {
                answer.Add((int)(number % 2));
                number = number / 2;
            }

            return answer;
        }

        public static UInt64 FastPow(UInt64 number, UInt64 n)
        {
            UInt64 answer = new UInt64();
            answer = Convert.ToUInt64(number);
            var binaryExp = ConvertToBinary(n);

            for (int i = 0; i < binaryExp.Count - 1; i++)
            {
                if (binaryExp[i] == 1)
                    answer = (UInt64)Math.Pow(answer, 2) * (UInt64)number;
                else if (binaryExp[i] == 0)
                    answer = (UInt64)Math.Pow(answer, 2);
                else return 0;
            }

            return answer;
        }

        public static void Calculate_d()
        {
            Variables.d = Variables.functionEuler - 1;

            for (ulong i = 2; i <= Variables.functionEuler; i++)
                if ((Variables.functionEuler % i == 0) && (Variables.d % i == 0))
                {
                    Variables.d--;
                    i = 1;
                }
        }
    }

    public class RSA
    {
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
