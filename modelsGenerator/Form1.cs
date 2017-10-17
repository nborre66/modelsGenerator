using GAMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modelsGenerator
{
    public partial class frmApp : Form
    {
        // Instancia builder
        ScenarioBuilder builder = new ScenarioBuilder();
        // Lista total de parametros
        List<string> totalParameters = new List<string>();
        // Lista de resultados
        List<string> listResults = new List<string>();
        string valorCelda = "";
        public frmApp()
        {
            InitializeComponent();
        }

        private void btnGenScript_Click(object sender, EventArgs e)
        {
            //Limpio la ventana del modelo
            richScriptViewer.Clear();
            //Limpio Consola
            richConsoleViewer.Clear();
            //Inicializo contadores W y Eq
            int contadorEqs = 1;
            int contadorW = 1;
            /*
            initial = Encabezado de script
            parameters = Declaracion de parametros
            variables = Declaracion de variables
            equations = Declaracion de ecuaciones
            model = modelo generado
            complement = Pie de Script
             */
            string initial, parameters, variables, equations, model, complement = "";
            // finalModel = initial + parameters + variables + equations + model + complement
            StringBuilder finalModel = new StringBuilder();
            if (rbEscenario1.Checked)
            {
                // Adiciona parametros en tabla por escenario
                addParameters(1);
                // Construyo Initial
                initial = builder.getInitial();
                // Construyo Parameters
                parameters = builder.getParameters(totalParameters);
                // Construyo Modelo
                model = builder.scenario1Build((int)numPlayers.Value, ref contadorEqs);
                // Construyo Variables
                variables = builder.getVariables(variableScenario(1, contadorW), (int)numPlayers.Value);
                // Construyo Ecuaciones
                equations = builder.getEquations(contadorEqs-1);
                // Construyo Complemento
                complement = builder.getComplement();
                // Organizo y muestro en la ventana del modelo
                finalModel.Append(initial);
                finalModel.AppendLine();
                finalModel.Append(parameters);
                finalModel.AppendLine();
                finalModel.Append(variables);
                finalModel.AppendLine();
                finalModel.Append(equations);
                finalModel.AppendLine();
                finalModel.Append(model);
                finalModel.Append(complement);
                richScriptViewer.AppendText(finalModel.ToString());
            }
            else if (rbEscenario2.Checked)
            {
                addParameters(2);
                initial = builder.getInitial();
                parameters = builder.getParameters(totalParameters);
                model = builder.scenario2Build((int)numPlayers.Value, ref contadorEqs, ref contadorW);
                variables = builder.getVariables(variableScenario(2, contadorW), (int)numPlayers.Value);
                equations = builder.getEquations(contadorEqs-1);
                complement = builder.getComplement();
                finalModel.Append(initial);
                finalModel.AppendLine();
                finalModel.Append(parameters);
                finalModel.AppendLine();
                finalModel.Append(variables);
                finalModel.AppendLine();
                finalModel.Append(equations);
                finalModel.AppendLine();
                finalModel.Append(model);
                finalModel.Append(complement);
                richScriptViewer.AppendText(finalModel.ToString());
            }
            else
            {
                addParameters(3);
                initial = builder.getInitial();
                parameters = builder.getParameters(totalParameters);
                model = builder.scenario3Build((int)numPlayers.Value, ref contadorEqs, ref contadorW);
                variables = builder.getVariables(variableScenario(3, contadorW), (int)numPlayers.Value);
                equations = builder.getEquations(contadorEqs-1);
                complement = builder.getComplement();
                finalModel.Append(initial);
                finalModel.AppendLine();
                finalModel.Append(parameters);
                finalModel.AppendLine();
                finalModel.Append(variables);
                finalModel.AppendLine();
                finalModel.Append(equations);
                finalModel.AppendLine();
                finalModel.Append(model);
                finalModel.Append(complement);
                richScriptViewer.AppendText(finalModel.ToString());
            }
        }

        private async void btnExecuteProgram_Click(object sender, EventArgs e)
        {
            listResults.Clear();
            richConsoleViewer.Clear();
            StringBuilder respuesta = new StringBuilder();
            btnExecuteProgram.Enabled = false;
            respuesta.Append("Inicio Ejecucion Programa " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            respuesta.AppendLine();
            respuesta.Append("Solver: LINDOGLOBAL");
            respuesta.AppendLine();
            respuesta.Append("Iterlim: 900000000");
            respuesta.AppendLine();
            respuesta.Append("Obteniendo resultados, por favor espere");
            respuesta.AppendLine();
            richConsoleViewer.AppendText(respuesta.ToString());
            string modelo = @richScriptViewer.Text.ToString();
            await Task.Run(() => executeGamsJob(modelo));

            foreach (string lineConsole in listResults)
            {
                respuesta.Append(lineConsole);
                respuesta.AppendLine();
            }

            richConsoleViewer.Clear();
            richConsoleViewer.AppendText(respuesta.ToString());

            btnExecuteProgram.Enabled = true;
        }

        private void executeGamsJob(string modelo)
        {
            List<string> variablesEval = new List<string>();
            if (rbEscenario1.Checked) { variablesEval = getVariableEval(1); }
            else if (rbEscenario2.Checked) { variablesEval = getVariableEval(2); }
            else { variablesEval = getVariableEval(3); }

            GAMSWorkspace ws;
            if (Environment.GetCommandLineArgs().Length > 1)
                ws = new GAMSWorkspace(systemDirectory: Environment.GetCommandLineArgs()[1]);
            else
                ws = new GAMSWorkspace("D://");

            using (GAMSOptions opt = ws.AddOptions())
            {
                opt.AllModelTypes = "LINDOGLOBAL";
                opt.IterLim = 900000000;
                GAMSJob j1 = ws.AddJobFromString(modelo);
                j1.Run(opt);

                foreach (string variable in variablesEval)
                {
                    foreach (GAMSVariableRecord rec in j1.OutDB.GetVariable(variable))
                    {
                        listResults.Add("variable " + variable + "=" + rec.Variable.LastRecord().Level.ToString());
                    }

                }
                listResults.Add("Hora finalizacion: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }


        }

        private void addParameters(int scenario)
        {
            // Limpio lista total de parametros
            totalParameters.Clear();
            // Limpio la tabla de parametros
            dgvParameters.Rows.Clear();
            /*
             fixedParameters = Parametros fijos
             nonFixedParameters = Parametros con indice
             */
            List<string> fixedParameters = new List<string>();
            List<string> nonFixedParameters = new List<string>();

            //Adicion de parametros fijos en tabla
            fixedParameters = fixedValuesParametersScenario(scenario);
            //Agrego en la tabla
            foreach (string parameter in fixedParameters)
            {
                this.dgvParameters.Rows.Add(parameter, "0");
            }

            //Adicion de parametros con indice en tabla
            nonFixedParameters = nonFixedValuesParametersScenario(scenario);
            //Agrego en la tabla
            foreach (string parameter in nonFixedParameters)
            {
                this.dgvParameters.Rows.Add(parameter, "0");
            }

        }

        public List<List<string>> variableScenario(int scenario, int contadorW)
        {
            // Lista de Listas que voy a retornar
            List<List<string>> retornar = new List<List<string>>();
            // Lista total de variables
            List<string> totalVariable = new List<string>();
            // Lista de variables Enteras
            List<string> integerVariable = getIntegerVariables(scenario);
            // Lista de variables Positivas
            List<string> positiveVariable = getPositiveVariables(scenario, contadorW);
            // Lista de variables Binarias
            List<string> binaryVariable = getBinaryVariables(scenario);
            // Agrego todas las listas a la lista total de variables 
            totalVariable.AddRange(integerVariable);
            totalVariable.AddRange(positiveVariable);
            totalVariable.AddRange(binaryVariable);

            // Agrego Lista entera, Lista positiva, Lista Binaria y lista total a la lista que voy a retornar
            retornar.Add(integerVariable);
            retornar.Add(positiveVariable);
            retornar.Add(binaryVariable);
            retornar.Add(totalVariable);
            return retornar;
        }

        public List<string> getIntegerVariables(int scenario)
        {
            // Lista de variables
            List<string> values = new List<string>();
            values.Add("Qf");
            values.Add("Cf");
            for (int i = 1; i <= (int)numPlayers.Value; i++)
            {
                values.Add("q" + i.ToString());
            }
            for (int i = 1; i <= (int)numPlayers.Value; i++)
            {
                values.Add("b" + i.ToString());
            }
            for (int i = 1; i <= (int)numPlayers.Value; i++)
            {
                values.Add("Bf" + i.ToString());
            }
            if (scenario == 3)
            {
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    for (int j = 1; j <= (int)numPlayers.Value; j++)
                    {
                        if (i != j)
                        {
                            values.Add("Y" + i.ToString() + j.ToString());
                        }
                    }
                }
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    for (int j = 1; j <= (int)numPlayers.Value; j++)
                    {
                        if (i != j)
                        {
                            values.Add("L" + i.ToString() + j.ToString());
                        }
                    }
                }
            }
            return values;
        }

        public List<string> getPositiveVariables(int scenario, int contadorW)
        {
            //Lista de variables
            List<string> values = new List<string>();

            if (scenario == 2 || scenario == 3)
            {
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    values.Add("alfa" + i.ToString());
                }
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    values.Add("beta" + i.ToString());
                }
                for (int i = 1; i <= contadorW; i++)
                {
                    values.Add("w" + i.ToString());
                }
            }

            return values;
        }
        public List<string> getBinaryVariables(int scenario)
        {
            // Lista de variables 
            List<string> values = new List<string>();

            if (scenario == 3)
            {
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    for (int j = 1; j <= (int)numPlayers.Value; j++)
                    {
                        if (i != j)
                        {
                            values.Add("X" + i.ToString() + j.ToString());
                        }
                    }
                }
            }

            return values;
        }

        public List<string> fixedValuesParametersScenario(int scenario)
        {
            List<string> values = new List<string>();
            values.Add("Hf");
            values.Add("Sf");
            values.Add("Kf");
            values.Add("Z");
            totalParameters.AddRange(values);
            return values;
        }

        public List<string> getVariableEval(int scenario)
        {
            // Lista de Listas que voy a retornar
            List<string> retornar = new List<string>();

            retornar.Add("Qf");
            retornar.Add("Cf");
            for (int i = 1; i <= (int)numPlayers.Value; i++)
            {
                retornar.Add("q" + i);
            }
            for (int i = 1; i <= (int)numPlayers.Value; i++)
            {
                retornar.Add("b" + i);
            }
            for (int i = 1; i <= (int)numPlayers.Value; i++)
            {
                retornar.Add("Bf" + i);
            }


            if (scenario == 2 || scenario == 3)
            {
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    retornar.Add("alfa" + i);
                }
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    retornar.Add("beta" + i);
                }
            }

            if (scenario == 3)
            {
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    for (int j = 1; j <= (int)numPlayers.Value; j++)
                    {
                        if (i != j)
                        {
                            retornar.Add("L" + i.ToString() + j.ToString());
                        }
                    }
                }
            }

            return retornar;
        }

        public List<string> nonFixedValuesParametersScenario(int scenario)
        {
            List<string> values = new List<string>();

                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    values.Add("D" + i.ToString());
                }
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    values.Add("h" + i.ToString());
                }
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    values.Add("s" + i.ToString());
                }
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    values.Add("k" + i.ToString());
                }
            
            if(scenario==3)
            {
                for (int i = 1; i <= (int)numPlayers.Value; i++)
                {
                    for (int j = 1; j <= (int)numPlayers.Value; j++)
                    {
                        if (i != j)
                        {
                            values.Add("T" + i.ToString() + j.ToString());
                        }
                    }
                }
            }
            totalParameters.AddRange(values);
            return values;
        }

        private void dgvVariables_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress +=
                new KeyPressEventHandler(dgvVariables_KeyPress);
        }

        private void dgvVariables_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar.Equals('\b')) { e.Handled = false; }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow myRow in dgvParameters.Rows)
            {
                string replaceOld = @"scalar " + dgvParameters[0, myRow.Index].Value.ToString() + " /" + dgvParameters[1, myRow.Index].Value.ToString() + "/";
                string replaceNew = @"scalar " + dgvParameters[0, myRow.Index].Value.ToString() + " /0/";
                richScriptViewer.Rtf = richScriptViewer.Rtf.Replace(replaceOld, replaceNew);
                myRow.Cells[1].Value = "0"; 
            }
        }

        private void dgvVariables_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            valorCelda = dgvParameters[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dgvVariables_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string replaceOld = @"scalar " + dgvParameters[0, e.RowIndex].Value.ToString() + " /" + valorCelda + "/";
            string replaceNew = @"scalar " + dgvParameters[0, e.RowIndex].Value.ToString() + " /" + dgvParameters[e.ColumnIndex, e.RowIndex].Value.ToString() + "/";

            richScriptViewer.Rtf = richScriptViewer.Rtf.Replace(replaceOld, replaceNew);
        }
    }
}
