using System;
using SwinGameSDK;
using System.Diagnostics;

namespace MyGame
{
    public class GameMain
    {
        static void draw_recursive_Circle (int color, int x, int y, int radius){
            SwinGame.FillCircle (SwinGame.RandomRGBColor ((byte)color), x, y, radius);   
            if (radius > 8) { // Recursively draw a Circle (limited to 8 pixels)
                radius = radius / 2;
                draw_recursive_Circle (color, x, y + radius, radius);
                draw_recursive_Circle (color, x, y - radius, radius);
                draw_recursive_Circle (color, x + radius, y, radius);
                draw_recursive_Circle (color, x - radius, y, radius);
            }
        }
        
        public static void Main() {
            // Set Variables
            Stopwatch stopwatch = new Stopwatch ();
            int x=300, y=300, rad = 300;
            int color = 10; // COLOR RANGE (10 = pastels, 250 = Bold colors)
            int refreshRate = 25;
            
            //Open the program window
            SwinGame.OpenGraphicsWindow("Fractal Generator", 600, 600);
            SwinGame.ClearScreen(Color.Black);
               
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested()) {
                stopwatch.Start (); // Stopwatch regulates the Screen Refresh Rate
                draw_recursive_Circle(color, x,y,rad);
                SwinGame.RefreshScreen ();
                stopwatch.Stop ();
                if (stopwatch.ElapsedMilliseconds < refreshRate)
                    SwinGame.Delay ((uint)(refreshRate - stopwatch.ElapsedMilliseconds));
                SwinGame.ProcessEvents(); //Fetch the next batch of UI interaction
                stopwatch.Reset ();
            }
        }
    }
}