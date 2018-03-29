using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frey_GOL
{
    class GOLCell
    {   //creation of the rectangle for the cell
        private System.Drawing.Rectangle rect;
        //use this int to varify if cell is alive or dead
        private int isAlive;
        

        public Rectangle Rect { get => rect; set => rect = value; }
        public int IsAlive { get => isAlive; set => isAlive = value; }
        
        



        //constructor for the GOLCell class
        public GOLCell()
        {
            //creates the rectangle
            rect = new Rectangle();
            // if isAlive=1 then its alive if isAlive=0 then its dead
            isAlive = 0;
            
                        
        }
        private Rectangle cell;
        private int fututureState;
        private int age;
    }
    
    
}
