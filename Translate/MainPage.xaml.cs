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
        Switch sw;
        BoxView box;
        Button btn;
        int i;
        Random rnd;
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
            btn = new Button()
            {
                Text = "Salvesta progress"
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
            btn.Clicked += Btn_Clicked;
            StackLayout st = new StackLayout { Children = { box,lb, btn, sw } };
            Content = st;
            st.Children.Add(lb);
        }

        /*public TimeSpan Vibraion(TimeSpan duration)
        {
            if (sw.IsToggled)
            {
                duration = TimeSpan.FromSeconds(0.2);
            }
            else
            {
                duration = TimeSpan.FromSeconds(0);
            }
            return duration;
        }*/

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
            base.OnAppearing();
        }

        public async void Btn_Clicked(object sender, EventArgs e)
        {
           
            string value = i.ToString();
            Preferences.Set("Number", value);
            lb.Text = value;
            
        }       


        public void Tap_Tapped(object sender, EventArgs e)
        {
           
            
            i++;
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
