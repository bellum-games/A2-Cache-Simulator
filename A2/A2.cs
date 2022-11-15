using System.IO;

namespace A2
{
    public partial class A2 : Form
    {
        public A2()
        {
            InitializeComponent();
            HistoryPrevious();
        }

        private void btnSTART_Click(object sender, EventArgs e)
        {
            if (SafeStart() == false)
            {
                textBoxConsole.Text = "You haven't selected enough parameters for simulation to start";
                return;
            }

            SetFuture();
        }

        private bool SafeStart() 
        {
            bool status;
            if (
                comboIC.SelectedIndex > -1 &&
                comboDC.SelectedIndex > -1 &&
                comboSIZE_IC.SelectedIndex > -1 &&
                comboSIZE_DC.SelectedIndex > -1 &&
                comboIBS.SelectedIndex > -1 &&
                comboIRmax.SelectedIndex > -1 &&
                comboLatenta.SelectedIndex > -1 &&
                comboFR.SelectedIndex > -1 &&
                comboV.SelectedIndex > -1 &&
                comboD.SelectedIndex > -1
                )
                status = true;
            else
                status = false;

            return status;
        }

        private void SetFuture()
        {
            if (!File.Exists("history.txt"))
            {
                File.Create("history.txt");
            }
            using (StreamWriter sw = new StreamWriter("history.txt"))
            {
                sw.WriteLine($"comboIC {comboIC.SelectedIndex}");
                sw.WriteLine($"comboDC {comboDC.SelectedIndex}");
                sw.WriteLine($"comboSIZE_IC {comboSIZE_IC.SelectedIndex}");
                sw.WriteLine($"comboSIZE_DC {comboSIZE_DC.SelectedIndex}");
                sw.WriteLine($"comboIBS {comboIBS.SelectedIndex}");
                sw.WriteLine($"comboIRmax {comboIRmax.SelectedIndex}");
                sw.WriteLine($"comboLatenta {comboLatenta.SelectedIndex}");
                sw.WriteLine($"comboFR {comboFR.SelectedIndex}");
                sw.WriteLine($"comboV {comboV.SelectedIndex}");
                sw.WriteLine($"comboD {comboD.SelectedIndex}");
                sw.Close();
            }
        }

        private void HistoryPrevious() 
        {
            if (!File.Exists("history.txt"))
            {
                File.Create("history.txt");
            }
            else if (File.Exists("history.txt")) 
            {
                GetPrevious(File.ReadAllText("history.txt"));
            }
        }
        private void GetPrevious(string allText) 
        {
            string[] rows = allText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            foreach (string row in rows) 
            {
                string[] values = row.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int value = Int32.Parse(values[1]);
                switch(i) 
                {
                    case 0: comboIC.SelectedIndex = value; break;
                    case 1: comboDC.SelectedIndex = value; break;
                    case 2: comboSIZE_IC.SelectedIndex = value; break;
                    case 3: comboSIZE_DC.SelectedIndex = value; break;
                    case 4: comboIBS.SelectedIndex = value; break;
                    case 5: comboIRmax.SelectedIndex = value; break;
                    case 6: comboLatenta.SelectedIndex = value; break;
                    case 7: comboFR.SelectedIndex = value; break;
                    case 8: comboV.SelectedIndex = value; break;
                    case 9: comboD.SelectedIndex = value; break;
                }
                i++;
            }
        }
    }
}