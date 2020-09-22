using System.Drawing;
using System.Windows.Forms;

namespace Ex05.UI
{
    public class GameButton : Button
    {
        private readonly int r_Row;
        private readonly int r_Column;
        private int m_ButtonAsciiCodeColor;
        public int Row
        {
            get
            {
                return r_Row;
            }
        }

        public int Column
        {
            get
            {
                return r_Column;
            }
        }

        public int ButtonAsciiCodeColor
        {
            get
            {
                return m_ButtonAsciiCodeColor;
            }
            set
            {
                m_ButtonAsciiCodeColor = value;
            }
        }

        public GameButton()
        {
            m_ButtonAsciiCodeColor = 0;
            BackColor = Color.Black;
        }

        public GameButton(int i_Row, int i_Column)
        {
            r_Row = i_Row;
            r_Column = i_Column;
            m_ButtonAsciiCodeColor = 0;
            BackColor = Color.Empty;
            updateAndChangeButton(m_ButtonAsciiCodeColor);
        }

        public void updateAndChangeButton(int i_ButtonAsciiColor)
        {
            switch(i_ButtonAsciiColor)
            {
                case 'A':
                    BackColor = Color.Aqua;
                    break;
                case 'B':
                    BackColor = Color.Blue;
                    break;
                case 'C':
                    BackColor = Color.Chartreuse;
                    break;
                case 'D':
                    BackColor = Color.DarkOrange;
                    break;
                case 'E':
                    BackColor = Color.Indigo;
                    break;
                case 'F':
                    BackColor = Color.Fuchsia;
                    break;
                case 'G':
                    BackColor = Color.Gold;
                    break;
                case 'H':
                    BackColor = Color.Red;
                    break;
                case 'X':
                    BackColor = Color.Yellow;
                    break;
                case 'V':
                    BackColor = Color.Black;
                    break;
                default:
                    BackColor = Color.Empty;
                    break;
            }

            m_ButtonAsciiCodeColor = i_ButtonAsciiColor;
        }
    }
}