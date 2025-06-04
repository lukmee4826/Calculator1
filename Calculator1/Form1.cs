using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculator1
{
    public partial class bracketopen : Form
    {
        public bracketopen()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void del_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Length > 0 ? textBox1.Text.Substring(0, textBox1.Text.Length - 1) : string.Empty;
        }

        private void plus_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void minus_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void multipile_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void divide_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void power_Click(object sender, EventArgs e)
        {
            textBox1.Text += "^2";
        }

        private void square_root_Click(object sender, EventArgs e)
        {
            textBox1.Text += "sqr";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void bracketoof_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void buttonopen_Click(object sender, EventArgs e)
        {
            textBox1.Text += "(";
        }

        private void equal_Click(object sender, EventArgs e)
        {
            calculate_Click(sender, e);
        }
        

        
        private void calculate_Click(object sender, EventArgs e)
        {
            // This method will handle the calculation logic
            // Now supports ^ operator as Math.Pow
            try
            {
                string input = textBox1.Text;

                // Replace ^ with Math.Pow
                input = ReplacePowersWithMathPow(input);

                var result = new DataTable().Compute(input, null);
                textBox1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in calculation: " + ex.Message);
            }
        }

        // Helper method to replace ^ with Math.Pow and evaluate Math.Pow(a,b) expressions before calculation
        private string ReplacePowersWithMathPow(string input)
        {
            // Find all occurrences of a^b and replace with Math.Pow(a,b)
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(
                @"(?<base>(?:\d+\.?\d*|\([^\(\)]+\)))\^(?<exp>(?:\d+\.?\d*|\([^\(\)]+\)))");

            while (regex.IsMatch(input))
            {
                input = regex.Replace(input, m =>
                {
                    string basePart = m.Groups["base"].Value;
                    string expPart = m.Groups["exp"].Value;
                    return $"Math.Pow({basePart},{expPart})";
                });
            }

            // Evaluate Math.Pow(a,b) expressions and replace with their result
            System.Text.RegularExpressions.Regex powRegex = new System.Text.RegularExpressions.Regex(
                @"Math\.Pow\((?<a>-?\d+\.?\d*),(?<b>-?\d+\.?\d*)\)");

            while (powRegex.IsMatch(input))
            {
                input = powRegex.Replace(input, m =>
                {
                    double a = double.Parse(m.Groups["a"].Value);
                    double b = double.Parse(m.Groups["b"].Value);
                    double result = Math.Pow(a, b);
                    return result.ToString();
                });
            }

            return input;
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

   

        
    }
}
