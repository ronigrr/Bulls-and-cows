using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.GameLogic;


namespace Ex05.UI
{
    public partial class MainGameForm : Form
    {
        private int m_NumOfTries;
        private Button[] m_ArrowButtons;
        private Button[] m_ResultButtons;
        private ColorTableDialog m_ColorTableDialog = new ColorTableDialog();
        private GameLogic.GameLogic m_GameLogic = new GameLogic.GameLogic();
        private SetAndStartDialog m_SetAndStartDialog = new SetAndStartDialog();
        private bool m_IsSetAndStartWasClosed = false;
        private char[] m_PlayerCurrentGuess = new[] { '0', '0', '0', '0' };
        private GameButton[,] m_BoardOfGameButtons;
        private const int k_GameBoardWidth = 8;
        private const int k_ResultButtonsSpaceSize = 92;
        private const int k_SingleLineSpaceSize = 52;

        public MainGameForm()
        {
            m_SetAndStartDialog.FormClosing += m_SetAndStartDialog_FormClosing;
            m_SetAndStartDialog.ShowDialog();
            m_NumOfTries = m_SetAndStartDialog.SizeOfGameBoard;
            m_BoardOfGameButtons = new GameButton [m_NumOfTries, k_GameBoardWidth];
            m_ArrowButtons = new Button[m_NumOfTries];
            m_ResultButtons = new Button[k_GameBoardWidth / 2];
            createBoard();
            playGame();
        }

        private void playGame()
        {
            m_GameLogic.GenerateTargetString();
            InitializeComponent();
            setBoardHeight(m_NumOfTries);
        }

        private void setBoardHeight(int i_NumOfTries)
        {
            (this as Form).Height = k_ResultButtonsSpaceSize + (m_NumOfTries * k_SingleLineSpaceSize);
        }

        private void createBoard()
        {
            const int k_Ystart = 10; //Margin left
            const int k_BigSize = 40;
            const int k_SmallSize = 18;
            const int k_BetweenButtonSpace = 5;
            const int k_BetweenRowSpace = 5;
            const int k_SpacialAxisSpace = 22;
            int axisX = 10;
            int axisY = 10;
            int savedAxisX = 0;
            int savedAxisY = 0;

            for(int i = 1; i <= k_GameBoardWidth / 2; i++)
            {
                m_ResultButtons[i - 1] = new GameButton();
                m_ResultButtons[i - 1].Width = k_BigSize;
                m_ResultButtons[i - 1].Height = k_BigSize;
                m_ResultButtons[i - 1].Enabled = false;
                m_ResultButtons[i - 1].Location = new Point(axisX, axisY);
                Controls.Add(m_ResultButtons[i - 1]);
                axisX += k_BigSize + k_BetweenButtonSpace;
                if(i == k_GameBoardWidth / 2)
                {
                    axisY += k_BigSize + k_BetweenButtonSpace + 10;
                }
            }

            for(int i = 1; i <= m_NumOfTries; i++)
            {
                axisX = k_Ystart;
                for(int j = 1; j <= k_GameBoardWidth; j++)
                {
                    if(j < 5)
                    {
                        m_BoardOfGameButtons[i - 1, j - 1] = new GameButton(i, j);
                        if(i != 1)
                        {
                            m_BoardOfGameButtons[i - 1, j - 1].Enabled = false;
                        }

                        m_BoardOfGameButtons[i - 1, j - 1].Width = k_BigSize;
                        m_BoardOfGameButtons[i - 1, j - 1].Height = k_BigSize;
                        m_BoardOfGameButtons[i - 1, j - 1].BackColor = Color.Empty;
                        m_BoardOfGameButtons[i - 1, j - 1].Location = new Point(axisX, axisY);
                        m_BoardOfGameButtons[i - 1, j - 1].Click += new EventHandler(this.GameButton_Click);
                        Controls.Add(m_BoardOfGameButtons[i - 1, j - 1]);
                        axisX += k_BigSize + k_BetweenButtonSpace;
                    }
                    else
                    {
                        if(j == 5)
                        {
                            m_ArrowButtons[i - 1] = new Button();
                            m_ArrowButtons[i - 1].Tag = i - 1;
                            m_ArrowButtons[i - 1].Width = 45;
                            m_ArrowButtons[i - 1].Height = 20;
                            m_ArrowButtons[i - 1].Text = "-->>";
                            m_ArrowButtons[i - 1].Location = new Point(axisX, axisY + 10);
                            m_ArrowButtons[i - 1].Click += new EventHandler(this.GameArrowButton_Click);
                            m_ArrowButtons[i - 1].Enabled = false;
                            Controls.Add(m_ArrowButtons[i - 1]);
                            axisX += k_BigSize + k_BetweenButtonSpace + 5;
                            savedAxisX = axisX;
                            savedAxisY = axisY;
                        }

                        if(j == 5 || j == 6)
                        {
                            m_BoardOfGameButtons[i - 1, j - 1] = new GameButton(i, j);
                            m_BoardOfGameButtons[i - 1, j - 1].Width = k_SmallSize;
                            m_BoardOfGameButtons[i - 1, j - 1].Height = k_SmallSize;
                            m_BoardOfGameButtons[i - 1, j - 1].Location = new Point(axisX, axisY);
                            Controls.Add(m_BoardOfGameButtons[i - 1, j - 1]);
                            axisX += k_SmallSize + k_BetweenButtonSpace;
                            if(j == 6)
                            {
                                axisX = savedAxisX;
                                axisY = savedAxisY + k_SpacialAxisSpace;
                            }
                        }

                        if(j == 7 || j == 8)
                        {
                            m_BoardOfGameButtons[i - 1, j - 1] = new GameButton(i, j);
                            m_BoardOfGameButtons[i - 1, j - 1].Width = k_SmallSize;
                            m_BoardOfGameButtons[i - 1, j - 1].Height = k_SmallSize;
                            m_BoardOfGameButtons[i - 1, j - 1].Location = new Point(axisX, axisY);
                            Controls.Add(m_BoardOfGameButtons[i - 1, j - 1]);
                            axisX += k_SmallSize + k_BetweenButtonSpace;
                        }

                        m_BoardOfGameButtons[i - 1, j - 1].Enabled = false;
                    }
                }

                axisY += k_SmallSize + k_BetweenButtonSpace + k_BetweenRowSpace;
            }
        }

        private void GameArrowButton_Click(object i_Sender, EventArgs i_E)
        {
            int currentRow = (int)(i_Sender as Button).Tag;
            (i_Sender as Button).Enabled = false;
            int numOfCorrectAnswers;
            int numOfIncorrectAnswers;
            bool isWin = m_GameLogic.CheckIsWin(
                new string(m_PlayerCurrentGuess),
                out numOfCorrectAnswers,
                out numOfIncorrectAnswers);

            if(currentRow+1 < m_NumOfTries)
            {
                if(isWin)
                {
                    revealCorrectAnswer();
                    paintFeedbackButtons(0, 4, currentRow);
                    disableSingleRow(currentRow);
                }
                else
                {
                    paintFeedbackButtons(numOfIncorrectAnswers, numOfCorrectAnswers, currentRow);
                    for(int i = 0; i < k_GameBoardWidth / 2; i++)
                    {
                        m_BoardOfGameButtons[currentRow+1, i].Enabled = true;
                        m_BoardOfGameButtons[currentRow, i].Enabled = false;
                    }
                }
            }
            else
            {
                if(isWin)
                {
                    paintFeedbackButtons(0, 4, currentRow);
                }
                else
                {
                    paintFeedbackButtons(numOfIncorrectAnswers, numOfCorrectAnswers, currentRow);
                }
                revealCorrectAnswer();
                disableSingleRow(currentRow);
            }

            resetPlayerGuess();
        }

        private void disableSingleRow(int i_Row)
        {
            for(int i = 0; i < k_GameBoardWidth / 2; i++)
            {
                m_BoardOfGameButtons[i_Row, i].Enabled = false;
            }
        }

        private void paintFeedbackButtons(int i_NumOfIncorrectAnswers, int i_NumOfCorrectAnswers, int i_Row)
        {
            int colIndex = 4;
            while(i_NumOfCorrectAnswers > 0)
            {
                m_BoardOfGameButtons[i_Row, colIndex++].updateAndChangeButton('V');
                i_NumOfCorrectAnswers--;
            } 

            while(i_NumOfIncorrectAnswers > 0)
            {
                m_BoardOfGameButtons[i_Row, colIndex++].updateAndChangeButton('X');
                i_NumOfIncorrectAnswers--;
            }
        }

        private void resetPlayerGuess()
        {
            for(int i = 0; i < m_PlayerCurrentGuess.Length; i++)
            {
                m_PlayerCurrentGuess[i] = '0';
            }
        }

        private void revealCorrectAnswer()
        {
            int index = 0;
            foreach(GameButton resultButton in m_ResultButtons)
            {
                resultButton.updateAndChangeButton(m_GameLogic.TargetAsciiCodes[index++]);
            }
        }

        private void GameButton_Click(object i_Sender, EventArgs i_E)
        {
            m_ColorTableDialog.ShowDialog();
            GameButton clickdGameButton = (i_Sender as GameButton);
            char currentChosenColor = m_ColorTableDialog.ChosenColor;
            if(!m_PlayerCurrentGuess.Contains(currentChosenColor))
            {
                m_PlayerCurrentGuess[clickdGameButton.Column - 1] = currentChosenColor;
                clickdGameButton.updateAndChangeButton(currentChosenColor);
            }
            
            if(checkIfAllFourGussesAreFull(clickdGameButton.Row - 1))
            {
                m_ArrowButtons[clickdGameButton.Row - 1].Enabled = true;
            }
            else
            {
                m_ArrowButtons[clickdGameButton.Row - 1].Enabled = false;
            }
        }

        private bool checkIfAllFourGussesAreFull(int i_Row)
        {
            bool isAllFourGussesAreFull = true;

            for(int i = 0; i <= 3; i++)
            {
                if(m_BoardOfGameButtons[i_Row, i].BackColor.Name.Equals("Control"))
                {
                    isAllFourGussesAreFull = false;
                }
            }

            return isAllFourGussesAreFull;
        }

        private void m_SetAndStartDialog_FormClosing(object i_Sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                m_IsSetAndStartWasClosed = true;
            }
        }

        public void BeginGame()
        {
            if(!m_IsSetAndStartWasClosed)
            {
                ShowDialog();
            }
        }

        private void MainGameForm_Load(object sender, EventArgs e)
        {

        }
    }
}