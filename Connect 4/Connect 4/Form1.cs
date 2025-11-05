using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics.PerformanceData;
using System;

namespace Connect_4
{
    public partial class Game_Display : Form
    { 
        private String projectRoot;
        private Image RedCounter;
        private Image YellowCounter;

        private PictureBox[,] displayPos = new PictureBox[7, 6];
        private int turn;

        private PictureBox counter = new PictureBox();
        private int counterPos;

        private bool AI;

        public Game_Display(bool playWithAI)
        {
            InitializeComponent();

            projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
            RedCounter = Image.FromFile(Path.Combine(projectRoot, "Images", "CounterRed.png"));
            YellowCounter = Image.FromFile(Path.Combine(projectRoot, "Images", "CounterYellow.png"));

            turn = 0;
            
            counterPos = 0;

            createGameArray();
            
            playPlayerTurn(counter, turn);

            AI = playWithAI;
        }
        private void Game_Display_Load(object sender, EventArgs e)
        {
            this.Text = "Connect 4";
            this.ClientSize = new Size(710, 710);
            this.BackColor = Color.Blue;
        }
        private void createGameArray()
        {
            int rows = 7;
            int cols = 6;
            int size = 90;
            int spacing = 10;
            int startX = 10;
            int startY = 110;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    PictureBox tempPB = new PictureBox();
                    tempPB.Height = size;
                    tempPB.Width = size;
                    tempPB.BackColor = Color.White;
                    tempPB.BorderStyle = BorderStyle.FixedSingle;

                    tempPB.Left = startX + (row * (size + spacing));
                    tempPB.Top = startY + (col * (size + spacing));

                    displayPos[row, col] = tempPB;

                    this.Controls.Add(tempPB);
                }
            }
        }
        private void playPlayerTurn(PictureBox counter, int turn)
        {
            int size = 90;
            int locationX = (counterPos * 100) + 10;
            int locationY = 10;

            counter.Image = (turn % 2 == 0) ? RedCounter : YellowCounter;
            counter.Height = size;
            counter.Width = size;
            counter.BackColor = Color.White;
            counter.BorderStyle = BorderStyle.FixedSingle;

            counter.Left = locationX;
            counter.Top = locationY;

            this.Controls.Add(counter);
        }
        private void playAITurn()
        {
            int temp = counterPos;



            //counterPos = ?;






            counter.Image = (turn % 2 == 0) ? RedCounter : YellowCounter;

            if (displayPos[counterPos, 0].Image == null)
            {
                int index = 0;
                while (displayPos[counterPos, index].Image == null)
                {
                    displayPos[counterPos, index].Image = counter.Image;
                    if (index > 0)
                    {
                        displayPos[counterPos, index - 1].Image = null;
                    }
                    if (index != 5)
                    {
                        index++;
                    }
                }

                counterPos = temp;

                if (winDetect(displayPos, turn))
                {
                    Application.Exit();
                }
                else
                {
                    turn++;
                    playPlayerTurn(counter, turn);
                }
            }
        }
        private bool winDetect(PictureBox[,] displayPos, int turn)
        {
            int rows = 7;
            int cols = 6;
            int drawCount = 0;
            bool win = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (displayPos[row, col].Image != null)
                    {
                        drawCount++;
                    }
                    if (displayPos[row, col].Image != null)
                    {
                        if (col <= cols - 4)
                        {
                            win = true;
                            for (int index = 1; index < 4; index++)
                            {
                                if (displayPos[row, col].Image != displayPos[row, col + index].Image)
                                {
                                    win = false;
                                    break;
                                }
                            }
                            if (win)
                            {
                                MessageBox.Show(((turn % 2 == 0) ? "Red" : "Yellow") + " wins!");
                                return true;
                            }
                        }
                    if (row <= rows -4)
                    {
                        win = true;
                        for (int index = 1; index < 4; index++)
                        {
                            if (displayPos[row, col].Image != displayPos[row + index, col].Image)
                            {
                                win = false;
                                break;
                            }
                        }
                        if (win)
                        {
                            MessageBox.Show(((turn % 2 == 0) ? "Red" : "Yellow") + " wins!");
                            return true;
                        }
                    }
                    if (row <= rows -4  && col <= cols - 4)
                    {
                        win = true;
                        for (int index = 1; index < 4; index++)
                        {
                            if (displayPos[row, col].Image != displayPos[row + index, col + index].Image)
                            {
                                win = false;
                                break;
                            }
                        }
                        if (win)
                        {
                            MessageBox.Show(((turn % 2 == 0) ? "Red" : "Yellow") + " wins!");
                            return true;
                        }
                    }
                        if (row >= rows - 3 && col <= cols - 4)
                        {
                            win = true;
                            for (int index = 1; index < 4; index++)
                            {

                                if (displayPos[row, col].Image != displayPos[row - index, col + index].Image)
                                {
                                    win = false;
                                    break;
                                }
                            }
                            if (win)
                            {
                                MessageBox.Show(((turn % 2 == 0) ? "Red" : "Yellow") + " wins!");
                                return true;
                            }
                        }
                    }
                }
            }
            if (drawCount == 42)
            {
                MessageBox.Show("Draw!");
                return true;
            }

            return false;
        }
        private void Game_Display_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && counterPos >  0)
            {
                counter.Left -= 100;
                counterPos--;
            }
            if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && counterPos < 6)
            {
                counter.Left += 100;
                counterPos++;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (displayPos[counterPos, 0].Image == null)
                {
                    int index = 0;
                    while (displayPos[counterPos, index].Image == null)
                    {
                        displayPos[counterPos, index].Image = counter.Image;
                        if (index > 0)
                        {
                            displayPos[counterPos, index - 1].Image = null;
                        }
                        if (index != 5)
                        {
                            index++;
                        }
                    }
                    if (winDetect(displayPos, turn) == false)
                    {
                        turn++;
                        if (AI)
                        {
                            playAITurn();
                        }
                        else
                        {
                            playPlayerTurn(counter, turn);
                        }
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("Column is full");
                }
            }
        }
    }
}