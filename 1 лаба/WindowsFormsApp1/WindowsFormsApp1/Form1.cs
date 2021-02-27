using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {




        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {


            EncrText.Clear();

            var Reader = new StringReader();
            Reader.Source = DecrText;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    var R = new RailFenceEnc();
                    R.Key = (int)KeyNumb.Value;
                    while (Reader.ReadLine())
                    {
                        R.Text = Reader.LastLine;
                        R.EncryptText();
                        EncrText.Text = EncrText.Text + R.Text + "\r\n";
                    }
                    break;
                case 1:
                    var T = new TableEncrypt();
                    T.Key = KeyBox.Text;
                    if (T.Key == "")
                        return;
                    while (Reader.ReadLine())
                    {
                        T.Text = Reader.LastLine;
                        T.EncryptText();
                        EncrText.Text = EncrText.Text + T.Text + "\r\n";
                    }
                    break;
                case 2:
                    var V = new VigenerEncrypt();
                    V.Key = KeyBox.Text;
                    if (V.Key == "")
                        return;
                    while (Reader.ReadLine())
                    {
                        V.Text = Reader.LastLine;
                        V.EncryptText();
                        EncrText.Text = EncrText.Text + V.Text + "\r\n";
                    }
                    break;
                case 3:
                    var Rs = new ReshetkaEncrypt();
                    while (Reader.ReadLine())
                    {
                        Rs.Text = Reader.LastLine;
                        Rs.EncryptText();
                        EncrText.Text = EncrText.Text + Rs.Text + "\r\n";
                    }

                    break;

            }




            
           
            
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            int ind = comboBox1.SelectedIndex;
            DecrText.Clear();
            var Reader = new StringReader();     
            Reader.Source = EncrText;

            switch (ind) {
                case 0:
                    var R = new RailFenceEnc();
                    R.Key = (int)KeyNumb.Value;

                    while (Reader.ReadLine())
                    {
                        R.Text = Reader.LastLine;
                        R.DecryptText();
                        DecrText.Text = DecrText.Text + R.Text + "\r\n";
                    }
                    break;

                case 1:
                    var T = new TableEncrypt();
                    T.Key = KeyBox.Text;
                    if (T.Key == "")
                        return;
                    while (Reader.ReadLine())
                    {
                        T.Text = Reader.LastLine;
                        T.DecryptText();
                        DecrText.Text = DecrText.Text + T.Text + "\r\n";
                    }
                    break;
                case 2:
                    var V = new VigenerEncrypt();
                    V.Key = KeyBox.Text;
                    if (V.Key == "")
                        return;
                    while (Reader.ReadLine())
                    {
                        V.Text = Reader.LastLine;
                        V.DecryptText();
                        DecrText.Text = DecrText.Text + V.Text + "\r\n";
                    }
                    break;
                case 3:
                    var Rs = new ReshetkaEncrypt();
                    while (Reader.ReadLine())
                    {
                        Rs.Text = Reader.LastLine;
                        Rs.DecryptText();
                        DecrText.Text = DecrText.Text + Rs.Text + "\r\n";
                    }

                    break;


            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                KeyNumb.Visible = true;
                KeyBox.Visible = false;
                label1.Visible = true;
            }
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
            {
                KeyNumb.Visible = false;
                KeyBox.Visible = true;
                label1.Visible = true;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                KeyNumb.Visible = false;
                KeyBox.Visible = false;
                label1.Visible = false;
            }

        }
    }




    public class RailFenceEnc : Object
    {
        private int key = 0;
        private string text = "";

        public int Key
        {
            get
            {
                return key;
            }

            set
            {
                if (value >= 0)
                    key = value;
                else
                    MessageBox.Show("Invalid Key value");

            }
        }
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        public void EncryptText() {

            int len = text.Length;
            char[,]tmp = new char [key,len];

            int i = 0, j = 0, ost, period = 2*(key-1); ;
            for ( i = 0; i < len ; i++ )
            {
                ost = i % period;
                j = key - 1 - Math.Abs(key - 1 - ost);              
                tmp[j,i] = text[i];       
            }
            text = "";
            for (i = 0; i < key; i++)
                for (j = 0; j < len; j++)
                    if (tmp[i, j] != 0)
                        text = text + tmp[i, j];
            
        }
        public void DecryptText() {

            string result = "";
            int len = text.Length;
            char[,] tmp = new char[key, len];

            int cycle = 2 * key - 2, i = 0, rowkey = key, step = cycle, row, n;
            int char_pos, block;
            for ( row = 0; row < key  ; row++ ) {
                char_pos = row ;
                n = 1;

                while ( char_pos < len)
                {
                    
                    if (i >= len)
                        break;
                    tmp[row,char_pos] = text[i];
                    i++;
                    if (row != 0 && row !=( key - 1))
                    {
                        char_pos += step;
                        n = -n; 
                        if (n < 0)
                            step = row*2;
                        else
                            step = 2 * rowkey - 2;
                        

                    }
                    else
                        char_pos += step;

                }
                rowkey--;
                if (rowkey == 1)
                    rowkey = key;
                step = 2 * rowkey - 2;
            }

            step = 1;
            row = 0;

            for (i = 0; i < len; i++)
            {
                result = result + tmp[row, i];
                row = row + step;
                if (row == key - 1 || row == 0)
                    step = -step;
            }

            text = result;

        }



    }

    public class TableEncrypt : Object
    {
        private string key = "";
        private string text = "";
        private int[] keys;

        public string Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        private void TurnIntoNums()
        {
            int len = key.Length,j,i, min;
            char[] tmp = key.ToCharArray();
            keys = new int[len];
            for (i = 0; i < len; i++)
            {
                min = 0;
                for (j = 1; j < len; j++)
                {
                    if (tmp[min] > tmp[j])
                        min = j;
                }
                keys[i] = min;
                tmp[min] = Char.MaxValue;

            }

        }


        public void EncryptText()
        {
            int len = key.Length, rows = text.Length/len +1,i,j,k;
            this.TurnIntoNums();
            char[,] tmp = new char[rows, len];

            k = 0;
            for (i = 0; i < rows; i++)           
                for (j=0; j < len; j++)
                {
                    if ( k < text.Length)
                    {
                        tmp[i, j] = text[k];
                        k++;
                    }
                    else
                        tmp[i, j] = Char.MaxValue;

                }

            string result = "";

            for (i = 0; i < len; i++)
            {
                k = keys[i];
                for (j = 0; j < rows; j++)
                {
                    if (tmp[j, k] != Char.MaxValue)
                        result = result + tmp[j,k];
                }
            }
            text = result;



        }

        public void DecryptText()
        {
            int len = key.Length, rows = text.Length / len + 1, i, j, k,g;
            int LastRow = text.Length % len;
            this.TurnIntoNums();
            char[,] tmp = new char[rows, len];

            g = 0;
            for (i = 0; i < len; i++)
            {
                k = keys[i];
                
                for (j = 0; j < rows; j++)
                {
                    if (j == rows - 1 && k >=LastRow)
                        tmp[j,k] = Char.MaxValue;
                    else
                    {
                        tmp[j, k] = text[g];
                        g++;
                    }
                }
            }

            text = "";
            for (i = 0; i < rows; i++)
                for (j = 0; j < len; j++)
                {
                    if (tmp[i, j] != Char.MaxValue)
                        text = text + tmp[i,j];
                }


        }



    }

    public class ReshetkaEncrypt : Object
    {
        const int size = 4;
        private string text = "";
        private int[,] table1 = { { 1, 0, 0, 0 }, { 0, 0, 0, 1 }, { 0, 0, 1, 0 }, { 0, 1, 0, 0 } };
        private int[,] table2 = { { 0, 0, 0, 1 }, { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 } };
        private int[,] table3 = { { 0, 0, 1, 0 }, { 0, 1, 0, 0 }, { 1, 0, 0, 0 }, { 0, 0, 0, 1 } };
        private int[,] table4 = { { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 }, { 1, 0, 0, 0 } };




        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        private string encTwoBytes(char[] s)
        {
            char[, ] tmp = new char [size, size];
            int i,j,l=0;
            string result = "";
            for ( i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (table1[i,j] == 1) {
                        tmp[i, j] = s[l];
                        l++;
                    }

                }
            }
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (table2[i, j] == 1)
                    {
                        tmp[i, j] = s[l];
                        l++;
                    }

                }
            }
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (table3[i, j] == 1)
                    {
                        tmp[i, j] = s[l];
                        l++;
                    }

                }
            }
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (table4[i, j] == 1)
                    {
                        tmp[i, j] = s[l];
                        l++;
                    }

                }
            }

            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                   if(tmp[i,j] != 0)
                       result = result + tmp[i, j];

                }
            }

            return result;
        }

        public void EncryptText()
        {

            int S = size * size, len = text.Length;
            string result = "";
            char[] tmp = new char[S];
            int k = text.Length / 16,i;
            if (text.Length % 16 != 0)
                k++;
            for (i = 0; i < k; i++)
            {
                if (len > S)
                    text.CopyTo(i * S, tmp, 0, S);
                else
                {
                    text.CopyTo(i * S, tmp, 0, len);
                    for (int j = len; j < S; j++)
                        tmp[j] = '*';
                }
                len -= S;
                result = result + encTwoBytes(tmp);
            }
            text = result;

        }



        private string decTwoBytes(char[] s)
        {
            char[,] tmp = new char[size, size];
            int i, j, l = 0;
            string result = "";
           
            for (i = 0; i < size; i++)
                for (j = 0; j < size; j++)
                    tmp[i, j] = s[i * size + j];

            for (i = 0; i < size; i++)           
                for (j = 0; j < size; j++)              
                    if (table1[i, j] == 1 && tmp[i,j] != 0 && tmp[i, j] != '*')                   
                        result = result + tmp[i, j];

            for (i = 0; i < size; i++)
                for (j = 0; j < size; j++)
                    if (table2[i, j] == 1 && tmp[i, j] != 0 && tmp[i, j] != '*')
                        result = result + tmp[i, j];

            for (i = 0; i < size; i++)
                for (j = 0; j < size; j++)
                    if (table3[i, j] == 1 && tmp[i, j] != 0 && tmp[i, j] != '*')
                        result = result + tmp[i, j];

            for (i = 0; i < size; i++)
                for (j = 0; j < size; j++)
                    if (table4[i, j] == 1 && tmp[i, j] != 0 && tmp[i, j] != '*')
                        result = result + tmp[i, j];

            return result;
        }



        public void DecryptText()
        {
            int S = size * size, len = text.Length;
            string result = "";
            char[] tmp = new char[S];
            int k = text.Length / 16, i;
            if (text.Length % 16 != 0)
                k++;
            for (i = 0; i < k; i++)
            {
                if (len > S)
                    text.CopyTo(i * S, tmp, 0, S);
                else
                    text.CopyTo(i * S, tmp, 0, len);
                len -= S;
                result = result + decTwoBytes(tmp);
            }
            text = result;

        }


    }



    public class VigenerEncrypt : Object
    {
        private const int AlphabetSize = 26;
        private string key = "";
        private string text = "";
        private char[,] keys;

        public string Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }


        private void MakeTable()
        {
            keys = new char[AlphabetSize,AlphabetSize];
            char start = 'a', tmp;
            for (int i = 0; i < AlphabetSize; i++)
            {

                tmp = start;
                for (int j = 0; j < AlphabetSize; j++)
                {
                    keys[i, j] = tmp;
                    tmp++;
                    if (tmp > 'z')
                        tmp = 'a';
                }
                start++;

            }

        }

        public void EncryptText()
        {
            this.MakeTable();
            int len = text.Length, i, a,b;
            text =  text.ToLower();
            string result = "";
            for (i = 0; i < len; i++)
            {
                if (text[i] == ' ')
                {
                    result = result + text[i];
                    continue;
                }
                a = text[i] - 'a';
                b = key[i % key.Length] - 'a';
                result = result + keys[a,b];

            }
            text = result;
        }

        public void DecryptText()
        {
            this.MakeTable();
            int len = text.Length, i, a, b;
            string result = "";
            for (i = 0; i < len; i++)
            {
                if (text[i] == ' ')
                {
                    result = result + text[i];
                    continue;
                }
                b = key[i % key.Length] - 'a';
                a = 'a';
                for (int j = 0; j < AlphabetSize; j++)
                {
                   
                    if (keys[j, b] == text[i])
                        break;
                    a++;

                }

                result = result + (char)a;

            }
            text = result;

        }   



    }


    public class StringReader : Object
    {
        private TextBox source;
        public string LastLine = "";
        private int i = 0;

        public TextBox Source
        {
            set
            {
                i = 0;
                source = value;

            }
        }


        public bool ReadLine()
        {
            if (i >= source.Lines.Length)
                return false;
            else
            {
                LastLine = (string)source.Lines[i];
                i++;
                return true;
            }
        }


    }




}
