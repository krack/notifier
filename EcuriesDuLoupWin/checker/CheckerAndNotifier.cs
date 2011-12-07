using EcuriesDuLoupWin.Options;
namespace EcuriesDuLoupWin
{
    public class CheckerAndNotifier
    {
        public string Message { get; set; }
        public string UrlToSend { get; set; }
        public Checker Checker { get; set; }
        public OptionsData Options { get; set; }
        public Notificater Notificater { get; set; }

        public void Run()
        {
            if (this.Checker.HasNews())
            {
                Notifier notifier = new Notifier();
                notifier.Message = this.Message;
                notifier.UrlToSend = this.UrlToSend;
                notifier.IsPlaySound = this.Options.IsNotificationSoundActivate;
                notifier.Notificater = this.Notificater;

                notifier.Show();
            }
        }

        public void reset()
        {
            this.Checker.reset();
        }
    }
}
