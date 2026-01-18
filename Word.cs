using System;
using System.IO;
using System.Windows.Forms;

//Declare namespace
namespace Translator
{
    //Create Word class
    internal class Word
    {
        //Declare class variables
        private string language { get; }
        public string content { get; set; }
        private int id { get; }
        private Word[] synonyms;


        

        //Create constructor given language and content
        public Word(string language, string content)
        {
            //Assign variables
            this.language = language.ToLower();
            this.content = content.ToLower();


            //Get id from database // find word from input text
            using (StreamReader reader = new StreamReader("Database/" + this.language + ".txt"))
            {
                //Search for word content and increment id
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    this.id++;
                    if (line.Equals(content))
                    {
                        //Break if content is found
                        break;
                    }
                }

                //Set id to 0 if content is not found
                if (line == null)
                {
                    this.id = 0;
                    MessageBox.Show("The word \"" + content + "\" has no current translation.");
                }
            }

        }

        //Create constructor given language and id
        public Word(string language, int id)
        {
            //Assign variables
            this.language = language.ToLower();
            this.id = id;

            //Get content from database // find translation based on ID in txt
            using (StreamReader reader = new StreamReader("Database/" + this.language + ".txt"))
            {
                for (int i = 0; i < this.id; i++)
                {
                    this.content = reader.ReadLine();
                }
            }
        }

        //Translate Word into new Word
        public Word translate(string language)
        {
            return new Word(language, this.id);
        }

        

        //Generate synonym word from synonyms list
        public Word generateSynonym()       //Synonym code has not been implemented yet
        {
            if (synonyms != null)
            {
                Random random = new Random();
                return synonyms[random.Next(0, (synonyms.Length - 1))];
            }
            else
            {
                return this;
            }
        }

        //Add synonym to synonyms list
        public void addSynonym(Word synonym)
        {
            //Not implemented
        }
    }
}
