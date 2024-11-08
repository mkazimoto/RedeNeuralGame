using Accord.Neuro;
using RedeNeuralGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RedeNeuralGame
{
  public partial class FormMain : Form
  {
    public Game Game { get; set; } = new Game();

    public List<double[]> listInput = new List<double[]>();
    public List<double[]> listOutput = new List<double[]>();

    public RedeNeural RedeNeural { get; set; } = new RedeNeural();

    public double[] Output { get; set; } = new double[2] { 0.0, 0.0 };


    public bool ModoTreinamento = true;

    public FormMain()
    {
      InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {

      Game.Width = pictureBoxOutput.Width;
      Game.Height = pictureBoxOutput.Height;

      Game.Init();
     
      // Carrega a rede neural treinada
      if (File.Exists(@"RedeNeuralTreinada.txt"))
      {
        RedeNeural.network = (ActivationNetwork)ActivationNetwork.Load(@"RedeNeuralTreinada.txt");
        RedeNeural.Treinada = true;
        ModoTreinamento = false;
      } 

      Task.Run(() =>
      {
        while (true)
        {
          if (ModoTreinamento)
          {
            listInput.Add(GetEntradas());
            listOutput.Add(GetSaidas());

            Game.Run();
          }
          else
          {
            if (RedeNeural.Treinada)
            {
              Output = RedeNeural.Execute(GetEntradas());

              //if (Output[0] < 0.3 &&
              //    Output[1] < 0.3)
              //{
              //  Game.Player.Speed = 0;
              //}
              //else
              if (Output[0] >= Output[1])
              {
                Game.Player.Speed = Ball.Speed;
              }
              else
              {
                Game.Player.Speed = -Ball.Speed;
              }

              Game.Run();
            }
          }

          Thread.Sleep(1);

          pictureBoxOutput.Invalidate();
        }
      });
    }

    private double[] GetEntradas()
    {
      return new double[] { 
        Game.Ball.X / Game.Width, 
        Game.Ball.Y / Game.Height, 
        Game.Player.X / Game.Width, 
        Game.Ball.SpeedX > 0 ? 1.0 : -1.0, 
        Game.Ball.SpeedY > 0 ? 1.0 : -1.0
      };
    }

    private double[] GetSaidas()
    {
      return new double[] {
        Game.Player.Speed > 0 ? 1.0 : 0.0,  // Direita
        Game.Player.Speed < 0 ? 1.0 : 0.0   // Esquerda
      };
    }


    private void pictureBoxOutput_Paint(object sender, PaintEventArgs e)
    {
      Game.Draw(e.Graphics);

      if (ModoTreinamento)
        e.Graphics.DrawString($"HUMANO", Font, Brushes.Blue, 10, 10);
      else
        e.Graphics.DrawString($"MÁQUINA", Font, Brushes.Red, 10, 10);
      e.Graphics.DrawString($"Modo Treinamento: {ModoTreinamento} (Pressione ESC)", Font, Brushes.White, 10, 30);
      e.Graphics.DrawString($"Total entradas: {listInput.Count}", Font, Brushes.White, 10, 50);
      e.Graphics.DrawString($"Velocidade: {Ball.Speed} (Setas para cima / para baixo)", Font, Brushes.White, 10, 70);

      if (!ModoTreinamento)
      {
        e.Graphics.DrawString($"Saída Direita: {Output[0]}", Font, Brushes.White, 10, 110);
        e.Graphics.DrawString($"Saída Esquerda: {Output[1]}", Font, Brushes.White, 10, 130);
      }
    }

    private void FormMain_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Left)
      {
        Game.Player.Speed = -Ball.Speed;
      }
      else
      if (e.KeyCode == Keys.Right)
      {
        Game.Player.Speed = Ball.Speed;
      }
      else
      if (e.KeyCode == Keys.Up)
      {
        if (Ball.Speed < 30)
        {
          Ball.Speed++;
          UpdateSpeed();
        }
      }
      else
      if (e.KeyCode == Keys.Down)
      {
        if (Ball.Speed > 0)
        {
          Ball.Speed--;
          UpdateSpeed();
        }
      }
      else
      if (e.KeyCode == Keys.Escape)
      {
        if (ModoTreinamento)
        {
          ModoTreinamento = false;
          Game.Init();
          Game.Player.Color = Brushes.Red;
          Game.Pause = true;
          Output = new double[2] { 0.0, 0.0 };

          var formWait = new FormWait();
          formWait.Action = () =>
          {
            RedeNeural.TreinamentoRedeNeural(listInput.ToArray(), listOutput.ToArray());
          };
          if (formWait.ShowDialog() == DialogResult.OK)
          {
            Game.Pause = false;
          }          
        }
        else
        {
          listInput = new List<double[]>();
          listOutput = new List<double[]>();
          Game.Init();
          Game.Player.Color = Brushes.Blue;
          ModoTreinamento = true;            
        }
      }
    }

    private void UpdateSpeed()
    {
      if (Game.Ball.SpeedX > 0)
        Game.Ball.SpeedX = Ball.Speed;
      else
        Game.Ball.SpeedX = -Ball.Speed;

      if (Game.Ball.SpeedY > 0)
        Game.Ball.SpeedY = Ball.Speed;
      else
        Game.Ball.SpeedY = -Ball.Speed;

      if (Game.Player.Speed == 0)
        Game.Player.Speed = 0;
      else
      if (Game.Player.Speed > 0)
        Game.Player.Speed = Ball.Speed;
      else
        Game.Player.Speed = -Ball.Speed;  
    }

    private void FormMain_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Left)
      {
        Game.Player.Speed = 0;
      }
      else
      if (e.KeyCode == Keys.Right)
      {
        Game.Player.Speed = 0;
      }
    }

    private void FormMain_Resize(object sender, EventArgs e)
    {
      Game.Width = pictureBoxOutput.Width;
      Game.Height = pictureBoxOutput.Height;
      Game.Player.Init();
      Game.Player.Width = Width * 15 / 100;
    }
  }
}