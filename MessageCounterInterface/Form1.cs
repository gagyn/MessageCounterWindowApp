using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageCounterInterface
{
    public partial class Form1 : Form
    {
        private MessageCounterBackend.StatsContainer statsContainer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = openJsonFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    statsContainer = new MessageCounterBackend.StatsContainer(openJsonFileDialog.FileName);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }              
        }
        
    }
}
