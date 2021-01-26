using Medallion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class PlayerChar : ScreenObject
    {

        /// <summary>
        /// Player character constructor
        /// </summary>
        public PlayerChar(Rectangle canvas)
        {
            //create random coordinates
            int playerX = Rand.Next((canvas.Left + 45), (canvas.Right - 49));
            int playerY = Rand.Next((canvas.Top + 45), (canvas.Bottom - 39));
            //create hitbox
            DisplayRect = new Rectangle(playerX, playerY, width, height);

        }
        
        
         /// <summary>
        /// draw player character method
        /// </summary>
        public override void Draw(Graphics graphics)
        {
            Image image = Image.FromFile("Images\\PlayerChar.png");
            graphics.DrawImage(image, DisplayRect);
        }

        /// <summary>
        /// move player character method
        /// </summary>
        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    this.DisplayRect.X -= 15;
                    break;
                case Direction.Right:
                    this.DisplayRect.X += 15;
                    break;
                case Direction.Up:
                    this.DisplayRect.Y -= 15;
                    break;
                case Direction.Down:
                    this.DisplayRect.Y += 15;
                    break;


            }
        }
    }
}
