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

        public Form1()
        {
            InitializeComponent();
        }


        string[] ShipName = {"Aircraft","Battleship","Submarine",
            "Destroyer","Patrol"};
        int[] length = { 5, 4, 3, 3, 2 };
        int PlayerNum = 2;
        const int ShipTotal = 5 + 4 + 3 + 3 + 2;
        const int BoardSize = 7;
        const int TotalGrid = 7 * 7;
        int SetShipOrder = 0;
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
   //         public location location;
     //       public int direction;
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

        }


        //initial players
        //initial buttons
        static player[] players = new player[2];
        static Button[] GameButton = new Button[TotalGrid * 2];


        //load form, start setting window
        private void Form1_Load(object sender, EventArgs e)
        {
            Setting();

        }


        //initial the variable
        private void Setting()
        {
            const int GapSize = 5;
            const int ButtonSize = 35;
            index = 0;

            //create player struct to set the game
            //create ship struct, for all player
            for (int i = 0; i < PlayerNum; i++)
            {
                players[i] = new player();
                players[i].board = new char[2, BoardSize, BoardSize];
                players[i].AllShip = new ship[5];

                for (int j = 0; j < 5; j++)
                {
                    players[i].AllShip[j].number = j;
                    players[i].AllShip[j].name = ShipName[j];
                }
            }

            //set game button size, text, name
            //add EventHandler
            for (int i = 0; i < TotalGrid * 2; i++)
            {
                GameButton[i] = new Button();
                GameButton[i].Size = new Size(ButtonSize, ButtonSize);
                GameButton[i].Name = i.ToString();
                if (i < TotalGrid)
                {
                    GameButton[i].Click += new EventHandler(SetButton);
                }
                else
                {
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
        private void reset()
        {
            index = 0;
            SetShipOrder = 0;
            EnemyRemain.Text = "0";

            //reset board information
            //reset text for each button
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
                players[i].TotalRemain = ShipTotal;

                for (int j = 0; j < 5; j++)
                {
                    players[i].AllShip[j].remain = length[j];
                }
            }

        }

        //start attacking enemy
        private void StartAttack()
        {
            //let setting button, disable to click
            //attacking button, enable
            for (int i = 0; i < TotalGrid; i++)
            {
                GameButton[i].Enabled = false;
                GameButton[i + TotalGrid].Enabled = true;
            }

            //reset SetShipOrder for AI to set ship
            SetShipOrder = 0;

            MyA.Text = length[0].ToString();
            MyB.Text = length[1].ToString();
            MyD.Text = length[2].ToString();
            MyS.Text = length[3].ToString();
            MyP.Text = length[4].ToString();

            AiSetShip();
            //---------------------
            //code for test
            //---------------------
            //copy board
            //char temp;
            //for (int i = 0; i < BoardSize; i++)
            //{
            //    for (int j = 0; j < BoardSize; j++)
            //    {
            //        temp = players[0].board[0, i, j];
            //        players[1].board[0, i, j] = temp;
            //    }

            //}
            //----------------------
        }

        private void AiSetShip(){
            Random rng = new Random();
            int direction;
            int valid = 0;
            location ChooseLocation;
            char symbol;
            while (SetShipOrder < 5)
            {
                direction = rng.Next(2);
                symbol = ShipName[SetShipOrder][0];
                ChooseLocation = RngLocation();
                valid = ValidLocation(1, ChooseLocation, direction, SetShipOrder);
                if (valid == 1)
                {

                    for (int i = 0; i < length[SetShipOrder]; i++)
                    {
                        if (direction == 0)
                        {
                            players[1].board[0, ChooseLocation.x_axis + i, ChooseLocation.y_axis] = symbol;
                        }
                        else
                        {
                            players[1].board[0, ChooseLocation.x_axis, ChooseLocation.y_axis + i] = symbol;
                        }
                    }
                    SetShipOrder++;
                }
            }
            EnemyRemain.Text = "17";
            EnemyA.Text = "Live";
            EnemyB.Text = "Live";
            EnemyS.Text = "Live";
            EnemyD.Text = "Live";
            EnemyP.Text = "Live";

            LogText.Text = "Enemy finish setting";
        }


        //ai choose location to fire
        
        private void AiAttack()
        {
            location ChooseLocation;
            int valid = 0;
            do
            {
                ChooseLocation = RngLocation();
                if (players[1].board[1, ChooseLocation.x_axis, ChooseLocation.y_axis] == '?')
                {
                    valid = 1;
                }
            } while (valid == 1);
//ShotShip(1,ChooseLocation);
            
        }

        //setting ships for player
        private void SetShip(int player, int ship, location location,
                                        int direction)
        {
            //direction variable 0 = horizontal, 1 = vertical, 
            //-1 control by radio button

            int DierctionTemp;

            int valid = 0;
            char symbol = ShipName[ship][0];
            index = LocToInt(location);

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
                        //players[player].AllShip[ship].location.x_axis = location.x_axis;
                        //players[player].AllShip[ship].location.y_axis = location.y_axis;
                        //players[player].AllShip[ship].direction = DierctionTemp;
                        GameButton[index + i].Text = symbol.ToString();
                    }
                    else
                    {
                        players[player].board[0, location.x_axis, location.y_axis + i] = symbol;
                        //players[player].AllShip[ship].location.x_axis = location.x_axis;
                        //players[player].AllShip[ship].location.y_axis = location.y_axis;
                        //players[player].AllShip[ship].direction = DierctionTemp;
                        GameButton[index + i * 7].Text = symbol.ToString();
                    }

                }
                LogText.Text = ShipName[ship] + " setting success \n\n\n";
                SetShipOrder++;
                if (SetShipOrder < 5)
                {
                    LogText.Text += "Choose location for " + ShipName[ship + 1];
                }
                else
                {
                    var result = MessageBox.Show("Is everything correct?", "Finish Setting", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        StartAttack();
                    }
                    else
                    {
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


        //function to check is the fire location have ship or not
        private void ShotShip(int self, location locate)
        {
            int enemy = 0;
            int shipType = 0;
            int buttonNum = LocToInt(locate) + 49;

            if (self == 0)
            {
                enemy = 1;
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
                        ChangeMesseage(shipType);
                        LogText.Text += ShipName[shipType] + " is sinked";
                    }

                    players[self].board[1, locate.x_axis, locate.y_axis] = 'H';
                    players[enemy].board[0, locate.x_axis, locate.y_axis] = 'H';
                    players[enemy].TotalRemain--;
                    EnemyRemain.Text = players[enemy].TotalRemain.ToString();
                    GameButton[buttonNum].Text = "H";
                }
            }
            
            
        }

        private void ChangeMesseage(int ship)
        {
            switch (ship)
            {
                case 0:
                    EnemyA.Text = "Dead";
                    break;
                case 1:
                    EnemyB.Text = "Dead";
                    break;
                case 2:
                    EnemyS.Text = "Dead";
                    break;
                case 3:
                    EnemyD.Text = "Dead";
                    break;
                case 4:
                    EnemyP.Text = "Dead";
                    break;
            }
        }

        //check is location valid to set ship
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

            SetShip(0, SetShipOrder, Currentlocate, -1);
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
            ShotShip(0, Currentlocate);

        }

        //random location
        private location RngLocation()
        {
            location returnLoc;
            Random rng = new Random();
            int x = rng.Next(BoardSize);
            int y = rng.Next(BoardSize);
            returnLoc.x_axis = x;
            returnLoc.y_axis = y;

            return returnLoc;
        }

        //enter a location, translate to index number
        //(0,0) will be 0, (0,1) will be 7
        private int LocToInt(location location)
        {
            int index;
            index = location.x_axis + location.y_axis * 7;
            return index;
        }


        //change int to char
        //return char
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


        //reset button
        private void RestartBtn_Click(object sender, EventArgs e)
        {
            LogText.Text = "Reset Game";
            reset();
        }


        //exit button   
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
