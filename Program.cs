using System;
using System.Diagnostics;

namespace WaestaToastNotifier
{
    class Program
    {
        static void Main(string[] args)
        {
            WaestaCore.AntiTamperCheck();
            WaestaCore.Banner(
                "🔔 WAESTA WINDOWS TOAST NOTIFIER",
                "Native WinRT Toast Notification Engine"
            );

            if (args.Length < 2)
            {
                WaestaCore.Error("Eksik parametre.");
                Console.WriteLine("\nKullanım: WaestaNotifier.exe \"Başlık\" \"Mesaj İçeriği\"");
                return;
            }

            string title = args[0];
            string message = args[1];

            WaestaCore.Info("Toast XML payload oluşturuluyor...");
            WaestaCore.Info("Windows Runtime (WinRT) ile iletişim kuruluyor...");

            string psScript = $@"
            [Windows.UI.Notifications.ToastNotificationManager, Windows.UI.Notifications, ContentType = WindowsRuntime] > $null;
            $template = [Windows.UI.Notifications.ToastTemplateType]::ToastText02;
            $xml = [Windows.UI.Notifications.ToastNotificationManager]::GetTemplateContent($template);
            $textNodes = $xml.GetElementsByTagName('text');
            $textNodes.Item(0).AppendChild($xml.CreateTextNode('{title}')) > $null;
            $textNodes.Item(1).AppendChild($xml.CreateTextNode('{message}')) > $null;
            $toast = [Windows.UI.Notifications.ToastNotification]::new($xml);
            $notifier = [Windows.UI.Notifications.ToastNotificationManager]::CreateToastNotifier('{WaestaCore.Author} System');
            $notifier.Show($toast);
            ";

            var processInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{psScript}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processInfo))
            {
                process?.WaitForExit();
            }

            WaestaCore.Success("Bildirim Windows Action Center'a gönderildi.");
        }
    }
}
