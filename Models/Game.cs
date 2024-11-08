using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeuralGame.Models
{
  public class Game
  {
    public double Width { get; set; } 

    public double Height { get; set; }

    public Ball Ball { get; set; }

    public Player Player { get; set; } 

    public Random Random { get; set; } = new Random();

    public Boolean Pause { get; set; } = false;

    public Game()
    {
      Player = new Player()
      {
        Game = this
      };

      Ball = new Ball()
      {
        Game = this
      };
    }

    public void Init()
    {
      Player.Init();
      Ball.Init(); 
    }

    public void Run()
    {
      if (Pause)
        return;

      Ball.Move();
      Player.Move();

      // Colisão bola com jogador
      if (Ball.Y + Ball.Size / 2 > Player.Y - Player.Height / 2 &&
          Ball.Y - Ball.Size / 2 < Player.Y + Player.Height / 2 &&
          Ball.X + Ball.Size / 2 > Player.X - Player.Width / 2 &&
          Ball.X - Ball.Size / 2 < Player.X + Player.Width / 2)
      {
        Ball.Y = Player.Y - Player.Height / 2 - Ball.Size / 2;
        Ball.SpeedX = Random.Next(2) == 1 ? Ball.Speed : -Ball.Speed;
        Ball.SpeedY *= -1;
      }
    }

    public void Draw(System.Drawing.Graphics g)
    {
      Ball.Draw(g);
      Player.Draw(g);
    }

  }
}
