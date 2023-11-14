using System;

namespace Proyecto_2_Pilas
{
    internal class Program
    {
        static void Gracias()
        {
            Console.WriteLine("LISTO... GRACIAS POR USAR >:)");
            Console.ReadKey();
            Console.Clear();
        }
        static string PedirExp()
        {
            Console.WriteLine("Ingrese la expresion con la que desea trabajar: ");
            string expresion = Console.ReadLine();

            return expresion;
        }
        static int calculo(int operador1, int operador2, string operando)
        {
            if (operando == "+") return operador1 + operador2;
            else if (operando == "-") return operador1 - operador2;
            else if (operando == "*") return operador1 * operador2;
            else if (operando == "/")
            {
                if (operador2 == 0)
                {
                    Console.WriteLine("No se puede dividir entre 0");
                    return 0;
                }
                else return operador1 / operador2;
            }
            else
            {
                return Convert.ToInt32(Math.Pow(Convert.ToDouble(operador1), Convert.ToDouble(operador2)));
            }
        }
        static void evaluar(string exp)
        {
            pilas p1 = new pilas();
            int aux = 0;
            int cont = 0;
            string operador1 = null;
            string operador2 = null;
            string operando = null;
            string expTrans = null;
            bool Error = false;
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    aux++;
                    cont = 0;
                }
                if (exp[i] == ')' && aux > 0)
                {
                    operador2 = p1.pop();
                    operando = p1.pop();
                    operador1 = p1.pop();

                    if (operador1 != null && operador2 != null && (operando == "+" || operando == "-" || operando == "*" || operando == "/" || operando == "^") && cont <= 3)
                    {
                        try
                        {
                            expTrans = Convert.ToString(calculo(int.Parse(operador1), int.Parse(operador2), operando));
                            p1.push(expTrans);
                        }
                        catch
                        {

                        }
                        aux--;
                        cont = 0;
                        operador2 = null;
                        operando = null;
                        operador1 = null;
                    }
                    else
                    {
                        Console.WriteLine("Error, Orden Incorrecto");
                        Error = true;
                        break;
                    }

                }
                else if (exp[i] != '(' && cont <= 3 && aux > 0)
                {
                    p1.push(Convert.ToString(exp[i]));
                    cont++;
                }
            }
            if (!Error) Console.WriteLine(p1.pop());
        }
        static void transformar(string exp)
        {
            pilas p1 = new pilas();
            int aux = 0;
            int cont = 0;
            string operador1 = null;
            string operador2 = null;
            string operando = null;
            string expTrans = null;
            bool Error = false;
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    aux++;
                    cont = 0;
                }
                if (exp[i] == ')' && aux > 0)
                {
                    operador2 = p1.pop();
                    operando = p1.pop();
                    operador1 = p1.pop();

                    if (operador1 != null && operador2 != null && (operando == "+" || operando == "-" || operando == "*" || operando == "/" || operando == "^") && cont <= 3)
                    {
                        expTrans = operador1 + operador2 + operando;
                        p1.push(expTrans);
                        aux--;
                        cont = 0;
                        operador2 = null;
                        operando = null;
                        operador1 = null;
                    }
                    else
                    {
                        Console.WriteLine("Error, Orden Incorrecto");
                        Error = true;
                        break;
                    }

                }
                else if (exp[i] != '(' && cont <= 3 && aux > 0)
                {
                    p1.push(Convert.ToString(exp[i]));
                    cont++;
                }
            }
            if (!Error) Console.WriteLine(p1.pop());

        }
        static bool ValidarTransformacion(string exp)
        {
            int parenA = 0;
            int parenC = 0;
            int operando = 0;
            int operador = 0;

            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    parenA++;
                }

                else if (exp[i] == ')')
                {
                    parenC++;
                }

                else if (exp[i] == '+' || exp[i] == '-' || exp[i] == '*' || exp[i] == '/' || exp[i] == '^')
                {
                    operador++;
                }
                else if ((exp[i] >= 65 && exp[i] <= 90) || (exp[i] >= 97 && exp[i] <= 122))
                {

                    operando++;
                }

            }

            if (parenA == parenC && parenA >= 1)
            {
                if (operando == operador + 1)
                {
                    if (operador >= 1 && operador == parenA)
                    {
                        if (parenA + parenC + operando + operador == exp.Length) return true;
                    }
                }
            }
            return false;
        }
        static bool ValidarInfijo(string exp)
        {
            int parenA = 0;
            int parenC = 0;
            int operando = 0;
            int operador = 0;

            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    parenA++;
                }

                else if (exp[i] == ')')
                {
                    parenC++;
                }

                else if (exp[i] == '+' || exp[i] == '-' || exp[i] == '*' || exp[i] == '/' || exp[i] == '^')
                {

                    operador++;
                }
                else if (exp[i] >= 48 && exp[i] <= 57)
                {

                    operando++;
                }

            }

            if (parenA == parenC && parenA >= 1)
            {
                if (operando == operador + 1)
                {
                    if (operador >= 1 && operador == parenA)
                    {
                        if (parenA + parenC + operando + operador == exp.Length) return true;
                    }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            int op;
            string Expresion;

            do
            {
                Console.WriteLine("Bienvenido a la evaluadora de pilas");

                Console.WriteLine("Ingrese el numero: ");

                Console.WriteLine("1 si desea transformar la Expresion en infijo a postfijo");

                Console.WriteLine("2 si desea evaluar la Expresion en infijo");

                Console.WriteLine("0 si desea salir");
                try
                {
                    Console.Write("Opcion: "); op = int.Parse(Console.ReadLine());
                }
                catch
                {
                    op = -1;
                }

                switch (op)
                {

                    case 1:

                        Console.Clear();
                        Expresion = PedirExp();
                        if (ValidarTransformacion(Expresion))
                        {
                            transformar(Expresion);
                            Console.WriteLine();
                            Gracias();
                        }
                        else
                        {
                            Console.WriteLine("Expresion Invalida");
                        }
                        break;

                    case 2:

                        Console.Clear();

                        Expresion = PedirExp();
                        if (ValidarInfijo(Expresion))
                        {
                            evaluar(Expresion);
                            Console.WriteLine();
                            Gracias();
                        }
                        else
                        {
                            Console.WriteLine("Expresion Invalida");
                        }
                        break;

                    case 0:
                        Console.WriteLine("GRACIAS POR USAR  >:)");
                        break;

                    default:
                        Console.WriteLine("NUMERO INVALIDO");
                        Console.WriteLine("VUELVA A INGRESAR LA OPCION");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (op != 0);

            Console.ReadKey();
        }
    }
}
