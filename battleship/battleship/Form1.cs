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

        //start shooting enemy
        private void Attack()
        {

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
                players[i].TotalRemain = 5 + 4 + 3 + 3 + 2;
                players[i].AllShip = new ship[5];

                for (int j = 0; j < 5; j++)
                {
                    players[i].AllShip[j].number = j;
                    players[i].AllShip[j].remain = length[j];
                    players[i].AllShip[j].name = ShipName[j];
                }
            }

            //create game button
            for (int i = 0; i < TotalGrid * 2; i++)
            {
                GameButton[i] = new Button();
                GameButton[i].Size = new Size(ButtonSize, ButtonSize);
                GameButton[i].Text = i.ToString();
                GameButton[i].Name = i.ToString();
                GameButton[i].Click += new EventHandler(ButtonClick);
                this.Controls.Add(GameButton[i]);
            }


            //locate the button position
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    GameButton[index].Location = new Point(120 + j * (ButtonSize + GapSize), 60 + i * (ButtonSize + GapSize));
                    GameButton[index + 49].Location = new Point(460 + j * (ButtonSize + GapSize), 60 + i * (ButtonSize + GapSize));
                   
                    index++;
                }
            }
            reset();  


        }

        //set board and button variable to initial
        public void reset()
        {
            index = 0;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    players[0].board[0, i, j] = '?';
                    players[0].board[1, i, j] = '?';
                    players[1].board[0, i, j] = '?';
                    players[1].board[1, i, j] = '?';
                    GameButton[index].Text = players[0].board[0, i, j].ToString();
                    index++;

                }

            }
        }


        //setting ships for player
        private void SetShip(player player, int ship, location location,
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
            if (valid == 1)
            {
                for (int i = 0; i < length[ship]; i++)
                {
                    if (DierctionTemp == 0)
                    {
                        player.board[0, location.x_axis + i, location.y_axis] = IntToChar(ship);
                        player.AllShip[ship].location.x_axis = location.x_axis;
                        player.AllShip[ship].location.y_axis = location.y_axis;
                        player.AllShip[ship].direction = DierctionTemp;
                        GameButton[index + i].Text = symbol.ToString();
                    }
                    else
                    {
                        player.board[0, location.x_axis, location.y_axis + i] = IntToChar(ship);
                        player.AllShip[ship].location.x_axis = location.x_axis;
                        player.AllShip[ship].location.y_axis = location.y_axis;
                        player.AllShip[ship].direction = DierctionTemp;
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

        private int ValidLocation(player player, location locate, int direction, int ship)
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
                        if (player.board[0, x + i, y] != '?')
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
                        if (player.board[0, x, y + i] != '?')
                        {
                            valid = 0;
                        }
                    }
                }

            }

            return valid;
        }

        //function to check is the fire location have ship or not
        private void Shot(player[] player, int self, location locate)
        {
            int enemy = 0;
            int shipType = 0;
            if (self == 0)
            {
                enemy = 1;
            }

            if (player[enemy].board[0, locate.x_axis, locate.y_axis] == '0')
            {
                player[self].board[1, locate.x_axis, locate.y_axis] = 'M';
                player[enemy].board[0, locate.x_axis, locate.y_axis] = 'M';
            }
            else
            {
                player[self].board[1, locate.x_axis, locate.y_axis] = 'H';
                player[enemy].board[0, locate.x_axis, locate.y_axis] = 'H';
                player[enemy].TotalRemain--;

                switch (player[enemy].board[0, locate.x_axis, locate.y_axis])
                {
                    case 'A':
                        shipType = 0;
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
                player[enemy].AllShip[shipType].remain--;
                if (player[enemy].AllShip[shipType].remain == 0)
                {
                    LogText.Text = ShipName[shipType] + " is sinked";
                }
            }
        }


        //click button event
        public void ButtonClick(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            int num;
            //          LogText.Text = btn.Name + " clicked";

            location Currentlocate;
            Currentlocate.x_axis = 0;
            Currentlocate.y_axis = 0;
            num = System.Convert.ToInt32(btn.Name);

            Currentlocate.x_axis = num % BoardSize;
            Currentlocate.y_axis = num / BoardSize;

            SetShip(players[0], order, Currentlocate, -1, GameButton);


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
    }
}
