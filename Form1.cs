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
using System.Media;
namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            numberAndImage.Add("0", @"../../0_48px.png");
            numberAndImage.Add("1", @"../../1_48px.png");
            numberAndImage.Add("2", @"../../2_48px.png");
            numberAndImage.Add("3", @"../../3_48px.png");
            numberAndImage.Add("4", @"../../4_48px.png");
            numberAndImage.Add("5", @"../../5_48px.png");
            numberAndImage.Add("6", @"../../6_48px.png");
            numberAndImage.Add("7", @"../../7_48px.png");
            numberAndImage.Add("8", @"../../8_48px.png");
            numberAndImage.Add("9", @"../../9_48px.png");

            PhepTinh.Add(button3);  // tram
            PhepTinh.Add(button2);  // chuc
            PhepTinh.Add(button16); // don vi



            PhepTinh.Add(button17); // tram
            PhepTinh.Add(button18); // chuc
            PhepTinh.Add(button19); // don vi


            ResButton.Add(button20); // ngan
            ResButton.Add(button21); // tram
            ResButton.Add(button23); // chuc
            ResButton.Add(button24); // don vi
            button22.BackgroundImage = Image.FromFile(@"../../minus_48px.png");

            //tabPage3.Text = "Dang Toan 2";
            //tabPage1.Text = "Dang Toan 1";
            fileNamesImg = getAllFileNames(@"../../HinhAnhGame");

            listTextBox.Add(textBox1);
            listTextBox.Add(textBox2);
            listTextBox.Add(textBox3);
            listTextBox.Add(textBox4);


            trueFalseAns[0] = false;
            trueFalseAns[1] = false;
            trueFalseAns[2] = false;
            trueFalseAns[3] = false;


            for(int i = 0; i < 5; ++i)
            {
                CauTraLoi.Add(i+1, "");
            }

        }
        private string[] fileNamesImg;
        private Dictionary<string, string> numberAndImage = new Dictionary<string, string>();
        private List<Button> PhepTinh = new List<Button>();
        private void richTextBox2_TextChanged(object sender, EventArgs e){}

        //private void DapAn_Click(object sender, EventArgs e)
        //{
        //    string NoiDung = NoiDungBT.Text;
        //    if (NoiDung != "")
        //    {
        //        //string[] SentenceBySentence = NoiDung.Split('.');
        //        //string[] s1 = getNumberAndUnit(SentenceBySentence[0]).Split(' ');
        //        //string[] s2 = getNumberAndUnit(SentenceBySentence[1]).Split(' ');

        //        //string tempOp = getOperatorFromQuestionWord(SentenceBySentence[2]);
        //        //switch (tempOp)
        //        //{
        //        //    case "+":
        //        //        DapAn.Text = (Int32.Parse(s1[0]) + Int32.Parse(s2[0])).ToString();
        //        //        break;
        //        //    case "-":
        //        //        break;
        //        //    case "*":
        //        //        break;
        //        //}

        //        var dangToan = comboBox1.GetItemText(comboBox1.SelectedItem);
        //        if (dangToan == "Dang 1")
        //        {
        //            string[] lines = File.ReadAllLines(@"E:\CSharp\FinalProject\DangToan\DapAnDang1.txt");
        //            string lineTemp = "";
        //            for (int i = 0; i < lines.Length; ++i)
        //            {
        //                lineTemp += lines[i];
        //            }
        //            DapAn.Text = lineTemp;
        //        }

        //    }
        //    else
        //    {
        //        return;
        //    }

        //}


        private string getOperatorFromQuestionWord(string s)
        {
            string[] QuestionWord = { "tất cả", "cả hai", "nhiều hơn", "ít hơn", "gấp" };
            Dictionary<string, string> ToanTu = new Dictionary<string, string>();
            ToanTu.Add("tất cả", "+");
            ToanTu.Add("cả hai", "+");
            string Operator = "";
            for (int i = 0; i < QuestionWord.Length; ++i)
            {
                if(s.IndexOf(QuestionWord[i]) >= 0)
                {
                    Operator =  ToanTu[QuestionWord[i]];
                    break;
                }
                
            }
            return Operator;
        }

        
        private string getNumberAndUnit(string s)
        {
            //get Number
            char[] num = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            string number = "";
            for(int i = 0; i < s.Length; ++i)
            {
                for(int j = 0; j < num.Length; ++j)
                {
                    if (s[i] == num[j])
                    {
                        number += s[i];
                    }
                }
            }
            // return number and unit
            int indexOfNumber = s.IndexOf(number);
            string res = s.Substring(indexOfNumber);
            return res;
        }

        /*<------------------------------------------------------------>*/
        private bool[] checkBoxState = new bool[6];
        private void button3_MouseHover(object sender, EventArgs e)
        {
            checkBox1.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                checkBox1.Checked = true;
                checkBoxState[0] = true;
                //MessageBox.Show(checkBoxState[0].ToString());
            }
            else
            {
                checkBox1.Checked = false;
                checkBoxState[0] = false;
                //MessageBox.Show(checkBoxState[0].ToString());
            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Visible = true;
            } 
            else
            {
                checkBox1.Visible = false;
            }
        }
        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                checkBox1.Visible = false;
                checkBoxState[0] = false;
            }
        }

        /*<---------------------------------------------------------------------------->*/

        private bool plus = true;
        private bool currentState;
        private void button22_Click(object sender, EventArgs e)
        {
            if (plus)
            {
                currentState = plus;
                button22.BackgroundImage = Image.FromFile(@"../../plus_48px.png");
                plus = false;
                for(int i = 0; i < ResButton.Count; ++i)
                {
                    ResButton[i].BackgroundImage = null;
                }

            } 
            else
            {
                currentState = plus;
                button22.BackgroundImage = Image.FromFile(@"../../minus_48px.png");
                plus = true;
                for (int i = 0; i < ResButton.Count; ++i)
                {
                    ResButton[i].BackgroundImage = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                checkBox2.Checked = true;
                checkBoxState[1] = true;
            }
            else
            {
                checkBox2.Checked = false;
                checkBoxState[1] = false;

            }
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            checkBox2.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox2.Visible = true;
            }
            else
            {
                checkBox2.Visible = false;
            }
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                checkBox2.Visible = false;
                checkBoxState[1] = false;
            }
        }
        /*----------------------------------------------------------*/
        private void button16_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                checkBox3.Checked = true;
                checkBoxState[2] = true;
            }
            else
            {
                checkBox3.Checked = false;
                checkBoxState[2] = false;
            }
        }

        private void button16_MouseHover(object sender, EventArgs e)
        {
            checkBox3.Visible = true;
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox3.Visible = true;
            }
            else
            {
                checkBox3.Visible = false;
            }
        }

        private void checkBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                checkBox3.Visible = false;
                checkBoxState[2] = false;
            }
        }
        /*----------------------------------------------------------*/
        private void button17_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                checkBox4.Checked = true;
                checkBoxState[3] = true;

            }
            else
            {
                checkBox4.Checked = false;
                checkBoxState[3] = false;
            }
        }

        private void button17_MouseHover(object sender, EventArgs e)
        {
            checkBox4.Visible = true;
        }

        private void button17_MouseLeave(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox4.Visible = true;
            }
            else
            {
                checkBox4.Visible = false;
            }
        }

        private void checkBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                checkBox4.Visible = false;
                checkBoxState[3] = false;
            }
        }
        /*---------------------------------------*/
        private void button18_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == false)
            {
                checkBox5.Checked = true;
                checkBoxState[4] = true;
            }
            else
            {
                checkBox5.Checked = false;
                checkBoxState[4] = false;

            }
        }

        private void button18_MouseHover(object sender, EventArgs e)
        {
            checkBox5.Visible = true;
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox5.Visible = true;
            }
            else
            {
                checkBox5.Visible = false;
            }
        }

        private void checkBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox5.Checked == false)
            {
                checkBox5.Visible = false;
                checkBoxState[4] = false;
            }
        }

        /*---------------------------------------*/
        private void button19_Click(object sender, EventArgs e)
        {
            
            if (checkBox6.Checked == false)
            {
                checkBox6.Checked = true;
                checkBoxState[5] = true;
            }
            else
            {
                checkBox6.Checked = false;
                checkBoxState[5] = false;

            }
        }

        private void button19_MouseHover(object sender, EventArgs e)
        {
            checkBox6.Visible = true;
        }

        private void button19_MouseLeave(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox6.Visible = true;
            }
            else
            {
                checkBox6.Visible = false;
            }
        }

        private void checkBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox6.Checked == false)
            {
                checkBox6.Visible = false;
                checkBoxState[5] = false;
            }
        }

        private void clearButton(object sender, EventArgs e)
        {
            // xoa
            for(int i = 0; i < checkBoxState.Length; ++i)
            {
                if (checkBoxState[i] == true)
                {
                    deleteImageNumber(i);
                    checkBoxState[i] = false;
                }
            }
            /*----------------*/
            checkBox1.Checked = false;
            checkBox1.Visible = false;

            checkBox2.Checked = false;
            checkBox2.Visible = false;

            checkBox3.Checked = false;
            checkBox3.Visible = false;

            checkBox4.Checked = false;
            checkBox4.Visible = false;

            checkBox5.Checked = false;
            checkBox5.Visible = false;

            checkBox6.Checked = false;
            checkBox6.Visible = false;
            for(int i = 0; i < ResButton.Count; ++i)
            {
                ResButton[i].BackgroundImage = null;
            }


            int count = 0;
            for (int i = 0; i < PhepTinh.Count; ++i)
            {
                if (PhepTinh[i].BackgroundImage!=null)
                {
                    ++count;
                }
                //deleteImageNumber(i);
                //number[i] = null;
            }

            if (count == 6)
            {
                for (int i = 0; i < PhepTinh.Count; ++i)
                {

                    deleteImageNumber(i);
                }
            }
        }
        private void deleteImageNumber(int caseNumber)
        {
            switch (caseNumber)
            {
                case 0:
                    button3.BackgroundImage = null;
                    number[caseNumber] = null;
                    break;
                case 1:
                    button2.BackgroundImage = null;
                    number[caseNumber] = null;
                    break;
                case 2:
                    button16.BackgroundImage = null;
                    number[caseNumber] = null;
                    break;
                case 3:
                    button17.BackgroundImage = null;
                    number[caseNumber] = null;
                    break;
                case 4:
                    button18.BackgroundImage = null;
                    number[caseNumber] = null;
                    break;
                case 5:
                    button19.BackgroundImage = null;
                    number[caseNumber] = null;
                    break;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // so 0
            for(var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["0"]);
                    number[i] = "0";

                    break;
                }
               
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // so 1
            for (var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["1"]);
                    number[i] = "1";
                    break;
                }

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // so 2
            for (var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["2"]);
                    number[i] = "2";
                    break;
                }

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // so 3
            for (var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["3"]);
                    number[i] = "3";
                    break;
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // so 4
            for (var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["4"]);
                    number[i] = "4";
                    break;
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // so 5
            for (var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["5"]);
                    number[i] = "5";
                    break;
                }

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // so 6
            for (var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["6"]);
                    number[i] = "6";
                    break;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // so 7
            for (var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["7"]);
                    number[i] = "7";
                    break;
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // so 8
            for (var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["8"]);
                    number[i] = "8";
                    break;
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // so 9
            for (var i = 0; i < PhepTinh.Count; i++)
            {
                if (PhepTinh[i].BackgroundImage == null)
                {
                    PhepTinh[i].BackgroundImage = Image.FromFile(numberAndImage["9"]);
                    number[i] = "9";
                    break;
                }

            }
        }


        private string[] number = new string[6];
        private List<Button> ResButton= new List<Button>();
        private void button14_Click(object sender, EventArgs e)
        {

            // Equal to
            for(int i = 0; i < number.Length; ++i)
            {
                if (number[i] == null)
                {
                    return;
                }
            }

            string firstNum = number[0] + number[1] + number[2];
            string secondNum = number[3] + number[4] + number[5];
            if (!plus)
            {
                //plus

                //MessageBox.Show((Int32.Parse(firstNum) + Int32.Parse(secondNum)).ToString());
                int temp = Int32.Parse(firstNum) + Int32.Parse(secondNum);
                List<int> res = showRes(temp);
                
                if (res.Count == 3)
                {
                    int index = 1;
                    for (int i = res.Count - 1; i >= 0; --i)
                    {
                        res[i].ToString();
                        ResButton[index].BackgroundImage = Image.FromFile(numberAndImage[res[i].ToString()]);
                        ++index;
                    }
                } 
                else if (res.Count == 4)
                {
                    int index = 0;
                    for (int i = res.Count - 1; i >= 0; --i)
                    {
                        res[i].ToString();
                        ResButton[index].BackgroundImage = Image.FromFile(numberAndImage[res[i].ToString()]);
                        ++index;
                    }
                } 
                else if (res.Count == 2)
                {
                    //
                    int index = 2;
                    for (int i = res.Count - 1; i >= 0; --i)
                    {
                        res[i].ToString();
                        ResButton[index].BackgroundImage = Image.FromFile(numberAndImage[res[i].ToString()]);
                        ++index;
                    }
                }
                else if (res.Count == 1)
                {
                    int index = 3;
                    for (int i = res.Count - 1; i >= 0; --i)
                    {
                        res[i].ToString();
                        ResButton[index].BackgroundImage = Image.FromFile(numberAndImage[res[i].ToString()]);
                        ++index;
                    }
                }

                
            }
            else
            {
                //subtract
                //MessageBox.Show((Int32.Parse(firstNum) - Int32.Parse(secondNum)).ToString());
                int temp = Int32.Parse(firstNum) - Int32.Parse(secondNum);
                if (temp >= 0)
                {
                    List<int> res = showRes(temp);
                    if (res.Count == 3)
                    {
                        int index = 1;
                        for (int i = res.Count - 1; i >= 0; --i)
                        {
                            res[i].ToString();
                            ResButton[index].BackgroundImage = Image.FromFile(numberAndImage[res[i].ToString()]);
                            ++index;
                        }
                    }
                    else if (res.Count == 2)
                    {
                        //
                        int index = 2;
                        for (int i = res.Count - 1; i >= 0; --i)
                        {
                            res[i].ToString();
                            ResButton[index].BackgroundImage = Image.FromFile(numberAndImage[res[i].ToString()]);
                            ++index;
                        }
                    }
                    else if (res.Count == 1)
                    {
                        int index = 3;
                        for (int i = res.Count - 1; i >= 0; --i)
                        {
                            res[i].ToString();
                            ResButton[index].BackgroundImage = Image.FromFile(numberAndImage[res[i].ToString()]);
                            ++index;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Không thể trừ");
                }
            }
        }
        private List<int> showRes(int number)
        {
            // tach tung chu so
            List<int> arr = new List<int>();
            while (true) {
                if (number == 0)
                {
                    //arr.Add(number);
                    break;
                }
                int temp = number % 10;
                arr.Add(temp);
                number /=10; 
            }
            if (arr.Count == 0)
            {
                arr.Add(0);
            }
            return arr;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dangToan = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (dangToan == "Dạng 1")
            {
                NoiDungBT.Clear();
                string[] lines = File.ReadAllLines(@"../../DangToan/Dang1.txt");
                string lineTemp = "";
                for(int i = 0; i < lines.Length; ++i)
                {
                    lineTemp += lines[i];
                }
                NoiDungBT.Text = lineTemp;
                DapAn.Clear();
            } 
            else if (dangToan == "Dạng 2")            
            {
                NoiDungBT.Clear();
                string[] lines = File.ReadAllLines(@"../../DangToan/Dang2.txt");
                string lineTemp = "";
                for (int i = 0; i < lines.Length; ++i)
                {
                    lineTemp += lines[i];
                }
                NoiDungBT.Text = lineTemp;
                DapAn.Clear();
            }
            else if (dangToan == "Dạng 3")
            {
                NoiDungBT.Clear();
                string[] lines = File.ReadAllLines(@"../../DangToan/Dang3.txt");
                string lineTemp = "";
                for (int i = 0; i < lines.Length; ++i)
                {
                    lineTemp += lines[i];
                }
                NoiDungBT.Text = lineTemp;
                DapAn.Clear();
            }
            else if (dangToan == "Dạng 4")
            {
                NoiDungBT.Clear();
                string[] lines = File.ReadAllLines(@"../../DangToan/Dang4.txt");
                string lineTemp = "";
                for (int i = 0; i < lines.Length; ++i)
                {
                    lineTemp += lines[i];
                }
                NoiDungBT.Text = lineTemp;
                DapAn.Clear();
            }
            else if (dangToan == "Dạng 5")
            {
                NoiDungBT.Clear();
                string[] lines = File.ReadAllLines(@"../../DangToan/Dang5.txt");
                string lineTemp = "";
                for (int i = 0; i < lines.Length; ++i)
                {
                    lineTemp += lines[i];
                }
                NoiDungBT.Text = lineTemp;
                DapAn.Clear();
            }


        }
        private void DapAn_Click(object sender, EventArgs e)
        {
            string NoiDung = NoiDungBT.Text;
            if (NoiDung != "")
            {
                var dangToan = comboBox1.GetItemText(comboBox1.SelectedItem);
                if (dangToan == "Dạng 1")
                {
                    string[] lines = File.ReadAllLines(@"../../DangToan/DapAnDang1.txt");
                    string lineTemp = "";
                    for (int i = 0; i < lines.Length; ++i)
                    {
                        lineTemp += "\n" + lines[i];
                    }
                    DapAn.Text = lineTemp;
                }
                else if(dangToan== "Dạng 2")
                {
                    string[] lines = File.ReadAllLines(@"../../DangToan/DapAnDang2.txt");
                    string lineTemp = "";
                    for (int i = 0; i < lines.Length; ++i)
                    {
                        lineTemp += "\n" + lines[i];
                    }
                    DapAn.Text = lineTemp;
                }
                else if (dangToan == "Dạng 3")
                {
                    string[] lines = File.ReadAllLines(@"../../DangToan/DapAnDang3.txt");
                    string lineTemp = "";
                    for (int i = 0; i < lines.Length; ++i)
                    {
                        lineTemp += "\n" + lines[i];
                    }
                    DapAn.Text = lineTemp;
                }
                else if (dangToan == "Dạng 4")
                {
                    string[] lines = File.ReadAllLines(@"../../DangToan/DapAnDang4.txt");
                    string lineTemp = "";
                    for (int i = 0; i < lines.Length; ++i)
                    {
                        lineTemp += "\n" + lines[i];
                    }
                    DapAn.Text = lineTemp;
                }
                else if (dangToan == "Dạng 5")
                {
                    string[] lines = File.ReadAllLines(@"../../DangToan/DapAnDang5.txt");
                    string lineTemp = "";
                    for (int i = 0; i < lines.Length; ++i)
                    {
                        lineTemp += "\n" + lines[i];
                    }
                    DapAn.Text = lineTemp;
                }

            }
            else
            {
                return;
            }

        }

        private string[] getAllFileNames(string link)
        {
            string[] fileNames = Directory.GetFiles(link, "*.jpg");
            return fileNames;
        }
        private int cur = 1;
        private int hinhHienTai = 1;
        private void tiepTheo_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"../../AmThanhGame/next.wav");
            player.Play();
            pictureBox2.Visible = false;
            int count = 0;
            for(int i = 0; i < trueFalseAns.Length; ++i)
            {
                if (trueFalseAns[i] == true)
                {
                    ++count;
                }
            }

            if (count == 4)
            {

                int next = cur + 1;
                if (hinhHienTai < 3)
                {
                    ++hinhHienTai;
                    textBox6.Text = "Hình " + hinhHienTai.ToString();
                }
                if (next <= fileNamesImg.Length)
                {
                    string link = @"../../HinhAnhGame/" + next.ToString() + ".jpg";
                    Bitmap image = new Bitmap(link);
                    pictureBox1.Image = (Image)image;
                    for (int i = 0; i < trueFalseAns.Length; ++i)
                    {
                        trueFalseAns[i] = false;
                    }
                    cur = next;

                    for (int i = 0; i < listTextBox.Count; ++i)
                    {
                        listTextBox[i].Text = null;
                    }
                }

                
            }
        }

        private void choiGame_Click(object sender, EventArgs e)
        {
            //SoundPlayer player = new SoundPlayer(@"../../AmThanhGame/play.wav");
            //player.Play();

            button26.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;

            button25.Enabled = true;
            button27.Enabled = false;
        }
        private List<TextBox> listTextBox = new List<TextBox>();
        private bool[] trueFalseAns = new bool[4];
        private int tongSoDiem = 0;
        private void kiemTra_Click(object sender, EventArgs e)
        {
            if (cur == 1)
            {
                string[] lines = File.ReadAllLines(@"../../HinhAnhGame/1.txt");
                string[] ans = lines[0].Split(' ');

                for(int i = 0; i < ans.Length; ++i)
                {
                    if(listTextBox[i].Text != "" && trueFalseAns[i]==false)
                    {
                        if (ans[i] == listTextBox[i].Text)
                        {
                            listTextBox[i].ForeColor = Color.Blue;
                            listTextBox[i].BackColor = listTextBox[i].BackColor;
                            listTextBox[i].ReadOnly = true;
                            tongSoDiem += 1;
                            trueFalseAns[i] = true;
                        }
                        else
                        {
                            listTextBox[i].ForeColor = Color.Red;
                        }
                    }
                    
                }
                textBox5.Text = tongSoDiem.ToString();

                int count = 0;
                for (int i = 0; i < trueFalseAns.Length; ++i)
                {
                    if (trueFalseAns[i] == true)
                    {
                        ++count;
                    }
                }
                if (count == 4)
                {
                    SoundPlayer player = new SoundPlayer(@"../../AmThanhGame/win.wav");
                    player.Play();
                    //string link = @"../../HinhAnhGame/fireworks.gif";
                    //Bitmap image = new Bitmap(link);
                    //pictureBox2.Image = (Image)image;
                    pictureBox2.Visible = true;
                }
                else
                {
                    SoundPlayer player = new SoundPlayer(@"../../AmThanhGame/lose.wav");
                    player.Play();
                }

            } 
            else if (cur == 2)
            {
                string[] lines = File.ReadAllLines(@"../../HinhAnhGame/2.txt");
                string[] ans = lines[0].Split(' ');

                for (int i = 0; i < ans.Length; ++i)
                {
                    if (listTextBox[i].Text != "" && trueFalseAns[i] == false)
                    {
                        if (ans[i] == listTextBox[i].Text)
                        {
                            listTextBox[i].ForeColor = Color.Blue;
                            listTextBox[i].BackColor = listTextBox[i].BackColor;
                            listTextBox[i].ReadOnly = true;
                            tongSoDiem += 1;
                            trueFalseAns[i] = true;
                        }
                        else
                        {
                            listTextBox[i].ForeColor = Color.Red;
                        }
                    }
                }
                textBox5.Text = tongSoDiem.ToString();

                int count = 0;
                for (int i = 0; i < trueFalseAns.Length; ++i)
                {
                    if (trueFalseAns[i] == true)
                    {
                        ++count;
                    }
                }
                if (count == 4)
                {
                    SoundPlayer player = new SoundPlayer(@"../../AmThanhGame/win.wav");
                    player.Play();
                    pictureBox2.Visible = true;
                }
                else
                {
                    SoundPlayer player = new SoundPlayer(@"../../AmThanhGame/lose.wav");
                    player.Play();
                }
            }
            else if (cur == 3)
            {
                string[] lines = File.ReadAllLines(@"../../HinhAnhGame/3.txt");
                string[] ans = lines[0].Split(' ');

                for (int i = 0; i < ans.Length; ++i)
                {

                    if (listTextBox[i].Text != "" && trueFalseAns[i] == false)
                    {
                        if (ans[i] == listTextBox[i].Text)
                        {
                            listTextBox[i].ForeColor = Color.Blue;
                            listTextBox[i].BackColor = listTextBox[i].BackColor;
                            listTextBox[i].ReadOnly = true;
                            tongSoDiem += 1;
                            trueFalseAns[i] = true;
                        }
                        else
                        {
                            listTextBox[i].ForeColor = Color.Red;
                        }
                    }
                }
                textBox5.Text = tongSoDiem.ToString();

                int count = 0;
                for (int i = 0; i < trueFalseAns.Length; ++i)
                {
                    if (trueFalseAns[i] == true)
                    {
                        ++count;
                    }
                }
                if (count == 4)
                {
                    SoundPlayer player = new SoundPlayer(@"../../AmThanhGame/win.wav");
                    player.Play();
                    pictureBox2.Visible = true;
                }
                else
                {
                    SoundPlayer player = new SoundPlayer(@"../../AmThanhGame/lose.wav");
                    player.Play();
                }
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < listTextBox.Count; ++i)
            {
                listTextBox[i].Text = null;
            }
            button27.Enabled = true;
            tongSoDiem = 0;
            textBox5.Text = "0";
            cur = 1;
            string link = @"../../HinhAnhGame/" + cur.ToString() + ".jpg";
            Bitmap image = new Bitmap(link);
            pictureBox1.Image = (Image)image;
            pictureBox2.Visible = false;
            hinhHienTai=1;
            textBox6.Text = "Hình " + hinhHienTai.ToString();
            for(int i = 0; i < listTextBox.Count; ++i)
            {
                listTextBox[i].ReadOnly = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deOn = comboBox2.GetItemText(comboBox2.SelectedItem);
            textBox7.Enabled = true;
            button29.Enabled = true;
            dataGridView1.Rows.Clear();

            for(int i = 1; i <= 2; ++i)
            {
                if (deOn == "Đề " + i.ToString())
                {
                    NoiDungDeOn.Clear();
                    string[] lines = File.ReadAllLines(@"../../DeOnTap/De" + i.ToString() + ".txt");
                    string lineTemp = "";
                    for (int j = 0; j < lines.Length; ++j)
                    {
                        lineTemp += lines[j] + " " + '\n';
                    }
                    NoiDungDeOn.Text = lineTemp;
                    //DapAn.Clear();
                }
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly == false)
            {
                textBox1.ForeColor = Color.Black;
                trueFalseAns[0] = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.ReadOnly == false)
            {
                textBox2.ForeColor = Color.Black;
                trueFalseAns[1] = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.ReadOnly == false)
            {
                textBox3.ForeColor = Color.Black;
                trueFalseAns[2] = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.ReadOnly == false)
            {
                textBox4.ForeColor = Color.Black;
                trueFalseAns[3] = false;
            }
        }



        private Dictionary<int, string> CauTraLoi = new Dictionary<int, string>();

        private int cauHienTai = 1;
        private void next_Click(object sender, EventArgs e)
        {
            if (cauHienTai <= 5)
            {
                CauTraLoi[cauHienTai] = textBox7.Text; // dua vao dictionary
                cauHienTai += 1;
                if (cauHienTai <= 5)
                {
                    label11.Text = "Câu " + cauHienTai.ToString();
                    textBox7.Clear();
                    if (textBox7.Text == "")
                    {
                        if (cauHienTai <= 5)
                        {
                            textBox7.Text = CauTraLoi[cauHienTai];
                        }

                    }
                }
            }
            if (cauHienTai > 5)
            {
                cauHienTai -= 1;
            }
            
        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (cauHienTai > 1)
            {
                textBox7.Clear();
                cauHienTai -= 1;
                label11.Text = "Câu " + cauHienTai.ToString();
                textBox7.Text = CauTraLoi[cauHienTai];
            }
            
        }

        private void xemDapAn_Click(object sender, EventArgs e)
        {
            int soCauDung = 0;
            var deOn = comboBox2.GetItemText(comboBox2.SelectedItem);
            for(int i = 1; i <= 5; ++i) // so de kiem tra
            {
                if(deOn==("Đề " + i.ToString()))
                {
                    
                    string[] lines = File.ReadAllLines(@"../../DeOnTap/DapAn" + i.ToString() + ".txt");

                    for (int j = 0; j < lines.Length; ++j)
                    {
                        if (CauTraLoi[j + 1].Equals(lines[j]))
                        {
                            dataGridView1.Rows.Add(CauTraLoi[j + 1], lines[j], "1");
                            ++soCauDung;
                        }
                        else
                        {
                            dataGridView1.Rows.Add(CauTraLoi[j + 1], lines[j], "0");
                        }

                    }

                }
            }
            label12.Text = "Số câu đúng " + soCauDung.ToString()+"/5";
            label13.Text = "Tổng điểm: " + soCauDung.ToString();
            button29.Enabled = false;
        }

        private void lamLai_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < CauTraLoi.Count; ++i)
            {
                CauTraLoi[i + 1] = "";
            }
            textBox7.Text = null;
            dataGridView1.Rows.Clear();
            cauHienTai = 1;
            label11.Text = "Câu " + cauHienTai.ToString();
            label12.Text = "Số câu đúng:";
            label12.Text = "Tổng điểm:";
            button29.Enabled = true;

        }
    }

}
