using AppCognitive.Model;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;
using Plugin.Media;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCognitive.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPage : ContentPage
    {
        EmotionServiceClient emotionClient;

        public SelectPage()
        {
            InitializeComponent();
            emotionClient = new EmotionServiceClient(Constants.EmotionApiKey, Constants.AuthenticationTokenEndpoint);
            PickPhoto();
        }

        async void PickPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }

            var photo = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });


            if (photo == null)
                return;

            image.Source = ImageSource.FromStream(photo.GetStream);
            try
            {
                if (photo != null)
                {
                    using (var photoStream = photo.GetStream())
                    {
                        Emotion[] emotionResult = await emotionClient.RecognizeAsync(photoStream);
                        if (emotionResult.Any())
                        {
                            // Emotions detected are happiness, sadness, surprise, anger, fear, contempt, disgust, or neutral.
                            emotion.Text = TranslateEmotions.emotiones(emotionResult.FirstOrDefault().Scores.ToRankedList().FirstOrDefault().Key);
                        }
                        else
                            emotion.Text = "No emotion Detected";
                        photo.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            photo.Dispose();
        }
    }
}