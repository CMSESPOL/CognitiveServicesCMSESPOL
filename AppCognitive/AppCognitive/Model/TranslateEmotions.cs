using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCognitive.Model
{
    public class TranslateEmotions
    {
        public static string emotiones(String _text)
        {
            if (_text.Equals("Happiness"))
            {
                return "Feliz";
            }
            else if (_text.Contains("Sadness"))
            {
                return "Triste";
            }
            else if (_text.Contains("Surprise"))
            {
                return "Sorpresa";
            }
            else if (_text.Contains("Anger"))
            {
                return "Ira";
            }
            else if (_text.Contains("Fear"))
            {
                return "Miedo";
            }
            else if (_text.Contains("Contempt"))
            {
                return "Desprecio";
            }
            else if (_text.Contains("Disgust"))
            {
                return "Disgusto";
            }
            else if (_text.Contains("Neutral"))
            {
                return "Neutral";
            }
            return _text;
        }
    }
}
