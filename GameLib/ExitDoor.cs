using Medallion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    /// <summary>
    /// Exit Door object
    /// </summary>
    public class ExitDoor : ScreenObject
    {
        //declare size
        private new readonly int height = 80;
        private new readonly int width = 50;
        //declare image for sprite
        


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="canvas"></param>
        public ExitDoor(Rectangle canvas)
        {
            int doorX = Rand.Next((canvas.Left + 20), (canvas.Right - 20));
            int doorY = Rand.Next((canvas.Top + 20), (canvas.Bottom - 20));

            DisplayRect = new Rectangle(doorX, doorY, width, height);

        }

        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            //take image from file, display
            image = Image.FromFile("Images/Door.png");
            graphics.DrawImage(image, DisplayRect);
        }

        



    }
}
