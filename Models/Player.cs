using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeuralGame.Models
{
  public class Player
  {
    public Game Game { get; set; }  

    public Brush Color { get; set; } = Brushes.Red; 

    public double X { get; set; }
    public double Y { get; set; }

    public double Width { get; set; } = 200;
    public double Height { get; set; } = 20;

    public double Speed { get; set; } = 0;

    public void Init()
    {
      X = 50;
      Y = Game.Height - 30;
      //Y = 30;
      Speed = 0;
      Width = Game.Width * 15 / 100;
    }

    public void Draw(Graphics g)
    {
      g.FillRectangle(Color, (int)(X- Width/2), (int)(Y -Height/2), (int)Width, (int)Height);
      g.DrawRectangle(Pens.Black, (int)(X - Width / 2), (int)(Y - Height / 2), (int)Width, (int)Height);
    }

    public void Move()
    {
      X += Speed;

      if (X + Width / 2 > Game.Width) 
        X = Game.Width - Width / 2;

      if (X - Width / 2 < 0)
        X = Width / 2;

    }
  }
}
