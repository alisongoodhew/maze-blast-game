using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameLib
{/// <summary>
/// Maze object to create maze
/// </summary>
    public class Maze
    {
        //declare dimension variables
        public int height;
        public int width;
        public int mazeX;
        public int mazeY;
        public Rectangle MazeRect;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="canvas"></param>
        public Maze(Rectangle canvas) { }

       /// <summary>
       /// Constructor with all dimensions
       /// </summary>
       /// <param name="mazeX"></param>
       /// <param name="mazeY"></param>
       /// <param name="width"></param>
       /// <param name="height"></param>
        public Maze(int mazeX, int mazeY, int width, int height)
        {
            this.mazeX = mazeX;
            this.mazeY = mazeY;
            this.width = width;
            this.height = height;
            //Create hitbox
            MazeRect = new Rectangle(mazeX, mazeY, width, height);
            
        }

        /// <summary>
        /// Draw method
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.SandyBrown, MazeRect);
        }

        /// <summary>
        /// Method to create all maze walls and save to Hashset
        /// </summary>
        /// <param name="DisplayRectangle"></param>
        /// <param name="newMaze"></param>
        /// <param name="mazes"></param>
        public void DrawMaze(Rectangle DisplayRectangle, Maze newMaze, HashSet<Maze> mazes)
        {
            //declare dimensions
            int mazeWidth = DisplayRectangle.Width - 20;
            int mazeHeight = DisplayRectangle.Height - 45;
            int outerMazeWallThickness = 35;
            int innerMazeWallThickness = 15;
            int minimumMazeLeft = outerMazeWallThickness + 50;
            int horizontalWidth = 80;
            //Create all walls
            //outer walls
            newMaze = new Maze(10, 10, mazeWidth, outerMazeWallThickness);
            mazes.Add(newMaze);
            newMaze = new Maze(10, mazeHeight, mazeWidth, outerMazeWallThickness);
            mazes.Add(newMaze);
            newMaze = new Maze(10, 10, outerMazeWallThickness, mazeHeight);
            mazes.Add(newMaze);
            newMaze = new Maze(mazeWidth - 25, 10, outerMazeWallThickness, mazeHeight);
            mazes.Add(newMaze);
            //vertical interior walls
            //1
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft, 10, innerMazeWallThickness, mazeHeight / 2);
            mazes.Add(newMaze);
            ////2
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 80, 130, innerMazeWallThickness, (int)(mazeHeight / 1.5));
            mazes.Add(newMaze);
            ////3
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 160, 10, innerMazeWallThickness, (int)(mazeHeight / 1.5));
            mazes.Add(newMaze);
            ////4
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 240, mazeHeight / 2, innerMazeWallThickness, (int)(mazeHeight / 2));
            mazes.Add(newMaze);
            //5
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 320, 130, innerMazeWallThickness, (int)(mazeHeight / 2));
            mazes.Add(newMaze);
            //6
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 240, 130, innerMazeWallThickness, (int)(mazeHeight / 4));
            mazes.Add(newMaze);
            ////7
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 400, 210, innerMazeWallThickness, (int)(mazeHeight / 1.5));
            mazes.Add(newMaze);
            ////8
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 480, 130, innerMazeWallThickness, (int)(mazeHeight / 1.5));
            mazes.Add(newMaze);
            ////9
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 560, mazeHeight / 3, innerMazeWallThickness, (int)(mazeHeight / 3));
            mazes.Add(newMaze);
            //10
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 560, mazeHeight / 9, innerMazeWallThickness, (int)(mazeHeight / 3));
            mazes.Add(newMaze);
            //11
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 560, mazeHeight / 9, innerMazeWallThickness, (int)(mazeHeight - 80));
            mazes.Add(newMaze);
            //12
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 625, mazeHeight / 9, innerMazeWallThickness, (int)(mazeHeight / 7));
            mazes.Add(newMaze);
            //13
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 705, mazeHeight / 9, innerMazeWallThickness, (int)(mazeHeight / 5) + 25);
            mazes.Add(newMaze);
            //14
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 705, mazeHeight / 2 - 80, innerMazeWallThickness, (int)(mazeHeight / 3) + 25);
            mazes.Add(newMaze);
            //15
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 790, mazeHeight / 3, innerMazeWallThickness, (int)(mazeHeight / 3));
            mazes.Add(newMaze);
            //16
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 870, mazeHeight / 9 - 80, innerMazeWallThickness, (int)(mazeHeight / 6) + 40);
            mazes.Add(newMaze);
            ////17
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 870, mazeHeight / 3, innerMazeWallThickness, (int)(mazeHeight / 2) + 70);
            mazes.Add(newMaze);
            //18
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 950, mazeHeight / 4 - 120, innerMazeWallThickness, (int)(mazeHeight / 2) + 70);
            mazes.Add(newMaze);
            //19
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1030, mazeHeight / 4 - 200, innerMazeWallThickness, (int)(mazeHeight / 2) + 70);
            mazes.Add(newMaze);
            //20
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1190, mazeHeight / 4 - 120, innerMazeWallThickness, (int)(mazeHeight / 2) + 70);
            mazes.Add(newMaze);
            //21
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1190, mazeHeight / 2 + 260, innerMazeWallThickness, (int)(mazeHeight / 6));
            mazes.Add(newMaze);
            //22
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1270, mazeHeight / 2 - 120, innerMazeWallThickness, (int)(mazeHeight / 2) + 35);
            mazes.Add(newMaze);
            //23
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1270, 45, innerMazeWallThickness, (int)(mazeHeight / 4) + 1);
            mazes.Add(newMaze);
            //24
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1430, 45, innerMazeWallThickness, (int)(mazeHeight / 2) + 80);
            mazes.Add(newMaze);
            //25
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1510, 160, innerMazeWallThickness, (int)(mazeHeight / 2) + 240);
            mazes.Add(newMaze);
            //26
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1590, 45, innerMazeWallThickness, (int)(mazeHeight / 2) + 260);
            mazes.Add(newMaze);


            //horizontal interior walls
            //1
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft, 130, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //2
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 160, 130, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //3
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 320, 130, horizontalWidth * 2, innerMazeWallThickness);
            mazes.Add(newMaze);
            //4
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 320, mazeHeight - 129, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //5
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 480, mazeHeight / 3, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //6
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 560, 105, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //7
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 560, 105, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //8
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 560, mazeHeight / 3, horizontalWidth * 3, innerMazeWallThickness);
            mazes.Add(newMaze);
            //9
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 560, mazeHeight / 2 - 80, horizontalWidth * 2, innerMazeWallThickness);
            mazes.Add(newMaze);
            //10
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 790, mazeHeight / 2 + 150, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //11
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 870, mazeHeight / 2, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //12
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 870, mazeHeight / 2 + 260, horizontalWidth * 4, innerMazeWallThickness);
            mazes.Add(newMaze);
            //13
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1030, mazeHeight / 3 + 80, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //14
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1110, mazeHeight / 3 - 10, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //15
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1030, mazeHeight / 3 - 200, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //16
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1195, mazeHeight / 3 - 50, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //17
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1275, mazeHeight / 3 + 42, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //18
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1275, mazeHeight / 2 + 386, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //19
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1460, mazeHeight / 2 + 386, horizontalWidth * 2, innerMazeWallThickness);
            mazes.Add(newMaze);
            //20
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1595, mazeHeight / 2 + 200, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //21
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1595, mazeHeight / 2, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);
            //22
            newMaze = new Maze(outerMazeWallThickness + minimumMazeLeft + 1680, mazeHeight / 2 - 250, horizontalWidth, innerMazeWallThickness);
            mazes.Add(newMaze);

        }
    }
}
