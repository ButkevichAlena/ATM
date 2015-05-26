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

namespace GUI
{
    public partial class ResultEnglish : Form
    {
        Money _money =  new Money();

        public ResultEnglish(Money money)
        {
            InitializeComponent();
            _money = money;            
        }

        private void ResultEnglish_Load(object sender, EventArgs e)
        {
            Converter converter = new Converter();
            BindingSource _bindingSource = new BindingSource();
            dataGridView1.DataSource = _bindingSource;
            _bindingSource.DataSource = converter.Convert(_money);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns[0].HeaderText = "Banknote";
            dataGridView1.Columns[1].HeaderText = "Number";

        }
    }
}
