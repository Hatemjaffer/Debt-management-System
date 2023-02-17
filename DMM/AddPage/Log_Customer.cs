using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading;

namespace DMM.AddPage
{
    public partial class Log_Customer : DevExpress.XtraEditors.XtraForm
    {
        //Data Base and Tables
        DBDMMEntities db = new DBDMMEntities();
        Debit_Oustomer tbAdd = new Debit_Oustomer(); // change table name
        PaymentCustomer tbpayment;                  //------------------

        //other varaibles
        int id;
        int SupplierID;
        String PaymentValue;

        double Payment;
        double Debit;
        double PaymentRs;


        public Log_Customer()
        {
            InitializeComponent();
        }

        //نقوم بعمل get علية اسنادة بشكل مباشر

        // Load Debit Data
        public void LoadDebitData()
        {
            try
            {
                id = Convert.ToInt32(txxxt_id.Text);
                db = new DBDMMEntities();
                gridControl1.DataSource = db.Debit_Oustomer.Where(x => x.ID_Supplier == id).ToList();
            }
            catch//(Exception e)
            {
                //MessageBox.Show(e.Message);
            }

        }

        //Load Payments
        private void LoadPaymentsData()
        {
            try
            {
                id = Convert.ToInt32(txxxt_id.Text);
                db = new DBDMMEntities();
                gridControl2.DataSource = db.PaymentCustomers.Where(x => x.ID_Supplier == id).ToList();// Cahange db....
            }
            catch//(Exception e)
            {
                //MessageBox.Show(e.Message);
            }

        }

        private void Log_Supplier_Load(object sender, EventArgs e)
        {
            LoadDebitData();
            LoadPaymentsData();
        }
        // Add Debit Data Event
        private void btn_add_debit_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(txxxt_id.Text); //new  هدي لتجيب id لتحته الاسم 
            var supplierName = txt_name.Text; //new
            DMM.Pages.Add_Debit_Customer add = new Pages.Add_Debit_Customer();// Change Add_Debit...
            add.id = 0;
            add.btn_add.Text = "اضافة";
            add.btn_addclose.Text = " اغلاق + اضافة";
            add.page = this;
            add.SupplierID = id; //new
            add.SupplierName = supplierName;//new
            add.Show();
        }
        //Edit Dbit Data Event
        private void btn_edt_debit_Click(object sender, EventArgs e) //دائما تعديل زي كود الاظافة مع بعض التعديلات
        {
            try
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                if (id > 0)
                {
                    db = new DBDMMEntities();
                    var supplireid = Convert.ToInt32(txxxt_id.Text); //
                    var supplierName = txt_name.Text; //new
                    DMM.Pages.Add_Debit_Customer add = new Pages.Add_Debit_Customer(); // change
                    add.id = id;//new id
                    add.btn_add.Text = "تعديل";
                    add.btn_addclose.Text = " اغلاق + تعديل";
                    add.page = this;
                    add.SupplierID = supplireid; //new supplierid
                    add.SupplierName = supplierName;//new
                    add.edt_name.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("FullName")); //new
                    add.edt_Debit.Text = Convert.ToString(gridView1.GetFocusedRowCellValue("Debit"));   //new

                    add.Show();
                }
                else
                {
                    MessageBox.Show("لا يوجد بيانات لتعديلها");//لما يكون عندك الحقل فارغ
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("هل انت متأكد من هذا الاجراء , لايمكن استرجاع البيانات", "اجراء حدف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                // اولا تأخد الكود لعمالية التعديل
                try
                {
                    id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                    if (id > 0)
                    {
                        db = new DBDMMEntities();
                        tbAdd = db.Debit_Oustomer.Where(x => x.ID == id).FirstOrDefault();// change table name

                        db.Entry(tbAdd).State = EntityState.Deleted;
                        db.SaveChanges();
                        // change funcation name
                        LoadDebitData(); //   اثنتاء الاضافة , لعمل تحديث تلقائي للبيانات
                        DebitPaymentCal(); // لعمل ثحديث اثناء عملية الحدف

                    }
                    else
                    {
                        MessageBox.Show("لا يوجد بيانات لحدفها");//لما يكون عندك الحقل فارغ
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // Debit Data Print Event
        private void btn_print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
        // Add Payment Data Event
        private void btn_paymentAdd_Click(object sender, EventArgs e)
        {
            PaymentValue = XtraInputBox.Show("اكتب المبلغ المراد دفعة", "اضافة دفعة", "0");// هذي وضفتها  وقت تضغط علي اضافة طلع زي مسج بوكس 
            //شرح للدالة اف ادا كانت لا تساوي صفر لا تقم باعملية الاضافة وادا كانت لم تكن فارغةلا تقوم باعملية اضافة
            if (PaymentValue != "0" && PaymentValue != "")
            {
                //Make Payment نعمل دفعة

                AddPayment();
                LoadPaymentsData();
                MessageBox.Show("تم عمل الدفعة بانجاح");


            }
            else
            {
                MessageBox.Show("اكتب المبلغ المراد دفعة اولا");
            }
        }

        private void AddPayment()
        {
            try
            {
                SupplierID = Convert.ToInt32(txxxt_id.Text); //new from btn Add
                var supplierName = txt_name.Text; //new
                db = new DBDMMEntities();
                var tbpaymant = new PaymentCustomer{       // مغير فاصلة // change next new ....
                

                    Payment = Convert.ToDouble(PaymentValue), //change
                    Supplier_Name = supplierName,
                    ID_Supplier = SupplierID,
                    DateT = DateTime.Now          // ولازم تعلاج قصة طهور المؤشر في اول حقل حل مشكلة موجد في يوتيوب
                };

                db.Entry(tbpaymant).State = System.Data.Entity.EntityState.Added;// تم تغير مابين الاقواس فقط
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                // مسج هذا يخدم لما دخل قيمة فاضية
                MessageBox.Show(ex.Message);
                //MessageBox.Show("الرجاء دخال القيمة المطلوبة","تنبية",MessageBoxButtons.OK,MessageBoxIcon.Stop);

            }
        }
        //Edit Payment Event
        private void btn_paymentedt_Click(object sender, EventArgs e)
        {
            String CurrValue = Convert.ToString(gridView2.GetFocusedRowCellValue("Payment"));

            // نفس كود الاضافة مع بعض التعديلات
            PaymentValue = XtraInputBox.Show("اكتب المبلغ المراد دفعة", "اضافة دفعة", CurrValue);// هذي وضفتها  وقت تضغط علي اضافة طلع زي مسج بوكس 
            //شرح للدالة اف ادا كانت لا تساوي صفر لا تقم باعملية الاضافة وادا كانت لم تكن فارغةلا تقوم باعملية اضافة
            if (PaymentValue != "0" && PaymentValue != "")
            {
                //Edit Payment نعمل دفعة

                EditPayment();
                LoadPaymentsData();
                MessageBox.Show("تم عمل الدفعة بانجاح");


            }
            else
            {
                MessageBox.Show("اكتب المبلغ المراد دفعة اولا");
            }
        }
        private void EditPayment()
        {
            try
            {
                id = Convert.ToInt32(gridView2.GetFocusedRowCellValue("ID"));
                if (id > 0)
                {
                    SupplierID = Convert.ToInt32(txxxt_id.Text); //new from btn Add

                    var supplierName = txt_name.Text; //new
                    db = new DBDMMEntities();
                    var tbpaymant = new PaymentCustomer       // مغير فاصلة
                    {
                        ID = id,
                        Payment = Convert.ToDouble(PaymentValue), //change
                        Supplier_Name = supplierName,
                        ID_Supplier = SupplierID,
                        DateT = DateTime.Now          // ولازم تعلاج قصة طهور المؤشر في اول حقل حل مشكلة موجد في يوتيوب
                    };




                    //  db.Entry(tbpaymant).State = System.Data.Entity.EntityState.Modified;// تم تغير مابين الاقواس فقط
                    //or
                    db.Set<PaymentCustomer>().AddOrUpdate(tbpaymant); //change <...>
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("لا يوجد بيانات لتعديلها");


                }

            }

            catch (Exception ex)
            {
                // مسج هذا يخدم لما دخل قيمة فاضية
                MessageBox.Show(ex.Message);
                //MessageBox.Show("الرجاء دخال القيمة المطلوبة","تنبية",MessageBoxButtons.OK,MessageBoxIcon.Stop);

            }
        }

        private void btn_payment_Delelet_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("هل انت متأكد من هذا الاجراء , لايمكن استرجاع البيانات", "اجراء حدف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                // اولا تأخد الكود لعمالية التعديل
                try
                {
                    id = Convert.ToInt32(gridView2.GetFocusedRowCellValue("ID"));//change
                    if (id > 0)
                    {
                        db = new DBDMMEntities();
                        tbpayment = db.PaymentCustomers.Where(x => x.ID == id).FirstOrDefault();// change table name

                        db.Entry(tbpayment).State = EntityState.Deleted;// change()
                        db.SaveChanges();
                        // change funcation name
                        LoadPaymentsData(); // لعمل تحديث تلقائي للبيانات change
                        DebitPaymentCal(); // لعمل ثحديث اثناء عملية الحدف

                    }
                    else
                    {
                        MessageBox.Show("لا يوجد بيانات لحدفها");//لما يكون عندك الحقل فارغ
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // Print Payment Event
        private void btn_payment_print_Click(object sender, EventArgs e)
        {
            gridControl2.ShowPrintPreview();
        }

        //Cal debit and payment
        private void DebitPaymentCal()
        {
            try
            {
                id= Convert.ToInt32(txxxt_id.Text);
                db = new DBDMMEntities();
                //Get Debit
                Debit =(double) db.Debit_Oustomer.Where(x => x.ID_Supplier == id).Select(x => x.Debit).ToArray().Sum();
                Payment = (double)db.PaymentCustomers.Where(x => x.ID_Supplier == id).Select(x => x.Payment).ToArray().Sum();
                PaymentRs = Debit - Payment;

                //set Data
                txt_debit.Text = "الديون :" + Debit.ToString();
                txt_payment.Text = "المدفوع :" + Payment.ToString();
                txt_paymentrs.Text = "المتبقي : " + PaymentRs.ToString(); 

            }
            catch (Exception e)
            {

            }
        } 

        private void Log_Supplier_Activated(object sender, EventArgs e) 
        {
            DebitPaymentCal(); 
        }
             
        private async void btn_logclear_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("هل انت متأكد من هذا الاجراء , لايمكن استرجاع البيانات", "اجراء حدف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                // Loading .....
                this.Text = "الرجاء الانتطار قليلا بينما يتم تنظيف السجل";
                Thread.Sleep(2000);
                //Clear Data
                this.Text = "تنظيف سجل الديون ....";

                //Clear Debit Data
                await Task.Run(() => LogDebitClearData());

                //Clear Payment
                this.Text = "تنظيف  الدفعات ....";
                //Clear Payment Data
                await Task.Run(() => LogPaymentClearData());
                MessageBox.Show("تم تنظيف السجل بنجاح");

                this.Text = "سجل العملاء";   //change ""
                LoadPaymentsData();
                LoadDebitData();

            }
           
        }
        //Clear Debit Data
        private void LogDebitClearData()
        {   
            try
            {
                id = Convert.ToInt32(txxxt_id.Text);
                db = new DBDMMEntities();
                var Debit_List = db.Debit_Oustomer.Select(x => x.ID).ToArray();

                for(int i=0 ;  i<Debit_List.Length; i++)
                {
                    tbAdd = db.Debit_Oustomer.Where(x => x.ID_Supplier == id).FirstOrDefault();
                    db.Entry(tbAdd).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch
            {

            }
        }


        //Clear Payment Data
        private void LogPaymentClearData()
        {
            try
            {
                id = Convert.ToInt32(txt_id.Text);
                db = new DBDMMEntities();
                var Debit_List = db.PaymentCustomers.Select(x => x.ID).ToArray();//change

                for (int i = 0; i < Debit_List.Length; i++)
                {
                    tbpayment = db.PaymentCustomers.Where(x => x.ID_Supplier == id).FirstOrDefault();//change
                    db.Entry(tbpayment).State = EntityState.Deleted;//change
                    db.SaveChanges();
                }
            }
            catch
            {

            }
        }
    }
}