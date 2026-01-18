using System;
using System.Collections.Generic;
using System.Windows.Forms;

/**@author Tucker Carda, Helmi Yatim, Peter Ruehle
 * @class CSC 470
 * @date 12//2023*/

namespace Translator
{
    public partial class Translator : Form
    {
        // Add a list to store past translations
        private List<string> pastTranslations = new List<string>();

        public Translator()
        {
            InitializeComponent();
            
        }

        private void Translate_Click(object sender, EventArgs e)
        {
            var text = Input.Text.ToString();
            if (InputLang.Text == OutputLang.Text)
            {
                Output.Text = Input.Text;
            }
            if (InputLang.Text != OutputLang.Text)
            {
                Output.Clear();
                string[] words = Input.Text.Split(new char[]{' '});
                Word single = new Word(InputLang.Text, words[0].ToLower());
                single = single.translate(OutputLang.Text);
                Output.Text += single.content + ' ';
                for (int i = 1; i< words.Length; i++)
                {
                    single = new Word(InputLang.Text, words[i]);
                    single = single.translate(OutputLang.Text);
                    Output.Text += single.content + ' ';
                }

            }

            pastTranslations.Add(Input.Text);
            pastTranslations.Add(InputLang.Text + "=" + OutputLang.Text);
            pastTranslations.Add(Output.Text);
            pastTranslations.Add("---------------");

        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void History_Click(object sender, EventArgs e)
        {
            var pastTranslationsForm = new History(pastTranslations);
            pastTranslationsForm.ShowDialog();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            pastTranslations.Clear();
            MessageBox.Show("Past translations cleared.");
        }

        private void Translator_Load(object sender, EventArgs e)
        {

        }

        private void InputLang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
