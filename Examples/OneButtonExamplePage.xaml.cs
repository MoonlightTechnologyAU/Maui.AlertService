using Maui.AlertService.Controls;
using Maui.AlertService.Enums;

namespace Maui.AlertService.Examples;

public partial class OneButtonExamplePage : ContentPage
{
    public OneButtonExamplePage() => InitializeComponent();

    private async void OnShowAlertClicked(object sender, EventArgs e)
    {
        var result = await this.ShowPopupAsync(new CustomAlertPopup(
            title: "Notice",
            message: "All tasks completed successfully.",
            rightOption: "OK",
            iconType: AlertIconType.Success));

        if (result is CustomAlertResult.Option1)
        {
            await DisplayAlert("Result", "OK clicked", "Got it");
        }
    }
}
