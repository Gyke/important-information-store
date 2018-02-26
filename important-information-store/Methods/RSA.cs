using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace important_information_store.Methods
{    public class Calculation
    {
        public const int level = 1024;
        public static double e, d, n, functionEuler;

        public static void Calculate()
        {
            var rand = new Random();

            double p = rand.Next((int)(Math.Sqrt(level)) + 1, level);
            double q = rand.Next((int)(Math.Sqrt(level)) + 1, level);

            e = rand.Next(2, 6);
            e = Math.Pow(2, Math.Pow(2, e)) + 1;

            n = p * q;
            functionEuler = (p - 1) * (q - 1);

            Calculate_d();
        }

        private static List<int> ConvertToBinary(double number)
        {
            List<int> answer = new List<int>();
            for (int i = 0; number > 0; i++)
            {
                answer.Add((int)(number % 2));                      // check here
                number = (int)number / 2;
            }

            return answer;
        }

        public static double FastPow(double number, double n)       // check here everything
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

        public static void Calculate_d()                            // check this method maybe opperation d++ will be better?
        {                                                           // how should i realize calculate_d-method
            double u, v;                                            // e*u + functionEuler*v = 1; u,v - ?
                                                                    // u == d mod functionEuler, d++
            d = EuclidMethod(e, functionEuler, u, v);
        }

        public static double EuclidMethod(double e, double f, double u, double v)       //  e * u + f * v = 1;
        {
            if (e == 0)
            {
                u = 0; v = 1;
                return f;
            }
            double u1, v1;
            double d = EuclidMethod(f % e, e, u1, v1);
            u = u1 - (f / e) * u1;
            v = u1;
            return d;

            /*int gcd (int a, int b, int & x, int & y) {
	            if (a == 0) {
		            x = 0; y = 1;
		            return b;
	            }
	            int x1, y1;
	            int d = gcd (b%a, a, x1, y1);
	            x = y1 - (b / a) * x1;
	            y = x1;
	            return d;
                }
             */
        }

    }

    public class RSA
    {
        public void Method(string text, string path)                         //Encrypting method
        {
            try
            {
                string answer = RSA_Encrypt(text);
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

            //long tmp;

            //for (int item = 0; item < text.Length; item++)
            //{
            //    tmp = Convert.ToInt64(item);
            //    tmp = (long)Math.Pow(tmp, d);

            //    long n_Upper = n;

            //    tmp = tmp % n_Upper;

            //    int index = Convert.ToInt32(tmp.ToString());

            //    answer += symbols[index].ToString();
            //}

            return answer;
        }

        public static string RSA_Encrypt(string text)
        {
            string answer = "";
            Calculation.Calculate();

            //long tmp;

            //for (int i = 0; i < text.Length; i++)
            //{
            //    int index = Array.IndexOf(symbols, text[i]);

            //    tmp = index;
            //    tmp = (long)Math.Pow(tmp, e);

            //    long n_Upper = n;

            //    tmp = tmp % n_Upper;

            //    answer += tmp;
            //}
            return answer;
        }
    }
}
