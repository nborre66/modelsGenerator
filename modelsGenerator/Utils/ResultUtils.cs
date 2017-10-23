using System;
using System.Collections.Generic;

namespace modelsGenerator
{
    class ResultUtils
    {
        public double getFScenario1(double Kf, double totalD, double Qf, double Hf, double Cf, 
                                    double Sf, double totalBf)
        {
            double result = (Kf * (totalD / Qf)) +
                            (Hf * ((Cf + 1) / 2) * (Qf / Cf)) +
                            (Sf * (Math.Pow(totalBf, 2) / (2 * Qf)));


            return result;
        }

        public List<double> getMScenario1(int numPlayers, List<double> listK, List<double> listD, 
                                List<double> listH, List<double> listS, List<double> listQ, 
                                List<double> listB)
        {
            List<double> retornar = new List<double>();

            for (int i = 0; i<numPlayers; i++)
            {
                double result = (listK[i] * (listD[i]/listQ[i])) + 
                                (listH[i] * ((Math.Pow(listQ[i]-listB[i],2))/(2*listQ[i]))) +
                                (listS[i] * ((Math.Pow(listB[i], 2)) / (2 * listQ[i])));
                retornar.Add(result);
            }

            return retornar;
        }

        public double getFScenario2(int numPlayers, double Kf, double totalD, double Qf, double Hf, 
                                double Cf, double Sf, double totalBf, 
                                List<double> listK, List<double> listD,
                                List<double> listH, List<double> listS, 
                                List<double> listQ, List<double> listB,
                                List<double> ListAlfa)
        {
            double result = (Kf * (totalD / Qf)) +
                            (Hf * ((Cf + 1) / 2) * (Qf / Cf)) +
                            (Sf * (Math.Pow(totalBf, 2) / (2 * Qf)));

            for (int i = 0; i < numPlayers; i++)
            {
                result = result + ListAlfa[i] * ((listK[i] * (listD[i] / listQ[i])) +
                                ListAlfa[i] * (listH[i] * ((Math.Pow(listQ[i] - listB[i], 2)) / (2 * listQ[i]))) +
                                ListAlfa[i] * (listS[i] * ((Math.Pow(listB[i], 2)) / (2 * listQ[i]))));
                
            }

            return result;
        }

        public List<double> getMScenario2(int numPlayers, List<double> listK, List<double> listD,
                                List<double> listH, List<double> listS, List<double> listQ,
                                List<double> listB, List<double> listBetas)
        {
            List<double> retornar = new List<double>();

            for (int i = 0; i < numPlayers; i++)
            {
                double result = listBetas[i] * (listK[i] * (listD[i] / listQ[i])) +
                                listBetas[i] * (listH[i] * ((Math.Pow(listQ[i] - listB[i], 2)) / (2 * listQ[i]))) +
                                listBetas[i] * (listS[i] * ((Math.Pow(listB[i], 2)) / (2 * listQ[i])));
                retornar.Add(result);
            }

            return retornar;
        }
    }
}
