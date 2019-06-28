using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            float n1, n2, ans;
            string temp1, temp2, a, b, c;
            CalculatingIndexForSubstr(equation, out temp1, out temp2, out a, out b, out c);
            if (c.Contains('?'))
            {
                MissingCharInC(out n1, out n2, out ans, out temp1, out temp2, a, b, c);
            }
            else if (a.Contains('?'))
            {
                MissingCharInA(out n1, out n2, out ans, out temp1, out temp2, a, b, c);
            }
            else if (b.Contains('?'))
            {
                MissingCharInB(out n1, out n2, out ans, out temp1, out temp2, a, b, c);
            }
            if (temp1.Length == temp2.Length)
            {
                for (int i = 0; i < temp1.Length; i++)
                {
                    if (temp1[i] != temp2[i])
                    {
                        return int.Parse(temp1[i].ToString());
                    }
                }
            }
            else
            {
                return -1;
            }

            throw new NotImplementedException();
        }

        private static void MissingCharInB(out float n1, out float n2, out float ans, out string temp1, out string temp2, string a, string b, string c)
        {
            n1 = float.Parse(a);
            n2 = float.Parse(c);
            ans = n2 / n1;
            temp1 = ans.ToString();
            temp2 = b.ToString();
        }

        private static void MissingCharInA(out float n1, out float n2, out float ans, out string temp1, out string temp2, string a, string b, string c)
        {
            n1 = float.Parse(b);
            n2 = float.Parse(c);
            ans = n2 / n1;
            temp1 = ans.ToString();
            temp2 = a.ToString();
        }

        private static void MissingCharInC(out float n1, out float n2, out float ans, out string temp1, out string temp2, string a, string b, string c)
        {
            n1 = float.Parse(a);
            n2 = float.Parse(b);
            ans = n1 * n2;
            temp1 = ans.ToString();
            temp2 = c.ToString();
        }

        private static void CalculatingIndexForSubstr(string equation, out string temp1, out string temp2, out string a, out string b, out string c)
        {
            float n1, n2, ans;
            temp1 = null;
            temp2 = null;
            int p = equation.Length;
            var x = equation.IndexOf('*');
            a = equation.Substring(0, x);
            var y = equation.IndexOf('=');
            //Console.WriteLine(y);
            y = y - x - 1;
            b = equation.Substring(x + 1, y);
            y = equation.IndexOf('=');
            var z = p - y;
            c = equation.Substring(y + 1, z - 1);
        }
    }
}
