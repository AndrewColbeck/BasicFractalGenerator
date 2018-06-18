// Basic Fractal Generator, by Andrew Colbeck © 2018, all rights reserved.
// The Purpose of this Program is to generate a Fractal-like structure
// consisting of multi-colored circles, through the implementation of a 
// recursive function.

// This Program builds on code provided by Dr. Prince Kurumthodathu Surendran.

#include <stdio.h>
#include <stdlib.h>
#include "SwinGame.h"
#include "stdbool.h"

void draw_recursive_Circle(float x, float y, float radius) 
{
  draw_circle(random_color(), x, y, radius);
  // refresh_screen(60); // Refreshing after each Circle will
  // significantly increase execution times

  if(radius > 8) 
  {
  	// For practical purposes, the radius of all drawn circles is capped at 8 pixels.
  	// This violates the nature of a true Fractal, however the principle is here and easily adapted.

    draw_recursive_Circle(x, y  + radius/2, radius/2);
    draw_recursive_Circle(x, y - radius/2, radius/2);
    draw_recursive_Circle(x + radius/2, y, radius/2);
    draw_recursive_Circle(x - radius/2, y, radius/2);
  }
}

int main()
{	
	float x=300, y=300, rad = 200.0;
	open_graphics_window("Fractal Generator",600,600);
	clear_screen(ColorBlack);
	
	do
	{
	  draw_recursive_Circle(x,y,rad);
	  delay(20);
	  refresh_screen(60);	
	}
	while(!(window_close_requested()));
}