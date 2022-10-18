using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab_3_5_Var_
{
    public partial class Form1 : Form
    {
        string path = "C:\\TestFile.txt";

        string[] arrayLine = new string[10];

        string[] readyArrayLine = {
                    "First line",
                    "Second line",
                    "Third line",
                    "Fourth line",
                    "Fifth line",
                    "Sixth line",
                    "Seventh line",
                    "Eighth line",
                    "Ninth line",
                    "Tenth line"
                };

        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.FromKnownColor(KnownColor.Azure);

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    int i = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        arrayLine[i] = line;
                        i++;
                    }
                }
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                for (int i = 0; i < arrayLine.Length; i++)
                {
                    writer.WriteLine(arrayLine[i]);
                }
            }

        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < arrayLine.Length; i++)
                if (arrayLine[i] == null)
                    arrayLine[i] = readyArrayLine[i];
            
            Graphics g = pictureBox1.CreateGraphics();

            FontStyle fontStyle;
            Font fn = new Font("Arial", 36); 
            StringFormat sf;

            float marginTop = 0;

            for (int i = 0; i < arrayLine.Length; i++)
            {
                if (i < 6)
                {
                    sf = (StringFormat)StringFormat.GenericTypographic.Clone();

                    fontStyle = FontStyle.Underline;

                    fn = new Font("Arial", 36, fontStyle);

                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;

                    g.DrawString(arrayLine[i], fn, Brushes.Black,
                                 new RectangleF(0 + marginTop, 0, this.pictureBox1.Width,
                                 this.pictureBox1.Height), sf);

                    marginTop += 48;
                }
                else if (i > 5 && i < 9)
                {
                    if(i == 6)
                        marginTop = 0;

                    sf = (StringFormat)StringFormat.GenericTypographic.Clone();

                    fontStyle = FontStyle.Regular;

                    fn = new Font("Broadway", 24, fontStyle);

                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;

                    g.DrawString(arrayLine[i], fn, Brushes.Black,
                                 new RectangleF(0, 0 + marginTop, this.pictureBox1.Width,
                                this.pictureBox1.Height), sf);

                    marginTop += 32;
                } else if( i > 8)
                {
                    g.PageUnit = GraphicsUnit.Inch;

                    sf = (StringFormat)StringFormat.GenericTypographic.Clone();

                    fontStyle = FontStyle.Strikeout;

                    fn = new Font("Times New Roman", 96 * 0.5f, fontStyle);

                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;

                    g.DrawString(arrayLine[i], fn, Brushes.Black,
                                 new RectangleF(0, 0, this.pictureBox1.Width/96,
                                 this.pictureBox1.Height/96), sf);
                }
            }

            fn.Dispose();
        }
        
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
        }

    }
}
