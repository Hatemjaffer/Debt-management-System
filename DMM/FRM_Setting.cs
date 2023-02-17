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
using System.IO;

namespace DMM
{
    
    public partial class FRM_Setting : DevExpress.XtraEditors.XtraForm
    {
        MemoryStream ma;
        private DBDMMEntities db;
        public FRM_Setting()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save_Setting();
        }
        // وظيفة الذالة ارجاع الاعدادات الافتراضية
        private void Set_Setting()
        {
            var comp_name = Properties.Settings.Default.CompanyName;
            var comp_desc = Properties.Settings.Default.CompanyDec;
            txt_name.Text = comp_name;
            txt_desc.Text = comp_desc;

            try  // يجب ان تضع كود الصورة دائما في تراي لتجنب الاخطاء ادا لم تضعها ستسبب في كراش للجهاز
            {
                var imagebyt =Convert.FromBase64String ( Properties.Settings.Default.Logo);
                ma = new MemoryStream(imagebyt);
                pic_logo.Image = Image.FromStream(ma);
            }
            catch { }

        }

        private void Save_Setting()
        {
            Properties.Settings.Default.CompanyName = txt_name.Text;
            Properties.Settings.Default.CompanyDec = txt_desc.Text;
            try
            {
                ma = new MemoryStream();
                pic_logo.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Png);
                Properties.Settings.Default.Logo = Convert.ToBase64String(ma.ToArray());
            }
            catch { }
            Properties.Settings.Default.Save();
            MessageBox.Show("تم الحفط الاعدادات بانجاح");
        }

        private void FRM_Setting_Load(object sender, EventArgs e)
        {
            Set_Setting();
        }
        //تمت اضافة async
        // ملاحظة يتم نسخ الاحطياطي في الفلاش او اي قرص خارخ السي
        private async void btn_backup_Click(object sender, EventArgs e)
        {
           try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                var rs = folder.ShowDialog();
                if(rs == DialogResult.OK)
                {
                    pn_progress.Visible = true;

                    var result = await Task.Run(() => BackUp(folder)); //Time
                    if(result ==true)
                    {
                        MessageBox.Show("تم النسخ الاحطياطي بنجاح");
                        pn_progress.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("خظأ, لا يمكن النسخ الاحطياطي الا المسار المحدد , الرجاء تحديد مسار المختلف , تذكر لا تحدد القرص C");
                        pn_progress.Visible = false;
                        
                    }
                }
            }
            catch
            {
                MessageBox.Show("خظأ , لا يمكن النسخ الاحطياطي الا المسار المحدد , الرجاء تحديد مسار المختلف , تذكر لا تحدد القرص C");
                pn_progress.Visible = false;
            }
        }
        //Backup
        private bool BackUp(FolderBrowserDialog folder)
        {
            try
            {
                db = new DBDMMEntities();
                    
                String dbname = db.Database.Connection.Database;
                String dbBackup = "DMMback" + DateTime.Now.ToString("yyyyMMddHHmm");//اسم مبدئي للباك اب     وتاريخ وقت 
                var fullpath = folder.SelectedPath.ToString() + dbBackup + ".bak";
                String sqlcommand = @"BACKUP DATABASE [{0}] TO DISK = '" + fullpath + "'WITH NOFORMAT , NOINIT , NAME = N'DBMDD' , SKIP , NOREWIND , NOUNLOAD , STATS = 10";
                int path = db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, String.Format(sqlcommand, dbname, dbBackup));
                return true;
            }
            catch
            {
                return false; //لما يكون عندك خظأ
            }
        }
        //Restore
        private async void btn_restore_Click(object sender, EventArgs e) //نفس كود backup  تغير في بعض اشياء
        {
            try
            {
                OpenFileDialog folder = new OpenFileDialog();//......
                var rs = folder.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    pn_progress.Visible = true;

                    var result = await Task.Run(() => Restore(folder));//....
                    if (result == true)
                    {
                        
                        pn_progress.Visible = false;
                        MessageBox.Show("تم اعادة النسخ الاحطياظي بنجاح");
                    }
                    else
                    {
                        pn_progress.Visible = false;
                        MessageBox.Show("  خظأ ,استعادة النسخة الاحطياطية , قم بتجربة تشغيل البرنامج كا مسؤول جتي تتمكن من اتمام العملية");
                        

                    }
                }
            }
            catch(Exception ex)
            {
                pn_progress.Visible = false;
                MessageBox.Show("خظأ,استعادة النسخة الاحطياطية , قم بتجربة تشغيل البرنامج كا مسؤول جتي تتمكن من اتمام العملية"+ ex);
               
            }
        }

        private bool Restore(OpenFileDialog folder)
        {
            try
            {
                db = new DBDMMEntities();
                String dbname = db.Database.Connection.Database;
                
                String sqlcommand = @"Use master;Restore DATABASE [{0}] From DISK = '" +folder.FileName + "'";
                int path = db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, String.Format(sqlcommand, dbname));//int path لانها بترجع يا  0 , 1
                return true;
            }
            catch
            {
                return false; // لما يكون عندك خظأ يرجعلك 
            }
        }
    }
}