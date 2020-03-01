using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string Slojenie(string number1, string number2) 
        {
            int i,max,s,zpz1,zpz2;
            string otvet1,otvet2,cnumber,save;
            zpz1 = 0;
            zpz2 = 0;
            if (number1.Contains(","))
            {
                zpz1 = number1.Length - number1.IndexOf(',') - 1;
                number1 = (double.Parse(number1) * Math.Pow(10, zpz1+zpz2)).ToString();
                number2 = (double.Parse(number2) * Math.Pow(10, zpz1+zpz2)).ToString();
            }
            if (number2.Contains(","))
            {
                zpz2 = number2.Length - number1.IndexOf(',') - 1;
                number1 = (double.Parse(number1) * Math.Pow(10, zpz1+zpz2)).ToString();
                number2 = (double.Parse(number2) * Math.Pow(10, zpz1+zpz2)).ToString();
            }
            max = Math.Max(number1.Length, number2.Length);
            if(number1.Length>number2.Length)
            {
                save = number2;
                number2 = "";
                for (i=0;i<number1.Length-save.Length;i++)
                {
                    number2 += "0";
                }
                number2 += save;
            }
            else
            {
                save = number1;
                number1 = "";
                for (i = 0; i < number2.Length - save.Length; i++)
                {
                    number1 += "0";
                }
                number1 += save;
            }
            otvet1 = "";
            otvet2 = "";
            s = 0;
            for (i=max-1;i>=0;i--)
            {
                cnumber = (int.Parse(number1[i].ToString()) + int.Parse(number2[i].ToString())).ToString();
                cnumber = (int.Parse(cnumber) + s).ToString();
                s = 0;
                
                if (int.Parse(cnumber) > 9)
                {
                    otvet1 += int.Parse(cnumber) % Math.Pow(10, cnumber.Length - 1);
                    s += 1;
                }
                else
                {
                    otvet1 += cnumber;
                }
               
            }
            for (i = otvet1.Length - 1; i >= 0; i--)
            {
                otvet2 += otvet1[i].ToString();
            }
            if(zpz1>0||zpz2>0)
            {
               otvet2 = otvet2.Insert(otvet2.Length - (zpz1 + zpz2), ",");
            }
            return otvet2;
        }
        
         public static string Umnojenie(string number1, string number2) 
         {
          int i,max,s,zpz1,zpz2;
          double cnumber;
          string otvet,save;
            zpz1 = 0;
            zpz2 = 0;
            if (number1.Contains(","))
            {
                zpz1 = number1.Length - number1.IndexOf(',') - 1;
                number1 = (double.Parse(number1) * Math.Pow(10, zpz1 + zpz2)).ToString();
            }
            if (number2.Contains(","))
            {
                zpz2 = number2.Length - number1.IndexOf(',') - 1;
                number2 = (double.Parse(number2) * Math.Pow(10, zpz1 + zpz2)).ToString();
            }
            if (number1.Length > number2.Length)
            {
                save = number2;
                number2 = "";
                for (i = 0; i < number1.Length - save.Length; i++)
                {
                    number2 += "0";
                }
                number2 += save;
            }
            else
            {
                save = number1;
                number1 = "";
                for (i = 0; i < number2.Length - save.Length; i++)
                {
                    number1 += "0";
                }
                number1 += save;
            }
            s = -1;
            otvet = "0";
            max = Math.Max(number1.Length, number2.Length);
            for (i = max - 1; i >= 0; i--)
            {
                s += 1;
                cnumber = int.Parse(number1) * int.Parse(number2[i].ToString());
                cnumber *= Math.Pow(10, s);
                otvet = (int.Parse(otvet) + cnumber).ToString();
            }
            if (zpz1 > 0 || zpz2 > 0)
            {
                otvet = otvet.Insert(otvet.Length - (zpz1 + zpz2), ",");
            }
            return otvet;
         }
        public static string Delenie (string number1, string number2)
        {
            bool check1,check2;
            int i,mod,s,zpz1,zpz2;
            string otvet,cnumber;
            otvet = "";
            cnumber = "";
            mod = 0;
            s = 0;
            zpz1 = 0;
            zpz2 = 0;
            check1 = false;
            check2 = false;
            if (number1.Contains(","))
            {
                zpz1 = number1.Length - number1.IndexOf(',') - 1;
                number1 = (double.Parse(number1) * Math.Pow(10, zpz1 + zpz2)).ToString();
                number2 = (double.Parse(number2) * Math.Pow(10, zpz1 + zpz2)).ToString();
            }
            if (number2.Contains(","))
            {
                zpz2 = number2.Length - number1.IndexOf(',') - 1;
                number1 = (double.Parse(number1) * Math.Pow(10, zpz1 + zpz2)).ToString();
                number2 = (double.Parse(number2) * Math.Pow(10, zpz1 + zpz2)).ToString();
            }
            for (i = 0; ;i++)
            {
                if ((mod == 0 && i < number1.Length) || (mod > 0 && i < number1.Length))
                {
                    cnumber += number1[i].ToString();
                    if (int.Parse(cnumber) / int.Parse(number2) > 0)
                    {
                        check1 = true;
                        otvet += int.Parse(cnumber) / int.Parse(number2);
                        mod = int.Parse(cnumber) % int.Parse(number2);
                        if (int.Parse(cnumber) % int.Parse(number2) == 0) cnumber = "";
                        else cnumber = (int.Parse(cnumber) % int.Parse(number2)).ToString();

                    }
                    else
                    {
                        if (cnumber == "0" || (check1 == true && (int.Parse(number1[i].ToString()) < int.Parse(number2)))) otvet += "0";
                    }

                }
                else if ((mod > 0 && i >= number1.Length))
                {
                    s += 1;
                    if (check2 == false) otvet += ",";
                    check2 = true;
                    mod *= 10;
                    otvet += mod / int.Parse(number2);
                    mod = mod % int.Parse(number2);
                    if (s == 5) break;
                }
                else if((int.Parse(number2) > int.Parse(number1)))
                {

                }
                else break;
            }
            return otvet;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string[] primer = textBox1.Text.Split('/', '+', '-', '*');
            if (textBox1.Text.Contains("/"))
            {
                textBox1.Text += "=" + Delenie(primer[0], primer[1]);
            }
            if (textBox1.Text.Contains("+"))
            {
                textBox1.Text += "=" + Slojenie(primer[0], primer[1]);
            }
            if (textBox1.Text.Contains("*"))
            {
                textBox1.Text += "=" + Umnojenie(primer[0], primer[1]);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
