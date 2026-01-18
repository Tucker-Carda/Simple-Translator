using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Translator
{
    public partial class History : Form
    {
        private List<string> pastTranslations;
        private TextBox pastTranslationsTextBox;

        public History(List<string> pastTranslations)
        {
            InitializeComponent();
            this.pastTranslations = pastTranslations;
            PopulatePastTranslations();
        }

        private void PopulatePastTranslations()
        {
            // Display past translations in a TextBox or any other control of your choice
            foreach (var translation in pastTranslations)
            {
                pastTranslationsTextBox.Text += translation + Environment.NewLine;
            }
        }

        private void InitializeComponent()
        {
            this.pastTranslationsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pastTranslationsTextBox
            // 
            this.pastTranslationsTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pastTranslationsTextBox.Enabled = false;
            this.pastTranslationsTextBox.Location = new System.Drawing.Point(12, 12);
            this.pastTranslationsTextBox.Multiline = true;
            this.pastTranslationsTextBox.Name = "pastTranslationsTextBox";
            this.pastTranslationsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.pastTranslationsTextBox.Size = new System.Drawing.Size(378, 276);
            this.pastTranslationsTextBox.TabIndex = 0;
            // 
            // History
            // 
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(402, 300);
            this.Controls.Add(this.pastTranslationsTextBox);
            this.Name = "History";
            this.Text = "Translator - History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
