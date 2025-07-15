using Maui.AlertService.Controls;
using Maui.AlertService.Enums;

namespace Maui.AlertService.Examples;

public partial class TwoButtonExamplePage : ContentPage
{
    public TwoButtonExamplePage() => InitializeComponent();

    private async void OnShowAlertClicked(object sender, EventArgs e)
    {
        var result = await this.ShowPopupAsync(new CustomAlertPopup(
            title: "Confirm",
            message: "Do you want to continue?",
            middleOption: "No",
            rightOption: "Yes",
            iconType: AlertIconType.Question));

        if (result is CustomAlertResult.Option1)
        {
            await DisplayAlert("Result", "User confirmed.", "OK");
        }
    }
}
