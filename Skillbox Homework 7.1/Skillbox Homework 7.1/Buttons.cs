using System;
using System.Collections.Generic;
using System.Text;

namespace Skillbox_Homework_7._1
{
    struct Buttons
    {
        public string Text { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Buttons(string text, int positionX, int positionY)
        {
            Text = text;
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
