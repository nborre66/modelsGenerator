using GAMS;
using modelsGenerator.Objects;
using System;
using System.Collections.Generic;
using System.Text;
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
        // Lista de resultados formato consola
        List<string> listResultsConsole = new List<string>();
        // valores Resultantes variable
        List<Variable> ListResultsVariable = new List<Variable>();
        // texto de validacion de formulario
        string warning = "";
        
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
            bool err = validaForm();
            

            if (err)
            {
                MessageBox.Show(warning, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ResultUtils util = new ResultUtils();
                List<Parameter> listParameterValues = getParametersFromTable();
                listResultsConsole.Clear();
                ListResultsVariable.Clear();
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
                string directorio = txtResultDirectory.Text;
                await Task.Run(() => executeGamsJob(modelo, directorio));

                foreach (string lineConsole in listResultsConsole)
                {
                    respuesta.Append(lineConsole);
                    respuesta.AppendLine();
                }

                respuesta.AppendLine();

                if (rbEscenario1.Checked)
                {
                    respuesta.Append("Inicio calculo de resultados " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    respuesta.AppendLine();
                    respuesta.Append("Costo fabricante: " + util.getFScenario1(getValueParameter(listParameterValues, false, "Kf"),
                                                                    getValueParameter(listParameterValues, true, "D"),
                                                                    getValueVariable(ListResultsVariable, false, "Qf"),
                                                                    getValueParameter(listParameterValues, false, "Hf"),
                                                                    getValueVariable(ListResultsVariable, false, "Cf"),
                                                                    getValueParameter(listParameterValues, false, "Sf"),
                                                                    getValueVariable(ListResultsVariable, true, "Bf")));
                    respuesta.AppendLine();

                    List<double> retailerValues = util.getMScenario1((int)numPlayers.Value,
                                                            getListValuePameter(listParameterValues, "k"),
                                                            getListValuePameter(listParameterValues, "D"),
                                                            getListValuePameter(listParameterValues, "h"),
                                                            getListValuePameter(listParameterValues, "s"),
                                                            getListValueVariable(ListResultsVariable, "q"),
                                                            getListValueVariable(ListResultsVariable, "b"));
                    int contadorMinorista = 1;
                    foreach (double value in retailerValues)
                    {
                        respuesta.Append("Costo minorista " + contadorMinorista + ": " + value);
                        respuesta.AppendLine();
                        contadorMinorista++;
                    }

                    List<double> reOrderPointsValues = util.getReOrderPoint((int)numPlayers.Value,
                                                        getListValueVariable(ListResultsVariable, "q"),
                                                        getListValuePameter(listParameterValues, "D"),
                                                        getListValueVariable(ListResultsVariable, "b"),
                                                        double.Parse(txtLeadTime.Text, System.Globalization.CultureInfo.InvariantCulture)
                                                        );

                    int contadorPunto = 1;
                    foreach (double value in reOrderPointsValues)
                    {
                        respuesta.Append("R" + contadorPunto + ": " + value);
                        respuesta.AppendLine();
                        contadorPunto++;
                    }

                    respuesta.Append("Hora Finalizacion: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else if (rbEscenario2.Checked)
                {
                    respuesta.Append("Inicio calculo de resultados " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    respuesta.AppendLine();
                    respuesta.Append("Costo fabricante: " + util.getFScenario2((int)numPlayers.Value,
                                                    getValueParameter(listParameterValues, false, "Kf"),
                                                    getValueParameter(listParameterValues, true, "D"),
                                                    getValueVariable(ListResultsVariable, false, "Qf"),
                                                    getValueParameter(listParameterValues, false, "Hf"),
                                                    getValueVariable(ListResultsVariable, false, "Cf"),
                                                    getValueParameter(listParameterValues, false, "Sf"),
                                                    getValueVariable(ListResultsVariable, true, "Bf"),
                                                    getListValuePameter(listParameterValues, "k"),
                                                    getListValuePameter(listParameterValues, "D"),
                                                    getListValuePameter(listParameterValues, "h"),
                                                    getListValuePameter(listParameterValues, "s"),
                                                    getListValueVariable(ListResultsVariable, "q"),
                                                    getListValueVariable(ListResultsVariable, "b"),
                                                    getListValueVariable(ListResultsVariable, "alfa")
                                                    ));
                    respuesta.AppendLine();

                    List<double> retailerValues = util.getMScenario2((int)numPlayers.Value,
                                                            getListValuePameter(listParameterValues, "k"),
                                                            getListValuePameter(listParameterValues, "D"),
                                                            getListValuePameter(listParameterValues, "h"),
                                                            getListValuePameter(listParameterValues, "s"),
                                                            getListValueVariable(ListResultsVariable, "q"),
                                                            getListValueVariable(ListResultsVariable, "b"),
                                                            getListValueVariable(ListResultsVariable, "beta"));
                    int contadorMinorista = 1;
                    foreach (double value in retailerValues)
                    {
                        respuesta.Append("Costo minorista " + contadorMinorista + ": " + value);
                        respuesta.AppendLine();
                        contadorMinorista++;
                    }

                    List<double> reOrderPointsValues = util.getReOrderPoint((int)numPlayers.Value,
                                    getListValueVariable(ListResultsVariable, "q"),
                                    getListValuePameter(listParameterValues, "D"),
                                    getListValueVariable(ListResultsVariable, "b"),
                                    double.Parse(txtLeadTime.Text, System.Globalization.CultureInfo.InvariantCulture)
                                    );

                    int contadorPunto = 1;
                    foreach (double value in reOrderPointsValues)
                    {
                        respuesta.Append("R" + contadorPunto + ": " + value);
                        respuesta.AppendLine();
                        contadorPunto++;
                    }

                    respuesta.Append("Hora Finalizacion: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    respuesta.Append("Inicio calculo de resultados " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    respuesta.AppendLine();
                    respuesta.Append("Costo fabricante: " + util.getFScenario3((int)numPlayers.Value,
                                    getValueParameter(listParameterValues, false, "Kf"),
                                    getValueParameter(listParameterValues, true, "D"),
                                    getValueVariable(ListResultsVariable, false, "Qf"),
                                    getValueParameter(listParameterValues, false, "Hf"),
                                    getValueVariable(ListResultsVariable, false, "Cf"),
                                    getValueParameter(listParameterValues, false, "Sf"),
                                    getValueVariable(ListResultsVariable, true, "Bf"),
                                    getListValuePameter(listParameterValues, "k"),
                                    getListValuePameter(listParameterValues, "D"),
                                    getListValuePameter(listParameterValues, "h"),
                                    getListValuePameter(listParameterValues, "s"),
                                    getListValueVariable(ListResultsVariable, "q"),
                                    getListValueVariable(ListResultsVariable, "b"),
                                    getListValueVariable(ListResultsVariable, "alfa")
                                    ));
                    respuesta.AppendLine();

                    List<double> retailerValues = util.getMScenario3((int)numPlayers.Value,
                                                            getListValuePameter(listParameterValues, "k"),
                                                            getListValuePameter(listParameterValues, "D"),
                                                            getListValuePameter(listParameterValues, "h"),
                                                            getListValuePameter(listParameterValues, "s"),
                                                            getListValueVariable(ListResultsVariable, "q"),
                                                            getListValueVariable(ListResultsVariable, "b"),
                                                            getListValueVariable(ListResultsVariable, "beta"),
                                                            getListValuePameter(listParameterValues, "T"),
                                                            getListValueVariable(ListResultsVariable, "L"));
                    int contadorMinorista = 1;
                    foreach (double value in retailerValues)
                    {
                        respuesta.Append("Costo minorista " + contadorMinorista + ": " + value);
                        respuesta.AppendLine();
                        contadorMinorista++;
                    }

                    List<double> reOrderPointsValues = util.getReOrderPoint((int)numPlayers.Value,
                                    getListValueVariable(ListResultsVariable, "q"),
                                    getListValuePameter(listParameterValues, "D"),
                                    getListValueVariable(ListResultsVariable, "b"),
                                    double.Parse(txtLeadTime.Text, System.Globalization.CultureInfo.InvariantCulture)
                                    );

                    int contadorPunto = 1;
                    foreach (double value in reOrderPointsValues)
                    {
                        respuesta.Append("R" + contadorPunto + ": " + value);
                        respuesta.AppendLine();
                        contadorPunto++;
                    }

                    respuesta.Append("Hora Finalizacion: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                richConsoleViewer.Clear();
                richConsoleViewer.AppendText(respuesta.ToString());

                btnExecuteProgram.Enabled = true;
            }
        }

        private bool validaForm()
        {
            warning = string.Empty;
            bool err = false;
            StringBuilder errTxt = new StringBuilder();

            errTxt.Append("Se encontraron los siguientes errores:");
            errTxt.AppendLine();

            if (txtLeadTime.Text.Equals("0.0") || txtLeadTime.Text.Equals(""))
            {
                errTxt.Append("Debe asignar valor de Lead Time");
                errTxt.AppendLine();
                err = true;
            }
            if (txtResultDirectory.Text.Equals(""))
            {
                errTxt.Append("Debe seleccionar un directorio para guardar resultados");
                errTxt.AppendLine();
                err = true;
            }
            if (richScriptViewer.Text.Equals(""))
            {
                errTxt.Append("Debe generar el Script Gams");
                errTxt.AppendLine();
                err = true;
            }
            bool asignaParameters = false;
            foreach (DataGridViewRow row in dgvParameters.Rows)
            {
                if (!row.Cells[1].Value.Equals("0"))
                {
                    asignaParameters = true;
                }
            }

            if (!asignaParameters)
            {
                errTxt.Append("Debe darle valores a los parametros");
                errTxt.AppendLine();
                err = true;
            }
            warning = errTxt.ToString();
            return err;
        }

        private double getValueParameter(List<Parameter> parameters, bool isTotal, string parameterName)
        {
            double valorRetorno = 0;
            if (isTotal)
            {
                foreach (Parameter p in parameters)
                {
                    if (p.Name.Contains(parameterName))
                    {
                        valorRetorno = valorRetorno + p.Value;
                    }
                }
            }
            else
            {
                foreach (Parameter p in parameters)
                {
                    if (p.Name.Contains(parameterName))
                    {
                        valorRetorno = p.Value;
                    }
                }
            }
            return valorRetorno;
        }

        private List<double> getListValuePameter(List<Parameter> parameters, string parameterName)
        {
            List<double> retornar = new List<double>();
            foreach (Parameter p in parameters)
            {
                if (p.Name.Contains(parameterName))
                {
                    retornar.Add(p.Value);
                }
            }
            return retornar;
        }

        private List<double> getListValueVariable(List<Variable> variables, string variableName)
        {
            List<double> retornar = new List<double>();
            foreach (Variable v in variables)
            {
                if (v.Name.Contains(variableName))
                {
                    retornar.Add(v.Value);
                }
            }
            return retornar;
        }

        private double getValueVariable(List<Variable> variables, bool isTotal, string variableName)
        {
            double valorRetorno = 0;
            if (isTotal)
            {
                foreach (Variable v in variables)
                {
                    if (v.Name.Contains(variableName))
                    {
                        valorRetorno = valorRetorno + v.Value;
                    }
                }
            }
            else
            {
                foreach (Variable v in variables)
                {
                    if (v.Name.Contains(variableName))
                    {
                        valorRetorno = v.Value;
                    }
                }
            }
            return valorRetorno;
        }

        private List<Parameter> getParametersFromTable()
        {
            List<Parameter> retorno = new List<Parameter>();
            foreach (DataGridViewRow row in dgvParameters.Rows)
            {
                retorno.Add(new Parameter(row.Cells[0].Value.ToString(), Double.Parse(row.Cells[1].Value.ToString())));
            }
            return retorno;
        }

        private void executeGamsJob(string modelo, string directorio)
        {
            List<string> variablesEval = new List<string>();
            if (rbEscenario1.Checked) { variablesEval = getVariableEval(1); }
            else if (rbEscenario2.Checked) { variablesEval = getVariableEval(2); }
            else { variablesEval = getVariableEval(3); }

            GAMSWorkspace ws;
            if (Environment.GetCommandLineArgs().Length > 1)
                ws = new GAMSWorkspace(systemDirectory: Environment.GetCommandLineArgs()[1]);
            else
                ws = new GAMSWorkspace(@directorio);

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
                        listResultsConsole.Add("variable " + variable + "=" + rec.Variable.LastRecord().Level.ToString());
                        ListResultsVariable.Add(new Variable(variable, rec.Variable.LastRecord().Level));
                    }

                }
                listResultsConsole.Add("Hora finalizacion: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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

        private void txtLeadTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            DialogResult dialog = fbdResults.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                txtResultDirectory.Text = fbdResults.SelectedPath;
            }
        }
    }
}
