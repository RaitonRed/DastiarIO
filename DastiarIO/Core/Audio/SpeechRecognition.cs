using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace DastiarIO.Core.Audio;

public class SpeechRecognizer : IDisposable
{
    private readonly SpeechRecognitionEngine _recognizer;
    public event EventHandler<string> SpeechRecognized;

    public SpeechRecognizer()
    {
        _recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        _recognizer.SetInputToDefaultAudioDevice();
        _recognizer.SpeechRecognized += (s, e) =>
            SpeechRecognized?.Invoke(this, e.Result.Text);
    }

    public void LoadGrammar(IEnumerable<string> pharses)
    {
        _recognizer.UnloadAllGrammars();
        var grammarBuilder = new GrammarBuilder(new Choices(pharses.ToArray()));

        _recognizer.LoadGrammar(new Grammar(grammarBuilder));
    }

    public void StrartListening() => _recognizer.RecognizeAsync(RecognizeMode.Multiple);

    public void StopListening() => _recognizer.RecognizeAsyncStop();

    public void Dispose() => _recognizer?.Dispose();
}
