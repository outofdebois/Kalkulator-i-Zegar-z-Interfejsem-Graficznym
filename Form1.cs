using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Projekt_1
{
    public partial class Form1 : Form
    {
        Timer zegar = new Timer();
        public Form1()
        {
            InitializeComponent();

            zegar.Interval = 1000;
            zegar.Tick += new EventHandler(this.tik_zegara);
            zegar.Start();
        }

        private bool CheckOperator(string text)
        {
            if (text.Length > 0)
            {
                char lastChar = text[text.Length - 1];
                return (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/');
            }
            return false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            textBox1.Text += button.Text.ToString();
        }


        private void Power_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double number))
            {
                double result = Math.Pow(number, 2);
                textBox1.Text = result.ToString();
            }
            else
            {
                textBox1.Text = "Błąd";
            }
        }

        private void Root_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double number))
            {
                if (number >= 0)
                {
                    double result = Math.Sqrt(number);
                    textBox1.Text = result.ToString();
                }
                else
                {
                    textBox1.Text = "Błąd";
                }
            }
            else
            {
                textBox1.Text = "Błąd";
            }
        }

        private void Coma_Click(object sender, EventArgs e)
        {
            string currentText = textBox1.Text;

            if (!currentText.EndsWith(",") && !CheckOperator(currentText))
            {
                textBox1.Text += ",";
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void Solve_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dataTable = new System.Data.DataTable())
                {
                    string expression = textBox1.Text.Replace(',', '.');
                    var result = dataTable.Compute(expression, null);
                    textBox1.Text = result.ToString();
                }
            }
            catch
            {
                textBox1.Text = "Błąd";
            }
        }

        private void tik_zegara(object sender, EventArgs e)
        {
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second;

            string czas = "";
            czas += hours + ":";
            if (minutes < 10)
            {
                czas += "0" + minutes;
            }
            else
            {
                czas += minutes;
            }
            czas += ":";
            if (seconds < 10)
            {
                czas += "0" + seconds;
            }
            else
            {
                czas += seconds;
            }
            Zegar.Text = czas;
        }

        private void Red_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void Green_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Zegar_Click(object sender, EventArgs e)
        {

        }

        private void White_button_Click(object sender, EventArgs e)
        {
            Zegar.ForeColor = Color.White;
        }

        private void Czcionka_Click(object sender, EventArgs e)
        {
            FontDialog czcionka = new FontDialog();
            if (czcionka.ShowDialog() == DialogResult.OK)
            {
                Zegar.Font = czcionka.Font;
            }
        }


        private void Black_Click(object sender, EventArgs e)
        {
            Zegar.ForeColor = Color.Black;
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            Zegar.ForeColor = Color.Yellow;
        }
    }
}
