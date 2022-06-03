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
using Android.Media;
using Android.Content.Res;

namespace Translate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [assembly: Dependency(typeof(AudioService))]

    public partial class MainPage : ContentPage
    {
        Label lb;
        Switch sw;
        BoxView box;
        Button btn,btn2;
        int i;
        int j;
        ListView list;

        Random rnd;
        Xamarin.Forms.Image img;
        
        double a;
        public MainPage()

        {
            
            this.BackgroundColor = Color.White;
            lb = new Label()
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start

            };
            rnd = new Random();

            box = new BoxView()
            {
                
                Color = Color.Red,
                CornerRadius = 1000,
                WidthRequest = 300,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                
            };
            img = new Xamarin.Forms.Image()
            {

            };
            btn = new Button()
            {
                Text = "Salvesta progress"
            };
            btn2 = new Button()
            {
                Text = "Pood"
            };
            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            sw.Toggled += Sw_Toggled;
            box.GestureRecognizers.Add(tap); 
            img.GestureRecognizers.Add(tap);

            btn.Clicked += Btn_Clicked;
            btn2.Clicked += Btn2_Clicked;
            StackLayout st = new StackLayout { Children = { box, img, lb, btn,btn2, sw } };
            Content = st;
            st.Children.Add(lb);
        }

        async void Btn2_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Pood", "Ei osta", "Osta", "standardne pall", "Küpsis");
            if (action == "Deatful")
            {
                box.IsVisible = true;
                img.IsVisible = false;
            }
            else if (action == "Küpsis")
            {
                j = 0;
                img.IsVisible = true;
                box.IsVisible = false;
                int a = 50;
                i = i - a;
                img.Source = "cookie.png";
                string value = i.ToString();
                Preferences.Set("Number", value);
                lb.Text = "Сохранение " + value + " нажатий успешно!";
                
            }

        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (sw.IsToggled)
            {
                a = 0.2;
            }
            else
            {
                a = 0.01;
            }
        }

        protected override void OnAppearing()
        {
            lb.Text = Preferences.Get("Number", "ei ole sisestatud");
            i = Convert.ToInt32(lb.Text);
            lb.Text = "Загружнено: " + Preferences.Get("Number", "ei ole sisestatud") + " нажатий";
            base.OnAppearing();
        }

        public async void Btn_Clicked(object sender, EventArgs e)
        {
           
            string value = i.ToString();
            Preferences.Set("Number", value);
            lb.Text = "Сохранение " + value + " нажатий успешно!";
            
        }       


        public void Tap_Tapped(object sender, EventArgs e)
        {
           
            
            i++;
            j++;
            if (img.IsVisible==true && box.IsVisible == false)
            {
                
                i += 2;
                if (j == 20)
                {
                    img.Source = "cookie2.png";

                }
                else if (j == 50)
                {
                    img.IsVisible = false;
                    box.IsVisible = true;

                }
            }
            
            lb.Text = "Ты нажал " + i + " раз";
            if (i >= 1)
            {
                try
                {
                    // Use default vibration length
                    Vibration.Vibrate();
                    var duration = TimeSpan.FromSeconds(a);
                    // Or use specified time
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
    }
}
