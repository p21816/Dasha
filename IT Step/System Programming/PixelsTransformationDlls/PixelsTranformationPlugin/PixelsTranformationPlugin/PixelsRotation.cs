using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelsRotateDll;

namespace PixelsTranformationPlugin
{
    public class PixelsRotation : DashkasPlugin
    {
        public string GetButtonName()
        {
            return "Rotate it!";
        }

        public void Transform(uint[,] input, uint[,] output)
        {
            int ImageSize = 600;
            double alpha = Math.PI / 4; //6.283185
            double cos = Math.Cos(alpha);
            double sin = Math.Sin(alpha);
            for (int i = 0; i < ImageSize; i++)
            {
                for (int j = 0; j < ImageSize; j++)
                {
                    if ((i > ImageSize / 4) && (i < ImageSize * 3 / 4) &&
                        (j > ImageSize / 4) && (j < ImageSize * 3 / 4))
                    {
                        var ii = i - ImageSize / 2;
                        var jj = j - ImageSize / 2;
                        var oldi = ImageSize / 2 + (int)(cos * ii + sin * jj); // x
                        var oldj = ImageSize / 2 + (int)(-sin * ii + cos * jj); // y
                        output[i, j] = input[oldi, oldj];
                    }
                    else
                    {
                        output[i, j] = input[i, j];
                    }
                }
            }
            //  alpha += 0.01;
        }

        public double angle
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int imgSize
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
