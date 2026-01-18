//Declare namespace
using System.Collections.Generic;

namespace Translator
{
    //Create Sentence class
    internal class Sentence
    {
        //Declare class variables
        private string language { get; }
        private List<Word> content { get; }

        //Create constructor
        public Sentence(string language, List<Word> content)
        {
            //Assign variables
            this.language = language;
            this.content = content;
        }

        //Translate sentence into new sentence
        public Sentence translate(string language)
        {
            //Create new Word List and translate
            List<Word> translated = new List<Word>();

            foreach(Word word in content)
            {
                translated.Add(word.translate(language));
            }

            return new Sentence(language, translated);
        }
    }
}
