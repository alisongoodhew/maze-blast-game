using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using GameLib;
using System.Timers;

using static GameLib.ScreenObject;

namespace Assignment4
{
    public partial class GameForm : Form
    {
        //Declare objects
        PlayerChar player;
        EnemyChar enemy;
        ExitDoor door;
        Maze newMaze;
        Graphics graphics;
        //Declare hashsets for maze pieces and enemies
        HashSet<Maze> mazes = new HashSet<Maze>();
        HashSet<EnemyChar> enemies = new HashSet<EnemyChar>();
        public GameForm()
        {   
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //GameWindow fixed in size for now
            this.Size = new Size(1920, 1057);

            //construct character player, enemy, door, use specs from Display
            door = new ExitDoor(this.DisplayRectangle);
            player = new PlayerChar(this.DisplayRectangle);
            enemy = new EnemyChar(this.DisplayRectangle);
            
            //construct maze object
            newMaze = new Maze(this.DisplayRectangle);
            //draw maze and save in hashset
            newMaze.DrawMaze(this.DisplayRectangle, newMaze, mazes);
            //check player/door for intersect with maze, proximity to each other
            player = CheckPlayerPlacement(player, mazes);
            door = CheckDoorPlacement(door, mazes);
            //call function to generate enemies
            GenerateEnemies();

        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {

            //This is where the form paints itself
            //will load with every refresh
            graphics = e.Graphics;

            //draw all maze pieces
            foreach (var maze in mazes)
            {
                maze.Draw(graphics);

            }

            //draw all enemies
            foreach (var badGuy in enemies)
            {
                badGuy.Draw(graphics);
            }
            
            //draw player and door
            player.Draw(graphics);
            door.Draw(graphics);
 
        }

        

        /// <summary>
        /// React to player Key Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if user presses space, game will unlock
            switch (e.KeyCode)
            {
                case Keys.Space:
                    animationTimer.Enabled = true;
                    
                    break;
            }
            //once game unlocked
            if (animationTimer.Enabled)
            {
                switch (e.KeyCode)
                {
                    
                    case Keys.Left:
                        //move player, check if maze in the way
                        player.Move(PlayerChar.Direction.Left);
                        CheckForMazePlayer(Direction.Left);

                        foreach (var badGuy in enemies)
                        {
                            if (badGuy.Teleport())
                            {
                                badGuy.ChangeEnemy(DisplayRectangle, null);
                                enemy = CheckEnemyPlacement(badGuy, mazes);
                                badGuy.ChangeEnemy(DisplayRectangle, enemy);
                            }

                            badGuy.Move(PlayerChar.Direction.Right);
                            CheckForMazeEnemy(Direction.Right, badGuy);
                            
                        }

                        Invalidate();
                        break;

                    case Keys.Right:
                        //move player, check if maze in the way
                        player.Move(PlayerChar.Direction.Right);
                        CheckForMazePlayer(Direction.Right);

                        foreach (var badGuy in enemies)
                        {
                            //check if this enemy will teleport
                            if (badGuy.Teleport())
                            {
                                //generate new position through a new object, use it to save info to enemy in hashset
                                badGuy.ChangeEnemy(DisplayRectangle, null);
                                enemy = CheckEnemyPlacement(badGuy, mazes);
                                badGuy.ChangeEnemy(DisplayRectangle, enemy);
                                

                            }
                            //move enemy, check if maze in the way
                            badGuy.Move(PlayerChar.Direction.Left);
                            CheckForMazeEnemy(Direction.Left, badGuy);
                            

                        }
                        //invalidate so movement is shown
                        Invalidate();
                        break;

                    case Keys.Up:
                        //move player, check if maze in the way
                        player.Move(PlayerChar.Direction.Up);
                        CheckForMazePlayer(Direction.Up);

                        foreach (var badGuy in enemies)
                        {
                            //check if this enemy will teleport
                            if (badGuy.Teleport())
                            {
                                //generate new position through a new object, use it to save info to enemy in hashset
                                badGuy.ChangeEnemy(DisplayRectangle, null);
                                enemy = CheckEnemyPlacement(badGuy, mazes);
                                badGuy.ChangeEnemy(DisplayRectangle, enemy);
                            }
                            //move enemy, check if maze in the way
                            badGuy.Move(PlayerChar.Direction.Down);
                            CheckForMazeEnemy(Direction.Down, badGuy);
                            
                        }

                        Invalidate();
                        break;

                    case Keys.Down:
                        //move player, check if maze in the way
                        player.Move(PlayerChar.Direction.Down);
                        CheckForMazePlayer(Direction.Down);
                        foreach (var badGuy in enemies)
                        {
                            //check if this enemy will teleport
                            if (badGuy.Teleport())
                            {  
                                //generate new position through a new object, use it to save info to enemy in hashset
                                badGuy.ChangeEnemy(DisplayRectangle, null);
                                enemy = CheckEnemyPlacement(badGuy, mazes);
                                badGuy.ChangeEnemy(DisplayRectangle, enemy);
                            }
                            //move enemy, check if maze in the way
                            badGuy.Move(PlayerChar.Direction.Up);
                            CheckForMazeEnemy(Direction.Up, badGuy);
                            
                        }
                        Invalidate();
                        break;


                    case Keys.Space:
                        break;
                }
                    
            }
        }

        /// <summary>
        /// method to generate random number of enemies
        /// </summary>
        public void GenerateEnemies()
        {
            Random random = new Random();
            int enemyLimit = random.Next(4,12);
            for (int i = 0; i < enemyLimit; i++)
            {
                //create enemy, check placement on map and add to hashset
                enemy = new EnemyChar(this.DisplayRectangle);
                enemy = CheckEnemyPlacement(enemy, mazes);
                enemies.Add(enemy);
            }
        }


        /// <summary>
        /// method to check if player move intersects with maze
        /// </summary>
        /// <param name="direction"></param>
        public void CheckForMazePlayer(Direction direction)
        {
            foreach (var maze in mazes)
            {
                if (!maze.MazeRect.IntersectsWith(player.DisplayRect))
                {
                    continue;
                }
                else
                {   //if the maze intersects, move player back in direction they came
                    if (direction == Direction.Left)
                    {
                        player.Move(PlayerChar.Direction.Right);
                    }
                    else if(direction == Direction.Right)
                    {
                        player.Move(PlayerChar.Direction.Left);
                    }
                    else if (direction == Direction.Up)
                    {
                        player.Move(PlayerChar.Direction.Down);
                    }
                    else
                    {
                        player.Move(PlayerChar.Direction.Up);
                    }
                }
            }

        }

        /// <summary>
        /// Method to check if enemy move intersects maze
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="enemy"></param>
        public void CheckForMazeEnemy(Direction direction, EnemyChar enemy)
        {
            foreach (var maze in mazes)
            {
                if (!maze.MazeRect.IntersectsWith(enemy.DisplayRect))
                {
                    continue;
                }
                else
                {
                    //if enemy move intersects maze, move enemy back
                    if (direction == Direction.Left)
                    {
                        enemy.Move(EnemyChar.Direction.Right);
                    }
                    else if (direction == Direction.Right)
                    {
                        enemy.Move(EnemyChar.Direction.Left);
                    }
                    else if (direction == Direction.Up)
                    {
                        enemy.Move(EnemyChar.Direction.Down);
                    }
                    else
                    {
                        enemy.Move(EnemyChar.Direction.Up);
                    }
                }
            }

        }




        /// <summary>
        /// Timer method to control movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            //number to tell program game ending event has occured
            //1 = player eaten
            //2 = bad guy has blocked exit
            int eventToken = 0;

            foreach (var badGuy in enemies)
            {
                //check if this enemy has eaten a player or blocked exit
                if (CheckForPlayerEaten(badGuy))
                {
                    eventToken = 1;
                }
                else if (CheckForEnemyBlocked(badGuy))
                {
                    eventToken = 2;
                }
 
            }
            //if player has reached door object, player wins
            //if any event has happened, restartTimer begins, game restarts
            if (CheckForWinGame())
            {
                DisplayMessage("You have escaped the maze! You win!");
                animationTimer.Stop();
                RestartTimer();
            }
            //If player has been eaten
            else if(eventToken == 1)
            {
                DisplayMessage("You've been eaten by a monster! You lose!");
                animationTimer.Stop();
                RestartTimer();
            }
            //if enemy has reached the door first
            else if(eventToken == 2)
            {
                DisplayMessage("A monster has blocked the exit! You lose!");
                animationTimer.Stop();
                RestartTimer();
            }
            //if no event, continue with game
            else
            {
                Invalidate();
            }
            

        }


        /// <summary>
        /// Method to check if player and enemy intersect
        /// </summary>
        private bool CheckForPlayerEaten(EnemyChar enemy)
        {
            //check if enemy reaches player
            if (enemy.DisplayRect.IntersectsWith(player.DisplayRect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// method to check if enemy has reached door
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        private bool CheckForEnemyBlocked(EnemyChar enemy)
        {
            //check if enemy reaches player
            if (enemy.DisplayRect.IntersectsWith(door.DisplayRect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// method to determine if player has reached door
        /// </summary>
        /// <returns></returns>
        private bool CheckForWinGame()
        {
            if(player.DisplayRect.IntersectsWith(door.DisplayRect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// method to display message when game ends
        /// </summary>
        private void DisplayMessage(String messageToDisplay)
        {
            //determine placement and size of window
            int messageRectWidth = DisplayRectangle.Width / 2;
            int messageRectHeight = DisplayRectangle.Height / 2;
           
            int messageRectX = DisplayRectangle.Width / 4;
            int messsageRectY = DisplayRectangle.Height / 4;
            
            //Create FontFamily and font for display messages
            FontFamily fontFamily = new FontFamily("Courier New");
            Font font = new Font(fontFamily, 20, FontStyle.Bold);
            //Create StringFormat to center text
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            
            //Create message rectangle
            Rectangle MessageRect = new Rectangle(messageRectX, messsageRectY, messageRectWidth, messageRectHeight);
            graphics = this.CreateGraphics();
            //Draw message box
            graphics.FillRectangle(Brushes.Yellow, MessageRect);
            //Draw message
            graphics.DrawString(messageToDisplay, font, Brushes.Black, MessageRect, stringFormat);

        }

        /// <summary>
        /// timer method to restart game
        /// </summary>
        private void RestartTimer()
        {
            System.Timers.Timer restartTimer = new System.Timers.Timer(5000);
            //add event to timer
            restartTimer.Elapsed += OnTimedEventTwo;
            restartTimer.AutoReset = true;
            restartTimer.Enabled = true;


        }

        /// <summary>
        /// method to restart application
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEventTwo(Object source, ElapsedEventArgs e)
        {
            Application.Restart();
        }

        /// <summary>
        /// method to create player object with correct coordinates
        /// </summary>
        /// <param name="player"></param>
        /// <param name="mazes"></param>
        /// <returns></returns>

        public PlayerChar CheckPlayerPlacement(PlayerChar player, HashSet<Maze> mazes)
        {
        LoopStart:
            foreach (var maze in mazes)
            {
                if (!player.DisplayRect.IntersectsWith(maze.MazeRect))
                {
                    continue;
                }
                else
                {
                    //if intersect, create a new player object, check against all maze pieces again
                    player = new PlayerChar(this.DisplayRectangle);
                    goto LoopStart;
                }
            }
            return player;
        }

        /// <summary>
        /// method to create enemy object with correct coordinates
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="mazes"></param>
        /// <returns></returns>
        public EnemyChar CheckEnemyPlacement(EnemyChar enemy, HashSet<Maze> mazes)
        {
   
        LoopStart:
            foreach (var maze in mazes)
            {
                if (!enemy.DisplayRect.IntersectsWith(maze.MazeRect))
                {
                    //keep enemy from spawning too close to door
                    if ((Math.Abs(door.CurrentX - enemy.CurrentX) > 200) || (Math.Abs(door.CurrentY - enemy.CurrentY) > 200))
                    {
                        //keep enemy from spawning too close to player
                        if ((Math.Abs(player.CurrentX - enemy.CurrentX) > 200) || (Math.Abs(player.CurrentY - enemy.CurrentY) > 200))
                        {
                            continue;
                        }
                    }
                    //create new enemy object if all conditions not met; restart compare
                    else
                    {
                        enemy = new EnemyChar(this.DisplayRectangle);
                        goto LoopStart;
                    }
                }
                else
                {
                    enemy = new EnemyChar(this.DisplayRectangle);
                    goto LoopStart;
                }
            }
            return enemy;
        }

        /// <summary>
        /// method to return a ExitDoor object with correct coordinates
        /// </summary>
        /// <param name="door"></param>
        /// <param name="mazes"></param>
        /// <returns></returns>
        public ExitDoor CheckDoorPlacement(ExitDoor door, HashSet<Maze> mazes)
        {
        LoopStart:
            foreach (var maze in mazes)
            {
                if (!door.DisplayRect.IntersectsWith(maze.MazeRect))
                {
                    //Check if door is too close to player
                    if ((Math.Abs(door.CurrentX - player.CurrentX) > 200) || (Math.Abs(door.CurrentY - player.CurrentY) > 200))
                    {
                        continue;
                    }
                    //If not all conditions are met, create new object and restart compare
                    else
                    {
                        door = new ExitDoor(this.DisplayRectangle);
                        //call to return to LoopStart flag - restart foreach loop
                        goto LoopStart;
                    }   
                }
                else
                {
                    door = new ExitDoor(this.DisplayRectangle);
                    //call to return to LoopStart flag - restart foreach loop
                    goto LoopStart;
                }
            }
            return door;
        }

    }
    
}
