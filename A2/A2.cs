using System.IO;

namespace A2
{
    /*
     FR = 0;
     */
    public partial class A2 : Form
    {
        public A2()
        {
            InitializeComponent();
            HistoryPrevious();
        }

        private void A2_Load(object sender, EventArgs e)
        {

        }

        private void btnSTART_Click(object sender, EventArgs e)
        {

        }

        private void HistoryPrevious() 
        {
            if (!File.Exists("history.txt"))
            {
                File.Create("history.txt");
            }
            else if (File.Exists("history.txt")) 
            {
                string allText = File.ReadAllText("history.txt");
                SetPrevious(allText);
            }
        }
        private void SetPrevious(string allText) 
        {
            string[] splitedValues = allText.Split(" ");
        }
    }
}