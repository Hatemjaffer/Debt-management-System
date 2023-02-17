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
    public partial class Add_Users : DevExpress.XtraEditors.XtraForm
    {
        //Data Base and Tables
        DBDMMEntities db = new DBDMMEntities();
        TB_Users tbAdd = new TB_Users();// change name table

        public DMM.Pages.Page_Users page;   // change

        //متغيرات اخري
        public int id;      // بنستخدمها لتفريق بين عملية اضافة وتعديل
        public Add_Users()
        {
            InitializeComponent();
        }

        //Add Function
        private void Add()
        {
            //Check Empty value
            if (edt_name.Text == "" || edt_username.Text == "" || edt_password.Text == "" || edt_name.Text == "" || edt_role.SelectedItem==null )
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
                tbAdd = new TB_Users         // change name table
                {
                    FullName = edt_name.Text,    // ركز هنا فصلة عادية ونهاية ماغير فاصلة
                    Password = edt_password.Text,
                    UserName = edt_username.Text,     // ملاحظة لازم تعدل انك تخلي مستخدم يدخل ارقام فقط تقريبا عندب كود في صالة الرياضة
                    Role = edt_role.SelectedItem.ToString(),
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
                tbAdd = new TB_Users      //change name table
                {
                    ID=id,
                    FullName = edt_name.Text,    // ركز هنا فصلة عادية ونهاية ماغير فاصلة
                    Password = edt_password.Text,
                    UserName = edt_username.Text,     // ملاحظة لازم تعدل انك تخلي مستخدم يدخل ارقام فقط تقريبا عندب كود في صالة الرياضة
                    Role = edt_role.SelectedItem.ToString(),
                    DateT = DateTime.Now

                };
                //كود هذا في مستقبل يديرلك مشاكل
                //db.Entry(tbAdd).State = System.Data.Entity.EntityState.Modified;  
                //  وهذا الحل البديل ليها واحسن
                db.Set<TB_Users>().AddOrUpdate(tbAdd); //change name table

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
        // ذالة هاذي متع اضافة مستخدم جديد في حالة لم يوجد مستخدم في قاعد البيانات
        //Add and close void     
        private void btn_addclose_Click(object sender, EventArgs e)
        {
            if(btn_addclose.Text == "اعادة التشغيل + اضافة")
            {
                Add();
                Application.Restart();
            }
            else
            {
               
                Add();
                Close();

            }
           
        }

        //Clear Value 
        private void ClearData()
        {
            edt_password.Text = edt_name.Text = edt_username.Text = ""; //لتفريغ الحقول بعد عملية الاضافةوليس الضافة ثم الغلق
        }

        private void Add_Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (btn_addclose.Text == "اعادة التشغيل + اضافة")
            {
                Application.Exit();
            }
        }
    }
}