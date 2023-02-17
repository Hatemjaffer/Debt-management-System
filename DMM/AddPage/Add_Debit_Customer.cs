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
using System.Data.Entity.Migrations;

namespace DMM.Pages
{
    public partial class Add_Debit_Customer : DevExpress.XtraEditors.XtraForm
    {
        //Data Base and Tables
        DBDMMEntities db;
        Debit_Oustomer tbAdd;                //change
        public DMM.AddPage.Log_Customer page;//change

        //متغيرات اخري
        public int id;      // بنستخدمها لتفريق بين عملية اضافة وتعديل
        public int SupplierID;
        public String SupplierName;
        public Add_Debit_Customer()
        {
            InitializeComponent();
        }

        //Add Function
        private void Add()
        {
            //Check Empty value
            if (edt_name.Text == "" || edt_Debit.Text=="")
            {
                MessageBox.Show("بعض الحقول مطلوبة", "بعض الحقول مطلوبة",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                //Check Add or Edit

                if (id == 0)
                {
                    //Add
                    AddData();
                    ClearData(); 
                }
                else
                {
                    //Edit
                    EditData();
                }
                 
                //Update Data
                page.LoadDebitData();
            }

        }

        //Add data
        private void AddData()
        {
            try
            {
                db = new DBDMMEntities();
                tbAdd = new Debit_Oustomer{       // مغير فاصلة
                
                    FullName = edt_name.Text,    // ركز هنا فصلة عادية ونهاية ماغير فاصلة
                    Debit = Convert.ToDouble(edt_Debit.Text),
                    Supplier_Name=SupplierName,
                    ID_Supplier=SupplierID,
                    DateT = DateTime.Now          // ولازم تعلاج قصة طهور المؤشر في اول حقل حل مشكلة موجد في يوتيوب
                 };
                                                
                db.Entry(tbAdd).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                MessageBox.Show("تمت الاضافة بنجاح","اضافة"); // منضومة الرياضة فيها مسج نضيف او بدير توست صناعي زي لدرنه في منضومة السابقة   

                toastNotificationsManager1.ShowNotification("c7f22432-08e3-48e1-98ad-4dfc65f4b589"); //هدي تطلع في win 10,11 فقط
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Edit data
        private void EditData()
        {                                        // نفس كود الاضافة للدلة AddData()
            try
            {
                db = new DBDMMEntities();
                tbAdd = new Debit_Oustomer  
                {
                    ID = id,
                    FullName = edt_name.Text,    // ركز هنا فصلة عادية ونهاية ماغير فاصلة
                    Debit = Convert.ToDouble(edt_Debit.Text),
                    Supplier_Name = SupplierName,
                    ID_Supplier = SupplierID,
                    DateT = DateTime.Now

                };
            //db.Entry(tbAdd).State = System.Data.Entity.EntityState.Modified;  كود هذا في متقبل يديرلك مشاكل
            //  وهذا الحل البديل ليها واحسن
            db.Set<Debit_Oustomer>().AddOrUpdate(tbAdd);//change

                db.SaveChanges();
                MessageBox.Show("تمت التعديل بنجاح", "تعديل"); // منضومة الرياضة فيها مسج نضيف او بدير توست صناعي زي لدرنه في منضومة السابقة   

                toastNotificationsManager1.ShowNotification("d8d4e151-8d70-4771-9fbe-cba92ef89029"); //هدي تطلع في win 10,11 فقط
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Add void
        private void btn_add_Click(object sender, EventArgs e)
        {
            Add();
            //عملية تنضيف الحقول عند الاضافة وليس تعديل نحتاج ان نخصصها
             
        }

        //Add and close void
        private void btn_addclose_Click(object sender, EventArgs e)
        {
            Add();
            Close();
        }

        //Clear Value 
        private void ClearData()
        {
             edt_name.Text = edt_Debit.Text = ""; //لتفريغ الحقول بعد عملية الاضافة
        }
    }
}