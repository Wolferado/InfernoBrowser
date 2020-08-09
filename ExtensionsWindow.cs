using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfernoBrowser
{
    public partial class ExtensionsWindow : Form
    {
        public ExtensionsWindow()
        {
            InitializeComponent();
            InitializeExtWin();
        }

        public void InitializeExtWin()
        {
            MaximizeBox = false;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.FromArgb(232, 70, 21);
            this.BackgroundImage = Properties.Resources.ExtForm_Shape;
        }
    }
}
