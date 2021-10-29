using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace x_pract_7
{
    public partial class MainPage : ContentPage
    {
        bool isRun = false;
        string message = "";
        DateTime setDate;
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), TimeTick);
        }

        private void btn_Set_Clicked(object sender, EventArgs e)
        {
            setDate = datePicker.Date + timePicker.Time;
            message = ent_Message.Text;
            datePicker.IsEnabled = false;
            timePicker.IsEnabled = false;
            ent_Message.IsEnabled = false;
            isRun = true;
        }

        private void btn_Reset_Clicked(object sender, EventArgs e)
        {
            setDate = DateTime.MinValue;
            datePicker.IsEnabled = true;
            timePicker.IsEnabled = true;
            ent_Message.IsEnabled = true;
            isRun = false;
        }
        bool TimeTick()
        {
            if (isRun)
            {
                if(setDate <= DateTime.Now)
                {                    
                    DisplayAlert("Напиминание", message, "Ok");
                    isRun = false;
                    datePicker.IsEnabled = true;
                    timePicker.IsEnabled = true;
                    ent_Message.IsEnabled = true;
                }
            }
            return true;
        }
    }
}
