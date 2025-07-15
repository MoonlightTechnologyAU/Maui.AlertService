using CommunityToolkit.Maui.Views;
using Maui.AlertService.Enums;
using System.Threading.Tasks;

namespace Maui.AlertService.Controls
{
    public partial class CustomAlertPopup : Popup
    {
        public CustomAlertPopup(
            string title,
            string message,
            string? leftOption = null,
            string? middleOption = null,
            string? rightOption = null,
            AlertIconType iconType = AlertIconType.None,
            SuccessStyle successStyle = SuccessStyle.Checkmark,
            TimeSpan? autoDismissDelay = null,
            Color? backgroundColor = null,
            string? titleFontFamily = null, Color? titleColor = null, double? titleFontSize = null,
            string? messageFontFamily = null, Color? messageColor = null, double? messageFontSize = null,
            string? buttonFontFamily = null, Color? buttonColor = null, double? buttonFontSize = null)
        {
            InitializeComponent();

            if (backgroundColor != null)
                BackgroundColor = backgroundColor;

            TitleLabel.Text = title;
            if (titleFontFamily != null) TitleLabel.FontFamily = titleFontFamily;
            if (titleColor != null) TitleLabel.TextColor = titleColor;
            if (titleFontSize.HasValue) TitleLabel.FontSize = titleFontSize.Value;

            MessageLabel.Text = message;
            if (messageFontFamily != null) MessageLabel.FontFamily = messageFontFamily;
            if (messageColor != null) MessageLabel.TextColor = messageColor;
            if (messageFontSize.HasValue) MessageLabel.FontSize = messageFontSize.Value;

            ConfigureButton(LeftButton, leftOption, CustomAlertResult.Cancel, buttonFontFamily, buttonColor, buttonFontSize);
            ConfigureButton(MiddleButton, middleOption, CustomAlertResult.Option0, buttonFontFamily, buttonColor, buttonFontSize);
            ConfigureButton(RightButton, rightOption, CustomAlertResult.Option1, buttonFontFamily, buttonColor, buttonFontSize);

            ConfigureIcon(iconType, successStyle);

            if (autoDismissDelay.HasValue)
                _ = AutoDismissAsync(autoDismissDelay.Value);
        }

        private void ConfigureButton(Button button, string? text, CustomAlertResult returnValue, string? font, Color? color, double? size)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                button.Text = text;
                button.IsVisible = true;
                button.Command = new Command(() => Close(returnValue));
                if (font != null) button.FontFamily = font;
                if (color != null) button.TextColor = color;
                if (size.HasValue) button.FontSize = size.Value;
            }
            else
            {
                button.IsVisible = false;
            }
        }

        private void ConfigureIcon(AlertIconType iconType, SuccessStyle successStyle)
        {
            string? file = iconType switch
            {
                AlertIconType.Info => "info.json",
                AlertIconType.Success => successStyle switch
                {
                    SuccessStyle.Checkmark => "success_checkmark.json",
                    SuccessStyle.Confetti => "success_confetti.json",
                    _ => "success_checkmark.json"
                },
                AlertIconType.Warning => "warning.json",
                AlertIconType.Error => "error.json",
                AlertIconType.Question => "question.json",
                _ => null
            };

            if (file != null)
            {
                IconAnimation.IsVisible = true;
                IconAnimation.Animation = LottieResource.FromJson(file);
            }
        }

        private async Task AutoDismissAsync(TimeSpan delay)
        {
            await Task.Delay(delay);
            if (this.Handler is not null)
                Close(CustomAlertResult.Option1);
        }
    }
}
