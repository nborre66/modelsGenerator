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
        public frmApp()
        {
            InitializeComponent();
        }

        private void grbAditionalParameters_Enter(object sender, EventArgs e)
        {

        }

        private void frmApp_Load(object sender, EventArgs e)
        {

        }

        private void btnGenScript_Click(object sender, EventArgs e)
        {
            richScriptViewer.Clear();
            int contadorEqs = 1;
            if (rbEscenario1.Checked)
            {
                addParametersNVariables(1);
                richScriptViewer.AppendText(builder.scenario1Build((int)numPlayers.Value, ref contadorEqs));
            }
            else if (rbEscenario2.Checked)
            {
                richScriptViewer.AppendText(builder.scenario2Build((int)numPlayers.Value, ref contadorEqs));
            }
            else
            {
                richScriptViewer.AppendText(builder.scenario3Build((int)numPlayers.Value, ref contadorEqs));
            }
        }

        private void btnExecuteProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En construccion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void addParametersNVariables(int scenario)
        {
            dgvVariables.Rows.Clear();
            List<string> fixedParameters = new List<string>();
            List<string> nonFixedParameters = new List<string>();

            if (scenario == 1)
            {
                //Adicion de parametros fijos en tabla
                fixedParameters = fixedValuesParametersScenario(1);

                foreach (string parameter in fixedParameters)
                {
                    this.dgvVariables.Rows.Add(parameter, null);
                }

                //Adicion de parametros variables en tabla
                nonFixedParameters = nonFixedValuesParametersScenario(1);

                foreach (string parameter in nonFixedParameters)
                {
                    this.dgvVariables.Rows.Add(parameter, null);
                }
            }
            else if (scenario == 2)
            {

            }
            else
            {

            }
        }

        public List<string> fixedValuesParametersScenario(int scenario)
        {
            List<string> values = new List<string>();
            if (scenario == 1)
            {
                values.Add("Hf");
                values.Add("Sf");
                values.Add("Kf");
                values.Add("Z");
            }
            else if (scenario == 2)
            {

            }
            else
            {

            }

            return values;
        }

        public List<string> nonFixedValuesParametersScenario(int scenario)
        {
            List<string> values = new List<string>();
            if (scenario == 1)
            {
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
            }
            else if (scenario == 2)
            {

            }
            else
            {

            }

            return values;
        }
    }
}
