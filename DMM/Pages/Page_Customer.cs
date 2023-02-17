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
    public partial class Page_Customer : DevExpress.XtraEditors.XtraUserControl
    {
        //Data Base and Tables
        DBDMMEntities db = new DBDMMEntities();
        TB_Customers tbAdd = new TB_Customers(); //Change table

        int id = 0; // للتعديل
        public Page_Customer()
        {
            InitializeComponent();
            LoadData();


            
        }

        //Load Data 
        //مدرنا شي درنا دلة حولنة فيها الكود الجهاز علي نضافة

        public void LoadData()
        {
            DMM.DBDMMEntities dbContext = new DMM.DBDMMEntities();
            
            dbContext.TB_Customers.LoadAsync().ContinueWith(loadTask => //Change name databse
            {
                gridControl1.DataSource = dbContext.TB_Customers.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // صار خظا بسيط مني صفحة Add_suppliers موجودة في pages رغم اني حولتها الا ان برنامج قاعد يقرا فيها موجودة في pages

            DMM.Pages.Add_Customer add = new Add_Customer();
            add.id = 0;
            add.btn_add.Text = "اضافة";
            add.btn_addclose.Text = " اغلاق + اضافة";
            add.page = this;
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
                    tbAdd = db.TB_Customers.Where(x => x.ID == id).FirstOrDefault();

                    DMM.Pages.Add_Customer add = new Add_Customer();// نفس كود الاضافة مع بعض تعديلات الخفيفة
                    add.id = id;
                    add.btn_add.Text = "تعديل";
                    add.btn_addclose.Text = " اغلاق + تعديل";
                    add.edt_name.Text = tbAdd.FullName;
                    add.edt_address.Text = tbAdd.Address;
                    add.edt_phone.Text = tbAdd.Phone;


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
                        tbAdd = db.TB_Customers.Where(x => x.ID == id).FirstOrDefault();

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

        private void btn_log_Click(object sender, EventArgs e)
        {
            //نفس كود التعديل
            try
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                if (id > 0)
                {
                    db = new DBDMMEntities();
                    tbAdd = db.TB_Customers.Where(x => x.ID == id).FirstOrDefault();
                    DMM.AddPage.Log_Customer add = new AddPage.Log_Customer();// نفس كود الاضافة مع بعض تعديلات الخفيفة

                    //نقوم بعمل set للبيانات لحني نبوها
                    add.txxxt_id.Text = id.ToString();
                    add.txt_name.Text = tbAdd.FullName.ToString();

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
    }
}
