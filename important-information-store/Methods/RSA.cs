using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace important_information_store.Methods
{    public class Calculation
    {
        public const int level = 1024;
        public static double e, n, d, functionEuler;

        public static void Calculate()
        {
            var rand = new Random();

            double p = rand.Next((int)(Math.Sqrt(level)) + 1, level);
            double q = rand.Next((int)(Math.Sqrt(level)) + 1, level);

            //e = rand.Next(2, 5);
            //e = Math.Pow(2, Math.Pow(2, e)) + 1;
            e = 17;

            n = p * q;
            functionEuler = (p - 1) * (q - 1);
            d = Calculate_d();
        }

        private static List<int> ConvertToBinary(double number)
        {
            List<int> answer = new List<int>();
            for (int i = 0; number > 0; i++)
            {
                answer.Add((int)(number % 2));
                number = (int)number / 2;
            }
            return answer;
        }

        public static double FastPow(double number, double n)
        {
            double answer = number;
            var binaryExp = ConvertToBinary(n);

            for (int i = 0; i < binaryExp.Count - 1; i++)
            {
                if (binaryExp[i] == 1)
                    answer = Math.Pow(answer, 2) * number;
                else if (binaryExp[i] == 0)
                    answer = Math.Pow(answer, 2);
                else return 0;
            }

            return answer;
        }

        public static double Calculate_d()
        {
            double d = functionEuler - 1;

            for (double i = 2; i <= functionEuler; i++)
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
                var answer = RSA_Encrypt(text);
                //File.WriteAllText(path, answer);
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

            return answer;
        }

        public static List<char> RSA_Encrypt(string text)
        {
            List<char> answer = new List<char>();
            Calculation.Calculate();

            double tmp;
            for(int i = 0; i < text.Length; i++)
            {
                tmp = Calculation.FastPow(text[i], Calculation.e) % Calculation.n;
                answer[i] = Convert.ToChar(tmp % 255);
            }
            return answer;
        }
    }
}
