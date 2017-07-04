using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCognitive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCapturePage : ContentPage
    {
        public NewCapturePage()
        {
            InitializeComponent();

            Capture();

            //captura.Clicked += async (sender, args) =>
            //{

            //    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //    {
            //        await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
            //        return;
            //    }

            //    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //    {
            //        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            //        Directory = "Sample",
            //        Name = "test.jpg"
            //    });

            //    if (file == null)
            //        return;

            //    await DisplayAlert("File Location", file.Path, "OK");

            //    image.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //};
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
                            emotion.Text = emotionResult.FirstOrDefault().Scores.ToRankedList().FirstOrDefault().Key;
                        }
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