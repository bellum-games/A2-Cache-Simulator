using System.IO;

namespace A2
{
    public partial class A2 : Form
    {
        private int IC, DC, SIZE_IC, SIZE_DC, IBS, IRmax, N_PEN, FR, V, D, NR_REG, NR_PORT;

        private int MissRateIC, MissRateDC, PercentageIBS_Empty, Influence_IRmax, OptimalREG_Number;

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
            IOneeded();
            InitializeComponent();
            PreviousHistory();
        }

        private void IOneeded()
        {
            if (!File.Exists("history.txt"))
            {
                File.Create("history.txt");
            }
            if (!File.Exists("results.csv"))
            {
                File.Create("results.csv");
            }
        }

        private void btnSTART_Click(object sender, EventArgs e)
        {
            if (!SafeStart())
            {
                textBoxConsole.Text = "You haven't selected enough parameters for simulation to start";
                return;
            }
            SIZE_IC = int.Parse((string)comboSIZE_IC.SelectedItem);
            SIZE_DC = int.Parse((string)comboSIZE_DC.SelectedItem);
            IRmax = int.Parse((string)comboIRmax.SelectedItem);
            IBS = int.Parse((string)comboIBS.SelectedItem);
            FR = int.Parse((string)comboFR.SelectedItem);
            N_PEN = int.Parse((string)comboN_PEN.SelectedItem);
            NR_REG = int.Parse((string)comboNR_REG.SelectedItem);
            NR_PORT = int.Parse((string)comboNR_PORT.SelectedItem);
            if (!ValidParameters()) 
            {
                textBoxConsole.Text = "Selected paramenters can't be used at simulation, try other combination.";
                return;
            }
            SetFuture();
            Simulate();
            WriteResults();
        }

        private void Simulate() //Simulate(int IC, int DC, int SIZE_IC, int SIZE_DC, int IBS, int IRmax, int N_PEN, int FR, int V, int D) 
        {
            //Cosmin tasks
        }

        private bool ValidParameters() 
        {
            if (IRmax > FR)
                return false;
            if (IC > IBS || DC > IBS)
                return false;
            if (NR_REG > IRmax)
                return false;
            return true;
        }

        private bool SafeStart() 
        {
            bool status;
            if (
                comboSIZE_IC.SelectedIndex > -1 && 
                comboSIZE_DC.SelectedIndex > -1 &&
                comboIRmax.SelectedIndex > -1 && 
                comboIBS.SelectedIndex > -1 &&
                comboFR.SelectedIndex > -1 &&
                comboN_PEN.SelectedIndex > -1 &&
                comboNR_REG.SelectedIndex > -1 &&
                comboNR_PORT.SelectedIndex > -1)
                status = true;
            else
                status = false;
            return status;
        }

        private void WriteResults()
        {
            using (StreamWriter sw = new StreamWriter("results.csv"))
            {
                MissRateIC = 0;
                MissRateDC = 0; 
                PercentageIBS_Empty = 0;
                Influence_IRmax = 0; 
                OptimalREG_Number = 0;

                sw.WriteLine(",,,,");
                sw.WriteLine(",,,,");
                sw.WriteLine(",,Data,Result");
                sw.WriteLine($",,Miss Rate in IC,{MissRateIC}");
                sw.WriteLine($",,Miss Rate in DC,{MissRateDC}");
                sw.WriteLine($",,Percentage of prefetch buffer that is empty,{PercentageIBS_Empty}");
                sw.WriteLine($",,Influence of IRmax on performance,{Influence_IRmax}");
                sw.WriteLine($",,Optimal number of registers,{OptimalREG_Number}");
                sw.Close();
            }
        }

        private void SetFuture()
        {
            using (StreamWriter sw = new StreamWriter("history.txt"))
            {
                //sw.WriteLine($"comboIC {comboIC.SelectedIndex}");
                //sw.WriteLine($"comboDC {comboDC.SelectedIndex}");
                sw.WriteLine($"comboSIZE_IC {comboSIZE_IC.SelectedIndex}");
                sw.WriteLine($"comboSIZE_DC {comboSIZE_DC.SelectedIndex}");
                sw.WriteLine($"comboIRmax {comboIRmax.SelectedIndex}");
                sw.WriteLine($"comboIBS {comboIBS.SelectedIndex}");
                sw.WriteLine($"comboFR {comboFR.SelectedIndex}");
                //sw.WriteLine($"comboV {comboV.SelectedIndex}");
                //sw.WriteLine($"comboD {comboD.SelectedIndex}");
                sw.WriteLine($"comboN_PEN {comboN_PEN.SelectedIndex}");
                sw.WriteLine($"comboNR_REG {comboNR_REG.SelectedIndex}");
                sw.WriteLine($"comboNR_PORT {comboNR_PORT.SelectedIndex}");
                sw.Close();
            }
        }

        private void PreviousHistory() 
        {
            string allText = File.ReadAllText("history.txt");
            if (!allText.Equals(string.Empty))
                GetPrevious(allText);
        }
        private void GetPrevious(string allText) 
        {
            string[] rows = allText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            foreach (string row in rows) 
            {
                string[] values = row.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int value = int.Parse(values[1]);
                switch(i)
                {
                    //case 0: comboIC.SelectedIndex = value; break;
                    //case 1: comboDC.SelectedIndex = value; break;
                    case 2: comboSIZE_IC.SelectedIndex = value; break;
                    case 3: comboSIZE_DC.SelectedIndex = value; break;
                    case 4: comboIRmax.SelectedIndex = value; break;
                    case 5: comboIBS.SelectedIndex = value; break;
                    case 6: comboFR.SelectedIndex = value; break;
                    //case 7: comboV.SelectedIndex = value; break;
                    //case 8: comboD.SelectedIndex = value; break;
                    case 9: comboN_PEN.SelectedIndex = value; break;
                    case 10: comboNR_REG.SelectedIndex = value; break;
                    case 11: comboNR_PORT.SelectedIndex = value; break;
                }
                i++;
            }
        }
    }
}