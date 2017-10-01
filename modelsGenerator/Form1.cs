using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modelsGenerator
{
    public partial class frmApp : Form
    {
        StringUtils utils = new StringUtils();
        ScenarioBuilder builder = new ScenarioBuilder();
        List<string> totalParameters = new List<string>();
        string valorCelda = "";
        public frmApp()
        {
            InitializeComponent();
        }

        private void btnGenScript_Click(object sender, EventArgs e)
        {
            richScriptViewer.Clear();
            int contadorEqs = 1;
            int contadorW = 1;
            string initial, parameters, variables, equations, model, complement = "";
            StringBuilder finalModel = new StringBuilder();
            if (rbEscenario1.Checked)
            {
                addParametersNVariables(1);
                initial = builder.getInitial();
                parameters = builder.getParameters(totalParameters);
                model = builder.scenario1Build((int)numPlayers.Value, ref contadorEqs);
                variables = builder.getVariables(variableScenario(1, contadorW), (int)numPlayers.Value);
                equations = builder.getEquations(contadorEqs);
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
            else if (rbEscenario2.Checked)
            {
                addParametersNVariables(2);
                initial = builder.getInitial();
                parameters = builder.getParameters(totalParameters);
                model = builder.scenario2Build((int)numPlayers.Value, ref contadorEqs, ref contadorW);
                variables = builder.getVariables(variableScenario(2, contadorW), (int)numPlayers.Value);
                equations = builder.getEquations(contadorEqs);
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
                addParametersNVariables(3);
                initial = builder.getInitial();
                parameters = builder.getParameters(totalParameters);
                model = builder.scenario3Build((int)numPlayers.Value, ref contadorEqs, ref contadorW);
                variables = builder.getVariables(variableScenario(3, contadorW), (int)numPlayers.Value);
                equations = builder.getEquations(contadorEqs);
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

        private void btnExecuteProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En construccion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void addParametersNVariables(int scenario)
        {
            totalParameters.Clear();
            dgvVariables.Rows.Clear();
            List<string> fixedParameters = new List<string>();
            List<string> nonFixedParameters = new List<string>();

            //Adicion de parametros fijos en tabla
            fixedParameters = fixedValuesParametersScenario(scenario);

            foreach (string parameter in fixedParameters)
            {
                this.dgvVariables.Rows.Add(parameter, "0");
            }

            //Adicion de parametros variables en tabla
            nonFixedParameters = nonFixedValuesParametersScenario(scenario);

            foreach (string parameter in nonFixedParameters)
            {
                this.dgvVariables.Rows.Add(parameter, "0");
            }

        }

        public List<List<string>> variableScenario(int scenario, int contadorW)
        {
            List<List<string>> retornar = new List<List<string>>();
            List<string> totalVariable = new List<string>();
            List<string> integerVariable = getIntegerVariables(scenario);
            List<string> positiveVariable = getPositiveVariables(scenario, contadorW);
            List<string> binaryVariable = getBinaryVariables(scenario);
            totalVariable.AddRange(integerVariable);
            totalVariable.AddRange(positiveVariable);
            totalVariable.AddRange(binaryVariable);

            retornar.Add(integerVariable);
            retornar.Add(positiveVariable);
            retornar.Add(binaryVariable);
            retornar.Add(totalVariable);
            return retornar;
        }

        public List<string> getIntegerVariables(int scenario)
        {
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
            foreach (DataGridViewRow myRow in dgvVariables.Rows)
            {
                string replaceOld = @"scalar " + dgvVariables[0, myRow.Index].Value.ToString() + " /" + dgvVariables[1, myRow.Index].Value.ToString() + "/";
                string replaceNew = @"scalar " + dgvVariables[0, myRow.Index].Value.ToString() + " /0/";
                richScriptViewer.Rtf = richScriptViewer.Rtf.Replace(replaceOld, replaceNew);
                myRow.Cells[1].Value = "0"; 
            }
        }

        private void dgvVariables_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            valorCelda = dgvVariables[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dgvVariables_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string replaceOld = @"scalar " + dgvVariables[0, e.RowIndex].Value.ToString() + " /" + valorCelda + "/";
            string replaceNew = @"scalar " + dgvVariables[0, e.RowIndex].Value.ToString() + " /" + dgvVariables[e.ColumnIndex, e.RowIndex].Value.ToString() + "/";

            richScriptViewer.Rtf = richScriptViewer.Rtf.Replace(replaceOld, replaceNew);
        }
    }
}
