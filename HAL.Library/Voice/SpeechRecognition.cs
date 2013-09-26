using HAL.Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace HAL.Library.Voice
{
    public class SpeechRecognition
    {
        private SpeechRecognitionEngine _recognizer;

        private Grammar CreateGrammar(List<String> commandes)
        {
            GrammarBuilder grammarBuider = new GrammarBuilder();
            grammarBuider.Culture = new System.Globalization.CultureInfo("fr-fr");

            Choices _commandChoices = new Choices();
            foreach (var item in commandes)
                _commandChoices.Add(item);

            grammarBuider.Append(_commandChoices);
            return new Grammar(grammarBuider);
        }


        public void Recognition(List<String> commandes)
        {
            try
            {
                _recognizer = new SpeechRecognitionEngine();
                _recognizer.LoadGrammar(CreateGrammar(commandes));
                _recognizer.SpeechRecognized += RecognitionFinished;
                _recognizer.SetInputToDefaultAudioDevice();
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                throw new ExceptionHal("un problème c'est produit lors de l'initialisation de la reconnaissance vocale." + ex.Message);
            }

        }

     
        private void RecognitionFinished(object sender, SpeechRecognizedEventArgs e)
        {

        }

    }
}
