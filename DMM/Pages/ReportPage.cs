using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace DMM.Rrport
{
    public partial class ReportPage : DevExpress.XtraEditors.XtraUserControl
    {
        public ReportPage()
        {
            InitializeComponent();
        }

        private void btn_supplierreport_Click(object sender, EventArgs e)
        {
            DMM.Rrport.SupplierReport report = new Rrport.SupplierReport();
            ReportPrintTool report_print = new ReportPrintTool(report);   //  لازم تكتبReportPrintTool وتستدعي المكتبة
            report_print.ShowPreview();
        }

        private void btn_customerreport_Click(object sender, EventArgs e)
        {
            DMM.Rrport.CustomerReport report = new Rrport.CustomerReport();
            ReportPrintTool report_print = new ReportPrintTool(report);   //  لازم تكتبReportPrintTool وتستدعي المكتبة
            report_print.ShowPreview();
        }
    }
}
