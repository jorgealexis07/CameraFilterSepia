using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;

namespace PruebaCamera
{
    public partial class Form1 : Form
    {
        private Bitmap mapa;
        private Bitmap r;
        private bool ExisteDispositivo = false;
        private FilterInfoCollection DispositivoDeVideo;
        private VideoCaptureDevice FuenteDeVideo = null;
        public Form1()
        {
            InitializeComponent();
            BuscarDispositivos();
        }
        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++)
            {
                comboBox1.Items.Add(Dispositivos[0].Name.ToString());
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
        }

        public void BuscarDispositivos()
        {
            DispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivoDeVideo.Count == 0)
            {
                ExisteDispositivo = false;
            }
            else
            {
                ExisteDispositivo = true;
                CargarDispositivos(DispositivoDeVideo);
            }
        }

        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo = null;
                }
        }

        public void Video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            mapa = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = mapa;
        }

        public void Video_NuevoFrame2(object sender, NewFrameEventArgs eventArgs)
        {
            Imagen img = new Imagen();
            mapa = (Bitmap)eventArgs.Frame.Clone();
            pictureBox2.Image = img.Inversa(mapa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[comboBox1.SelectedIndex].MonikerString);
            FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
            FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame2);
            FuenteDeVideo.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TerminarFuenteDeVideo();
        }
    }
}
