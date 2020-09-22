using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.UI
{
    public partial class ColorTableDialog : Form
    {
        private char m_ChosenColor;

        public char ChosenColor
        {
            get
            {
                return m_ChosenColor;
            }
        }

        public ColorTableDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object i_Sender, EventArgs i_E)
        {
            m_ChosenColor = (i_Sender as Button).Name[0];
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            m_ChosenColor = 'o';
        }

        private void ColorTableDialog_Load(object sender, EventArgs e)
        {

        }
    }
}