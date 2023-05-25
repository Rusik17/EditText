using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EditText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click_1(object sender, EventArgs e)
        {
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем был ли выбран файл
                {
                    richTextBox1.Clear(); //Очищаем richTextBox
                    openFileDialog1.Filter = "Text Files (*.txt)|*.txt"; //Указываем что нас интересуют только текстовые файлы
                string fileName = openFileDialog1.FileName; //получаем наименование файл и путь к нему.
                    richTextBox1.Text = File.ReadAllText(fileName, Encoding.GetEncoding(1251)); //Передаем содержимое файла в richTextBox
                }
            }

        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";//Задаем доступные расширения
            saveFileDialog1.DefaultExt = ".txt"; //Задаем расширение по умолчанию
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем подтверждение сохранения информации.
            {
                var name = saveFileDialog1.FileName; //Задаем имя файлу
                File.WriteAllText(name, richTextBox1.Text, Encoding.GetEncoding(1251)); //Записываем в файл содержимое textBox с кодировкой 1251
            }
            richTextBox1.Clear();
        }

        private void buttonCut_Click_1(object sender, EventArgs e)
        {
            // Ensure that text is currently selected in the text box.   
            if (richTextBox1.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                richTextBox1.Cut();
        }

        private void buttonCopy_Click_1(object sender, EventArgs e)
        {
            // Ensure that text is selected in the text box.   
            if (richTextBox1.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                richTextBox1.Copy();
        }

        private void buttonPaste_Click_1(object sender, EventArgs e)
        {
            // Determine if there is any text in the Clipboard to paste into the text box.
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (richTextBox1.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                richTextBox1.Paste();
            }
        }

        private void поЛевомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Select(); // выравнивание только выделенного текста
                                  //richTextBox1.SelectAll(); //выделение всего текста
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            //richTextBox1.DeselectAll(); //Отмена выделения
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Select(); // выравнивание только выделенного текста
                                  //richTextBox1.SelectAll(); //выделение всего текста
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            //richTextBox1.DeselectAll(); //Отмена выделения
        }

        private void поПравомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Select(); // выравнивание только выделенного текста
                                  //richTextBox1.SelectAll(); //выделение всего текста
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            //richTextBox1.DeselectAll(); //Отмена выделения
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font myFont = new Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            string Hello = "Hello World!";
            e.Graphics.DrawString(Hello, myFont, Brushes.Black, 20, 20);
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK) 
                printDocument1.Print();
        }

        private void предварительныйПросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void настройкаПринтераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем был ли выбран файл
                {
                    richTextBox1.Clear(); //Очищаем richTextBox
                    openFileDialog1.Filter = "Text Files (*.txt)|*.txt"; //Указываем что нас интересуют только текстовые файлы
                    string fileName = openFileDialog1.FileName; //получаем наименование файл и путь к нему.
                    richTextBox1.Text = File.ReadAllText(fileName, Encoding.GetEncoding(1251)); //Передаем содержимое файла в richTextBox
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";//Задаем доступные расширения
            saveFileDialog1.DefaultExt = ".txt"; //Задаем расширение по умолчанию
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем подтверждение сохранения информации.
            {
                var name = saveFileDialog1.FileName; //Задаем имя файлу
                File.WriteAllText(name, richTextBox1.Text, Encoding.GetEncoding(1251)); //Записываем в файл содержимое textBox с кодировкой 1251
            }
            richTextBox1.Clear();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ensure that text is currently selected in the text box.   
            if (richTextBox1.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                richTextBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ensure that text is selected in the text box.   
            if (richTextBox1.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine if there is any text in the Clipboard to paste into the text box.
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (richTextBox1.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                richTextBox1.Paste();
            }
        }

        private void buttonColor_Click_1(object sender, EventArgs e)
        {
            ColorDialog colorDialog2 = new ColorDialog();
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog2.Color;
                richTextBox1.SelectionColor = selectedColor;
                richTextBox1.SelectionLength = 0;
            }
        }

        private void buttonFont_Click_1(object sender, EventArgs e)
        {
            FontDialog fontDialog2 = new FontDialog();
            if (fontDialog2.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = fontDialog2.Font;
                richTextBox1.SelectionFont = selectedFont;
                richTextBox1.SelectionLength = 0;
            }

        }

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog2 = new ColorDialog();
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog2.Color;
                richTextBox1.SelectionColor = selectedColor;
                richTextBox1.SelectionLength = 0;
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog2 = new FontDialog();
            if (fontDialog2.ShowDialog() == DialogResult.OK)
            { 
                Font selectedFont = fontDialog2.Font;
                richTextBox1.SelectionFont = selectedFont;
                richTextBox1.SelectionLength = 0;
            }
        }

        private void buttonHighlight_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.Focus();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 abtbt = new AboutBox1();
            abtbt.ShowDialog();
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Ensure that text is currently selected in the text box.   
            if (richTextBox1.SelectedText != "")
                // Cut the selected text in the control and paste it into the Clipboard.
                richTextBox1.Cut();
        }

        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Ensure that text is selected in the text box.   
            if (richTextBox1.SelectionLength > 0)
                // Copy the selected text to the Clipboard.
                richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Determine if there is any text in the Clipboard to paste into the text box.
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                // Determine if any text is selected in the text box.
                if (richTextBox1.SelectionLength > 0)
                {
                    // Ask user if they want to paste over currently selected text.
                    if (MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
                        // Move selection to the point after the current selection and paste.
                        richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                }
                // Paste current text in Clipboard into text box.
                richTextBox1.Paste();
            }
        }

        private void очиститьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
    
}
