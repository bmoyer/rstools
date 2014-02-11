using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Autoclicker
{
    public partial class Form1 : Form
    {
        Clicker c;
        public int x1 = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "Start")
            {
                button1.Text = "Stop";
                double clickInterval = Convert.ToDouble(clickerIntervalField.Text);
                c = new Clicker(clickInterval, fuzzingCheckbox.Checked, Convert.ToInt32(fuzzStrengthBox.Value));
                c.Start(sender, e);
            }

            else
            {
                c.Stop(sender, e);
                button1.Text = "Start";
            }
        }

        private void fuzzingCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!(fuzzingCheckbox.Checked)) {
                fuzzStrengthBox.Value = 0;
                fuzzStrengthBox.Visible = false; fuzzStrengthLabel.Visible = false; }
            else {
                fuzzStrengthBox.Value = 1;
                fuzzStrengthBox.Visible = true; fuzzStrengthLabel.Visible = true; }
        }

        public void changeTimeDisplay(int i)
        {
            timeDisplay.Text = Convert.ToString(i)+"ms";

        }

        private void timeDisplay_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
