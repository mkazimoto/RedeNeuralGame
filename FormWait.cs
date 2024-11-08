using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedeNeuralGame
{
  public partial class FormWait : Form
  {
    public Action Action { get; set; }

    public FormWait()
    {
      InitializeComponent();
    }

    private void FormWait_Load(object sender, EventArgs e)
    {
      var task = Task.Run(() =>
      {
        Action();

        this.Invoke(new Action(() =>
        {
          DialogResult = DialogResult.OK;
          this.Close();
        }));
      });


      

    }
  }
}
