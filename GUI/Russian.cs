using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATMLibrary;
using log4net;

namespace GUI
{
    public partial class Russian : Form
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static string FileName = @"C:\Users\NotePad.by\Desktop\Money.txt";

        public Russian()
        {
            InitializeComponent();
        }

        private void btInputSum_Click(object sender, EventArgs e)
        {
            try
            {

                log4net.Config.XmlConfigurator.Configure();

                CasseteLoader casseteLoader = new CasseteLoader();

                ATM atm = new ATM();

                atm.InsertCassete(casseteLoader.Read(FileName));

                ATMState state;

                string s = textBox1.Text;

                int sum = Convert.ToInt32(s);

                log.Info("Sum requered by the user: " + sum.ToString());

                Money money = new Money();

                money = atm.WithdrawnMoney(sum);

                state = atm.state;

                ResultRussian r = new ResultRussian(money);

                r.Show();
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Invalid input! Try again!");
            }
        }

        private void Russian_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();
        }

    }
}
