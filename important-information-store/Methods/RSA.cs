using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Numerics;

namespace important_information_store.Methods
{
    public class Calculation
    {
        public const int level = 1024;
        public static BigInteger e, n, d, functionEuler;

        public static void Calculate()
        {
            var rand = new Random();

            BigInteger p = rand.Next((int)(Math.Sqrt(level)) + 1, level);
            BigInteger q = rand.Next((int)(Math.Sqrt(level)) + 1, level);

            e = rand.Next(2, 5);
            e = FastPow(2, FastPow(2, e)) + 1;

            n = p * q;
            functionEuler = (p - 1) * (q - 1);
            d = Calculate_d();
        }

        private static List<int> ConvertToBinary(BigInteger number)
        {
            List<int> answer = new List<int>();
            for (int i = 0; number > 0; i++)
            {
                answer.Add((int)(number % 2));
                number = (int)number / 2;
            }
            return answer;
        }

        public static BigInteger FastPow(BigInteger number, BigInteger n)
        {
            var tmp = number;
            BigInteger answer = number;

            var binaryExp = ConvertToBinary(n);

            for (int i = 0; i < binaryExp.Count - 1; i++)
            {
                if (binaryExp[i] == 1)
                    answer = BigInteger.Multiply(BigInteger.Pow(answer, 2), tmp);
                else if (binaryExp[i] == 0)
                    answer = BigInteger.Pow(answer, 2);
                else return 0;
            }
            return answer;
        }

        public static BigInteger Calculate_d()
        {
            BigInteger d = functionEuler - 1;

            for (BigInteger i = 2; i <= functionEuler; i++)
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
                MessageBox.Show("d: " + Calculation.d + "; n: " + Calculation.n + "; e: " + Calculation.e);
            }
            catch
            {
                MessageBox.Show("Error at stage of encrypting by 1st method");
            }
}

        public void Method(string text, int secret_D, int secret_N, int public_E, string path)         //Decrypting method
        {
            try
            {
                Calculation.e = public_E;
                Calculation.d = secret_D;
                Calculation.n = secret_N;

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
            foreach (int count in text)
                answer += Convert.ToChar(Calculation.FastPow(text[count], Calculation.d) % Calculation.n);

            return answer;
        }

        public static List<char> RSA_Encrypt(string text)
        {
            List<char> answer = new List<char>();
            Calculation.Calculate();
            
            for(int i = 0; i < text.Length; i++)
            {
                BigInteger tmp = Calculation.FastPow((int)text[i], Calculation.e) % Calculation.n;
                answer.Add(Convert.ToChar((int)(tmp % 255)));
            }
            return answer;
        }
    }
}
