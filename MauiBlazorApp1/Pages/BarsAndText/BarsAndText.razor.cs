using MauiBlazorApp1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Calendars;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.Navigations;
using System.Collections.ObjectModel;
using MauiBlazorApp1.Pages.BarsAndText;

namespace MauiBlazorApp1.Pages.BarsAndText
{
    public partial class BarsAndText
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        //Functions of the Top-Bar
        protected override async Task OnInitializedAsync()
        {
            var targetUrl = "./scripts/ChangelColorScript.js";
            await JSRuntime.InvokeVoidAsync("loadJs", targetUrl);
            MainPage.hideWebBrowserFunction();
        }

        private async void ShowPrimaryColor()
        {
            string content = "primary";
            await JSRuntime.InvokeVoidAsync("changeStyle", content);
        }

        private async void ShowSecondaryColor()
        {
            string content = "secondary";
            await JSRuntime.InvokeVoidAsync("changeStyle", content);
        }

        private async void ShowErrorColor()
        {
            string content = "error";
            await JSRuntime.InvokeVoidAsync("changeStyle", content);
        }

        private async void ShowSuccessColor()
        {
            string content = "success";
            await JSRuntime.InvokeVoidAsync("changeStyle", content);
        }

        private async void ShowInfoColor()
        {
            string content = "info";
            await JSRuntime.InvokeVoidAsync("changeStyle", content);
        }

        private async void ShowWarningColor()
        {
            string content = "warning";
            await JSRuntime.InvokeVoidAsync("changeStyle", content);
        }

        private async void ShowDesaturatedColor()
        {
            string content = "desaturated";
            await JSRuntime.InvokeVoidAsync("changeStyle", content);
        }

        private async void AddSearchFieldToBar()
        {
            await JSRuntime.InvokeVoidAsync("addSearchBar");
        }
        private async void DeleteSearchFieldToBar()
        {
            await JSRuntime.InvokeVoidAsync("deleteSearchBar");
        }

        private async void ShowSecondaryBar()
        {
            await JSRuntime.InvokeVoidAsync("showSecondaryBar");
        }
        private async void HideSecondaryBar()
        {
            await JSRuntime.InvokeVoidAsync("hideSecondaryBar");
           
        }

        //Text functions
        private bool isVisible { get; set; } = true;
        private bool IsDisabled { get; set; } = true;

        private string color { get; set; } = "00f";
        private string font { get; set; } = "00f";
        private void EnableText()
        {
            if (IsDisabled)
            {
                IsDisabled = false;
            }
            else
            {
                IsDisabled = true;
            }
        }
        private void HideText()
        {
            if (isVisible)
            {
                isVisible = false;
            }
            else
            {
                isVisible = true;
            }

        }

        private void ChangeColor()
        {
            Random r = new Random();
            int num = r.Next(0, 3);

            if (num == 0)
            {
                color = "#A2001D";

            }
            else if (num == 1)
            {
                color = "#244959";
            }
            else if (num == 2)
            {
                color = "#CAB637";
            }
            else if (num == 3)
            {
                color = "#1864A2";
            }
        }


        private void ChangeStyle()
        {
            Random r = new Random();
            int num = r.Next(0, 3);

            if (num == 0)
            {
                font = "font: var(--unnamed-font-style-normal) normal var(--unnamed-font-weight-normal) var(--unnamed-font-size-16)/var(--unnamed-line-spacing-19) var(--unnamed-font-family-roboto);\r\nletter-spacing: var(--unnamed-character-spacing-0-5);\r\ncolor: var(--on-surface-high-emphasis);\r\ntext-align: left;\r\nfont: normal normal normal 16px/19px Roboto;\r\nletter-spacing: 0.5px;\r\ncolor: #000000DE;\r\nopacity: 1;";
            }
            else if (num == 1)
            {
                font = "font: var(--unnamed-font-style-normal) normal var(--unnamed-font-weight-medium) var(--unnamed-font-size-10)/var(--unnamed-line-spacing-16) var(--unnamed-font-family-roboto);\r\nletter-spacing: var(--unnamed-character-spacing-1-5);\r\ncolor: var(--on-surface-high-emphasis);\r\ntext-align: left;\r\nfont: normal normal medium 10px/16px Roboto;\r\nletter-spacing: 1.5px;\r\ncolor: #000000DE;\r\ntext-transform: uppercase;\r\nopacity: 1;";
            }
            else if (num == 2)
            {
                font = "font: var(--unnamed-font-style-normal) normal var(--unnamed-font-weight-medium) var(--unnamed-font-size-20)/var(--unnamed-line-spacing-24) var(--unnamed-font-family-roboto);\r\nletter-spacing: var(--unnamed-character-spacing-0-15);\r\ncolor: var(--on-surface-high-emphasis);\r\ntext-align: left;\r\nfont: normal normal medium 20px/24px Roboto;\r\nletter-spacing: 0.15px;\r\ncolor: #000000DE;\r\nopacity: 1;";
            }
            else if (num == 3)
            {
                font = "font: var(--unnamed-font-style-normal) normal var(--unnamed-font-weight-medium) var(--unnamed-font-size-14)/var(--unnamed-line-spacing-20) var(--unnamed-font-family-roboto);\r\nletter-spacing: var(--unnamed-character-spacing-0-25);\r\ncolor: var(--on-surface-high-emphasis);\r\ntext-align: left;\r\nfont: normal normal medium 14px/20px Roboto;\r\nletter-spacing: 0.25px;\r\ncolor: #000000DE;\r\nopacity: 1;";
            }

        }

        //Dropdown
        public string[] MultiVal { get; set; } = new string[] { };
        private string newDropDownItem { get; set; } = "";
        public class DevelopmentSkills
        {
            public string ID { get; set; }
            public string Text { get; set; }
        }
        ObservableCollection<DevelopmentSkills> Skills = new ObservableCollection<DevelopmentSkills> {
        new DevelopmentSkills() { ID= 1.ToString(), Text= "C#" },
        new DevelopmentSkills() { ID= 2.ToString(), Text= "JavaScript" },
        new DevelopmentSkills() { ID= 3.ToString(), Text= "MAUI" }
        };


        public void addItemToDropDown()
        {
            var lastId = int.Parse(Skills.Last().ID);
            var data = new DevelopmentSkills() { ID = (lastId + 1).ToString(), Text = newDropDownItem };
            Skills.Add(data);
        }

        private bool isDropDownVisible { get; set; } = false;

        private void ShowHideDropdown()
        {
            if (isDropDownVisible)
            {
                isDropDownVisible = false;
            }
            else
            {
                isDropDownVisible = true;
            }

        }

        //Datepicker
        public DateTime? SelectedDate { get; set; } 
        public DateTime? SelectedTime { get; set; }
        public string? DateTime { get; set; }
        public void UpdateValue()
        {
            if(format == "dd-MM-yyyy" && SelectedDate != null && SelectedTime != null)
            {
                DateTime = new DateTime(SelectedDate.Value.Year, SelectedDate.Value.Month, SelectedDate.Value.Day,
                                  SelectedTime.Value.Hour, SelectedTime.Value.Minute, SelectedTime.Value.Second).ToString("dd-MM-yyyy HH:mm:ss");
            }
            else
            {
                if (SelectedDate != null && SelectedTime != null)
                {
                    DateTime = new DateTime(SelectedDate.Value.Year, SelectedDate.Value.Month, SelectedDate.Value.Day,
                                      SelectedTime.Value.Hour, SelectedTime.Value.Minute, SelectedTime.Value.Second).ToString("MM-dd-yyyy HH:mm:ss");
                }
                }
        }
        public string format { get; set; }
        private bool language { get; set; } = false;
        public void changeFormat()
        {
           if(language)
            {
                format = "dd-MM-yyyy";
                language = false;
            }
            else
            {
                format = "MM-dd-yyyy";
                language = true;
            }
        }
      

        string time = "09:20";
    

}
}
