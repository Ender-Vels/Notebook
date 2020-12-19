using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rich
{
	public partial class Form3 : Form
	{
		NoteContext db;//контекст даних
		public Form3()
		{
			InitializeComponent();

			db = new NoteContext(); //ініціалізація контекста даних
			db.Notes.Load();// загрузка бази

			dataGridView1.DataSource = db.Notes.Local.ToBindingList(); //підгрузка в датагрид
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form4 form4 = new Form4();
			DialogResult result = form4.ShowDialog(this);//Форма 4 викликається як діалогова

			if (result == DialogResult.Cancel)
				return;


			Note note = new Note();
			note.Noting = form4.textBox1.Text;
			note.DateTime = DateTime.Now;
			db.Notes.Add(note);//передання даних в локальну базу
			db.SaveChanges();//збереження даних з обєкту в базу

			MessageBox.Show("Новий запис додано!");

		}

		private void button2_Click(object sender, EventArgs e)// редагування даних
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int index = dataGridView1.SelectedRows[0].Index;
				int id = 0;
				bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
				if (converted == false)
					return;


				Note note = db.Notes.Find(id);//пошук запису по айді
				Form4 form4 = new Form4();

				form4.textBox1.Text = note.Noting;

				DialogResult result = form4.ShowDialog(this);//фора 4 виступпає як діалогове вікно

				if (result == DialogResult.Cancel)
					return;



				note.Noting = form4.textBox1.Text;
				note.DateTime = DateTime.Now;
				db.SaveChanges();
				dataGridView1.Refresh();//після збереження обновлюємо датагрід для обновлення внесених даних

				MessageBox.Show("Запис відредаговано!");

			}
		}

		private void button3_Click(object sender, EventArgs e)//видалення
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int index = dataGridView1.SelectedRows[0].Index;
				int id = 0;
				bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
				if (converted == false)
					return;

				Note note = db.Notes.Find(id);

				db.Notes.Remove(note);//видалення
				db.SaveChanges();

				MessageBox.Show("Запис Видалено!");
			}
		}

		private void button5_Click(object sender, EventArgs e)//назад
		{
			Form1 form1 = new Form1();
			Form3 form3 = new Form3();
			form3.Close();
			form1.Show();
			
		}

		private void button4_Click(object sender, EventArgs e)//вихід
		{
			Application.Exit();
		}
	}
}
