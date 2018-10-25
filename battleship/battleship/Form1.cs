using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship
{
    public partial class Form1 : Form
    {
        string[] ShipName = {"Aircraft","Battleship","Submarine",
            "Destroyer","Patrol"};
        int[] length = { 5, 4, 3, 3, 2 };
        public int PlayerNum = 2;
        int BoardSize = 7;
        int order = 0;
        int index = 0;
        //struct for locatoin.
        public struct location
        {
            public int x_axis;
            public int y_axis;
        }
        //set the struct for the ships
        //include information about ships
        //location, name ,direction and remain
        //direction 0 = horizontal, 1 = vertical
        public struct ship
        {
            public int number;
            public string name;
            public location location;
            public int direction;
            public int remain;
        }

        //sturct for player
        //include 2 boards for each players
        //board will be 3D array
        //first variable show which board
        //first board will have their own ships
        //second board will show the hit or miss
        //second and third board show x,y axis
        //TotalRemain show how many ship player left
        public class player
        {

            public char[,,] board;
            public ship[] AllShip;
            public int TotalRemain;

            //public player()
            //{

            //    this.board = new char[2, 7, 7];
            //    this.AllShip = new ship[5];
            //    this.TotalRemain = 5 + 4 + 3 + 3 + 2;
            //}
        }

        static player[] players = new player[2];
        int TotalGrid = 7 * 7;
        static Button[] GameButton = new Button[49 * 2];



        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Setting();

        }

        //start attacking enemy
        private void Attack()
        {
            //set the avaliable button
            for (int i = 0; i < TotalGrid; i++)
            {
                GameButton[i].Enabled = false;
                GameButton[i + TotalGrid].Enabled = true;
            }

            char temp;
            //copy board
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    temp = players[0].board[0, i, j];
                    players[1].board[0, i, j] = temp;
                }

            }
            
        }

        //initial the variable
        public void Setting()
        {

            int GapSize = 5;
            int ButtonSize = 35;
            int index = 0;


            //create player struct to set the game
            //create ship struct, for all player
            for (int i = 0; i < PlayerNum; i++)
            {
                players[i] = new player();
                players[i].board = new char[2, BoardSize, BoardSize];
  //              players[i].TotalRemain = 5 + 4 + 3 + 3 + 2;
                players[i].AllShip = new ship[5];

                for (int j = 0; j < 5; j++)
                {
                    players[i].AllShip[j].number = j;
//                    players[i].AllShip[j].remain = length[j];
                    players[i].AllShip[j].name = ShipName[j];
                }
            }

            //create game button
            for (int i = 0; i < TotalGrid * 2; i++)
            {
                GameButton[i] = new Button();
                GameButton[i].Size = new Size(ButtonSize, ButtonSize);
                GameButton[i].Name = i.ToString();
                if (i < TotalGrid)
                {
                    GameButton[i].Click += new EventHandler(SetButton);
                }
                else {
                    GameButton[i].Click += new EventHandler(AttackButton);
                }
                this.Controls.Add(GameButton[i]);

            }


            //locate the button position
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    GameButton[index].Location = new Point(120 + j * (ButtonSize + GapSize), 60 + i * (ButtonSize + GapSize));
                    GameButton[index + TotalGrid].Location = new Point(460 + j * (ButtonSize + GapSize), 60 + i * (ButtonSize + GapSize));
                   
                    index++;
                }
            }

            reset();  


        }

        //set board and button variable to initial
        public void reset()
        {
            index = 0;
            order = 0;
            EnemyRemain.Text = "17";
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    players[0].board[0, i, j] = '?';
                    players[0].board[1, i, j] = '?';
                    players[1].board[0, i, j] = '?';
                    players[1].board[1, i, j] = '?';
                    GameButton[index].Text = "?";
                    GameButton[index + TotalGrid].Text = "?";
                    GameButton[index].Enabled = true;
                    GameButton[index + TotalGrid].Enabled = false;
                    
                    index++;

                }
            }

            for (int i = 0; i < PlayerNum; i++)
            {
                players[i].TotalRemain = 5 + 4 + 3 + 3 + 2;

                for (int j = 0; j < 5; j++)
                {
                    players[i].AllShip[j].remain = length[j];
                }
            }

        }


        //setting ships for player
        private void SetShip(int player, int ship, location location,
                                        int direction, Button[] GameButton)
        {
            //direction variable 0 = horizontal, 1 = vertical, 
            //-1 control by radio button

            int DierctionTemp;
            int index;
            int valid = 0;
            char symbol = ShipName[ship][0];
            index = Translate(location);

            if (direction == -1)
            {
                if (Horizontal.Checked == true)
                {
                    DierctionTemp = 0;
                }
                else
                {
                    DierctionTemp = 1;
                }
            }
            else
            {
                DierctionTemp = direction;
            }

            valid = ValidLocation(player, location, DierctionTemp, ship);
            //direction variable 0 = horizontal, 1 = vertical, 
            //-1 control by radio button

            if (valid == 1)
            {
                for (int i = 0; i < length[ship]; i++)
                {
                    if (DierctionTemp == 0)
                    {
                        players[player].board[0, location.x_axis + i, location.y_axis] = symbol;
                        players[player].AllShip[ship].location.x_axis = location.x_axis;
                        players[player].AllShip[ship].location.y_axis = location.y_axis;
                        players[player].AllShip[ship].direction = DierctionTemp;
                        GameButton[index + i].Text = symbol.ToString();
                    }
                    else
                    {
                        players[player].board[0, location.x_axis, location.y_axis + i] = symbol;
                        players[player].AllShip[ship].location.x_axis = location.x_axis;
                        players[player].AllShip[ship].location.y_axis = location.y_axis;
                        players[player].AllShip[ship].direction = DierctionTemp;
                        GameButton[index + i * 7].Text = symbol.ToString();
                    }

                }
                LogText.Text = ShipName[ship] + " setting success \n\n\n";
                order++;
                if (order < 5)
                {
                    LogText.Text += "Choose location for " + ShipName[ship + 1];
                }
                else
                {
                    var result = MessageBox.Show("Is everything correct?", "Finish Setting", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Attack();
                    }
                    else
                    {
                        order = 0;
                        reset();
                    }
                }
            }
            else
            {
                LogText.Text = ShipName[ship] + " setting fail \n\n\n";
                LogText.Text += "please choose location for " + ShipName[ship] + " again";


            }

        }

        private int ValidLocation(int player, location locate, int direction, int ship)
        {

            int valid = 1;
            int x = locate.x_axis;
            int y = locate.y_axis;
            //direction variable 0 = horizontal, 1 = vertical, 
            if (direction == 0)
            {
                if ((x + length[ship]) > BoardSize)
                {
                    valid = 0;
                }
                else
                {
                    for (int i = 0; i < length[ship]; i++)
                    {
                        if (players[player].board[0, x + i, y] != '?')
                        {
                            valid = 0;
                        }
                    }
                }

            }
            else
            {
                if ((y + length[ship]) > BoardSize)
                {
                    valid = 0;
                }
                else
                {
                    for (int i = 0; i < length[ship]; i++)
                    {
                        if (players[player].board[0, x, y + i] != '?')
                        {
                            valid = 0;
                        }
                    }
                }

            }

            return valid;
        }

        //function to check is the fire location have ship or not
        private void Shot(int self, location locate)
        {
            int enemy = 0;
            int shipType = 0;
            int buttonNum = Translate(locate) + 49;
            char ship;

            if (self == 0)
            {
                enemy = 1;
            }

            if (players[enemy].board[0, locate.x_axis, locate.y_axis] == '?')
            {
                players[self].board[1, locate.x_axis, locate.y_axis] = 'M';
                players[enemy].board[0, locate.x_axis, locate.y_axis] = 'M';
                GameButton[buttonNum].Text = "M";
                LogText.Text = "You miss at [";
                LogText.Text += locate.x_axis.ToString();
                LogText.Text += ",";
                LogText.Text += locate.y_axis.ToString();
                LogText.Text += "]\n\n";
            }
            else
            {

                switch (players[enemy].board[0, locate.x_axis, locate.y_axis])
                {
                    case 'A':
                        shipType = 0;
//                        EnemyA.Text = (players[enemy].AllShip[shipType].remain - 1).ToString();
                        break;
                    case 'B':
                        shipType = 1;
                        break;
                    case 'S':
                        shipType = 2;
                        break;
                    case 'D':
                        shipType = 3;
                        break;
                    case 'P':
                        shipType = 4;
                        break;
                }
                players[enemy].AllShip[shipType].remain--;

                LogText.Text = "You hit something at [";
                LogText.Text += locate.x_axis.ToString();
                LogText.Text += ",";
                LogText.Text += locate.y_axis.ToString();
                LogText.Text += "]\n\n";


                if (players[enemy].AllShip[shipType].remain == 0)
                {
                    LogText.Text += ShipName[shipType] + " is sinked";
                }

                players[self].board[1, locate.x_axis, locate.y_axis] = 'H';
                players[enemy].board[0, locate.x_axis, locate.y_axis] = 'H';
                players[enemy].TotalRemain--;
                EnemyRemain.Text = players[enemy].TotalRemain.ToString();
                GameButton[buttonNum].Text = "H";
            }
        }


        //click button for set ship
        public void SetButton(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            int num;
            location Currentlocate;
            Currentlocate.x_axis = 0;
            Currentlocate.y_axis = 0;
            num = System.Convert.ToInt32(btn.Name);

            Currentlocate.x_axis = num % BoardSize;
            Currentlocate.y_axis = num / BoardSize;

           
            SetShip(0, order, Currentlocate, -1, GameButton);


        }

        //click button for attack
        public void AttackButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int num;
            location Currentlocate;
            Currentlocate.x_axis = 0;
            Currentlocate.y_axis = 0;
            num = System.Convert.ToInt32(btn.Name);
            num -= TotalGrid;
            Currentlocate.x_axis = num % BoardSize;
            Currentlocate.y_axis = num / BoardSize;

            btn.Enabled = false;
            Shot(0,Currentlocate);

        }


        //enter a location, translate to index number
        //(0,0) will be 0, (0,1) will be 7
        private int Translate(location location)
        {
            int index;
            index = location.x_axis + location.y_axis * 7;
            return index;
        }

        private char IntToChar(int num)
        {
            char returnChar = '0';

            switch (num)
            {
                case 0:
                    returnChar = '0';
                    break;
                case 1:
                    returnChar = '1';
                    break;
                case 2:
                    returnChar = '2';
                    break;
                case 3:
                    returnChar = '3';
                    break;
                case 4:
                    returnChar = '4';
                    break;
                case 5:
                    returnChar = '5';
                    break;
            }
            return returnChar;
        }



        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            LogText.Text = "Reset Game";
            reset();
        }
    }
}
