using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelsGenerator
{
    public class StringUtils
    {
        public string funcionSumaHorizontal (int numJugadores, string letra, string operador)
        {
            string retornar = "";

            for (int i = 1; i <= numJugadores; i++)
            {
                if (i != numJugadores)
                {
                    retornar += letra + i + operador;
                }
                else
                {
                    retornar += letra + i;
                }
            }

            return retornar;
        }

        public string reemplazoIndiceConstante(string indice, string cadena)
        {
            return cadena.Replace("1",indice);
        }

        public string getEqSplitW(string eq, ref int contadorEqs, ref int contadorW, string separador)
        {
            string[] stringSeparators = new string[] { separador };
            string[] eqComplementSplit = eq.Split(stringSeparators, StringSplitOptions.None);

            //Armo su W

            string w = "eq" + contadorEqs.ToString() + ".. " + "w" + contadorW + "*(" + eqComplementSplit[0] + "-" + eqComplementSplit[1].Replace("(","").Replace(")","").Replace(";","") + ")=E=0;";
            return w;
        }

        public List<string> getDesigualdadesSc1(int numJugadores, ref int contadorEqs, ref int contadorW)
        {
            List<string> listaRetorno = new List<string>();

            //tipo 1
            string eqDesType1 = "(q1-Bf1)*(D1/q1) +";
            string eqDesType1Final = eqDesType1;
            for (int m = 1; m < numJugadores; m++)
            {
                if (m == numJugadores - 1)
                {
                    eqDesType1Final += reemplazoIndiceConstante((m + 1).ToString(), eqDesType1).Remove(reemplazoIndiceConstante((m + 1).ToString(), eqDesType1).Length - 1) + "=L=Z;";
                }
                else
                {
                    eqDesType1Final += reemplazoIndiceConstante((m + 1).ToString(), eqDesType1);
                }
            }

            listaRetorno.Add("eq" + contadorEqs.ToString() + ".. " + eqDesType1Final);
            contadorEqs++;

            //tipo 4

            
            for (int k = 1; k <= numJugadores; k++)
            {
                string eqComplement = "b" + k + "*(D" + k + "/q" + k + ")+(q" + k + "-Bf" + k + ")*(D" + k + "/q" + k + ")=G=D" + k + ";";
                string eq = "eq" + contadorEqs.ToString() + ".. " + eqComplement;
                listaRetorno.Add(eq);
                contadorEqs++;
            }

            return listaRetorno;
        }

        public List<string> getIgualdadesSc1(int numJugadores, ref int contadorEqs)
        {
            List<string> listaRetorno = new List<string>();

            //tipo 1

            string eqEquType1 = "eq" + contadorEqs.ToString() + ".. " + "Cf =E= Qf/(" + funcionSumaHorizontal(numJugadores, "q", "+") + ");";
            listaRetorno.Add(eqEquType1);
            contadorEqs++;

            //tipo 2

            for (int i = 1; i <= numJugadores; i++)
            {
                string eqEquType2 = "eq" + contadorEqs.ToString() + ".. " + "D" + i + "/q" + i + "=E= (" + funcionSumaHorizontal(numJugadores, "D", "+") + ")/Qf;";
                listaRetorno.Add(eqEquType2);
                contadorEqs++;
            }

            return listaRetorno;
        }

        public List<string> getDesigualdadesSc3(int numJugadores, ref int contadorEqs, ref int contadorW)
        {
            //tipo 1
            List<string> listaRetorno = new List<string>();
            int eval1 = 1;
            int eval2 = 1;
            for (int i = eval1; i <= numJugadores; i++)
            {
                for (int j = eval2; j <= numJugadores; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else
                    {
                        string ij = i.ToString() + j.ToString();
                        string ji = j.ToString() + i.ToString();
                        string eqComplement = "X" + ij + "+" + "X" + ji + "=L=1;";
                        listaRetorno.Add("eq" + contadorEqs.ToString() + ".. " + eqComplement);
                        contadorEqs++;

                        string w = getEqSplitW(eqComplement,ref contadorEqs,ref contadorW, "=L=");
                        
                        listaRetorno.Add(w);
                        contadorW++;
                        contadorEqs++;
                    }
                    eval1++;
                }
                eval2++;
            }
            //tipo 2
            List<string> sumElementsEq = new List<string>();
            for (int k = 1; k <= numJugadores; k++)
            {
                sumElementsEq.Clear();
                for (int l = 1; l <= numJugadores; l++)
                {
                    if (k != l)
                    {
                        sumElementsEq.Add(l.ToString() + k.ToString());
                    }
                }

                string sumaEq = "";
                foreach (string element in sumElementsEq)
                {
                    sumaEq += "L" + element + "+";
                }
                string eqComplement = sumaEq.Remove(sumaEq.Length - 1) + "=L=(q" + k + "-Bf" + k + ");";
                string eq = "eq" + contadorEqs.ToString() + ".. " + eqComplement;
                listaRetorno.Add(eq);
                contadorEqs++;

                string w = getEqSplitW(eqComplement, ref contadorEqs, ref contadorW, "=L=");

                listaRetorno.Add(w);
                contadorW++;
                contadorEqs++;
            }

            //tipo 3
            string eqDesType3 = "(q1-Bf1)*(D1/q1) +";
            string eqDesType3Final = eqDesType3;
            for (int m = 1; m < numJugadores; m++)
            {
                if (m == numJugadores - 1)
                {
                    eqDesType3Final += reemplazoIndiceConstante((m + 1).ToString(), eqDesType3).Remove(reemplazoIndiceConstante((m + 1).ToString(), eqDesType3).Length-1) + "=L=Z;";
                }
                else
                {
                    eqDesType3Final += reemplazoIndiceConstante((m + 1).ToString(), eqDesType3);
                }
            }

            listaRetorno.Add("eq" + contadorEqs.ToString() + ".. " + eqDesType3Final);
            contadorEqs++;

            string w3 = getEqSplitW(eqDesType3Final, ref contadorEqs, ref contadorW, "=L=");

            listaRetorno.Add(w3);
            contadorW++;
            contadorEqs++;

            //tipo 4

            List<string> sumElementsEq4 = new List<string>();
            for (int k = 1; k <= numJugadores; k++)
            {
                sumElementsEq4.Clear();
                for (int l = 1; l <= numJugadores; l++)
                {
                    if (k != l)
                    {
                        sumElementsEq4.Add(k.ToString() + l.ToString());
                    }
                }

                string sumaEq = "";
                foreach (string element in sumElementsEq4)
                {
                    sumaEq += "L" + element + "+";
                }
                string eqComplement = "b" + k + "*(D" + k + "/q" + k + ")+(q" + k + "-Bf" + k + ")*(D" + k + "/q" + k + ")+((D" + k + "/q" + k + ")*(" + sumaEq.Remove(sumaEq.Length - 1) + "))=G=D" + k + ";";
                string eq = "eq" + contadorEqs.ToString() + ".. " + eqComplement;
                listaRetorno.Add(eq);
                contadorEqs++;

                string w = getEqSplitW(eqComplement, ref contadorEqs, ref contadorW, "=G=");

                listaRetorno.Add(w);
                contadorW++;
                contadorEqs++;
            }

            return listaRetorno;
        }

        public List<string> getIgualdadesSc3(int numJugadores, ref int contadorEqs)
        {
            List<string> listaRetorno = new List<string>();
            //tipo 1
            List<string> sumElementsEq = new List<string>();
            for (int k = 1; k <= numJugadores; k++)
            {
                sumElementsEq.Clear();
                for (int l = 1; l <= numJugadores; l++)
                {
                    if (k != l)
                    {
                        sumElementsEq.Add(k.ToString() + l.ToString());
                    }
                }


                foreach (string element in sumElementsEq)
                {
                    string eq = "eq" + contadorEqs.ToString() + ".. " + "L" + element + "=E=Y" + element + "*X" + element + ";";
                    listaRetorno.Add(eq);
                    contadorEqs++;
                }

            }
            //tipo 2
            string eqEquType2 = "alfa1+beta1";
            string eqEquType2Final = eqEquType2;
            for (int i = 0; i < numJugadores; i++)
            {
                eqEquType2Final = reemplazoIndiceConstante((i + 1).ToString(), eqEquType2)+"=E=1;";
                listaRetorno.Add("eq" + contadorEqs.ToString() + ".. " + eqEquType2Final);
                contadorEqs++;
            }
            //tipo 3

            string eqEquType3 = "eq" + contadorEqs.ToString() + ".. " + "Cf =E= Qf/(" + funcionSumaHorizontal(numJugadores, "q", "+")+");";
            listaRetorno.Add(eqEquType3);
            contadorEqs++;
            //tipo 4

            for (int i = 1; i <= numJugadores; i++)
            {
                string eqEquType4 = "eq" + contadorEqs.ToString() + ".. " + "D" + i + "/q " + i + "=E= (" + funcionSumaHorizontal(numJugadores, "D", "+") + ")/Qf;";
                listaRetorno.Add(eqEquType4);
                contadorEqs++;
            }

            return listaRetorno;
        }

        public List<string> getBetasSc3(int numJugadores, ref int contadorEqs)
        {
            //prueba
            List<string> listaRetorno = new List<string>();
            int inicioW = calcularValorInicioW(numJugadores);
            string entradaConstante = "beta1*((-h1*((q1-b1/q1))+(s1+(b1/q1)))+((D1/q1)";
            listaRetorno.Add("eq" + contadorEqs.ToString() + ".. " + entradaConstante + "*w" + inicioW + ")=E=0;");
            inicioW++;
            contadorEqs++;
            for (int i = 2; i <= numJugadores; i++)
            {
                string eq = reemplazoIndiceConstante(i.ToString(), entradaConstante) + "*w" + inicioW + ")=E=0;";
                listaRetorno.Add("eq" + contadorEqs.ToString() + ".. " + eq);
                inicioW++;
                contadorEqs++;
            }

            return listaRetorno;
        }

        public int calcularValorInicioW(int numJugadores)
        {
            List<int> jugadores = new List<int>();
            List<int> valores = new List<int>();

            int valorSumar = 0;
            int valorIteracion = 0;

            for (int i = 2; i <= numJugadores; i++)
            {
                jugadores.Add(i);
            }

            for (int i = 2; i <= numJugadores; i++)
            {
                if (i == 2)
                {
                    valorIteracion = 5;
                    valores.Add(valorIteracion);
                    valorSumar = 3;
                }
                else
                {
                    valorIteracion = valorIteracion + valorSumar;
                    valores.Add(valorIteracion);
                    valorSumar++;
                }
            }

            int posicion = jugadores.IndexOf(numJugadores);

            return valores[posicion];
        }
    }
}
