///////////////////////////////////////////////////////////////////////////////////////////////////
//Trent Frey GOL 3/7/18
//Create Conways game of life
//First Part,create random rectangles and put them on the panle, some alive=yellow some dead =white
//////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frey_GOL
{
    public partial class GOLBoard : Form
    {
        private Graphics gr; //create the grapics for the panel and rectangles
        private Pen pen; //create the pen to outline the rectangles
        private Brush brush;//create a brush to fill in the color of the rectangles

        public const int RECT_HEIGHT = 20; //height for the rectangle
        public const int RECT_WIDTH = 20;  //width for the rectangle
        public const int ROWS = 42;//length of rectangles
        public const int COLS = 62;//vertical length of rectagles

        private GOLCell[,] board; //array for board

        public Random gen;//random genorator


        public GOLBoard()
        {
            InitializeComponent();

            gr = panGol.CreateGraphics();  //create GFX for panel
            pen = new Pen(Color.Black);    //create out line for the object using black color
            brush = new SolidBrush(Color.White); // create color to fill in the object
            board = new GOLCell[ROWS, COLS]; //2d array of GOLCells that shows the board
            gen = new Random();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            createGrid(true);
            updateGrid();

        }

        public void createGrid(bool genRandom)
        {
            for (int i = 0; i < ROWS; i++)  // for loop to go through 2d array
            {
                for (int j = 0; j < COLS; j++)//nested for loop to go through 2d array
                {

                    Rectangle aRectangle = new Rectangle(j * RECT_WIDTH, i * RECT_HEIGHT, RECT_WIDTH, RECT_HEIGHT);//rectangle in the memory


                    gr.FillRectangle(brush, aRectangle); //use brush to fill rectangle white
                    gr.DrawRectangle(pen, aRectangle); //draw rectangle using the black pen

                    int alive; // set alive to 0 witch is dead
                    board[i, j] = new GOLCell(); // new GOLCell object

                    //Add GOLCell object to 2d array
                    board[i, j].Rect = aRectangle;

                    if (genRandom == false)
                    {
                        alive = 0;
                    }
                    else
                    {
                        alive = DetermineCellLife();
                    }

                    board[i, j].IsAlive = alive;


                }
            }





        }

        private void btnGenGrid_Click(object sender, EventArgs e)
        {
            createGrid(false); //calls createGide and creates emtpy grid
        }

        public int DetermineCellLife()
        {

            int dOa = gen.Next(0, 2);//random num 0,1 to find if dead or alive cell


            return dOa;





        }

        public void updateGrid()
        {
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);//Create Brushes for color rect
            SolidBrush whiteBruish = new SolidBrush(Color.White);

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    Rectangle aRectangle = new Rectangle(j * RECT_WIDTH, i * RECT_HEIGHT, RECT_WIDTH, RECT_HEIGHT); //create rectangle
                    if (board[i, j].IsAlive == 0)
                    {
                        gr.FillRectangle(yellowBrush, aRectangle); //if isAlive is ==0 its alive
                    }
                    else
                    {
                        gr.FillRectangle(whiteBruish, aRectangle); //if isAlive is =0 the dead
                    }

                    gr.DrawRectangle(pen, aRectangle);
                }
            }



        }

        public int GetLivingNeighbors(int x, int y)   //part 2 ageing stuffs
        {
            int count = 0;
            for(int i = -1; i <= 1; i++)
            {
                for(int j=-1;j<=1;j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    count += board[x+i, y+j].IsAlive;
                        
                }
            }
          
         
            return count;
        }


    }


    }
