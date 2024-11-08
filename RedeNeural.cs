using Accord.Genetic;
using Accord.IO;
using Accord.MachineLearning;
using Accord.Neuro;
using Accord.Neuro.Learning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeuralGame
{
  public class RedeNeural
  {
    public bool Treinada { get; set; } = false; 

    public ActivationNetwork network { get; set; } = new ActivationNetwork(new SigmoidFunction(), 5, 20, 2);

    public void TreinamentoRedeNeural(double[][] entradas, double[][] saidas)
    {
      var teacher = new BackPropagationLearning(network);
      teacher.RunEpoch(entradas, saidas);

      network.Save(@"RedeNeuralTreinada.txt");

      Treinada = true;
    }
    public double[] Execute(double[] input)
    {
      var result = network.Compute(input);
      return result;
    }

  }
  
}
