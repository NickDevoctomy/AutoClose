using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClose
{
    public partial class frmPrivacyShield : Form
    {

        #region private objects

        private Boolean cBlnAllowClose = false;

        #endregion

        #region constructor / destructor

        public frmPrivacyShield()
        {
            InitializeComponent();
        }

        #endregion

        #region base class events

        private void frmPrivacyShield_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = !cBlnAllowClose;
            }
        }

        #endregion

        #region object events

        private void butClose_Click(object sender, EventArgs e)
        {
            cBlnAllowClose = true;
            Close();
        }

        #endregion

        #region base class events

        private void frmPrivacyShield_SizeChanged(object sender, EventArgs e)
        {
            picImage.Location = new Point((Width / 2) - (picImage.Width / 2), (Height / 2) - (picImage.Height / 2));
        }

        #endregion


    }
}
