using System;
using System.Data;
using System.Linq;


namespace Calculatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Ma Calculatrice : 1\nCalculatrice Cheap : 2 \nSortire : 3 ");
                string a = Console.ReadLine();

                switch (a)
                {
                    case "1":
                        MyMethode();                      
                        break;
                    case "2":
                        CheapMethode();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Entrer un choix valide");
                        break;
                }
            }
        }

        static void CheapMethode()
        {
            Console.WriteLine("Calculatrice Cheap");
            Console.WriteLine("Entrer votre équation");
            var equation = Console.ReadLine();
            var result = new DataTable().Compute(equation, "") + "";
            Console.WriteLine( "Reponse : " + result);
            return;
        }

        static void MyMethode()
        {
            string equation;
            bool debug = false;
            Console.WriteLine("Ma Calculatrice");
            Console.WriteLine("Entrer votre équation");
            equation = Console.ReadLine();

            if (equation == "debug")
            {
                if (debug)
                {
                    debug = false;
                    Console.WriteLine("Debug Mode : Deactivated");
                }
                else
                {
                    debug = true;
                    Console.WriteLine("Debug Mode : Activated");
                }
                equation = Console.ReadLine();
            }

            Spliting(equation);


            //Console.WriteLine(equation);

            void Spliting(string e)
            {
                char[] charEquation = new char[e.Length];
                char symbole = ' ';
                string sNum1 = "";
                string sNum2 = "";
                int num1 = 0;
                int num2 = 0;

                charEquation = e.ToCharArray();

                foreach (char c in charEquation)
                {
                    if (new[] { '+', '-', '/', '*', '^' }.Contains(c))
                    {
                        symbole = c;
                    }
                }

                //----------------------------------------------------------------------------------------------------------------------------

                for (int i = 0; i <= e.IndexOf(symbole); i++)
                {
                    if (Char.IsDigit(e[i]))
                    {
                        sNum1 += e[i];
                    }
                }

                if (sNum1.Length > 0)
                {
                    num1 = int.Parse(sNum1);
                }

                //----------------------------------------------------------------------------------------------------------------------------

                for (int i = e.IndexOf(symbole) + 1; i < e.Length; i++)
                {
                    if (Char.IsDigit(e[i]))
                    {
                        sNum2 += e[i];
                    }
                }

                if (sNum2.Length > 0)
                {
                    num2 = int.Parse(sNum2);
                }

                if (debug)
                {
                    Console.WriteLine("Operateur : " + symbole);
                    Console.WriteLine("Premier chiffre : " + num1);
                    Console.WriteLine("Deuxieme chiffre : " + num2);
                }
                

                Calculate(symbole, num1, num2);
            }

            void Calculate(char sym, int n1, int n2)
            {
                float result = 0;
                switch (sym)
                {
                    case '+':
                        result = n1 + n2;
                        break;

                    case '-':
                        result = n1 - n2;
                        break;

                    case '*':
                        result = n1 * n2;
                        break;
                        
                    case '/':
                        if (n1 == 0 && n2 > 0)
                        {
                            Console.WriteLine("Erreur");
                            return;
                        }
                        result = n1 / n2;
                        break;

                    case '^':
                        double d1 = Convert.ToDouble(n1);
                        double d2 = Convert.ToDouble(n2);
                        Console.WriteLine("Reponse : " + Math.Pow(d1, d2));
                        return;

                    default:
                        break;
                }

                Console.WriteLine("Reponse : " + result);
                return;
            }
        }
    }
}
