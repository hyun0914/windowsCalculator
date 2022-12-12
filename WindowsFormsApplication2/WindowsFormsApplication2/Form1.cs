using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        String vacate;       

        public Form1()
        {
            InitializeComponent();
        }
    
        private void buttons_Click(object sender, EventArgs e)
        {          
            try
            {
                String getButtonTag = ((Button)sender).Tag.ToString().ToUpper();

                DataTable dt = new DataTable();
                
                switch (getButtonTag)
                {
                    //숫자버튼을 눌렀을 때 이벤트          
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        if (vacate == "EQUAL")
                        {
                            textBox1.Text = ""; vacate = "";
                        }
                        textBox3.Text = textBox3.Text + ((Button)sender).Text;
                        textBox1.Text = textBox1.Text + ((Button)sender).Text;
                        break;
                    //소수점버튼을 눌렀을 때 이벤트  
                    case "COMMA":
                        if (textBox1.Text.IndexOf(".") != -1) return;  //문자열 중 어떤 위치에 소숫점이 두개이상 존재 할 수 없다.
                        textBox1.Text = textBox1.Text + ((Button)sender).Text;
                        textBox3.Text = textBox3.Text + ((Button)sender).Text;
                        break;
                    case "EQUAL":
                        String formula = dt.Compute(textBox3.Text, "").ToString();
                        textBox1.Text = formula;
                        textBox2.Text = textBox2.Text + textBox3.Text + ((Button)sender).Text + formula + "\r\n";
                        textBox3.Text = "";
                        vacate = "EQUAL";
                        break;
                    //사칙연산버튼을 눌렀을 때 이벤트
                    case "PLUS":
                        if (textBox3.Text.Substring(textBox3.Text.Length - 1, 1) == "+") return;
                        switch (textBox3.Text.Substring(textBox3.Text.Length - 1, 1))
                        {
                            case "-":
                            case "*":
                            case "/":
                            case "%":
                                textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1) + "+";
                                break;
                            default:
                                textBox3.Text = textBox3.Text + ((Button)sender).Text;
                                textBox1.Text = "";
                                break;
                        }
                        break;
                    case "MINUS":
                        if (textBox3.Text.Substring(textBox3.Text.Length - 1, 1) == "-") return;
                        switch (textBox3.Text.Substring(textBox3.Text.Length - 1, 1))
                        {
                            case "+":
                            case "*":
                            case "/":
                            case "%":
                                textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1) + "-";
                                break;
                            default:
                                textBox3.Text = textBox3.Text + ((Button)sender).Text;
                                textBox1.Text = "";
                                break;
                        }
                        break;
                    case "MULTIPLY":
                        if (textBox3.Text.Substring(textBox3.Text.Length - 1, 1) == "*") return;
                        switch (textBox3.Text.Substring(textBox3.Text.Length - 1, 1))
                        {
                            case "+":
                            case "-":
                            case "/":
                            case "%":
                                textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1) + "*";
                                break;
                            default:
                                textBox3.Text = textBox3.Text + ((Button)sender).Text;
                                textBox1.Text = "";
                                break;
                        }
                        break;
                    case "DIVISION":
                        if (textBox3.Text.Substring(textBox3.Text.Length - 1, 1) == "/") return;
                        switch (textBox3.Text.Substring(textBox3.Text.Length - 1, 1))
                        {
                            case "+":
                            case "-":
                            case "*":
                            case "%":
                                textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1) + "/";
                                break;
                            default:
                                textBox3.Text = textBox3.Text + ((Button)sender).Text;
                                textBox1.Text = "";
                                break;
                        }
                        break;
                    //()버튼 눌렀을 때 이벤트
                    case "BRACKET1":              
                        textBox3.Text = textBox3.Text + ((Button)sender).Text;
                        textBox1.Text = "";     
                        break;
                    case "BRACKET2":                      
                        textBox3.Text = textBox3.Text + ((Button)sender).Text;
                        textBox1.Text = "";
                        break;
                    //AC버튼을 눌렀을 때 이벤트
                    case "AC":
                        textBox1.Text = "";
                        textBox3.Text = "";
                        break;
                    //Back Space버튼을 눌렀을 때 이벤트
                    default:
                        if (textBox1.Text.Length == 0)
                        {
                            if (textBox3.Text.Length == 0) return;
                            textBox1.Text = "";
                            textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1);
                        }
                        else
                        {
                            if (textBox3.Text.Length == 0)
                            {
                                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                            }
                            else
                            {
                                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                                textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1);
                            }
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
               
            }           
        }
    }
}