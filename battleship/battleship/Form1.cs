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

        //my list to save the location Ai will fire
        public class MyList
        {
            private int length = 0;
            public location[] List;

            //return the current length
            public int getLength()
            {
                return length;

            }

            //pop the last location in the list
            //if list is empty, return location (-1,-1)
            public location pop()
            {

                location returnVal;
                if (length != 0)
                {
                    returnVal = List[length - 1];
                    length--;
                }
                else
                {
                    location Errorlocation;
                    Errorlocation.x_axis = -1;
                    Errorlocation.y_axis = -1;
                    returnVal = Errorlocation;
                }

                return returnVal;
            }

            //check is 2 location is repeat
            //return 1 for it is repeat
            //return 0 no repeat
            public int CompareLocation(location location1, location location2)
            {
                int returnVal = 0;
                if (location1.x_axis == location2.x_axis)
                {
                    if (location1.y_axis == location2.y_axis)
                    {
                        returnVal = 1;
                    }
                }
                return returnVal;
            }

            //put one location into the end of list
            //return 1 if push success
            //return 0 if fail
            public int push(location location)
            {
                int valid = 0;
                int repeat = 0;
                
                //make sure it won't go though the end of list
                //49 is the total grid for one player
                if (length < 49)
                {
                    for (int i = 0; i < length; i++)
                    {
                        valid = CompareLocation(location, List[i]);
                        if (valid == 1)
                        {
                            repeat = 1;
                            return 0;
                        }
                    }

                    if (repeat == 0)
                    {
                        List[length] = location;
                        length++;
                        return 1;
                    }

                }
                return 0;
            }

        }
        //struct for locatoin.
        public struct location
        {
            public int x_axis;
            public int y_axis;
        }

        //struct for the ships
        //include information about ships
        //number, name, remain
        public struct ship
        {
            public int number;
            public string name;
            public int remain;
        }


        //sturct for player
        //include 2 boards for each players
        
        //first variable show which board

        //first board will have their own ships
        //second board will show the hit or miss

        //second and third variable show x,y axis
      
        //TotalRemain show how many ship player left
        public class player
        {
            public char[,,] board;
            public ship[] AllShip;
            public int TotalRemain;

        }


        //initial players
        //initial buttons
        //and attck list for ai
        static player[] players = new player[2];
        static Button[] GameButton = new Button[TotalGrid * 2];
        static MyList AttackList = new MyList();


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
            location initial;
            initial.x_axis = -1;
            initial.y_axis = -1;
            index = 0;
            AttackList.List = new location[TotalGrid];

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
                    GameButton[index].Location = new Point(120 + j *
                        (ButtonSize + GapSize),
                        60 + i * (ButtonSize + GapSize));

                    GameButton[index + TotalGrid].Location =
                        new Point(460 + j * (ButtonSize + GapSize),
                        60 + i * (ButtonSize + GapSize));

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
                    GameButton[index].BackColor = default(Color);
                    GameButton[index + TotalGrid].BackColor = default(Color);
                    index++;

                }
            }

            //reset data of remain ship for both player
            for (int i = 0; i < PlayerNum; i++)
            {
                players[i].TotalRemain = ShipTotal;

                for (int j = 0; j < 5; j++)
                {
                    players[i].AllShip[j].remain = length[j];
                }
            }

            //show text messeage 
            LogText.Text = "Choose location for " +
                       ShipName[0];
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

            //reset the display remainning shit  
            MyA.Text = length[0].ToString();
            MyB.Text = length[1].ToString();
            MyD.Text = length[2].ToString();
            MyS.Text = length[3].ToString();
            MyP.Text = length[4].ToString();


            //reset SetShipOrder for AI to set ship
            SetShipOrder = 0;
            index = 0;

            //call function for ai to set ship, after user is done
            AiSetShip();
        }

        //ai setship
        //bascially random location and direction
        //check is location valid
        private void AiSetShip()
        {
            Random rng = new Random();
            int direction;
            int valid = 0;
            location ChooseLocation;
            char symbol;

            //randomize ship location and direction
            //check is location valid
            //if it is valid set it in that location
            //if not valid, randomize location and direction again
            while (SetShipOrder < 5)
            {
                direction = rng.Next(2);
                symbol = ShipName[SetShipOrder][0];
                ChooseLocation = RngLocation();
                valid = ValidLocation(1, ChooseLocation,
                    direction, SetShipOrder);
                if (valid == 1)
                {

                    for (int i = 0; i < length[SetShipOrder]; i++)
                    {
                        if (direction == 0)
                        {
                            players[1].board[0, ChooseLocation.x_axis + i,
                                ChooseLocation.y_axis] = symbol;
                        }
                        else
                        {
                            players[1].board[0, ChooseLocation.x_axis,
                                ChooseLocation.y_axis + i] = symbol;
                        }
                    }
                    SetShipOrder++;
                }
            }
            //display enemy ship information on the board
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
            location newLocation;
            int valid = 0;
            int hit = 0;
            int x;
            int y;

            //if there is something in attacklist
            //priority shoot the location in the list
            //if list is empty and still no valid location
            //use random location
            if (AttackList.getLength() != 0)
            {
                do
                {
                    ChooseLocation = AttackList.pop();

                    if (players[1].board[1, ChooseLocation.x_axis, ChooseLocation.y_axis] == '?')
                    {
                        valid = 1;
                    }

                    if ((AttackList.getLength() == 0) && (valid == 0))
                    {
                        ChooseLocation = RngLocation();
                    }

                } while (valid == 0);

            }
            else
            {
                //keep choosing random location
                //until have valid location
                do
                {
                    ChooseLocation = RngLocation();
                    if (players[1].board[1, ChooseLocation.x_axis,
                        ChooseLocation.y_axis] == '?')
                    {
                        valid = 1;
                    }
                } while (valid == 0);

            }
            //shotship return 1 or 0
            //1 = hit, 0 = miss
            hit = ShotShip(1, ChooseLocation);

            //if hit something, put the location near 
            //the target locationi into attack list
            //check no out of boundary
            if (hit == 1)
            {
                x = ChooseLocation.x_axis;
                y = ChooseLocation.y_axis;

                if (x != 0)
                {
                    newLocation.x_axis = (x - 1);
                    newLocation.y_axis = y;
                    if (players[1].board[1, newLocation.x_axis, newLocation.y_axis] == '?')
                    {
                        valid = AttackList.push(newLocation);
                    }

                }
                if (x != (BoardSize - 1))
                {
                    newLocation.x_axis = (x + 1);
                    newLocation.y_axis = y;
                    if (players[1].board[1, newLocation.x_axis, newLocation.y_axis] == '?')
                    {
                        valid = AttackList.push(newLocation);
                    }

                }
                if (y != 0)
                {
                    newLocation.x_axis = x;
                    newLocation.y_axis = y - 1;
                    if (players[1].board[1, newLocation.x_axis, newLocation.y_axis] == '?')
                    {
                        valid = AttackList.push(newLocation);
                    }

                }
                if (y != (BoardSize - 1))
                {
                    newLocation.x_axis = x;
                    newLocation.y_axis = (y + 1);
                    if (players[1].board[1, newLocation.x_axis, newLocation.y_axis] == '?')
                    {
                        valid = AttackList.push(newLocation);
                    }

                }

            }

        }

        //setting ships for player
        private void SetShip(int player, int ship, location location,
                                        int direction)
        {

            int DierctionTemp;
            int valid = 0;
            char symbol = ShipName[ship][0];
            index = LocToInt(location);

            //direction variable 0 = horizontal, 1 = vertical, 
            //-1 control by radio button
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

            //check valid for that player
            //show the symbol of ship on the button
            valid = ValidLocation(player, location, DierctionTemp, ship);
            if (valid == 1)
            {
                for (int i = 0; i < length[ship]; i++)
                {
                    if (DierctionTemp == 0)
                    {
                        players[player].board[0, location.x_axis + i,
                            location.y_axis] = symbol;
                        GameButton[index + i].Text = symbol.ToString();
                    }
                    else
                    {
                        players[player].board[0, location.x_axis,
                            location.y_axis + i] = symbol;
                        GameButton[index + i * 7].Text = symbol.ToString();
                    }

                }
                //show messeage of success setting
                LogText.Text = ShipName[ship] + " setting success \n\n\n";
                SetShipOrder++;

                //SetShipOrder show which ship is setting right now.
                //if every ship is done, 
                //show messeage box confirm is everything correct
                if (SetShipOrder < 5)
                {
                    LogText.Text += "Choose location for " +
                        ShipName[ship + 1];
                }
                else
                {
                    var result = MessageBox.Show("Is everything correct?",
                        "Finish Setting", MessageBoxButtons.YesNo);
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
                LogText.Text += "please choose location for ";
                LogText.Text += ShipName[ship] + " again";


            }

        }


        //function to check is the fire location have ship or not
        private int ShotShip(int self, location locate)
        {
            int enemy = 0;
            int shipType = 0;
            int buttonNum = LocToInt(locate);

            if (self == 0)
            {
                enemy = 1;
            }

            //miss shoot
            if (players[enemy].board[0, locate.x_axis, locate.y_axis] == '?')
            {
                players[self].board[1, locate.x_axis, locate.y_axis] = 'M';
                players[enemy].board[0, locate.x_axis, locate.y_axis] = 'M';

                //change log text and button color to clearly show hit or miss   
                //depend on which player change different button       
                if (self == 0)
                {
                    GameButton[buttonNum + TotalGrid].Text = "M";
                    GameButton[buttonNum + TotalGrid].BackColor = Color.PaleGreen;
                    LogText.Text = "You miss at [";
                    LogText.Text += locate.x_axis.ToString();
                    LogText.Text += ",";
                    LogText.Text += locate.y_axis.ToString();
                    LogText.Text += "]\n\n";
                }
                else
                {
                    GameButton[buttonNum].Text = "M";
                    GameButton[buttonNum].BackColor = Color.PaleGreen;
                }
                return 0;
            }
            else
            {//hit something

                //check which ship is hit
                switch (players[enemy].board[0, locate.x_axis, locate.y_axis])
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

                //decrease the remain number for ship and total amount
                players[enemy].AllShip[shipType].remain--;
                players[enemy].TotalRemain--;

                //change log text and button color to clearly show hit or miss   
                //depend on which player change different button       
                if (self == 0)
                {
                    LogText.Text = "You hit something at [";
                    LogText.Text += locate.x_axis.ToString();
                    LogText.Text += ",";
                    LogText.Text += locate.y_axis.ToString();
                    LogText.Text += "]\n\n";

                    //if no part remain in certain ship
                    //show log text, which ship is sink
                    if (players[enemy].AllShip[shipType].remain == 0)
                    {
                        ChangeMesseage(shipType, 0);
                        LogText.Text += ShipName[shipType] + " is sinked";
                    }
                    EnemyRemain.Text = players[enemy].TotalRemain.ToString();
                    GameButton[buttonNum + TotalGrid].Text = "H";
                    GameButton[buttonNum + TotalGrid].BackColor = Color.Red;

                }
                else
                {
                    GameButton[buttonNum].Text = "H";
                    ChangeMesseage(shipType, 1);
                    GameButton[buttonNum].BackColor = Color.Red;
                }

                players[self].board[1, locate.x_axis, locate.y_axis] = 'H';
                players[enemy].board[0, locate.x_axis, locate.y_axis] = 'H';

                //if one player don't have any ship
                //show messeage check play again or close  
                if (players[enemy].TotalRemain == 0)
                {
                    LogText.Text = "Congrualoation Player" + (self + 1);
                    var result = MessageBox.Show("Player " + (self + 1) 
                        + " is winner\n" +
                        "Would you like to play again?",
                       "Game Over", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        reset();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                return 1;
            }



        }

        //change the display ship information
        private void ChangeMesseage(int ship, int player)
        {
            if (player == 0)
            {
                //show enemy ship is sinked
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
            else
            {
                //show the remain of ship
                switch (ship)
                {
                    case 0:
                        MyA.Text = players[0].AllShip[0].remain.ToString();
                        break;
                    case 1:
                        MyB.Text = players[0].AllShip[1].remain.ToString();
                        break;
                    case 2:
                        MyS.Text = players[0].AllShip[2].remain.ToString();
                        break;
                    case 3:
                        MyD.Text = players[0].AllShip[3].remain.ToString();
                        break;
                    case 4:
                        MyP.Text = players[0].AllShip[4].remain.ToString();
                        break;
                }
            }

        }

        //check is location valid to set ship
        private int ValidLocation(int player, location locate,
            int direction, int ship)
        {

            int valid = 1;
            int x = locate.x_axis;
            int y = locate.y_axis;
            //direction variable 0 = horizontal, 1 = vertical
            //check will it out of boundary
            //or check is somethinh is in the middle
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
            //if there are still ship for enemy
            //let him attack
            if (players[1].TotalRemain != 0)
            {
                AiAttack();
            }
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
