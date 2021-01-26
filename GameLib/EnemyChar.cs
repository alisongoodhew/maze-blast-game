using Medallion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class EnemyChar : ScreenObject
    {
        //set speed
        public int speed = 15;
        Image imageMonster;



    /// <summary>
    /// Constructor for EnemyChar
    /// </summary>
    /// <param name="canvas"></param>
    /// enemyX and Y will have to be set to random
    public EnemyChar(Rectangle canvas)
        {
            //random x/y coordinates
            int enemyX = Rand.Next((canvas.Left + 40), (canvas.Right - 30));
            int enemyY = Rand.Next((canvas.Top + 15), (canvas.Bottom - 32));
            //rectangle hitbox
            DisplayRect = new Rectangle(enemyX, enemyY, width, height);

        }


        /// <summary>
        /// draw player character method
        /// </summary>
        public override void Draw(Graphics graphics)
        {
            imageMonster = Image.FromFile("Images\\EnemyChar.png");
            graphics.DrawImage(imageMonster, DisplayRect);
        }


        /// <summary>
        /// moth method
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Direction direction)
        {
            //switch statement for each move the player makes - enemy makes opposite
            switch (direction)
            {
                case Direction.Left:
                    this.DisplayRect.X -= speed;
                    break;
                case Direction.Right:
                    this.DisplayRect.X += speed;
                    break;
                case Direction.Up:
                    this.DisplayRect.Y -= speed;
                    break;
                case Direction.Down:
                    this.DisplayRect.Y += speed;
                    break;
            }
        }

        /// <summary>
        /// method to determine id enemy will teleport this turn
        /// </summary>
        /// <returns></returns>
        public bool Teleport()
        {
            //1/75 chance of teleporting per turn
            int chance = Rand.Next(0, 75);
            if(chance == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// method to change enemies' x/y coordinates while teleporting
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="enemy"></param>
        public void ChangeEnemy(Rectangle canvas, EnemyChar enemy)
        {
            //for first check - no previous enemy object created, generate random coordinates
            if (enemy == null)
            {
                this.DisplayRect.X = Rand.Next((canvas.Left + 40), (canvas.Right - 30));
                this.DisplayRect.Y = Rand.Next((canvas.Top + 15), (canvas.Bottom - 32));
            }
            //if an enemy has been created and validated, change this enemy object's coordinates to match theirs
            else
            {
                this.DisplayRect.X = enemy.DisplayRect.X;
                this.DisplayRect.Y = enemy.DisplayRect.Y;

            }
        }

}
    
}
