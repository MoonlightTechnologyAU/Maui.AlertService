using Maui.AlertService.Controls;
using Maui.AlertService.Enums;

namespace Maui.AlertService.Examples;

public partial class ThreeButtonExamplePage : ContentPage
{
    public ThreeButtonExamplePage() => InitializeComponent();

    private async void OnShowAlertClicked(object sender, EventArgs e)
    {
        var result = await this.ShowPopupAsync(new CustomAlertPopup(
            title: "Select Checklist",
            message: "Which checklist do you want to complete?",
            leftOption: "Cancel",
            middleOption: "Mobilisation",
            rightOption: "Daily",
            iconType: AlertIconType.Info));

        string message = result switch
        {
            CustomAlertResult.Option0 => "Mobilisation selected.",
            CustomAlertResult.Option1 => "Daily selected.",
            _ => "Cancelled."
        };

        await DisplayAlert("Result", message, "OK");
    }
}
