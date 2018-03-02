using MedijanSlike_UART.helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedijanSlike_UART
{
    public partial class Form1 : Form
    {
        Bitmap originalImg;
        Bitmap grayImg;       
        MemoryStream ms = new MemoryStream();
        StringBuilder sb = new StringBuilder();
        Image receivedImg;
        int send_pointer = 0;


        public Form1()
        {
            InitializeComponent();
            var ports = SerialPort.GetPortNames();
            
            
            if (ports.Any())
            {
                comboBox1.DataSource = ports;
                comboBox2.DataSource = EnumBaudRates.SupportedBaudRates;
            }


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort2.DataBits = 8;
            serialPort2.StopBits = StopBits.One;
            serialPort2.Parity = Parity.None;
            serialPort2.DtrEnable = true;
        }


       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort2.PortName = comboBox1.SelectedValue.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort2.BaudRate = int.Parse(comboBox2.SelectedValue.ToString());
        }
        private void btn_browse_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.bmp, *.png) | *.jpg; *.jpeg; *.bmp; *.png";
                dialog.Title = "Select an image";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    originalImg = new Bitmap(dialog.FileName);
                }
                if (originalImg != null)
                {
                    showImage(originalImg);
                }
            }


            btn_showoriginal.Enabled = true;
            btn_greyscale.Enabled = true;
        }

        private void showImage(Image img)
        {
            Form fm = new Form();
            PictureBox pb = new PictureBox();
            pb.Image = img;
            pb.Size = new Size(img.Width  + 300, img.Height + 300);           
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            fm.Controls.Add(pb);
            fm.Size = new Size(img.Width + 300, img.Height + 300);            
            fm.Show();
        }

        private Bitmap GenerateNoise(Bitmap image, double prob)
        {
            double tresh = 1 - prob;
            Bitmap finalBmp = image;
            Random r = new Random();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    double num = r.NextDouble();
                    if (num < prob)
                    {
                        finalBmp.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0));
                    }
                    else if (num > tresh){
                        finalBmp.SetPixel(x, y, Color.FromArgb(255, 255, 255, 255));
                    }
                    else continue;
                }
            }

            return finalBmp;
        }

        private void btn_showoriginal_Click(object sender, EventArgs e)
        {
            if (originalImg != null)
            {
                originalImg = GenerateNoise(originalImg, 0.02);
                showImage(originalImg);
            }
               
        }

        private void btn_greyscale_Click(object sender, EventArgs e)
        {
            if (originalImg != null)
            {
                grayImg = originalImg.MakeGrayScale();
                richTextBox1.AppendText("Grayscale finished! \n");
                grayImg.Save(ms, ImageFormat.Bmp);
            }
            btn_showgreyscale.Enabled = true;
            btn_send.Enabled = true;
        }

        private void btn_showgreyscale_Click(object sender, EventArgs e)
        {
            if (grayImg != null)
            {
                showImage(grayImg);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }


        private void btn_send_Click(object sender, EventArgs e)
        {
                if (!serialPort2.IsOpen)
                {
                    serialPort2.Open();
                    comboBox1.Enabled = false;
                    btn_disc.Enabled = true;
                }
                send_pointer = 0;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                ms.Position = 0;
                byte[] stupci = Encoding.ASCII.GetBytes(grayImg.Width.ToString());
                byte[] retci = Encoding.ASCII.GetBytes(grayImg.Height.ToString());
                byte[] imgConverted = ms.ToArray();           
                byte[] imgByteArray = new byte[ms.Length - imgConverted[10]];
               

                var x = 0;
                var start = imgConverted[10];
                for (int i = start; i < (imgConverted.Length - start); i++)
                {
                    imgByteArray[x] = imgConverted[i];
                    x++;
                }

                progressBar1.Maximum = grayImg.Width * grayImg.Height * 4;
                progressBar1.Value = 0;

                serialPort2.Write(stupci, 0, 3);
                serialPort2.Write(retci, 0, 3);

                for (int i = 0; i < grayImg.Width * grayImg.Height * 4; i += 4)
                {
                    serialPort2.Write(imgByteArray, i, 1);
                    progressBar1.Value = i;
                    send_pointer++;
                }
                progressBar1.Value = progressBar1.Maximum;
                richTextBox1.AppendText("Send finished! \n");
                btn_disc.Enabled = true;
            
           // }

        }

        private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            sp.Encoding = Encoding.GetEncoding(28591);
            string indata = sp.ReadExisting();
            sb.Append(indata);
            if (sb.Length == send_pointer)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    richTextBox1.AppendText("Receive finished! \n");
                }));

                ConvertReceived(sb.ToString());
            }

        }

        private void ConvertReceived(string input)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                richTextBox1.AppendText("Starting conversion.. \n");
            }));
            
            byte[] input_image = new byte[input.Length];
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            input_image = iso.GetBytes(input);
            byte[] image = ms.ToArray();
            int pocetak = image[10];
            int velicina = grayImg.Height * grayImg.Width * 4;
            int j = 0;
            for (int i = pocetak; i < velicina; i += 4)
            {
                image[i] = input_image[j];
                image[i + 1] = input_image[j];
                image[i + 2] = input_image[j];
                j++;
            }

            
            var ms_return = new MemoryStream(image);
            receivedImg = Image.FromStream(ms_return);

   
            // receivedImg.Save(".bmp", ImageFormat.Bmp);
          
            sb.Clear();

            Invoke(new MethodInvoker(delegate ()
            {
                richTextBox1.AppendText("Conversion finished! \n");
                btn_showaftermedian.Enabled = true;
            }));


        }

        private void btn_disc_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
                comboBox1.Enabled = true;
                btn_disc.Enabled = false;
            }
        }

        private void btn_showaftermedian_Click(object sender, EventArgs e)
        {
            {
                if (receivedImg != null)
                {
                    showImage(receivedImg);
                }
            }
        }


    }
}
