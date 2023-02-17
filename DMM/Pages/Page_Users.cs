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
using DMM.AddPage;

namespace DMM.Pages
{
    public partial class Page_Users : DevExpress.XtraEditors.XtraUserControl
    {
        //Data Base and Tables
        DBDMMEntities db = new DBDMMEntities();
        TB_Users tbAdd = new TB_Users(); //Change table

        int id = 0; // للتعديل
        public Page_Users()
        {
            InitializeComponent();
            LoadData();



          
        }

        //Load Data 
        //مدرنا شي درنا دلة حولنة فيها الكود الجهاز علي نضافة

        public void LoadData()
        {
            DMM.DBDMMEntities dbContext = new DMM.DBDMMEntities();
            
            dbContext.TB_Users.LoadAsync().ContinueWith(loadTask => //Change name databse
            {
                gridControl1.DataSource = dbContext.TB_Users.Local.ToBindingList(); // ......
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // صار خظا بسيط مني صفحة Add_suppliers موجودة في pages رغم اني حولتها الا ان برنامج قاعد يقرا فيها موجودة في pages

            DMM.Pages.Add_Users add = new DMM.Pages.Add_Users();
            add.id = 0;
            add.btn_add.Text = "اضافة";
            add.btn_addclose.Text = " اغلاق + اضافة";
            add.page = this;//........................لضمان التحديث التلقائي
            add.Show();


        }

        private void btn_edt_click_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                if(id > 0)
                {
                    db = new DBDMMEntities();
                    tbAdd = db.TB_Users.Where(x => x.ID == id).FirstOrDefault();

                    DMM.Pages.Add_Users add = new Add_Users();// نفس كود الاضافة مع بعض تعديلات الخفيفة
                    add.id = id;
                    add.btn_add.Text = "تعديل";               //لتغير اسم بوتن اتناء ضغظ علي تعديل
                    add.btn_addclose.Text = " اغلاق + تعديل";
                    add.Text = "تعديل بيانات مستخدم";
                    add.edt_name.Text = tbAdd.FullName;
                    add.edt_username.Text = tbAdd.UserName;
                    add.edt_password.Text = tbAdd.Password;

                   
                    add.page = this;
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
            if(rs == DialogResult.Yes)
            {
                // اولا تأخد الكود لعمالية التعديل
                try
                {
                    id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                    if (id > 0)
                    {
                        db = new DBDMMEntities();
                        tbAdd = db.TB_Users.Where(x => x.ID == id).FirstOrDefault();

                        db.Entry(tbAdd).State = EntityState.Deleted;
                        db.SaveChanges();

                        LoadData(); // لعمل تحديث تلقائي للبيانات
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

        private void btn_print_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview(); // هذا عرض للتقرير مغير شي
        }

        private void btn_pwoers_Click(object sender, EventArgs e)
        {
            AddPage.Add_user_pwoer addUserPwoer = new Add_user_pwoer();
            addUserPwoer.Show();
        }
    }
}
