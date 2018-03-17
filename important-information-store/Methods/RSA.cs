using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace important_information_store.Methods
{
    public class Calculation
    {
        public const int level = 1024;
        public static decimal e, n, d, functionEuler;

        public static void Calculate()
        {
            var rand = new Random();

            decimal p = rand.Next((int)(Math.Sqrt(level)) + 1, level);
            decimal q = rand.Next((int)(Math.Sqrt(level)) + 1, level);

            e = rand.Next(2, 5);
            e = FastPow(2, FastPow(2, e)) + 1;

            n = p * q;
            functionEuler = (p - 1) * (q - 1);
            d = Calculate_d();
        }

        private static List<int> ConvertToBinary(decimal number)
        {
            List<int> answer = new List<int>();
            for (int i = 0; number > 0; i++)
            {
                answer.Add((int)(number % 2));
                number = (int)number / 2;
            }
            return answer;
        }

        public static decimal FastPow(decimal number, decimal n)
        {
            decimal answer = number;
            var binaryExp = ConvertToBinary(n);

            for (int i = 0; i < binaryExp.Count - 1; i++)
            {
                if (binaryExp[i] == 1)
                    answer = FastPow(answer, 2) * number;
                else if (binaryExp[i] == 0)
                    answer = FastPow(answer, 2);
                else return 0;
            }

            return answer;
        }

        public static decimal Calculate_d()
        {
            decimal d = functionEuler - 1;

            for (decimal i = 2; i <= functionEuler; i++)
                if ((functionEuler % i == 0) && (d % i == 0))
                {
                    d--;
                    i = 1;
                }
            return d;
        }
    }

    public class RSA
    {
        public void Method(string text, string path)                         //Encrypting method
        {
            try
            {
                string answer = "";
                var tmp = RSA_Encrypt(text);
                foreach (char count in tmp)
                    answer += count;

                File.WriteAllText(path, answer);
                MessageBox.Show("d: " + Calculation.d + "n: " + Calculation.n);
            }
            catch
            {
                MessageBox.Show("Error at stage of encrypting by 1st method");
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
                MessageBox.Show("Error at stage of decrypting by 1st method");
            }
        }

        public static string RSA_Decrypt(string text)
        {
            string answer = "";

            return answer;
        }

        public static List<char> RSA_Encrypt(string text)
        {
            List<char> answer = new List<char>();
            Calculation.Calculate();

            decimal tmp;
            for(int i = 0; i < text.Length; i++)
            {
                tmp = Calculation.FastPow((int)text[i], Calculation.e) % Calculation.n;
                answer.Add(Convert.ToChar((int)(tmp % 255)));
            }
            return answer;
        }
    }
}
