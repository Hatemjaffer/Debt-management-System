using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMM.Pages; //لازم ضيفها حت تسطيع الوصول لصفحة page الموجدة في مجلد page-1
using System.Threading.Tasks;
using DMM.Rrport;   
// بعني كانك ديرلها في انشلايز 
namespace DMM
{
    public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        
        public Main()
        {
            InitializeComponent();
            LoadHomePage();
        }

       
        //void for load home page
        private void btn_home_Click(object sender, EventArgs e)
        {
            LoadHomePage();
        }

        //load page
        private void LoadPage(DevExpress.XtraEditors.XtraUserControl Page)
        {
            try
            {
                pn_container.Controls.Clear();
                Page.Dock = DockStyle.Fill;
                pn_container.Controls.Add(Page);
            }
            catch
            {

            }

        }

           private void LoadHomePage()
        {
            Page_Home page = new Page_Home(); //2-تقدر توصل فيها 
            LoadPage(page);//3-تخد الدلة لدرتها يااسفل وتحطها فيها اوبجكت
        }

        private void btn_suppliers_Click(object sender, EventArgs e)
        {
            Page_Suppliers page = new Page_Suppliers(); //2-تقدر توصل فيها 
            LoadPage(page);
        }

        // فوتها اثناء برمجة الكود تاني او افهمها
        private async void Main_Activated(object sender, EventArgs e) 
            //هام جدا العزض من وضع async حت لاتعمل اي تجميد في البرنامج لانها هي تعمل في الخلفية
        {
            BL.UPDATE Update = new BL.UPDATE();
            //SupplierDataUpdate()
            await Task.Run(()=> Update.SupplierDataUpdate());


            //CustomerDataUpdate()
            await Task.Run(() => Update.CustomerDataUpdate());
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            Page_Customer page = new Page_Customer(); //2-تقدر توصل فيها 
            LoadPage(page);
        }

        //Report
        private void btn_report_Click(object sender, EventArgs e)
        {
            ReportPage page = new ReportPage  (); //2-تقدر توصل فيها 
            LoadPage(page);
        }

        //Analysis
        private void btn_analysis_Click(object sender, EventArgs e)
        {
            AnaylisisPage page = new AnaylisisPage(); //2-تقدر توصل فيها 
            LoadPage(page);
        }

        //Users
        private void btn_users_Click(object sender, EventArgs e)
        {
            Page_Users page = new Page_Users(); //2-تقدر توصل فيها 
            LoadPage(page);
        }

        // Setting
        private void btn_settings_Click(object sender, EventArgs e)
        {

            FRM_Setting page = new FRM_Setting(); // هذي الاعدادات ليس لها علاقة بالبرنامج انما تحفط داخل مجلد البرنامج
            page.ShowDialog();
        }
       
        //تسجل لخروج
        private void btn_logout_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRM_User_Login frm_user = new FRM_User_Login();
            frm_user.Show();
            this.Hide();

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //About 
        private void btn_about_Click(object sender, EventArgs e)
        {
            FRM_About frm_about = new FRM_About();
            frm_about.Show();
        }
    }
}
