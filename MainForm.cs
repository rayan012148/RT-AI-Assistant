using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace RT_AI_Assistant
{
    public partial class MainForm : Form
    {
        private VoiceHelper voice;
        private GPTService gpt;

        public MainForm()
        {
            InitializeComponent();

            voice = new VoiceHelper();
            gpt = new GPTService();

            voice.CommandRecognized += HandleCommand;
        }

        private async void HandleCommand(string cmd)
        {
            Invoke(() => StatusLabel.Text = $"Heard: {cmd}");
            Invoke(() => ConversationBox.AppendText($"\nYou: {cmd}"));

            cmd = cmd.ToLower();

            // Simple commands
            if (cmd.Contains("open chrome"))
                Process.Start("chrome.exe");
            else if (cmd.Contains("open notepad"))
                Process.Start("notepad.exe");
            else if (cmd.Contains("shutdown"))
                Process.Start("shutdown", "/s /t 0");
            else if (cmd.Contains("restart"))
                Process.Start("shutdown", "/r /t 0");
            else if (cmd.Contains("lock"))
                LockWorkStation();
            else if (cmd.Contains("search youtube"))
                Process.Start("https://www.youtube.com/results?search_query=lofi+music");
            else if (cmd.Contains("send whatsapp message"))
            {
                // Simple parsing - user should say number and message clearly
                string number = ExtractNumber(cmd);
                string message = ExtractMessage(cmd);
                if (!string.IsNullOrEmpty(number) && !string.IsNullOrEmpty(message))
                {
                    Process.Start($"https://wa.me/{number}?text={Uri.EscapeDataString(message)}");
                    voice.Speak("WhatsApp message ready to send.");
                }
                else
                {
                    voice.Speak("Please specify the number and message clearly.");
                }
            }
            else
            {
                // Use GPT for other queries
                string response = await gpt.AskGPT(cmd);
                voice.Speak(response);
                Invoke(() => ConversationBox.AppendText($"\nRT: {response}"));
            }
        }

        private string ExtractNumber(string command)
        {
            // Simple extraction - improve as needed
            var words = command.Split(' ');
            foreach (var w in words)
            {
                if (long.TryParse(w, out _))
                    return w;
            }
            return null;
        }

        private string ExtractMessage(string command)
        {
            var idx = command.IndexOf("saying");
            if (idx >= 0)
                return command.Substring(idx + 6).Trim();
            return null;
        }

        [DllImport("user32")]
        public static extern void LockWorkStation();

        private void StartButton_Click(object sender, EventArgs e)
        {
            voice.StartListening();
            StatusLabel.Text = "Status: Listening...";
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            voice.StopListening();
            StatusLabel.Text = "Status: Stopped.";
        }
    }
}
