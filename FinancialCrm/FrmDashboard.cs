using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        int count = 0;

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.TblBankAccounts.Sum(x => x.BankBalance);
            lblTotalBankBalance.Text = totalBalance.ToString() + " TL";

            var process = db.TblBankProcesses.Select(x => new { x.ProcessType, x.ProcessAmount, x.ProcessDescription, x.ProcessDate });

            var lastProcessBalance = process.OrderByDescending(x => x.ProcessDate).Select(x => x.ProcessAmount).Take(1).FirstOrDefault();
            lblSonGelenHavaleBalance.Text = lastProcessBalance.ToString() + " TL";

            var lastProcessTitle = process.OrderByDescending(x => x.ProcessDate).Select(x => x.ProcessDescription).Take(1).FirstOrDefault();
            var lastProcessType = process.OrderByDescending(x => x.ProcessDate).Select(x => x.ProcessType).Take(1).FirstOrDefault();

            lblSonGelenHavaleTitle.Text = lastProcessTitle + " - " + lastProcessType;

            //chart1 kodları 

            var bankdata = db.TblBankAccounts.Select(x => new { x.BankTitle, x.BankBalance }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Banka Paraları");
            foreach (var item in bankdata)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            //chart2 kodları
            var billdata = db.TblBills.Select(x => new { x.BillTitle, x.BillAmount }).ToList();
            chart2.Series.Clear();
            var series1 = chart2.Series.Add("Faturalar");
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in billdata)
            {
                series1.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }

        private void btnBillingForm_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var bill = db.TblBills.Select(x => new { x.BillTitle, x.BillAmount });
            var billTitle = bill.Select(x => x.BillTitle).ToList();
            var billAmount = bill.Select(x => x.BillAmount).ToList();

            var title1 = billTitle.Take(1).FirstOrDefault();
            var title2 = billTitle.Take(2).Skip(1).FirstOrDefault();
            var title3 = billTitle.Take(3).Skip(2).FirstOrDefault();
            var title4 = billTitle.Take(4).Skip(3).FirstOrDefault();

            var amount1 = billAmount.Take(1).FirstOrDefault();
            var amount2 = billAmount.Take(2).Skip(1).FirstOrDefault();
            var amount3 = billAmount.Take(3).Skip(2).FirstOrDefault();
            var amount4 = billAmount.Take(4).Skip(3).FirstOrDefault();

            count++;
            if (count % 4 == 0)
            {
                lblBillTitle.Text = title1;
                lblBillAmount.Text = amount1.ToString() + " TL";
            }
            if (count % 4 == 1)
            {
                lblBillTitle.Text = title2;
                lblBillAmount.Text = amount2.ToString() + " TL";
            }
            if (count % 4 == 2)
            {
                lblBillTitle.Text = title3;
                lblBillAmount.Text = amount3.ToString() + " TL";
            }
            if (count % 4 == 3)
            {
                lblBillTitle.Text = title4;
                lblBillAmount.Text = amount4.ToString() + " TL";
            }
        }
    }
}
