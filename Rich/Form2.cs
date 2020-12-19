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



namespace Rich
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void Rich_Load(object sender, EventArgs e)//загрузка шрифтів
		{
			foreach (FontFamily font in FontFamily.Families)// при загрузке программы 
			{
				toolStripComboBox1.Items.Add(font.Name);//добавляет шрифты
			}

			toolStripComboBox1.SelectedIndex = 0;
			toolStripComboBox2.SelectedIndex = 0;
		}

		private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Clear();
		}

		private void выдкритиToolStripMenuItem_Click(object sender, EventArgs e)
		{
		if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) // если диалоговое окно открыто и результат положительный то открываеться имя по файлу
			{
				richTextBox1.LoadFile(openFileDialog1.FileName); // Метод открытия файла openFileDialog1-метод, FileName-имя файла
			}
		}

		private void зберегтиЯкToolStripMenuItem_Click(object sender, EventArgs e)//сохранение
		{
			if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) //то же самое что и с открытием
			{
				richTextBox1.SaveFile(saveFileDialog1.FileName);
			}
		}

		private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();//закрытие по нажатию
		}

		private void відмінитиToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			richTextBox1.Undo(); //метод отмены
		}

		private void повторитиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Redo();
		}

		private void вирізатиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Cut();
		}

		private void копіюватиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Copy();
		}

		private void вставитиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Paste();
		}

		private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectedRtf = "";
		}

		private void виділитиВсеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectAll();
		}

		private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) // если фонт список отобразится в форме то при выборе
			{
				richTextBox1.Font = fontDialog1.Font; // в текстбоксе будет этот шрифт  richTextBox1.Font-дефолтный шрифт которому присваивается  вфбранный шрифт в списке fontDialog1.Font
			}
		}


		private void font_SelectionChanged(object sender, EventArgs e)
		{
			if (toolStripComboBox1.SelectedItem == null
				| toolStripComboBox2.SelectedItem == null) // чтобы не было ошибки, когда не выбран никакой шрифт или никакой размер шрифта
			{
				return;
			}

			FontStyle fontStyle = FontStyle.Regular; //стандартный стиль текста

			if (toolStripButton1.Checked) //условие: Если выбран 
			{
				fontStyle |= FontStyle.Bold; // меняеться на жирный текст
			}

			if (toolStripButton2.Checked)//условие: Если выбран 
			{
				fontStyle |= FontStyle.Italic; //меняеться на курсив
			}

			if (toolStripButton3.Checked)//условие: Если выбран 
			{
				fontStyle |= FontStyle.Underline; // текст с подчеркиванием
			}

			richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(),//подключеніє як обєкта шрифтів і синхронізація з курсив жирний або підчеркнуто
				float.Parse(toolStripComboBox2.SelectedItem.ToString()),
				fontStyle);

			richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
			richTextBox1.SelectionLength = 0;

			richTextBox1.SelectionFont = richTextBox1.Font;
		}
	}
}
