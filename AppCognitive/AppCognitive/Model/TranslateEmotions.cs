using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCognitive.Model
{
    public class TranslateEmotions
    {
        public static string emotiones(String _text, Image _image)
        {
            if (_text.Equals("Happiness"))
            {
                _image.Source = ImageSource.FromFile(file: "bigsmile.png");
                return "Feliz";
            }
            else if (_text.Contains("Sadness"))
            {
                _image.Source = ImageSource.FromFile("crying.png");
                return "Triste";
            }
            else if (_text.Contains("Surprise"))
            {
                _image.Source = ImageSource.FromFile("sorprised.png");
                return "Sorpresa";
            }
            else if (_text.Contains("Anger"))
            {
                _image.Source = ImageSource.FromFile("angrymad.png");
                return "Ira";
            }
            else if (_text.Contains("Fear"))
            {
                _image.Source = ImageSource.FromFile("rolleyes.png");
                return "Miedo";
            }
            else if (_text.Contains("Contempt"))
            {
                return "Desprecio";
            }
            else if (_text.Contains("Disgust"))
            {
                _image.Source = ImageSource.FromFile("unamusedface.png");                
                return "Disgusto";
            }
            else if (_text.Contains("Neutral"))
            {
                _image.Source = ImageSource.FromFile(file: "amazed.png");
                return "Neutral";
            }

            _image.Source = ImageSource.FromFile(file: "amazed.png");
            return _text;
        }
    }
}
