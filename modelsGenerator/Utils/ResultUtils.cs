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

        public double getFScenario3(int numPlayers, double Kf, double totalD, double Qf, double Hf,
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

        public List<double> getMScenario3(int numPlayers, List<double> listK, List<double> listD,
                                List<double> listH, List<double> listS, List<double> listQ,
                                List<double> listB, List<double> listBetas, List<double> listT, List<double> listL)
        {
            List<double> retornar = new List<double>();

            for (int i = 0; i < numPlayers; i++)
            {
                double result = listBetas[i] * (listK[i] * (listD[i] / listQ[i])) +
                                listBetas[i] * (listH[i] * ((Math.Pow(listQ[i] - listB[i], 2)) / (2 * listQ[i]))) +
                                listBetas[i] * (listS[i] * ((Math.Pow(listB[i], 2)) / (2 * listQ[i])));

                for (int j = 0; j < numPlayers - 1; j++)
                {
                    result = result + listT[0] * (Math.Pow(listL[0], 2) / (2 * listQ[j]));
                    listT.RemoveAt(0);
                    listL.RemoveAt(0);
                }
                retornar.Add(result);
            }

            return retornar;
        }

        public List<double> getReOrderPoint(int numPlayers, List<double> listQ, List<double> listD, List<double> listB, double leadTime)
        {
            List<double> listaRetorno = new List<double>();

            for (int i = 0; i < numPlayers; i++)
            {
                double T = listQ[i] / listD[i];
                double LT = leadTime - (Math.Floor(leadTime / T) * T);
                double R = Math.Round((LT * listD[i]) - listB[i],1);
                listaRetorno.Add(R);
            }

            return listaRetorno;
        }
    }
}
