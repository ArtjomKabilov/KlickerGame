using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Translate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        Label lb;
        BoxView box;
        string filename;
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        Button btn, btn2;
        int i;
        public MainPage()
        {
            this.BackgroundColor = Color.White;
            lb = new Label()
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start

            };

            box = new BoxView()
            {
                Color = Color.Red,
                CornerRadius = 1000,
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            btn = new Button()
            {
                Text = "Salvesta"
            };
            btn2 = new Button()
            {
                Text = "Loe_failist"
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            btn.Clicked += Btn_Clicked;
            //btn2.Clicked += Btn2_Clicked;
            StackLayout st = new StackLayout { Children = { box, btn,btn2 } };
            Content = st;
            st.Children.Add(lb);
        }

        protected override void OnAppearing()
        {
            lb.Text = Preferences.Get("Number", "ei ole sisestatud");
            i = Convert.ToInt32(lb.Text);
            base.OnAppearing();
        }

        public async void Btn_Clicked(object sender, EventArgs e)
        {
           
            string value = i.ToString();
            Preferences.Set("Number", value);
            lb.Text = value;
            
        }



        private void Tap_Tapped(object sender, EventArgs e)
        {
           
            
            i++;
            lb.Text = "Ты нажал " + i + " раз";
            if (i >= 1)
            {
                try
                {
                    // Use default vibration length
                    Vibration.Vibrate();

                    // Or use specified time
                    var duration = TimeSpan.FromSeconds(0.2);
                    Vibration.Vibrate(duration);
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Feature not supported on device
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            }
        }
        /*public async void Btn_Clicked(object sender, EventArgs e)
        {
            filename = "Klicker.txt";
            if (String.IsNullOrEmpty(filename)) return;
            if (File.Exists(Path.Combine(folderPath, filename)))
            {
                bool isRewrited = await DisplayAlert("Kinnitus", "Fail on juba olemas, lisame andmeid sinna?", "Jah", "Ei");
                if (isRewrited == false) return;
            }
            string text = i.ToString();
            File.AppendAllLines(Path.Combine(folderPath, filename), text.Split('\n'));
        }
        public async void Btn2_Clicked(object sender, EventArgs e)
        {
            filename = "Klicker.txt";
            if (String.IsNullOrEmpty(filename)) return;
            if (filename != null)
            {
                lb.Text = File.ReadAllText(Path.Combine(folderPath, filename));
            }
        }*/
    }
}
