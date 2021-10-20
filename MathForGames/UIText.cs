using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    
    class UIText : Actor
    {
        public string Text;
        public int Width;
        public int Height;
        private Font Font;
        public int FontSize;

        public UIText(float x, float y, string name, Color color, int width, int height, int fontsize, string text = "")
            : base ('\0', x, y, color, name)
        {
            Text = text;
            Width = width;
            Height = height;
            FontSize = fontsize;
            Font = Raylib.LoadFont("resources/fonts/alagrad.png");

        }

        public override void Draw()
        {
            //Create a new rectangel that willa ct as the borders of the text box
            Rectangle textBox = new Rectangle(Postion.X, Postion.Y, Width, Height);
            //Draw text box
            Raylib.DrawTextRec(Font, Text, textBox, FontSize, 1, true, Icon.Color);
        }
    }
}
