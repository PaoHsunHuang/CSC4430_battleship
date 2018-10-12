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
        int PlayerNum = 2;
        int returnValue;
        struct location
        {
            public int x_axis;
            public int y_axis;

        }
        //set the struct for the ships
        //include information about ships
        //location, name ,direction and remain
        //direction 0 = horizontal, 1 = vertical
        struct ship
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
        struct player
        {
            public char[,,] board;
            public ship[] AllShip;
            public int TotalRemain;
        }

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }


        public void StartGame()
        {
            player[] players = new player[PlayerNum];
            int BoardSize = 7;
            int TotalGrid = BoardSize * BoardSize;
            int GapSize = 5;
            int ButtonSize = 35;
            ship[] AllShip = new ship[5];
            Button[] GameButton = new Button[TotalGrid * 2];
            int index = 0;

            //create player struct to set the game
            //create ship struct, for all player
            for (int i = 0; i < PlayerNum; i++)
            {
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

            //location newlocate;
            //newlocate.x_axis = 0;
            //newlocate.y_axis = 1;
            //index = 10;
            //          SetShip(players[0], 0, newlocate, -1, GameButton[10]);
            LogText.Text = returnValue.ToString();
            for (int i = 0; i < 5; i++)
            {
                LogText.Text = "Please choose location to locate your " + ShipName[i];


            }

        }

        //click button event
        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
//            LogText.Text = btn.Name + " clicked";
            returnValue = Convert.ToInt32(btn.Name);
        }

        //enter a location, translate to index number
        //(0,0) will be 0, (0,1) will be 7
        private int Translate(location location)
        {
            int index;
            index = location.x_axis + location.y_axis * 7;
            return index;
        }


        //setting ships for player

        private void SetShip(player player, int ship, location location, int direction, Button GameButton)
        {
            //direction variable 0 = horizontal, 1 = vertical
            int DierctionTemp;
            int index;
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
            player.board[0, location.x_axis, location.y_axis] = symbol;
            player.AllShip[ship].location.x_axis = location.x_axis;
            player.AllShip[ship].location.y_axis = location.y_axis;
            player.AllShip[ship].direction = DierctionTemp;
            GameButton.Text = symbol.ToString();
            LogText.Text = "setting success \n";
        }

        //private void Shot()
        //{


        //}


        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
