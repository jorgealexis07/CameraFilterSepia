using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge.Video;
using AForge.Video.DirectShow;


namespace PruebaCamera
{
    public class Imagen
    {
        public Bitmap BlancoNegro(Bitmap mapa)
        {
            Vector3 vnegro = new Vector3(0, 0, 0);
            Vector3 vblanco = new Vector3(255, 255, 255);
            Bitmap mapat = new Bitmap(mapa.Width,mapa.Height);

            for (int fila = 0; fila < mapa.Height; fila++)
            {
                for (int columna = 0; columna < mapa.Width; columna++)
                {
                    Color c = mapa.GetPixel(columna, fila);
                    Vector3 vc = Matematica.ColorAVector3(c);
                    float dvn = Matematica.Distancia(vc, vnegro);
                    float dvb = Matematica.Distancia(vc, vblanco);
                    if (dvn < dvb)
                    {
                        mapat.SetPixel(columna, fila, Color.Black);
                    }
                    else
                    {
                        mapat.SetPixel(columna, fila, Color.White);
                    }
                }

            }
            return mapat;
        }

        public Bitmap EscalaGrises(Bitmap mapa)
        {
            int div = 0;
        
            Bitmap mapat = new Bitmap(mapa.Width,mapa.Height);
            for (int x = 0; x < mapa.Height; x++)
            {
                for (int y = 0; y < mapa.Width; y++)
                {
                    Color c = mapa.GetPixel(y, x);
                    div = (int)((c.R + c.G + c.B) / 3.0f);
                    Color newColor =  Color.FromArgb(div,div,div);
                    mapat.SetPixel(y,x,newColor);
                }
            }
            return mapat;
        }
    
        public Bitmap Inversa(Bitmap mapa) 
        {
            
            Bitmap mapat = new Bitmap(mapa.Width,mapa.Height) ;
            
            for (int filas = 0; filas < mapa.Height; filas++)
            {
                for (int columnas = 0; columnas < mapa.Width; columnas++)
                {
                    Color c = mapa.GetPixel(columnas,filas);
                    mapat.SetPixel(columnas,filas,Color.FromArgb(255-c.R,255-c.G,255-c.B));
                }   
            }
            
            return mapat;
        }

        public Bitmap FiltroRGB(Bitmap mapa, float fr, float fg, float fb)
        {
            Bitmap mapat;
            mapat = new Bitmap(mapa.Width, mapa.Height);

            for (int filas = 0; filas < mapa.Height; filas++)
            {
                for (int columnas = 0; columnas < mapa.Width; columnas++)
                {
                    Color c = mapa.GetPixel(columnas, filas);
                    Color cf = Color.FromArgb((int)(c.R * fr), (int)(c.G * fg), (int)(c.B * fb));
                    mapat.SetPixel(columnas, filas, cf);
                }
            }
            return mapat;
        }
    }
}
