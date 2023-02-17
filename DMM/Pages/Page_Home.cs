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
using System.IO;

namespace DMM.Pages
{
    public partial class Page_Home : DevExpress.XtraEditors.XtraUserControl
    {
        MemoryStream ma;
        public Page_Home()
        {
            InitializeComponent();
        }

        //for date and time
        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_datetime.Text = DateTime.Now.ToString();
        }

        private void Set_Setting()
        {
            var comp_name = Properties.Settings.Default.CompanyName;
            var comp_desc = Properties.Settings.Default.CompanyDec;
            txt_companytitle.Text = comp_name;
            

            try  // يجب ان تضع كود الصورة دائما في تراي لتجنب الاخطاء ادا لم تضعها ستسبب في كراش للجهاز
            {
                var imagebyt = Convert.FromBase64String(Properties.Settings.Default.Logo);
                ma = new MemoryStream(imagebyt);
                pictureBox1.Image = Image.FromStream(ma);
            }
            catch { }

        }

        private void Page_Home_Load(object sender, EventArgs e)
        {
            Set_Setting();
        }
    }
}
