using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Medallion;

namespace GameLib
{
    //abstract class for all non-maze objects
    public abstract class ScreenObject
    {
        //create player/enemy width/height
        protected readonly int width = 40;
        protected readonly int height = 40;
        public Rectangle DisplayRect;
        //image object to hold sprites
        protected Image image;

        /// <summary>
        /// enum for all directions objects can move
        /// </summary>
        public enum Direction
        {
            Left, Right, Up, Down
        }
        
        /// <summary>
        /// methods to return the current position of the characters
        /// </summary>
        public int CurrentX
        {
            get { return DisplayRect.X; }
        }
        public int CurrentY
        {
            get { return DisplayRect.Y; }
        }




        /// <summary>
        /// abstract Draw Method
        /// </summary>
        /// <param name="graphics"></param>
        public abstract void Draw(Graphics graphics);



        /// <summary>
        /// method to change character shape if win - WIP
        /// </summary>
        /// <param name="graphics"></param>
        public void DrawWinner(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Yellow, DisplayRect);
        }

        /// <summary>
        /// method to change character shape if lose - WIP
        /// </summary>
        /// <param name="graphics"></param>
        public void DrawLoser(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.BurlyWood, DisplayRect);
        }





    }



}
