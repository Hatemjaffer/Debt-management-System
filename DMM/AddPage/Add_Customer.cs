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
    public partial class Add_Customer : DevExpress.XtraEditors.XtraForm
    {
        //Data Base and Tables
        DBDMMEntities db = new DBDMMEntities();
        TB_Customers tbAdd = new TB_Customers();// change name table
        public DMM.Pages.Page_Customer page;   // change

        //متغيرات اخري
        public int id;      // بنستخدمها لتفريق بين عملية اضافة وتعديل
        public Add_Customer()
        {
            InitializeComponent();
        }

        //Add Function
        private void Add()
        {
            //Check Empty value
            if (edt_name.Text == "")
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
                page.LoadData();
            }

        }

        //Add data
        private void AddData()
        {
            try
            {
                db = new DBDMMEntities();
                tbAdd = new TB_Customers         // change name table
                {
                    FullName = edt_name.Text,    // ركز هنا فصلة عادية ونهاية ماغير فاصلة
                    Address = edt_address.Text,  
                    Phone = edt_phone.Text,     // ملاحظة لازم تعدل انك تخلي مستخدم يدخل ارقام فقط تقريبا عندب كود في صالة الرياضة
                    DateT = DateTime.Now
                                                 // ولازم تعلاج قصة طهور المؤشر في اول حقل حل مشكلة موجد في يوتيوب
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
        {                                // نفس كود الاضافة للدلة AddData()
            try
            {
                db = new DBDMMEntities();
                tbAdd = new TB_Customers      //change name table
                {
                    ID = id,
                    FullName = edt_name.Text,    
                    Address = edt_address.Text,
                    Phone = edt_phone.Text,     
                    DateT = DateTime.Now,
                    Debit = 0   // حت وقت تقوم بعملة التعديل وانت معدلتش في شي ترجع قيمة نفسها
                    
                  
                };
            //db.Entry(tbAdd).State = System.Data.Entity.EntityState.Modified;  كود هذا في متقبل يديرلك مشاكل
            //  وهذا الحل البديل ليها واحسن
            db.Set<TB_Customers>().AddOrUpdate(tbAdd); //change name table

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
            edt_address.Text = edt_name.Text = edt_phone.Text = ""; //لتفريغ الحقول بعد عملية الاضافة
        }
    }
}