using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeuralGame.Models
{
  public class Ball
  {
    public static double Speed { get; set; } = 3.0;

    public Game Game { get; set; }

    public double X { get; set; }
    public double Y { get; set; }

    public double Size { get; set; } = 30;

    public double SpeedX { get; set; }
    public double SpeedY { get; set; }


    public void Init()
    {
      X = Game.Player.X;
      Y = Game.Player.Y - Game.Player.Height / 2 - Size / 2;
      SpeedX = Ball.Speed;
      SpeedY = -Ball.Speed;
    }

    public void Draw(System.Drawing.Graphics g)
    {
      g.FillEllipse(Brushes.White, (int)(X-Size / 2), (int)(Y - Size / 2), (int)Size, (int)Size);
      g.DrawEllipse(Pens.Black, (int)(X - Size / 2), (int)(Y - Size / 2), (int)Size, (int)Size);
    }
    public void Move()
    {
      X += SpeedX;
      Y += SpeedY;

      if (X + Size / 2 > Game.Width)
      {
        X = Game.Width - Size / 2;
        SpeedX *= -1;
      }

      if (X - Size / 2 < 0)
      {
        X = Size / 2;
        SpeedX *= -1;
      } 

      if (Y + Size / 2 > Game.Height)
      {
        Y = Game.Height - Size / 2;
        SpeedY *= -1;
      }

      if (Y - Size / 2 < 0)
      {
        Y = Size / 2;
        SpeedY *= -1;
      }
    }
  }
}
