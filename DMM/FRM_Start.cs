using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Linq;
using DMM.Pages;
using System.Threading.Tasks;
using System.Threading;

namespace DMM
{
    public partial class FRM_Start : SplashScreen
    {
        DBDMMEntities db;
        int state;
        public FRM_Start()
        {
            InitializeComponent();
            this.labelCopyright.Text = "جميع الحقوق المحفوظة © 2021-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private int Chack_StartApp()
        {
            try
            {
                db = new DBDMMEntities();
                var usernameid = db.TB_Users.Select(x => x.ID).FirstOrDefault();
                if(usernameid >= 1) // تأكد من وجود مستخدمين
                {
                    state = 1;
                }
                else
                {   
                    
                    state = 2;
                }
            }
            catch
            {
                state = 0;
            }

            return state;
        }

        private async void FRM_Start_Load(object sender, EventArgs e)
        {
            await Task.Run(() => Thread.Sleep( 2000 ));

            labelStatus.Text = ".......جاري الاتصال بقاعد البيانات";
            var st = await Task.Run(() => Chack_StartApp());
            if(st == 0)
            {
                MessageBox.Show("هنالك خظأ في الاتصال بالسيرفر");
                Application.Exit();
            }
            else if (st == 1)
            {
                //showLogin
                FRM_User_Login frm_user = new FRM_User_Login();
                frm_user.Show();
                this.Hide();


            }
            else //اول عملية تنصيب للبرنامج تضهر شاشة تسجيل ناغدة مستخدم جديد
            {
                // sing up
                Page_Users userpage = new Page_Users();
                DMM.Pages.Add_Users add = new DMM.Pages.Add_Users();
                add.id = 0;
                add.page = userpage;
                add.btn_add.Visible = false;
                add.btn_addclose.Text = " اعادة التشغيل + اضافة";
                add.Show();
            }
        }
    }
}