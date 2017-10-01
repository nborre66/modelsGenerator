using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelsGenerator
{
    class ScenarioBuilder
    {
        StringUtils utils = new StringUtils();

        public string scenario1Build(int numPlayers, ref int contadorEqs)
        {
            List<string> listaDesigualdades = new List<string>();
            List<string> listaIgualdades = new List<string>();
            List<string> listaBetas = new List<string>();
            int contadorW = 1;
            int numJugadores = numPlayers;
            string cadenaAlfa = "k1*((D1)/(q1)) + h1*(((q1-b1)**2)/(2*q1)) + s1*(((b1)**2)/(2*q1))";
            StringBuilder script = new StringBuilder();
            script.Append("funobj.. F =E= Kf*((");
            script.Append(utils.funcionSumaHorizontal(numJugadores, "D", "+"));
            script.Append(")/Qf) + Hf*((Cf+1)/2)*(Qf/Cf) + Sf*(((");
            script.Append(utils.funcionSumaHorizontal(numJugadores, "Bf", "+"));
            script.Append(")**2)/(2*Qf)) +");
            script.AppendLine();
            script.Append(cadenaAlfa + " +");
            script.AppendLine();
            for (int i = 1; i < numJugadores; i++)
            {
                if (i == numJugadores - 1)
                {
                    script.Append(utils.reemplazoIndiceConstante((i + 1).ToString(), cadenaAlfa));
                    script.Append(";");
                }
                else
                {
                    script.Append(utils.reemplazoIndiceConstante((i + 1).ToString(), cadenaAlfa) + " +");
                }
                script.AppendLine();
            }

            listaDesigualdades = utils.getDesigualdadesSc1(numJugadores, ref contadorEqs, ref contadorW);
            foreach (string eq in listaDesigualdades)
            {
                script.Append(eq);
                script.AppendLine();
            }

            listaIgualdades = utils.getIgualdadesSc1(numJugadores, ref contadorEqs);
            foreach (string eq in listaIgualdades)
            {
                script.Append(eq);
                script.AppendLine();
            }
            return script.ToString();
        }

        public string scenario2Build(int numPlayers, ref int contadorEqs)
        {
            List<string> listaDesigualdades = new List<string>();
            List<string> listaIgualdades = new List<string>();
            List<string> listaBetas = new List<string>();
            int contadorW = 1;
            int numJugadores = numPlayers;
            string cadenaAlfa = "alfa1*(k1*((D1)/(q1)) + h1*(((q1-b1)**2)/(2*q1)) + s1*(((b1)**2)/(2*q1)))";
            StringBuilder script = new StringBuilder();
            script.Append("funobj.. F =E= Kf*((");
            script.Append(utils.funcionSumaHorizontal(numJugadores, "D", "+"));
            script.Append(")/Qf) + Hf*((Cf+1)/2)*(Qf/Cf) + Sf*(((");
            script.Append(utils.funcionSumaHorizontal(numJugadores, "Bf", "+"));
            script.Append(")**2)/(2*Qf)) +");
            script.AppendLine();
            script.Append(cadenaAlfa + " +");
            script.AppendLine();
            for (int i = 1; i < numJugadores; i++)
            {
                if (i == numJugadores - 1)
                {
                    script.Append(utils.reemplazoIndiceConstante((i + 1).ToString(), cadenaAlfa));
                    script.Append(";");
                }
                else
                {
                    script.Append(utils.reemplazoIndiceConstante((i + 1).ToString(), cadenaAlfa) + " +");
                }
                script.AppendLine();
            }
            //Comienzan las eq
            listaDesigualdades = utils.getDesigualdadesSc2(numJugadores, ref contadorEqs, ref contadorW);
            foreach (string eq in listaDesigualdades)
            {
                script.Append(eq);
                script.AppendLine();
            }

            listaIgualdades = utils.getIgualdadesSc2(numJugadores, ref contadorEqs);
            foreach (string eq in listaIgualdades)
            {
                script.Append(eq);
                script.AppendLine();
            }

            listaBetas = utils.getBetasSc2(numJugadores, ref contadorEqs);
            foreach (string eq in listaBetas)
            {
                script.Append(eq);
                script.AppendLine();
            }
            return script.ToString();
        }

        public string scenario3Build(int numPlayers, ref int contadorEqs)
        {
            List<string> listaDesigualdades = new List<string>();
            List<string> listaIgualdades = new List<string>();
            List<string> listaBetas = new List<string>();
            List<string> listaComplemento = new List<string>();
            int contadorW = 1;
            int numJugadores = numPlayers;
            string cadenaAlfa = "alfa1*(k1*((D1)/(q1)) + h1*(((q1-b1)**2)/(2*q1)) + s1*(((b1)**2)/(2*q1)))";
            StringBuilder script = new StringBuilder();
            script.Append("funobj.. F =E= Kf*((");
            script.Append(utils.funcionSumaHorizontal(numJugadores, "D", "+"));
            script.Append(")/Qf) + Hf*((Cf+1)/2)*(Qf/Cf) + Sf*(((");
            script.Append(utils.funcionSumaHorizontal(numJugadores, "Bf", "+"));
            script.Append(")**2)/(2*Qf)) +");
            script.AppendLine();
            script.Append(cadenaAlfa + " +");
            script.AppendLine();
            for (int i = 1; i < numJugadores; i++)
            {
                if (i == numJugadores - 1)
                {
                    script.Append(utils.reemplazoIndiceConstante((i + 1).ToString(), cadenaAlfa));
                    script.Append(";");
                }
                else
                {
                    script.Append(utils.reemplazoIndiceConstante((i + 1).ToString(), cadenaAlfa) + " +");
                }
                script.AppendLine();
            }
            //Comienzan las eq
            listaDesigualdades = utils.getDesigualdadesSc3(numJugadores, ref contadorEqs, ref contadorW);
            foreach (string eq in listaDesigualdades)
            {
                script.Append(eq);
                script.AppendLine();
            }

            listaIgualdades = utils.getIgualdadesSc3(numJugadores, ref contadorEqs);
            foreach (string eq in listaIgualdades)
            {
                script.Append(eq);
                script.AppendLine();
            }

            listaBetas = utils.getBetasSc3(numJugadores, ref contadorEqs);
            foreach (string eq in listaBetas)
            {
                script.Append(eq);
                script.AppendLine();
            }

            listaComplemento = utils.getWcomplemento(numJugadores, ref contadorEqs);
            foreach (string eq in listaComplemento)
            {
                script.Append(eq);
                script.AppendLine();
            }
            return script.ToString();
        }
    }
}
