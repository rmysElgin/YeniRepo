using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormRepo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            NWDataContext db = new NWDataContext();

            var sorgu1 = from urun in db.Products
                         where urun.UnitPrice >= decimal.Parse(txtMin.Text) &&
                         urun.UnitPrice <= decimal.Parse(txtMax.Text)
                         select urun;


            var sorgu2 = db.Products.Where(u => u.UnitPrice >= decimal.Parse(txtMin.Text) && u.UnitPrice <= decimal.Parse(txtMax.Text))
                .Select(urun => new { urun.ProductName, urun.UnitPrice, urun.QuantityPerUnit }).OrderBy(u => u.ProductName);


            gvProducts.DataSource = sorgu2;
        }
    }
}
