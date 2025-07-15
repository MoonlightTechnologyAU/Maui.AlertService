using CommunityToolkit.Maui.Views;
using Maui.AlertService.Controls;
using Maui.AlertService.Enums;

namespace Maui.AlertService.Services
{
    public static class AlertService
    {
        public static async Task<CustomAlertResult> ShowAsync(
            Page page,
            string title,
            string message,
            string? leftOption = null,
            string? middleOption = null,
            string? rightOption = "OK",
            AlertIconType icon = AlertIconType.None,
            SuccessStyle successStyle = SuccessStyle.Checkmark,
            TimeSpan? autoDismissDelay = null)
        {
            var popup = new CustomAlertPopup(
                title, message,
                leftOption, middleOption, rightOption,
                icon,
                successStyle,
                autoDismissDelay);

            var result = await page.ShowPopupAsync(popup);
            return result is CustomAlertResult r ? r : CustomAlertResult.Cancel;
        }
    }
}
