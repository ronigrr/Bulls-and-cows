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
    public partial class SetAndStartDialog : Form
    {
        private int m_sizeOfGameBoard = 4;
        public int SizeOfGameBoard
        {
            get
            {
                return m_sizeOfGameBoard;
            }
        }

        public SetAndStartDialog()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object i_Sender, EventArgs i_E)
        {
            Hide();
        }

        private void BoardSizeBtn_Click(object i_Sender, EventArgs i_E)
        {
            if(m_sizeOfGameBoard == 10)
            {
                m_sizeOfGameBoard = 4;
            }
            else
            {
                m_sizeOfGameBoard++;
            }

            (i_Sender as Button).Text = string.Format("Board size is {0}", m_sizeOfGameBoard);
        }

        private void SetAndStartDialog_Load(object sender, EventArgs e)
        {
        }
    }
}