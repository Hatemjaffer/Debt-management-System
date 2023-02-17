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
    public partial class FRM_User_Login : DevExpress.XtraEditors.XtraForm
    {
        //Data Base and Tables
        DBDMMEntities db = new DBDMMEntities();
        TB_Users tbAdd = new TB_Users();// change name table
        public DMM.Pages.Page_Users page;   // change

       
        public FRM_User_Login()
        {
            InitializeComponent();
        }

        //Add Function
        private void Add()
        {
            //Check Empty value
            if ( edt_username.Text == "" || edt_password.Text == "" )
            {
                MessageBox.Show("بعض الحقول مطلوبة", "بعض الحقول مطلوبة",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                Login();
            }

        }

        //Add data
        private void Login()
        {
            Main main = new Main();
            try
            {
                db = new DBDMMEntities();
                tbAdd = db.TB_Users.Where(x => x.UserName == edt_username.Text && x.Password == edt_password.Text).FirstOrDefault();
                if(tbAdd != null)
                {
                      if (tbAdd.Role == "مستخدم")
                   {
                    main.btn_report.Visible = false;    //visible للاخفاء  enable وضحات لكن مخفيات
                    main.btn_settings.Visible = false;
                    main.btn_users.Visible = false;
                   }
                      //هنا مدير
                    main.txt_username.Caption = tbAdd.FullName;
                    main.txt_roll.Caption = tbAdd.Role;


                    main.Show();

                    Hide();

                }
               else
                {
                    MessageBox.Show("هنالك خظأ في معلومات تسجيل الدخول", "خظأ");
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FRM_User_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Add();
        }
    }
}