using EFNet48_WithCodeFirstReverse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoDBClient
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void LoadKontinentFromEF()
        {
            Model1 dbContext = new Model1();
            bsContinents.DataSource =  dbContext.Continents.ToList();
            comboBox1.DataSource = bsContinents;
            comboBox1.DisplayMember = "Name";
            //comboBox1.ValueMember = "Continents.Name";
        }

        private void LoadCountries()
        {
            Continents currentContinents = (Continents)bsContinents.Current;




            bsCountries.DataSource = currentContinents.Countries.ToList();
            dataGridView1.DataSource = bsCountries;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddKontinentFrm addKontinentFrm = new AddKontinentFrm();
            addKontinentFrm.ShowDialog();

            LoadKontinentFromEF();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadKontinentFromEF();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadKontinentFromEF();
        }
    }
}
