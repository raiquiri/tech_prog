using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const string InputFileText = "Enter input file path";
        private const string OutputFileText = "Enter output file path";
        private string inputFilePath;
        private string outputFilePath;
        private CancellationTokenSource cancellationToken;
        private FilePacker filePacker;
        private Packer packer;

        public Form1()
        {
            InitializeComponent();
            packer = new Packer();
            packer.ProgressChanged += ProgressBar_Load;
            filePacker = new FilePacker(packer);
        }

        private void ProgressBar_Load(int progress)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    if (progress == -1)
                    {
                        progressBar1.Value = 0; 
                    }
                    else
                    {
                        progressBar1.Value = progress;
                    }
                }));
            }
            else
            {
                if (progress == -1)
                {
                    progressBar1.Value = 0;
                }
                else
                {
                    progressBar1.Value = progress;
                }
            }
        }

       
        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == InputFileText)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = InputFileText;
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == OutputFileText)
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = OutputFileText;
                textBox2.ForeColor = Color.Gray;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != InputFileText && textBox2.Text != OutputFileText)
            {

                cancellationToken = new CancellationTokenSource();
                try
                {
                    inputFilePath = textBox1.Text;
                    outputFilePath = textBox2.Text;

                    if (File.Exists(inputFilePath))
                    {
                        await Task.Run(() => filePacker.Packed(inputFilePath, outputFilePath, cancellationToken.Token ));
                        MessageBox.Show("Accept");
                    }
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Operation was cancelled.");
                }
            }
            else
            {
                MessageBox.Show("Please enter correct input file path before start.");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != InputFileText && textBox2.Text != OutputFileText)
            {

                cancellationToken = new CancellationTokenSource();
                try
                {
                    inputFilePath = textBox1.Text;
                    outputFilePath = textBox2.Text;

                    if (File.Exists(inputFilePath))
                    {
                        await Task.Run(() => filePacker.UnPacked(inputFilePath, outputFilePath, cancellationToken.Token));
                        MessageBox.Show("Accept");
                    }
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Operation was cancelled.");
                }
            }
            else
            {
                MessageBox.Show("Please enter correct input file path before start.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cancellationToken?.Cancel();
        }
    }
}
