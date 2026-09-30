using System.Windows.Forms;
using System;
using System.Linq;
using FinancialCrm.Models;


namespace FinancialCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void FrmBilling_Load_1(object sender, EventArgs e)
        {
            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillCreate_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            TblBills newBill = new TblBills();
            newBill.BillTitle = title;
            newBill.BillAmount = amount;
            newBill.BillPeriod = period;
            db.TblBills.Add(newBill);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı!");

            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillID.Text);
            db.TblBills.Remove(db.TblBills.Find(id));
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı!");

            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;  
        }

        private void btnBillUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillID.Text);
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            db.TblBills.Find(id).BillTitle = title;
            db.TblBills.Find(id).BillAmount = amount;
            db.TblBills.Find(id).BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarılı!");

            var values = db.TblBills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void btnBillingForm_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
