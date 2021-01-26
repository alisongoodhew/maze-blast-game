using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Assignment4
{
    /// <summary>
    /// create form to display first - show instructions
    /// </summary>
    public partial class TitleForm : Form
    {
        Graphics graphics;
        public TitleForm()
        {
            InitializeComponent();
        }

        private void titleForm_Load(object sender, EventArgs e)
        {
            //starts maximized
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void titleForm_Paint(object sender, PaintEventArgs e)
        {
            //declare dimensions of message box
            int messageRectWidth = DisplayRectangle.Width / 2;
            int messageRectHeight = DisplayRectangle.Height / 2;

            int messageRectX = DisplayRectangle.Width / 4;
            int messsageRectY = DisplayRectangle.Height / 4;

            //declare message to be displayed
            string messageToDisplay = "Maze Blast! \n Get to the door before the monsters find it... or you. \n Warning: The monsters can teleport! \n" +
                    "Hit any key to preview the maze, Then press [space] to begin!";


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
      /// method to respond to user pressing any key
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void TitleForm_KeyDown(object sender, KeyEventArgs e)
        {
            //hide title screen, show game screen
            this.Hide();
            GameForm game = new GameForm();
            game.Show();
        }
        
    
        }
    }
