using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {

        English english = new English();
        Russian russian = new Russian();

        public MainForm()
        {
            InitializeComponent();
        }


        private void btEnglish_Click(object sender, EventArgs e)
        {
            english.Show();
        }

        private void btRussian_Click(object sender, EventArgs e)
        {
            russian.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
