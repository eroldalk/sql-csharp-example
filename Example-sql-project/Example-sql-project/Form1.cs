using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_sql_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'okulDataSet._Sayfa1_' table. You can move, or remove it, as needed.
            this.sayfa1_TableAdapter.Fill(this.okulDataSet._Sayfa1_);

        }
    }
}
