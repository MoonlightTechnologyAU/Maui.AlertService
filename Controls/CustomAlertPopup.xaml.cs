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
            TimeSpan? autoDismissDelay = null,
            Color? backgroundColor = null,
            string? titleFontFamily = null, Color? titleColor = null, double? titleFontSize = null,
            string? messageFontFamily = null, Color? messageColor = null, double? messageFontSize = null,
            string? buttonFontFamily = null, Color? buttonColor = null, double? buttonFontSize = null)
        {
            InitializeComponent();

            BackgroundColor = backgroundColor ?? Colors.Black;

            TitleLabel.Text = title;
            if (titleFontFamily != null) TitleLabel.FontFamily = titleFontFamily;
            TitleLabel.TextColor = titleColor ?? Colors.White;
            if (titleFontSize.HasValue) TitleLabel.FontSize = titleFontSize.Value;

            MessageLabel.Text = message;
            if (messageFontFamily != null) MessageLabel.FontFamily = messageFontFamily;
            MessageLabel.TextColor = messageColor ?? Colors.White;
            if (messageFontSize.HasValue) MessageLabel.FontSize = messageFontSize.Value;

            ConfigureButton(LeftButton, leftOption, CustomAlertResult.Cancel, buttonFontFamily, buttonColor, buttonFontSize);
            ConfigureButton(MiddleButton, middleOption, CustomAlertResult.Option0, buttonFontFamily, buttonColor, buttonFontSize);
            ConfigureButton(RightButton, rightOption, CustomAlertResult.Option1, buttonFontFamily, buttonColor, buttonFontSize);

            ConfigureIcon(iconType);

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
                button.TextColor = color ?? Colors.Gold;
                if (size.HasValue) button.FontSize = size.Value;
            }
            else
            {
                button.IsVisible = false;
            }
        }

        private void ConfigureIcon(AlertIconType iconType)
        {
            string? iconText = iconType switch
            {
                AlertIconType.Info => "\uf05a",           // info-circle
                AlertIconType.Success => "\uf058",        // check-circle
                AlertIconType.Warning => "\uf071",        // exclamation-triangle
                AlertIconType.Error => "\uf057",          // times-circle
                AlertIconType.Question => "\uf059",       // question-circle
                _ => null
            };

            if (iconText != null)
            {
                IconLabel.Text = iconText;
                IconLabel.IsVisible = true;
            }
            else
            {
                IconLabel.IsVisible = false;
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
