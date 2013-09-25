using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

using HAL.Library.Exceptions;

namespace HAL.Library.Voice
{
    public enum VoiceSynthesisType
    {
        Angry,
        Sad,
        Slow,
        Normal,
    }

    public class VoiceSynthesis
    {

        readonly private SpeechSynthesizer _speech;

        public VoiceSynthesis()
        {
            _speech = new SpeechSynthesizer();
            _speech.SelectVoice(GetVoices().First().Name);      // on récupére la premiére que l'on trouve en francais.  
        }

        public void SetVoice(String name)
        {
            try
            {
                _speech.SelectVoice(name);
            }
            catch (Exception)
            {

                throw new ExceptionHal(String.Format("la voix {0} n'existe pas."));
            }
            
        }


        public IEnumerable<TypeVoice> GetVoices()
        {
            var result = _speech.GetInstalledVoices(new System.Globalization.CultureInfo("fr-fr"));
            if (result == null || result.Count <= 0)
                throw new ExceptionHal("Aucune voix liée à la culture France n'a été trouvé sur ce poste.");

            foreach (var item in result)
                yield return new TypeVoice(item.VoiceInfo.Name, item.VoiceInfo.Age.ToString(), item.VoiceInfo.Gender.ToString());
        }


        private PromptStyle SetStyle(VoiceSynthesisType type)
        {
            
            PromptStyle style = new PromptStyle();
            style.Volume = PromptVolume.NotSet;
            style.Rate = PromptRate.NotSet;
            style.Emphasis = PromptEmphasis.NotSet;

            switch (type)
            {
                case VoiceSynthesisType.Angry:
                    style.Volume = PromptVolume.ExtraLoud;
                    style.Rate = PromptRate.Fast;
                    style.Emphasis = PromptEmphasis.Strong;
                    break;
                case VoiceSynthesisType.Sad:
                    style.Volume = PromptVolume.Soft;
                    style.Rate = PromptRate.Slow;
                    style.Emphasis = PromptEmphasis.None;
                    break;
                case VoiceSynthesisType.Slow:
                    style.Volume = PromptVolume.Medium;
                    style.Rate = PromptRate.Slow;
                    style.Emphasis = PromptEmphasis.None;
                    break;
                case VoiceSynthesisType.Normal:
                    style.Volume = PromptVolume.Medium;
                    style.Rate = PromptRate.Medium;
                    style.Emphasis = PromptEmphasis.None;
                    break;
            }


            return style;
        }

        public void Speak(String message, VoiceSynthesisType type)
        {
            PromptBuilder prompt = new PromptBuilder();
            prompt.StartStyle(SetStyle(type));
            prompt.StartSentence();
            prompt.AppendText(message);
            prompt.EndSentence();
            prompt.EndStyle();

            _speech.Speak(prompt);
        }

    }
}
