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
using System.Data.Entity;

namespace DMM.Pages
{
    public partial class AnaylisisPage : DevExpress.XtraEditors.XtraUserControl
    {
        DBDMMEntities db;


        public AnaylisisPage()
        {
            InitializeComponent();

            SupplierGetData();
            CustomerGetData();
            TotalGetData();

            //هدي وقت تربط شكل البياني ينزل الكود بروحة

            
            DMM.DBDMMEntities dbContext = new DMM.DBDMMEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.Debit_Oustomer.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    chartControl1.DataSource = dbContext.Debit_Oustomer.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }
        // جلب ديون العملاء
        private void SupplierGetData()
        {
            try
            {
                db = new DBDMMEntities();
                var data = db.TB_Suppliers.Select(x => x.Debit).ToArray().Sum();
                txt_supplier.Text = data.ToString();

            }
            catch { }
        }
        // جلب ديون العملاء
        private void CustomerGetData()
        {
            try
            {
                db = new DBDMMEntities();
                var data = db.TB_Customers.Select(x => x.Debit).ToArray().Sum();
                txt_customer.Text = data.ToString();

            }
            catch { }
        }
        //جمع ديون الموردين + العملاء
        private void TotalGetData()
        {
            try
            {
                db = new DBDMMEntities();
                var data1 = db.TB_Suppliers.Select(x => x.Debit).ToArray().Sum();
                var data2 = db.TB_Customers.Select(x => x.Debit).ToArray().Sum();

                txt_tototaldebit.Text = (data1 + data2).ToString();

            }
            catch { }
        }

    }
}
