using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;

        public Form1()
        {
            InitializeComponent();
        }
        
       
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int mR, mG, mB;
            mR = 0; mG = 0; mB = 0;
            for (int i = e.X - 5; i < e.X + 5; i++)
                for (int j = e.Y - 5; j < e.Y + 5; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            textBox1.Text = mR.ToString();
            textBox2.Text = mG.ToString();
            textBox3.Text = mB.ToString();
            cR = mR;
            cG = mG;
            cB = mB;

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = "server=(local);user=usuario;pwd=123456;database=academico";
            cmd.Connection = con;
            //solo ingresa si los textBox son  distintos de vacios
            if (textBox4.Text != "" && textBox5.Text != "") { 
                cmd.CommandText = "insert into colores values('" +
                textBox4.Text + "'," + mR.ToString() + "," + mG.ToString()
                + "," + mB.ToString() + ",'" + textBox5.Text + "')";

                textBox4.Text = "";
                textBox5.Text = "";
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "server=(local);user=usuario;pwd=123456;database=academico";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i=0;i<bmp.Width;i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i,j);
                    bmp2.SetPixel(i, j, Color.FromArgb(c.R, 0, 0));
                }
            pictureBox2.Image = bmp2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, c.G, 0));
                }
            pictureBox2.Image = bmp2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, 0, c.B));
                }
            pictureBox2.Image = bmp2;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           

           

           
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int mR, mG, mB;
            mR = 0; mG = 0; mB = 0;
            for (int i = e.X - 5; i < e.X + 5; i++)
                for (int j = e.Y - 5; j < e.Y + 5; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            textBox1.Text = mR.ToString();
            textBox2.Text = mG.ToString();
            textBox3.Text = mB.ToString();
            cR = mR;
            cG = mG;
            cB = mB;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int clR, clG, clB;
            string colorcambio;
            con.ConnectionString = "server=(local);user=usuario;pwd=123456;database=academico";
            cmd.Connection = con;
            cmd.CommandText = "select * from colores";
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cR = dr.GetInt32(1);
                cG = dr.GetInt32(2);
                cB = dr.GetInt32(3);
                colorcambio = dr.GetString(4);
                
                bmp2 = new Bitmap(bmp.Width, bmp.Height);
                for (int i = 0; i < bmp.Width; i++)
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        c = bmp.GetPixel(i, j);
                        if (((cR - 10 < c.R) && (c.R < cR + 10)) && ((cG - 10 < c.G) && (c.G < cG + 10))
                            && ((cB - 10 < c.B) && (c.B < cB + 10)))
                        {
                            clR = Convert.ToInt32(colorcambio.Substring(0, 2),16);
                            clG = Convert.ToInt32(colorcambio.Substring(2, 2),16);
                            clB = Convert.ToInt32(colorcambio.Substring(4, 2),16);
                            //textBox5.Text = clB.ToString();
                            /*if (colorcambio=="333dff")
                                bmp2.SetPixel(i, j, Color.FromArgb(clR, clG, clB));
                            if (colorcambio=="4d1f05")
                                bmp2.SetPixel(i, j, Color.FromArgb(clR, clG, clB));
                            if (colorcambio=="054d1a")/*/
                                bmp2.SetPixel(i, j, Color.FromArgb(clR, clG, clB));
                        }
                        else
                            bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }
                    bmp = bmp2;
             }
            pictureBox2.Image = bmp2;
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CargarDatosTabla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);

            con.ConnectionString = "server=(local);user=usuario;pwd=123456;database=academico";
            cmd.Connection = con;
            cmd.CommandText = "select * from colores";
            con.Open();
            dr = cmd.ExecuteReader();

            //ejecutamos cada textura
            while (dr.Read())
            {   //colores de la consulta
                int cR = dr.GetInt32(1);
                int cG = dr.GetInt32(2);
                int cB = dr.GetInt32(3);
                string colorcambio = dr.GetString(4);
                
                for (int i = 0; i < bmp.Width - 10; i = i + 10)
                {
                    for (int j = 0; j < bmp.Height - 10; j = j + 10)
                    {
                        int mmR = 0;
                        int mmG = 0;
                        int mmB = 0;

                        for (int k = i; k < i + 10; k++)
                        {
                            for (int l = j; l < j + 10; l++)
                            {
                                Color c = bmp.GetPixel(k, l);
                                mmR = mmR + c.R;
                                mmG = mmG + c.G;
                                mmB = mmB + c.B;
                            }
                        }

                        mmR = mmR / 100;
                        mmG = mmG / 100;
                        mmB = mmB / 100;

                        if (((cR - 10 < mmR) && (mmR < cR + 10)) && ((cG - 10 < mmG) && (mmG < cG + 10))
                            && ((cB - 10 < mmB) && (mmB < cB + 10)))
                        {
                            //colores de cambio
                            int clR = Convert.ToInt32(colorcambio.Substring(0, 2), 16);
                            int clG = Convert.ToInt32(colorcambio.Substring(2, 2), 16);
                            int clB = Convert.ToInt32(colorcambio.Substring(4, 2), 16);

                            for (int k = i; k < i + 10; k++)
                            {
                                for (int l = j; l < j + 10; l++)
                                {
                                    //Console.WriteLine("pasa:   " + colorcambio);
                                    bmp2.SetPixel(k, l, Color.FromArgb(clR, clG, clB));
                                }
                            }
                        }
                        else
                        {
                            for (int k = i; k < i + 10; k++)
                            {
                                for (int l = j; l < j + 10; l++)
                                {
                                    Color c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, Color.FromArgb(c.R, c.G, c.B));
                                }
                            }
                        }
                    }
                }
                bmp = bmp2;
            }

            pictureBox2.Image = bmp2;
            con.Close();
        }
        private void CargarDatosTabla()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            DataSet dataSet = new DataSet();

            con.ConnectionString = "server=(local);user=usuario;pwd=123456;database=academico";
            cmd.Connection = con;
            cmd.CommandText = "select color, descripcion from colores";
            con.Open();
            dr = cmd.ExecuteReader();

            DataTable dataTable = new DataTable("Info");
            dataTable.Load(dr);
            dataSet.Tables.Add(dataTable);

            // Agregar nueva columna para mostrar el color en cuadrado
            DataGridViewButtonColumn colorColumn = new DataGridViewButtonColumn();
            colorColumn.HeaderText = "Color";
            colorColumn.Name = "ColorColumn";
            colorColumn.Text = " "; // Espacio en blanco para que el botón aparezca vacío
            colorColumn.UseColumnTextForButtonValue = false;
            colorColumn.FlatStyle = FlatStyle.Flat;
            colorColumn.DefaultCellStyle.Padding = new Padding(1);
            colorColumn.DefaultCellStyle.Font = new Font("Arial", 1); // Tamaño de fuente pequeño para que el botón sea un cuadrado
            dataGridView1.Columns.Add(colorColumn);

            // Establecer el DataSource del DataGridView con la tabla del DataSet
            dataGridView1.DataSource = dataSet.Tables["Info"];

            // Convertir el valor en cadena a Color y establecerlo como color de fondo del botón
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["color"].Value != null) // Verificar si el valor de la celda no es nulo
                {
                    
                        string hexColor = row.Cells["color"].Value.ToString();
                        Color color = ColorTranslator.FromHtml("#"+hexColor);
                        row.Cells["ColorColumn"].Style.BackColor = color;
                    
                }
            }
        }
    }
}

