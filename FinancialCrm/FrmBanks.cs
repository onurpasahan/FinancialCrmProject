using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void FrmBanks_Load(object sender, EventArgs e)
        {
            //Banka Bakiyeleri
            var ziraatBankBalance = db.TblBankAccounts.Where(x => x.BankTitle == "Ziraat bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakıfBankBalance = db.TblBankAccounts.Where(x => x.BankTitle == "Vakıfbank").Select(y => y.BankBalance).FirstOrDefault();
            var işBankBalance = db.TblBankAccounts.Where(x => x.BankTitle == "İŞ bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblZiraatBankasıBalance.Text = ziraatBankBalance.ToString() + " TL";
            lblVakıfbankBalance.Text = vakıfBankBalance.ToString() + " TL";
            lblİşBankasıBalance.Text = işBankBalance.ToString() + " TL";

            //Banka Hareketleri
            var bankProcess1 = db.TblBankProcesses.OrderByDescending(x => x.ProcessID).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcess1.ProcessType + " - " + bankProcess1.ProcessDescription + " - " + bankProcess1.ProcessAmount + " - " + bankProcess1.ProcessDate + " TL";

            var bankProcess2 = db.TblBankProcesses.OrderByDescending(x => x.ProcessID).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.ProcessType + " - " + bankProcess2.ProcessDescription + " - " + bankProcess2.ProcessAmount + " - " + bankProcess2.ProcessDate + " TL";

            var bankProcess3 = db.TblBankProcesses.OrderByDescending(x => x.ProcessID).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.ProcessType + " - " + bankProcess3.ProcessDescription + " - " + bankProcess3.ProcessAmount + " - " + bankProcess3.ProcessDate + " TL";

            var bankProcess4 = db.TblBankProcesses.OrderByDescending(x => x.ProcessID).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.ProcessType + " - " + bankProcess4.ProcessDescription + " - " + bankProcess4.ProcessAmount + " - " + bankProcess4.ProcessDate + " TL";

            var bankProcess5 = db.TblBankProcesses.OrderByDescending(x => x.ProcessID).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.ProcessType + " - " + bankProcess5.ProcessDescription + " - " + bankProcess5.ProcessAmount + " - " + bankProcess5.ProcessDate + " TL";
        }

        private void btnBillingForm_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
