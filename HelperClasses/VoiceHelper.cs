using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace RT_AI_Assistant
{
    public class VoiceHelper
    {
        public SpeechRecognitionEngine recognizer;
        public SpeechSynthesizer synthesizer;

        public event Action<string> CommandRecognized;

        public VoiceHelper()
        {
            recognizer = new SpeechRecognitionEngine();
            synthesizer = new SpeechSynthesizer();

            var commands = new Choices(new string[]
            {
                "open chrome", "open notepad", "shutdown",
                "restart", "lock", "search youtube",
                "send whatsapp message", "what time is it",
                "hello", "hey rt"
            });

            var grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(commands);
            var grammar = new Grammar(grammarBuilder);

            recognizer.LoadGrammar(grammar);
            recognizer.SetInputToDefaultAudioDevice();

            recognizer.SpeechRecognized += (s, e) =>
            {
                CommandRecognized?.Invoke(e.Result.Text);
            };
        }

        public void StartListening()
        {
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void StopListening()
        {
            recognizer.RecognizeAsyncStop();
        }

        public void Speak(string text)
        {
            synthesizer.SpeakAsync(text);
        }
    }
}
