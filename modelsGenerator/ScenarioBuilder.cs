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
            /*
             listaDesigualdades = Lista de ecuaciones de desigualdad
             listaIgualdades = Lista de ecuaciones de igualdad
             listaBetas = Lista de ecuaciones con Betas
             numJugadores = numero de minoristas
             */
            List<string> listaDesigualdades = new List<string>();
            List<string> listaIgualdades = new List<string>();
            List<string> listaBetas = new List<string>();
            int numJugadores = numPlayers;
            int contadorW = 1;
            // cadenaAlfa = Ecuacion para jugador 1
            // Construyo Funcion objetivo
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
            //Obtengo desigualdades
            listaDesigualdades = utils.getDesigualdadesSc1(numJugadores, ref contadorEqs, ref contadorW);
            //Las agrego al script
            foreach (string eq in listaDesigualdades)
            {
                script.Append(eq);
                script.AppendLine();
            }
            //Obtengo igualdades
            listaIgualdades = utils.getIgualdadesSc1(numJugadores, ref contadorEqs);
            //Las agrego al script
            foreach (string eq in listaIgualdades)
            {
                script.Append(eq);
                script.AppendLine();
            }
            return script.ToString();
        }

        public string scenario2Build(int numPlayers, ref int contadorEqs, ref int contadorW)
        {
            List<string> listaDesigualdades = new List<string>();
            List<string> listaIgualdades = new List<string>();
            List<string> listaBetas = new List<string>();
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

        public string scenario3Build(int numPlayers, ref int contadorEqs, ref int contadorW)
        {
            List<string> listaDesigualdades = new List<string>();
            List<string> listaIgualdades = new List<string>();
            List<string> listaBetas = new List<string>();
            List<string> listaComplemento = new List<string>();
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

        public string getInitial()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"$TITLE modelo binivel vmi básico");
            sb.AppendLine();
            sb.Append("Option");
            sb.AppendLine();
            sb.Append("iterlim = 900000000;");
            return sb.ToString();
        }

        public string getParameters(List<string> parametros)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string element in parametros)
            {
                sb.Append(@"scalar " + element + " /0/");
                sb.AppendLine();
            }
            sb.Append(";");
            return sb.ToString();
        }

        public string getVariables(List<List<string>> variablesList, int numPLayers)
        {
            StringBuilder sb = new StringBuilder();
            List<string> integerVariable = variablesList[0];
            List<string> positiveVariable = variablesList[1];
            List<string> binaryVariable = variablesList[2];
            List<string> totalVariable = variablesList[3];

            sb.Append("VARIABLES");
            sb.AppendLine();

            foreach (string element in totalVariable)
            {
                sb.Append(element);
                sb.AppendLine();
            }

            sb.Append("F Funcion objetivo");
            sb.AppendLine();
            sb.Append("integer variables ");

            for (int i = 0; i < integerVariable.Count; i++)
            {
                if (i == integerVariable.Count-1)
                { sb.Append(integerVariable[i] + ";"); }
                else
                { sb.Append(integerVariable[i] + ","); }
            }
            if (positiveVariable.Count > 0)
            {
                sb.AppendLine();
                sb.Append("positive variables ");
                for (int i = 0; i < positiveVariable.Count; i++)
                {
                    if (i == positiveVariable.Count - 1)
                    { sb.Append(positiveVariable[i] + ";"); }
                    else
                    { sb.Append(positiveVariable[i] + ","); }
                }
            }
            if (binaryVariable.Count > 0)
            {
                sb.AppendLine();
                sb.Append("binary variables ");
                for (int i = 0; i < binaryVariable.Count; i++)
                {
                    if (i == binaryVariable.Count - 1)
                    { sb.Append(binaryVariable[i] + ";"); }
                    else
                    { sb.Append(binaryVariable[i] + ","); }
                }
            }
            sb.AppendLine();
            for (int i = 1; i <= numPLayers; i++)
            {
                sb.Append("q" + i.ToString() + ".LO=1;");
                sb.AppendLine();
            }
            sb.Append("Qf.LO=1;");
            sb.AppendLine();
            sb.Append("Cf.LO=1;");


            return sb.ToString();
        }

        public string getEquations(int contadorEq)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("EQUATIONS");
            sb.AppendLine();
            sb.Append("funobj  funcion objetivo");
            sb.AppendLine();

            for (int i = 1; i <= contadorEq; i++)
            {
                sb.Append("eq" + i.ToString());
                sb.AppendLine();
            }
            sb.Append(";");
            return sb.ToString();
        }

        public string getComplement()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"MODEL modelo1 / all /;"); 
            sb.AppendLine();
            sb.Append("SOLVE modelo1 using MINLP minimizing F");
            return sb.ToString();
        }
    }
}
