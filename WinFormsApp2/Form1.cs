namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)// открытие файла
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFile.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)// шифрование
        {
            if (radioButton1.Checked)// цезарь
            {
                var cezar = new Cezar();
                if (int.TryParse(textBox2.Text, out Temp) && textBox2.Text.Length > 0)
                {
                    textBox3.Text = cezar.Code(textBox1.Text, Temp);
                }
                else
                {
                    MessageBox.Show("Введите сдвиг!");
                }
            }
            if (radioButton2.Checked)// вижинер
            {
                if (textBox2.Text.Length > 0)
                {
                    var viziner = new Viziner();
                    textBox3.Text = viziner.Code(textBox1.Text, textBox2.Text, "1");
                }
                else
                    MessageBox.Show("Введите ключевое слово!");
            }
        }
        int Temp = 0;


        private void button2_Click(object sender, EventArgs e)// дешифрование
        {
            if (radioButton1.Checked)// цезарь
            {
                var cezar = new Cezar();
                if (int.TryParse(textBox2.Text, out Temp) && textBox2.Text.Length > 0)
                {
                    textBox3.Text = cezar.Code(textBox1.Text, -Temp);
                }
                else
                {
                    MessageBox.Show("Введите сдвиг!");
                }
            }
            if (radioButton2.Checked)// вижинер
            {
                if (textBox2.Text.Length > 0)
                {
                    var viziner = new Viziner();
                    textBox3.Text = viziner.Code(textBox1.Text, textBox2.Text, "0");

                }
                else
                    MessageBox.Show("Введите ключевое слово!");
            }

        }

        private void button4_Click(object sender, EventArgs e)// скачать файл
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Test files|*.txt";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName, true))
                {
                    sw.WriteLine(textBox3.Text);
                    sw.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".txt";
            saveFile.Filter = "Test files|*.txt";
            int shift = 0;
            Char[,] table = new char[32, 32];
            string a = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            string text = "";
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    shift = (j + i) % 32;
                    table[i, j] = a[shift];
                    text += table[i, j];
                }
                text += "\n";
            }
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName, true))
                {
                    sw.WriteLine(text);
                    sw.Close();
                }
            }
        }
    }
}