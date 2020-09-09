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
    public partial class AddKontinentFrm : Form
    {
        public AddKontinentFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Model1 dbContext = new Model1())
            {
                Continents continent = new Continents();
                continent.Id = Guid.NewGuid();
                continent.Name = textBox1.Text;



                dbContext.Continents.Add(continent);
                dbContext.SaveChanges();

                this.Close();
            }
        }
    }
}
