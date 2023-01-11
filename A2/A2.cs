using System.Collections.Generic;
using System.IO;

namespace A2
{
    public partial class A2 : Form
    {
        private Dictionary<string, List<Tuple<char, uint, uint>>> allTraceData = new Dictionary<string, List<Tuple<char, uint, uint>>>();
        private int latenta, NR_PORT, FR, IRmax, IBS, N_PEN, NR_REG, FR_IC, SIZE_IC, FR_DC, SIZE_DC; //Parameters for simulation
        private int MissRateIC, MissRateDC, PercentageIBS_Empty, Influence_IRmax, OptimalREG_Number; //This should be outputed in results.csv maybe? Cosmin any ideas?

        //date out:
        //rata de procesare (nr instr raportat la nr cicli de executie)
        //rata miss in IC si in DC (2 x rate de miss)
        //procent din timpul total cat buffer de prefetch (IBS) e gol
        //se vrea parametri optimi si factori de limitare in fiecare din cazuri

        //A2:
        //det. influenta nr max de instr ce pot fi trimise in exe asupra ratei de procesare (IRmax)(2.1)
        //(set limitat de reg) care e numarul optim de registri? :(2.2)
        //->varianta uniport cache date (DC): o singura instr cu ref la mem se poate executa
        //->varianta biport cache date (DC): 2 instr cu ref la mem se pot executa L + L sau L + S
        //Pt valoarea optima de la 2.2 a nr de reg. studiati rata de procesare (IRmax) pe cache date(DC) uni sau biport

        public A2()
        {
            InitializeComponent();
            IOneeded();
            SetComboFromHistory();
        }

        private void btnSTART_Click(object sender, EventArgs e)
        {
            if (!SafeStart())
            {
                textBoxConsole.Text = "You haven't selected enough parameters for simulation to start";
                return;
            }
            SetEnviroment();
            if (!ValidParameters()) 
            {
                textBoxConsole.Text = "Selected paramenters can't be used at simulation, try other combination.";
                return;
            }
            SetComboForFuture();
            ReadTraces();
            Simulate();
            WriteResults();
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IOneeded()
        {
            if (!File.Exists(@"..\..\..\output\history.txt"))
            {
                File.Create(@"..\..\..\output\history.txt");
            }
            if (!File.Exists(@"..\..\..\output\results.csv"))
            {
                File.Create(@"..\..\..\output\results.csv");
            }
        }

        private bool ValidParameters()
        {
            if(FR_IC != FR || FR_DC != FR)
                return false;
            if (IRmax > FR)
                return false;
            if (SIZE_IC > IBS || SIZE_DC > IBS)
                return false;
            if (NR_REG > IRmax)
                return false;
            return true;
        }

        private bool SafeStart()
        {
            if (
                latentaUpDown.Value >= 0 &&
                (uniportRadio.Checked == true || biportRadio.Checked == true) &&
                comboFR.SelectedIndex > -1 &&
                comboIRmax.SelectedIndex > -1 &&
                comboIBS.SelectedIndex > -1 &&
                comboN_PEN.SelectedIndex > -1 &&
                comboNR_REG.SelectedIndex > -1 &&

                comboFR_IC.SelectedIndex > -1 &&
                comboSIZE_IC.SelectedIndex > -1 &&
                comboFR_DC.SelectedIndex > -1 &&
                comboSIZE_DC.SelectedIndex > -1
            )
                return true;
            else
                return false;
        }

        private void SetEnviroment() 
        {
            latenta = (int)latentaUpDown.Value;
            if (uniportRadio.Checked == true && biportRadio.Checked == false)
                NR_PORT = 1;
            else if (uniportRadio.Checked == false && biportRadio.Checked == true)
                NR_PORT = 2;
            FR = int.Parse((string)comboFR.SelectedItem);
            IRmax = int.Parse((string)comboIRmax.SelectedItem);
            IBS = int.Parse((string)comboIBS.SelectedItem);
            N_PEN = int.Parse((string)comboN_PEN.SelectedItem);
            NR_REG = int.Parse((string)comboNR_REG.SelectedItem);
            FR_IC = int.Parse((string)comboFR_IC.SelectedItem);
            SIZE_IC = int.Parse((string)comboSIZE_IC.SelectedItem);
            FR_DC = int.Parse((string)comboFR_DC.SelectedItem);
            SIZE_DC = int.Parse((string)comboSIZE_DC.SelectedItem);
        }

        private void SetComboForFuture()
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\..\output\history.txt"))
            {
                sw.WriteLine($"latentaUpDown {latentaUpDown.Value}");
                if(uniportRadio.Checked == true && biportRadio.Checked == false)
                    sw.WriteLine($"uniportRadio_biportRadio {1}");
                else if(uniportRadio.Checked == false && biportRadio.Checked == true)
                    sw.WriteLine($"uniportRadio_biportRadio {2}");

                sw.WriteLine($"comboFR {comboFR.SelectedIndex}");
                sw.WriteLine($"comboIRmax {comboIRmax.SelectedIndex}");
                sw.WriteLine($"comboIBS {comboIBS.SelectedIndex}");
                sw.WriteLine($"comboN_PEN {comboN_PEN.SelectedIndex}");
                sw.WriteLine($"comboNR_REG {comboNR_REG.SelectedIndex}");

                sw.WriteLine($"comboFR_IC {comboFR_IC.SelectedIndex}");
                sw.WriteLine($"comboSIZE_IC {comboSIZE_IC.SelectedIndex}");
                sw.WriteLine($"comboFR_DC {comboFR_DC.SelectedIndex}");
                sw.WriteLine($"comboSIZE_DC {comboSIZE_DC.SelectedIndex}");
                sw.Close();
            }
        }

        private void SetComboFromHistory() 
        {
            string allText = File.ReadAllText(@"..\..\..\output\history.txt");
            if (!allText.Equals(string.Empty)) 
            {
                string[] rows = allText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                int i = 0;
                foreach (string row in rows)
                {
                    string[] values = row.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int value = int.Parse(values[1]);
                    switch (i)
                    {
                        case 0: latentaUpDown.Value = value; break;
                        case 1:
                            if(value == 1) 
                            {
                                uniportRadio.Checked = true;
                                biportRadio.Checked = false;
                            }
                            else if(value == 2) 
                            {
                                uniportRadio.Checked = false;
                                biportRadio.Checked = true;
                            }
                            break;
                        case 2: comboFR.SelectedIndex = value; break;
                        case 3: comboIRmax.SelectedIndex = value; break;
                        case 4: comboIBS.SelectedIndex = value; break;
                        case 5: comboN_PEN.SelectedIndex = value; break;
                        case 6: comboNR_REG.SelectedIndex = value; break;

                        case 7: comboFR_IC.SelectedIndex = value; break;
                        case 8: comboSIZE_IC.SelectedIndex = value; break;
                        case 9: comboFR_DC.SelectedIndex = value; break;
                        case 10: comboSIZE_DC.SelectedIndex = value; break;
                    }
                    i++;
                }
            }
        }

        private void ReadTrace(FileInfo file)
        {
            List<Tuple<char, uint, uint>> traceData = new List<Tuple<char, uint, uint>>();
            string allText = File.ReadAllText(file.FullName);
            allText = allText.Replace("\n", "");
            string[] rows = allText.Split(Environment.NewLine);
            foreach(string row in rows) 
            {
                string[] bits = row.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < bits.Length; i += 3)
                {
                    char instruction = bits[i][0];
                    uint addressOne = uint.Parse(bits[i + 1]);
                    uint addressTwo = uint.Parse(bits[i + 2]);
                    traceData.Add(new Tuple<char, uint, uint>(instruction, addressOne, addressTwo));
                }
            }
            allTraceData.Add(file.Name, traceData);
        }

        private void ReadTraces()
        {
            DirectoryInfo directory = new DirectoryInfo(@"..\..\..\traces\"); //get all traces inside traces folder in current project
            FileInfo[] files = directory.GetFiles("*.TRC");
            foreach (FileInfo file in files)
            {
                ReadTrace(file); //Read one trace
            }
        }

        private void Simulate()
        {
            /*
            string s = string.Empty;
            foreach (var item in allTraceData) 
            {
                s += item.Key.ToString() + " " + item.Value.Count.ToString() + Environment.NewLine;
            }
            textBoxConsole.Text = s;
            */
            textBox1.Text = "Finnish";
        }

        private void WriteResults()
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\..\output\results.csv"))
            {
                /*
                sw.WriteLine(",,,,");
                sw.WriteLine(",,,,");
                sw.WriteLine(",,Data,Result");
                sw.WriteLine($",,Miss Rate in IC,{MissRateIC}");
                sw.WriteLine($",,Miss Rate in DC,{MissRateDC}");
                sw.WriteLine($",,Percentage of prefetch buffer that is empty,{PercentageIBS_Empty}");
                sw.WriteLine($",,Influence of IRmax on performance,{Influence_IRmax}");
                sw.WriteLine($",,Optimal number of registers,{OptimalREG_Number}");
                */
                sw.Close();
            }
        }
    }
}