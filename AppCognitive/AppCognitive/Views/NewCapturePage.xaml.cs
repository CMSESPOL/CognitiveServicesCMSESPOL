using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCognitive.Model;

namespace AppCognitive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCapturePage : ContentPage
    {
        public NewCapturePage()
        {
            InitializeComponent();
            emotionClient = new EmotionServiceClient(Constants.EmotionApiKey, Constants.AuthenticationTokenEndpoint);
            Capture();
        }

        MediaFile photo;
        EmotionServiceClient emotionClient;

        async void Capture()
        {
            await CrossMedia.Current.Initialize();
            // Take photo
            if (CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakePhotoSupported)
            {
                photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Name = "emotion.jpg",
                    Directory = "Celula",
                    PhotoSize = PhotoSize.Small
                });

                if (photo != null)
                {
                    image.Source = ImageSource.FromStream(photo.GetStream);
                }
            }
            else
            {
                await DisplayAlert("No Camera", "Camera unavailable.", "OK");
            }
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
                            emotion.Text = TranslateEmotions.emotiones(emotionResult.FirstOrDefault().Scores.ToRankedList().FirstOrDefault().Key,result);
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