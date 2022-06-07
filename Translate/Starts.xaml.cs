
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Translate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Starts : ContentPage
    {
        Label lbl;
        Button btn, btn2;
        
        public Starts()
        {
            this.BackgroundColor = Color.LightYellow;
            lbl = new Label()
            {
                Text = "KLIKER",
                TextColor = Color.Black,
                FontFamily = "Comic Sans MS",
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                
            };
            btn = new Button()
            {
                Text = "Start Game",
                BackgroundColor = Color.LightGreen,
            };

            btn2 = new Button()
            {
                Text = "Exit",
                BackgroundColor = Color.LightGreen,
            };

            StackLayout st = new StackLayout()
            {
                Children = { lbl, btn,btn2 }
            };
            btn.Clicked += Btn_Clicked;
            btn2.Clicked += Btn2_Clicked;
            ScrollView scrollView = new ScrollView { Content = st };
            Content = scrollView;
        }

        private async void Btn2_Clicked(object sender, EventArgs e)
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new MainPage());
        }

    }
}