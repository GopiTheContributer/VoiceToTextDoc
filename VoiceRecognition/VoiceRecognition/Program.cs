using System;
using System.Speech;
using System.Speech.Recognition;

namespace VoiceRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            //title
            Console.WriteLine("win Speech to Text converter");
            for (int i = 0; i <= 28; i++)
                Console.Write("*");

            Console.WriteLine("\n");
            Console.WriteLine("type record");
            string inputType = Console.ReadLine();

            if (inputType == "r")
            {
                Console.WriteLine("recognizing...");
                SpeechRecognitionEngine speechRecognitionEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
                Grammar grammer = new DictationGrammar();
                speechRecognitionEngine.LoadGrammar(grammer);

                try
                {
                    speechRecognitionEngine.SetInputToDefaultAudioDevice();
                    RecognitionResult recognitionResult =  speechRecognitionEngine.Recognize();
                    Console.WriteLine(recognitionResult.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong" + ex.StackTrace);
                }
            }

            Console.ReadLine();
        }
    }
}
