using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class chartActivity : UserControl
    {
        public chartActivity()
        {
            InitializeComponent();
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chartActivity_Resize(object sender, EventArgs e)
        {
            comboBoxTime.Left = (int)((this.ClientSize.Width - comboBoxTime.Width) * 0.1);
            comboBoxTime.Top = (int)((this.ClientSize.Height - comboBoxTime.Height) / 2);

            chartActivity1.Left = (int)(comboBoxTime.Left + comboBoxTime.Width*1.5);
            chartActivity1.Top = (int)(labelActivity.Top + labelActivity.Height * 1.5);
            chartActivity1.Height = (int)(this.ClientSize.Height * 0.5);
            chartActivity1.Width = (int)(this.ClientSize.Width * 0.5);
        }
    }
}
