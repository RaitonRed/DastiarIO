using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DastiarIO.Core.Audio;
using System.Speech.Synthesis;

namespace DastiarIO.Core.Audio;

public class SpeechSynthesizer : IDisposable
{
    private readonly System.Speech.Synthesis.SpeechSynthesizer _synth;

    public SpeechSynthesizer()
    {
        _synth = new System.Speech.Synthesis.SpeechSynthesizer();
        _synth.SetOutputToDefaultAudioDevice();
        _synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
    }

    public void Speak(string text)
    {
        if (!string.IsNullOrWhiteSpace(text))
            _synth.SpeakAsync(text);
    }

    public void Dispose() => _synth.Dispose();
}
