using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework_BingoBingo_
{
    public partial class Form1 : Form
    {
        int[] ConNum = new int[20];
        int[] PlayNum = Enumerable.Repeat(0, 10).ToArray();
        List<int>玩家數字儲存 = new List<int>();
        int time倒數;
        int[] randomArray = new int[20];
        public List<Button> 選號碼 = new List<Button>();
        //List<int> myNum = new List<int>();
        bool 數目;
        List<Label> 顯示輸入號碼 = new List<Label>();
        bool 是包牌 = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //UI
            倒數計時();
            按鈕產生(10, 8);
            亂數產生();
            //PlayNumberInput();

            顯示輸入號碼.Add(lblPlay1);
            顯示輸入號碼.Add(lblPlay2);
            顯示輸入號碼.Add(lblPlay3);
            顯示輸入號碼.Add(lblPlay4);
            顯示輸入號碼.Add(lblPlay5);
            顯示輸入號碼.Add(lblPlay6);
            顯示輸入號碼.Add(lblPlay7);
            顯示輸入號碼.Add(lblPlay8);
            顯示輸入號碼.Add(lblPlay9);
            顯示輸入號碼.Add(lblPlay10);

            //預設
            radio不玩.Checked = true;
            combo基本星數.SelectedIndex = 0;
            chk超級獎號.Checked = false;
            combo幾星電腦選碼.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            txt包牌次數.Text = "1";
            radio猜大小不玩.Checked = true;
            textMoney.Text = "10000";

        }

        #region 產生按鈕
        //產生按鈕
        public void 按鈕產生(int intColumn, int intRow)
        {
            //Row水平
            //Column垂直
            int 編號 = 0;
            for (int i = 0; i < intRow; i++)
            {
                for (int j = 0; j < intColumn; j++)
                {
                    編號++;
                    Button dButton = new Button();
                    dButton.BackColor = Color.Pink;
                    dButton.ForeColor = Color.Blue;
                    dButton.Font = new Font("微軟正黑體", 12);
                    dButton.Text = 編號.ToString();
                    dButton.Location = new Point(31 + 40 * j, (390 + 30 * i));
                    dButton.Size = new Size(40, 27);

                    dButton.Click += new EventHandler(dButton_Click);

                    Controls.Add(dButton);
                    選號碼.Add(dButton);
                }
            }
        }
        #endregion

        #region 電腦快選號碼
        // 電腦快選號碼
        private void btn電腦選碼_Click(object sender, EventArgs e)
        {
            int 幾碼 = combo幾星電腦選碼.SelectedIndex;
            int 幾碼數字 = (幾碼 + 1 - 玩家數字儲存.Count);
            string 號碼 = "";
            if (玩家數字儲存.Count < (幾碼 + 1))
            {
                    //PlayNumberInput();
                    清除按鈕號碼();
                    List<int> 電腦 = new List<int>();
                    Random myNumRnd = new Random();
                    for (int i = 0; i < 幾碼數字; i++)
                    {
                        int 亂數 = myNumRnd.Next(1, 81);
                        電腦.Add(亂數);
                        //玩家數字儲存.Add(myNumRnd.Next(1, 81));
                        //for (int j = 0; j < 玩家數字儲存.Count; j++)
                        //{
                        //    while (玩家數字儲存[j] == 電腦[i])
                        //    {
                        //        j = 0;
                        //        電腦.Add(myNumRnd.Next(1, 81));
                        //    }
                        //}
                        if (玩家數字儲存.Contains(亂數))
                        {
                            電腦.Remove(亂數);
                            i--;
                        }

                    }
                    for (int m = 0; m < 電腦.Count; m++) { 玩家數字儲存.Add(電腦[m]); }
                    玩家數字儲存.Sort();
                    for (int k = 0; k < 玩家數字儲存.Count; k++)
                    {
                        號碼 += 玩家數字儲存[k] + ", ";
                        選號碼[玩家數字儲存[k] - 1].BackColor = Color.Red;
                        顯示輸入號碼[k].Text = Convert.ToString(玩家數字儲存[k]);
                    }
                    listBoxInformation.Items.Add("電腦代選:" + 號碼);
            }
            else if (玩家數字儲存.Count == (幾碼 + 1))
            {
                    DialogResult R = MessageBox.Show("你有沒有要對獎?(按是重新選碼)", "兌獎確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (R == DialogResult.Yes)
                    {
                        清除按鈕號碼();
                        顯示Label清除();
                        玩家數字儲存.Clear();
                        listBoxInformation.Items.Remove("電腦代選:" + 號碼);
                        return;
                    }
                    else
                    {
                        //cancel
                        //e.Cancel = true;
                    }
            }
        }
        #endregion

        #region 清除button號碼
        //清除button號碼
        public void 清除按鈕號碼()
        {
            for (int i = 0; i < 選號碼.Count; i++)
            {
                選號碼[i].BackColor = Color.Pink;

            }
        }
        #endregion

        #region 清除Label號碼
        //清除Label號碼
        internal void 顯示Label清除()
        {
            for (int i = 0; i < 10; i++)
            {
                顯示輸入號碼[i].Text = "";
            }
        }
        #endregion

        #region 按鈕號碼選擇
        //號碼選擇
        static int 按鈕號碼 = 0;
        internal void dButton_Click(object sender, EventArgs e)
        {
            Button mybtn = (Button)sender;
            int Num = Convert.ToInt32(mybtn.Text);

            if (mybtn.BackColor == Color.Red)
            {
                mybtn.BackColor = Color.Pink;
                按鈕號碼--;
                玩家數字儲存.Remove(Num);
                顯示Label清除();
                for (int k = 0; k < 玩家數字儲存.Count; k++)
                {
                    顯示輸入號碼[k].Text = Convert.ToString(玩家數字儲存[k]);
                }
            }
            else
            {
                mybtn.BackColor = Color.Red;
                玩家數字儲存.Add(Num);
                按鈕號碼++;
                if (按鈕號碼 > 10)
                {
                    MessageBox.Show("已超過可選最大數量");
                    玩家數字儲存.Remove(Num);
                    mybtn.BackColor = Color.Pink;
                    按鈕號碼--;
                }
                else
                {
                    顯示Label清除();
                    for (int k = 0; k < 玩家數字儲存.Count; k++)
                    {
                        顯示輸入號碼[k].Text = Convert.ToString(玩家數字儲存[k]);
                    }
                }
            }

        }
        #endregion

        #region 電腦對獎號碼
        //電腦選碼
        public void 亂數產生()
        {
            Random myRandom = new Random();

            for (int i = 0; i < 20; i++)
            {
                randomArray[i] = myRandom.Next(1, 81);   //亂數產生(正整數>0)，亂數產生的範圍是1~80

                for (int j = 0; j < i; j++)
                {
                    while (randomArray[j] == randomArray[i])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                    {
                        j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                        randomArray[i] = myRandom.Next(1, 81);   //重新產生，存回陣列，亂數產生的範圍是1~80
                    }
                }
            }
            Array.Copy(randomArray, ConNum, randomArray.Length);
            Array.Sort(randomArray);
            lblNum1.Text = randomArray[0].ToString();
            lblNum2.Text = randomArray[1].ToString();
            lblNum3.Text = randomArray[2].ToString();
            lblNum4.Text = randomArray[3].ToString();
            lblNum5.Text = randomArray[4].ToString();
            lblNum6.Text = randomArray[5].ToString();
            lblNum7.Text = randomArray[6].ToString();
            lblNum8.Text = randomArray[7].ToString();
            lblNum9.Text = randomArray[8].ToString();
            lblNum10.Text = randomArray[9].ToString();
            lblNum11.Text = randomArray[10].ToString();
            lblNum12.Text = randomArray[11].ToString();
            lblNum13.Text = randomArray[12].ToString();
            lblNum14.Text = randomArray[13].ToString();
            lblNum15.Text = randomArray[14].ToString();
            lblNum16.Text = randomArray[15].ToString();
            lblNum17.Text = randomArray[16].ToString();
            lblNum18.Text = randomArray[17].ToString();
            lblNum19.Text = randomArray[18].ToString();
            lblNum20.Text = randomArray[19].ToString();
        }
        #endregion

        #region 時間倒數事件
        //時間到
        void 倒數計時()
        {
            time電腦選號.Enabled = true;
            time倒數 = 30;
            time電腦選號.Interval = 1000;

        }
        //時間倒數發生事件
        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            if (time倒數 > 0)
            {
                lbl倒數.Text = time倒數.ToString();
                time倒數--;
            }
            else if (time倒數 == 0)
            {
 
                time倒數 = 30;
                lbl倒數.Text = "30";
                亂數產生();
                //btn基本下注.Enabled = true;
                btn兌獎.Enabled = true;
                btnMore.Enabled = true;
            }
        }
        #endregion

        #region 輸入數字(已失效
        //輸入數字
        //public void PlayNumberInput()
        //{
        //    int values = 0;
        //    string[] myPlayNum = new string[] { txtNum1.Text, txtNum2.Text, txtNum3.Text, txtNum4.Text, txtNum5.Text, txtNum6.Text, txtNum7.Text, txtNum8.Text, txtNum9.Text, txtNum10.Text };
        //    for (int i = 0; i < myPlayNum.Length; i++)
        //    {
        //        if (myPlayNum[i] == "")
        //        {
        //            myPlayNum[i] = "999";
        //            PlayNum[i] = Convert.ToInt32(myPlayNum[i]);
        //        }
        //        else
        //        {
        //            if (int.TryParse(myPlayNum[i], out values) == true)
        //            {
        //                if (values > 80)
        //                {
        //                    MessageBox.Show("超過了，請重新輸入");
        //                }
        //                else if (values <= 0)
        //                {
        //                    MessageBox.Show("太小了，請重新輸入");
        //                }
        //                PlayNum[i] = values;
        //                玩家數字儲存.Add(values);
        //                選號碼[values-1].BackColor = Color.Red;

        //            }
        //            else
        //            {
        //                MessageBox.Show("請輸入正確數字");
        //                break;
        //            }
        //        }

        //    }
        //}

        //bool 確認數值;
        ////當沒有輸入值時
        #endregion
        #region 輸入號碼空值確認(已失效
        //public void PlayNumberEmpty()
        //{
        //    if ((PlayNum[0] == 999) && (PlayNum[1] == 999) && (PlayNum[2] == 999) && (PlayNum[3] == 999) && (PlayNum[4] == 999) && (PlayNum[5] == 999) && (PlayNum[6] == 999) && (PlayNum[7] == 999) && (PlayNum[8] == 999) && (PlayNum[9] == 999))
        //    {
        //        確認數值 = false;
        //        MessageBox.Show("你並未輸入任何值", "提醒");
        //    }
        //    else
        //    {
        //        確認數值 = true;
        //    }
        //}
        #endregion

        #region 兌獎數目
        //獎項
        public int Award(int winTimes)
        {
            if (是包牌 == false)
            {
                if (winTimes == 1)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中1獎");
                    Globar.winTimes = 1;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 2)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中2獎");
                    Globar.winTimes = 2;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 3)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中3獎");
                    Globar.winTimes = 3;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 4)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中4獎");
                    Globar.winTimes = 4;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 5)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中5獎");
                    Globar.winTimes = 5;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 6)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中6獎");
                    Globar.winTimes = 6;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 7)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中7獎");
                    Globar.winTimes = 7;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 8)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中8獎");
                    Globar.winTimes = 8;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 9)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中9獎");
                    Globar.winTimes = 9;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 10)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星中10獎");
                    Globar.winTimes = 10;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 0)
                {
                    listBoxInformation.Items.Add($"玩基本{Globar.星數}星沒中獎");
                    Globar.winTimes = 0;
                    兌獎.幾星以及數目();
                }
            }
            else
            {
                if (winTimes == 1)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中1獎");
                    Globar.winTimes = 1;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 2)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中2獎");
                    Globar.winTimes = 2;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 3)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中3獎");
                    Globar.winTimes = 3;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 4)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中4獎");
                    Globar.winTimes = 4;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 5)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中5獎");
                    Globar.winTimes = 5;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 6)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中6獎");
                    Globar.winTimes = 6;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 7)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中7獎");
                    Globar.winTimes = 7;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 8)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中8獎");
                    Globar.winTimes = 8;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 9)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中9獎");
                    Globar.winTimes = 9;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 10)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星中10獎");
                    Globar.winTimes = 10;
                    兌獎.幾星以及數目();
                }
                else if (winTimes == 0)
                {
                    listBoxInformation.Items.Add($"玩包牌{Globar.包牌星數}星沒中獎");
                    Globar.winTimes = 0;
                    兌獎.幾星以及數目();
                }
            }
            return winTimes;
        }
        #endregion

        #region 關掉程式
        //關掉
        public void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 玩家輸入號碼取出
        //玩家號碼顯示
        public void 玩家號碼顯示()
        {
            string 號碼 = "";
            for (int i = 0; i < 玩家數字儲存.Count; i++)
            {
                號碼 += 玩家數字儲存[i] + ", ";
            }
            listBoxInformation.Items.Add($"你的號碼為: {號碼}");
        }
        #endregion

        #region 按鈕電腦對獎號碼
        //電腦選碼
        public void btnPrice_Click(object sender, EventArgs e)
        {
            亂數產生();
            btn兌獎.Enabled = true;
            btnMore.Enabled = true;
        }
        #endregion

        #region 電腦包牌function
        //選號(電腦幫忙選號or包牌
        List<List<int>> 電腦 = new List<List<int>>();
        List<int> 電腦2 = new List<int>();
        public int RandomComChoose(int 次數, int ChooseStar)
        {
            int Num = Globar.包牌星數-玩家數字儲存.Count;           
            Random myRandom = new Random();
            //int 包牌總數 = 次數 * Num;
            //List<List<int>> 電腦 = new List<List<int>>();
            //List<int> 電腦2 = new List<int>();
            //int[,] randomArray = new int[次數, Num];
            //玩家數字儲存.Contains(亂數)

            for (int i = 0; i < 次數; i++)
            {
                //List<int> 電腦2 = new List<int>();
                for (int j = 0; j < Num; j++)
                {
                    int 亂數 = myRandom.Next(1, 81);
                    電腦2.Add(亂數);
                    while (玩家數字儲存.Contains(亂數))
                    {
                        j--;
                        電腦2.Remove(亂數);
                        亂數 = myRandom.Next(1, 81);
                        電腦2.Add(亂數);
                    }
                    //電腦2[j] = myRandom.Next(1, 81);
                    //for (int k = 0; k < 電腦2.Count; k++)
                    //{
                    //    if (電腦2[k] == 電腦2[j])
                    //    {
                    //        k = 0;
                    //        電腦2[k] = myRandom.Next(1, 81);
                    //    }
                    //    foreach (int 數字 in 電腦2)
                    //    {
                    //        if (玩家數字儲存.Contains(數字))
                    //        {
                    //            電腦2.Remove(數字);
                    //        }
                    //    }
                    //}
                }
                電腦2.AddRange(玩家數字儲存);
                電腦2.Sort();
                string 號碼 = "";
                for (int n = 0; n < 電腦2.Count; n++)
                {
                    號碼 += 電腦2[n] + ", ";
                }
                listBoxInformation.Items.Add($"你的號碼為:{號碼}");
                if (chk超級包牌獎號.Checked == true)
                {
                    Globar.超級獎項 = true;
                    listBoxInformation.Items.Add($"兌獎時間: {DateTime.Now.ToString()}");
                    星數玩法2(Globar.包牌星數);
                    猜單雙();
                    猜大小比對();
                    錢包金額();
                    btnMore.Enabled = false;
                    btn兌獎.Enabled = false;
                }
                else
                {
                    Globar.超級獎項 = false;
                    listBoxInformation.Items.Add($"兌獎時間: {DateTime.Now.ToString()}");
                    星數玩法2(Globar.包牌星數);
                    猜單雙();
                    猜大小比對();
                    錢包金額();
                    btn兌獎.Enabled = false;
                    btnMore.Enabled = false;
                }
               
                //String Number2 = "";
                //for (int l = 0; l < 電腦2.Count; l++)
                //{
                //    Number2 += 電腦2[l].ToString() + ", ";
                //}
                //listBoxInformation.Items.Add(Number2);
                電腦.Add(電腦2);
                電腦2.Clear();
            }
            String Number = "";
            int[][] arrays = 電腦.Select(a => a.ToArray()).ToArray();

            // 打印二維數組
            foreach (var array in arrays)
            {
                Console.WriteLine(String.Join(", ", array));
                Number = String.Join(", ", array);
            }
            //listBoxInformation.Items.Add(Number);
            //arrays.Contains(ConNum);
            電腦.Clear();
            //for (int i = 0; i < 包牌總數; i++)
            //{
            //    randomArray[i] = myRandom.Next(1, 81);   //亂數產生(正整數>0)，亂數產生的範圍是1~80

            //    for (int j = 0; j < i; j++)
            //    {
            //        while (randomArray[j] == randomArray[i])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
            //        {
            //            j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
            //            randomArray[i] = myRandom.Next(1, 81);   //重新產生，存回陣列，亂數產生的範圍是1~80
            //        }
            //    }
            //}
            //Array.Sort(randomArray);
            //String Number = "";
            //for (int l = 0; l < randomArray.Length; l++)
            //{
            //    Number += randomArray[l].ToString() + ", ";
            //}
            //listBoxInformation.Items.Add(Number);
            return ChooseStar;
        }
        #endregion

        #region 電腦對獎號碼顯示(listbox
        //顯示
        public void 顯示()
        {
            string 號碼 = "";

            for (int k = 0; k < randomArray.Length; k++)
            {
                號碼 += randomArray[k] + ", ";
            }
            listBoxInformation.Items.Add(號碼);

        }
        #endregion

        #region 按鈕包牌
        //包牌
        public void btnMore_Click(object sender, EventArgs e)
        {
            //int result = comboBox1.SelectedIndex;
            int 次數;
            是包牌 = true;
            Globar.金額 = Convert.ToInt32(textMoney.Text);
            Globar.包牌星數 = comboBox1.SelectedIndex + 1;
            if (int.TryParse(txt包牌次數.Text, out 次數) == true)
            {
                //int 次數 = Convert.ToInt32(txt包牌次數.Text);
                RandomComChoose(次數, Globar.包牌星數);
                //listBoxInformation.Items.Add(result);             
            }
            else
            {
                MessageBox.Show("請輸入正確次數", "提醒");
            }
        }
        #endregion

        #region 列表清空
        //列表清空
        private void btnClear_Click(object sender, EventArgs e)
        {
            listBoxInformation.Items.Clear();
            清除按鈕號碼();
            顯示Label清除();
            玩家數字儲存.Clear();
            按鈕號碼 = 0;
        }
        #endregion

        #region 猜大小function
        //猜大小比對
        public void 猜大小比對()
        {
            int 大 = 0;
            int 小 = 0;
            foreach (int i in randomArray)
            {
                if (i == 0)
                {
                    break;
                }
                else if (i > 41)
                {
                    大++;
                }
                else if (i <= 40)
                {
                    小++;
                }
            }
            if (radio猜大.Checked == true)
            {
                if (大 >= 13)
                {
                    listBoxInformation.Items.Add($"恭喜你猜大中獎");
                    Globar.猜大 = true;
                }
                else
                {
                    listBoxInformation.Items.Add($"猜大再接再厲,數字大{大}個以及數字小{小}個");
                }
            }
            else if (radio猜小.Checked == true)
            {
                
                if (小 >= 13)
                {
                    listBoxInformation.Items.Add($"恭喜你猜小中獎");
                    Globar.猜小 = true;
                }
                else
                {
                    listBoxInformation.Items.Add($"猜小再接再厲");
                }
            }
        }
        #endregion

        #region 按鈕兌獎
        private void btn兌獎_Click(object sender, EventArgs e)
        {
            Globar.金額 = Convert.ToInt32(textMoney.Text);
            Globar.星數 = combo基本星數.SelectedIndex + 1;
            Globar.包牌星數 = comboBox1.SelectedIndex + 1;
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                是包牌 = true;
            }
            else{ 是包牌 = false; }
            if (是包牌 == false)
            {
                玩家數字(Globar.星數);
                if (數目 == true)
                {
                    if (chk超級獎號.Checked == true)
                    {
                        Globar.超級獎項 = true;
                        顯示();
                        玩家號碼顯示();
                        星數玩法(Globar.星數);
                        猜單雙();
                        猜大小比對();
                        錢包金額();
                        listBoxInformation.Items.Add($"兌獎時間: {DateTime.Now.ToString()}");
                        btn兌獎.Enabled = false;
                    }
                    else
                    {
                        Globar.超級獎項 = false;
                        顯示();
                        玩家號碼顯示();
                        星數玩法(Globar.星數);
                        猜單雙();
                        猜大小比對();
                        錢包金額();
                        listBoxInformation.Items.Add($"兌獎時間: {DateTime.Now.ToString()}");
                        btn兌獎.Enabled = false;
                    }
                    顯示Label清除();
                    清除按鈕號碼();
                    玩家數字儲存.Clear();
                }
            }
            else
            {
                int result = comboBox1.SelectedIndex;
                int 次數;
                是包牌 = true;
                Globar.金額 = Convert.ToInt32(textMoney.Text);
                Globar.包牌星數 = comboBox1.SelectedIndex + 1;
                if (int.TryParse(txt包牌次數.Text, out 次數) == true)
                {
                    //int 次數 = Convert.ToInt32(txt包牌次數.Text);
                    switch (result)
                    {
                        case 0:
                            RandomComChoose(次數, 0);
                            //listBoxInformation.Items.Add(result);
                            break;
                        case 1:
                            RandomComChoose(次數, 1);
                            //listBoxInformation.Items.Add(result);
                            break;
                        case 2:
                            RandomComChoose(次數, 2);
                            break;
                        case 3:
                            RandomComChoose(次數, 3);
                            break;
                        case 4:
                            RandomComChoose(次數, 4);
                            break;
                        case 5:
                            RandomComChoose(次數, 5);
                            break;
                        case 6:
                            RandomComChoose(次數, 6);
                            break;
                        case 7:
                            RandomComChoose(次數, 7);
                            break;
                        case 8:
                            RandomComChoose(次數, 8);
                            break;
                        case 9:
                            RandomComChoose(次數, 9);
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("請輸入正確次數", "提醒");
                }
            }
            //int 星數 = combo基本星數.SelectedIndex + 1;
            ////PlayNumberInput();
            ////PlayNumberEmpty();
            //玩家數字(星數);
            //if (數目 == true)
            //{
            //    星數玩法(星數);
            //    玩家數字儲存.Clear();
            //}
        }
        #endregion

        #region 按鈕顯示儲存號碼(未打
        private void btn玩家號碼顯示_Click(object sender, EventArgs e)
        {
        }
        #endregion
        #region 列印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string str檔案路徑 = @"C:\Users\iSpan\Desktop";
            Random myRnd = new Random();
            int rndNum = myRnd.Next(1000, 10000);
            string str檔名 = DateTime.Now.ToString("yyMMddHHmmss") + rndNum + "彩卷.txt";
            string str完整檔案路徑 = str檔案路徑 + @"\" + str檔名;

            //輸出
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = str檔案路徑;
            sfd.FileName = str檔名;

            //以|隔開,右邊為任意名稱(*.),左邊為描述
            sfd.Filter = "Text File|*.txt";   //檔名確認

            DialogResult R = sfd.ShowDialog();

            if (R == DialogResult.OK)
            {
                str完整檔案路徑 = sfd.FileName;
            }
            else
            {
                return;
            }

            /////訂單內容存檔
            List<string> list台灣彩卷資訊 = new List<string>();
            list台灣彩卷資訊.Add("*****************台灣彩卷資訊*****************");
            list台灣彩卷資訊.Add("---------------------------------------------");
            list台灣彩卷資訊.Add($"列印時間: {DateTime.Now.ToString()}");
            list台灣彩卷資訊.Add("---------------------------------------------");
            list台灣彩卷資訊.Add("    <<<<<號碼>>>>>    ");
            foreach (string 品項 in listBoxInformation.Items)
            {
                list台灣彩卷資訊.Add(品項);
            }
            list台灣彩卷資訊.Add("=============================================");
            list台灣彩卷資訊.Add($"你投注金額差值: {Globar.全部總金額}");
            list台灣彩卷資訊.Add("*****************謝謝光臨*****************");
            System.IO.File.WriteAllLines(str完整檔案路徑, list台灣彩卷資訊, Encoding.UTF8);
            MessageBox.Show("存檔成功");
        }
        #endregion

        #region 猜單雙function
        //猜單雙
        internal void 猜單雙()
        {
            int 基數 = 0;
            int 偶數 = 0;
            for (int i = 0; i < randomArray.Length; i++)
            {
                if ((randomArray[i]) % 2 == 0)
                {偶數++;}
                else
                {基數++;}
            }

            if (radio猜和.Checked == true)
            {
                if (基數 == 偶數)
                {
                    listBoxInformation.Items.Add($"猜和中獎");
                    Globar.猜和 = true;
                }
                else
                { listBoxInformation.Items.Add($"猜和再接再厲, 基數{基數}個偶數{偶數}個"); }
            }
            else if (radio猜小單.Checked == true)
            {
                if ((基數 == 11) || (基數 == 12))
                {
                    listBoxInformation.Items.Add($"猜小單中獎");
                    Globar.猜小單 = true;
                }
                else
                { listBoxInformation.Items.Add($"猜小單再接再厲, 基數{基數}個偶數{偶數}個"); }
            }
            else if (radio猜單數.Checked == true)
            {
                if (基數 >= 13)
                {
                    listBoxInformation.Items.Add($"猜單數中獎");
                    Globar.猜單 = true;
                }
                else
                { listBoxInformation.Items.Add($"猜單數再接再厲, 基數{基數}個偶數{偶數}個"); }
            }
            else if (radio猜雙數.Checked == true)
            {
                if (偶數 >= 13)
                {
                    listBoxInformation.Items.Add($"猜雙數中獎");
                    Globar.猜雙 = true;
                }
                else
                { listBoxInformation.Items.Add($"猜雙數再接再厲, 基數{基數}個偶數{偶數}個"); }
            }
            else if (radio猜小雙.Checked == true)
            {
                if ((偶數 == 11) || (偶數 == 12))
                {
                    listBoxInformation.Items.Add($"猜小雙中獎");
                    Globar.猜小雙 = true;
                }
                else
                { listBoxInformation.Items.Add($"猜小雙再接再厲, 基數{基數}個偶數{偶數}個"); }
            }
        }

        #endregion

        #region 按鈕基本下注(已失效
        //private void btn基本下注_Click(object sender, EventArgs e)
        //{
        //    //int 星數 = combo基本星數.SelectedIndex + 1;
        //    ////PlayNumberInput();
        //    ////PlayNumberEmpty();
        //    //玩家數字(星數);
        //    //if (數目 == true)
        //    //{
        //    //    星數玩法(星數);
        //    //    玩家數字儲存.Clear();
        //    //}
        //    Globar.星數 = combo基本星數.SelectedIndex + 1;
        //    //PlayNumberInput();
        //    //PlayNumberEmpty();
        //    玩家數字(Globar.星數);
        //    if (數目 == true)
        //    {
        //        星數玩法(Globar.星數);
        //        錢包金額();
        //        顯示Label清除();
        //        btn基本下注.Enabled = false;
        //        清除號碼();
        //        玩家數字儲存.Clear();
        //    }

        //}
        #endregion

        #region 玩家數字function
        //號碼數目比對
        public bool 玩家數字(int 星數)
        {
                if (星數 == 1)
                {
                    if (玩家數字儲存.Count == 0)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if(玩家數字儲存.Count>10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }
                else if (星數 == 2)
                {
                    if (玩家數字儲存.Count < 2)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if (玩家數字儲存.Count > 10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }
                else if (星數 == 3)
                {
                    if (玩家數字儲存.Count < 3)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if (玩家數字儲存.Count > 10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }
                else if (星數 == 4)
                {
                    if (玩家數字儲存.Count < 4)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if (玩家數字儲存.Count > 10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }
                else if (星數 == 5)
                {
                    if (玩家數字儲存.Count < 5)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if (玩家數字儲存.Count > 10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }
                else if (星數 == 6)
                {
                    if (玩家數字儲存.Count < 6)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if (玩家數字儲存.Count > 10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }
                else if (星數 == 7)
                {
                    if (玩家數字儲存.Count < 7)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if (玩家數字儲存.Count > 10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }
                else if (星數 == 8)
                {
                    if (玩家數字儲存.Count < 8)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if (玩家數字儲存.Count > 10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }
                else if (星數 == 9)
                {
                    if (玩家數字儲存.Count < 9)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if (玩家數字儲存.Count > 10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }
                else if (星數 == 10)
                {
                    if (玩家數字儲存.Count < 10)
                    {
                        MessageBox.Show($"數字不夠只有{玩家數字儲存.Count}個");
                    }
                    else if (玩家數字儲存.Count > 10)
                    {
                        MessageBox.Show("數目怪怪的");
                    }
                    else
                    {
                        數目 = true;
                    }
                }

            return 數目;
        }
        #endregion

        #region 星數玩法function
        //玩法
        public int 星數玩法(int 星數)
        {
            int winTimes = 0;
            //PlayNumberInput();
                if (星數 == 1)
                {
                    //Globar.星數 = 1;
                    foreach (int OneStar in ConNum) //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(OneStar))
                        {
                            winTimes++;
                        }

                    }
                    if (winTimes > 1)
                    {
                        Award(1);
                    
                    }
                    else
                    {
                        Award(winTimes);
                    }
                }
                else if (星數 == 2)
                {
                    //Globar.星數 = 2;
                    foreach (int TwoStar in ConNum) //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(TwoStar))
                        {
                            winTimes++;
                        }

                    }
                    if (winTimes > 2)
                    {
                        Award(2);
                    }
                    else
                    {
                        Award(winTimes);
                    }
                }
                else if (星數 == 3)
                {
                    foreach (int ThreeStar in ConNum)    //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(ThreeStar))
                        {
                            winTimes++;
                        }

                    }
                    if (winTimes > 3)
                    {
                        Award(3);
                    }
                    else
                    {
                        Award(winTimes);
                    }
                }
                else if (星數 == 4)
                {
                    foreach (int FourStar in ConNum)    //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(FourStar))
                        {
                            winTimes++;
                        }

                    }
                    if (winTimes > 4)
                    {
                        Award(4);
                    }
                    else
                    {
                        Award(winTimes);
                    }
                }
                else if (星數 == 5)
                {
                    foreach (int FiveStar in ConNum)    //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(FiveStar))
                        {
                            winTimes++;
                        }

                    }
                    if (winTimes > 5)
                    {
                        Award(5);
                    }
                    else
                    {
                        Award(winTimes);
                    }
                }
                else if (星數 == 6)
                {
                    foreach (int SixStar in ConNum)    //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(SixStar))
                        {
                            winTimes++;
                        }

                    }
                    if (winTimes > 6)
                    {
                        Award(6);
                    }
                    else
                    {
                        Award(winTimes);
                    }
                }
                else if (星數 == 7)
                {
                    foreach (int SevenStar in ConNum)    //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(SevenStar))
                        {
                            winTimes++;
                        }

                    }
                    if (winTimes > 7)
                    {
                        Award(7);
                    }
                    else
                    {
                        Award(winTimes);
                    }
                }
                else if (星數 == 8)
                {
                    foreach (int EightStar in ConNum)    //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(EightStar))
                        {
                            winTimes++;
                        }

                    }
                    if (winTimes > 8)
                    {
                        Award(8);
                    }
                    else
                    {
                        Award(winTimes);
                    }
                }
                else if (星數 == 9)
                {
                    foreach (int NineStar in ConNum)    //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(NineStar))
                        {
                            winTimes++;
                        }

                    }
                    if (winTimes > 9)
                    {
                        Award(9);
                    }
                    else
                    {
                        Award(winTimes);
                    }
                }
                else if (星數 == 10)
                {
                    foreach (int TenStar in ConNum)    //以自己數字為主找出中獎數字
                    {
                        if (玩家數字儲存.Contains(TenStar))
                        {
                            winTimes++;
                        }

                    }
                    Award(winTimes);
            }

            return winTimes;
        }
        public int 星數玩法2(int 星數)
        {
            int winTimes = 0;
            //PlayNumberInput();
            if (星數 == 1)
            {
                //Globar.星數 = 1;
                foreach (int OneStar in ConNum) //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(OneStar))
                    {
                        winTimes++;
                    }

                }
                if (winTimes > 1)
                {
                    Award(1);

                }
                else
                {
                    Award(winTimes);
                }
            }
            else if (星數 == 2)
            {
                //Globar.星數 = 2;
                foreach (int TwoStar in ConNum) //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(TwoStar))
                    {
                        winTimes++;
                    }

                }
                if (winTimes > 2)
                {
                    Award(2);
                }
                else
                {
                    Award(winTimes);
                }
            }
            else if (星數 == 3)
            {
                foreach (int ThreeStar in ConNum)    //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(ThreeStar))
                    {
                        winTimes++;
                    }

                }
                if (winTimes > 3)
                {
                    Award(3);
                }
                else
                {
                    Award(winTimes);
                }
            }
            else if (星數 == 4)
            {
                foreach (int FourStar in ConNum)    //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(FourStar))
                    {
                        winTimes++;
                    }

                }
                if (winTimes > 4)
                {
                    Award(4);
                }
                else
                {
                    Award(winTimes);
                }
            }
            else if (星數 == 5)
            {
                foreach (int FiveStar in ConNum)    //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(FiveStar))
                    {
                        winTimes++;
                    }

                }
                if (winTimes > 5)
                {
                    Award(5);
                }
                else
                {
                    Award(winTimes);
                }
            }
            else if (星數 == 6)
            {
                foreach (int SixStar in ConNum)    //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(SixStar))
                    {
                        winTimes++;
                    }

                }
                if (winTimes > 6)
                {
                    Award(6);
                }
                else
                {
                    Award(winTimes);
                }
            }
            else if (星數 == 7)
            {
                foreach (int SevenStar in ConNum)    //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(SevenStar))
                    {
                        winTimes++;
                    }

                }
                if (winTimes > 7)
                {
                    Award(7);
                }
                else
                {
                    Award(winTimes);
                }
            }
            else if (星數 == 8)
            {
                foreach (int EightStar in ConNum)    //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(EightStar))
                    {
                        winTimes++;
                    }

                }
                if (winTimes > 8)
                {
                    Award(8);
                }
                else
                {
                    Award(winTimes);
                }
            }
            else if (星數 == 9)
            {
                foreach (int NineStar in ConNum)    //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(NineStar))
                    {
                        winTimes++;
                    }

                }
                if (winTimes > 9)
                {
                    Award(9);
                }
                else
                {
                    Award(winTimes);
                }
            }
            else if (星數 == 10)
            {
                foreach (int TenStar in ConNum)    //以自己數字為主找出中獎數字
                {
                    if (電腦2.Contains(TenStar))
                    {
                        winTimes++;
                    }

                }
                Award(winTimes);
            }
            return (winTimes);
        }
        #endregion

        #region 說明
        private void 基本玩法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 說明 = new Form2();
            說明.tab顯示玩法.SelectedTab = 說明.tab顯示玩法.TabPages[0];
            說明.ShowDialog();
        }

        private void 超級獎號ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 說明 = new Form2();
            說明.tab顯示玩法.SelectedTab = 說明.tab顯示玩法.TabPages[1];
            說明.ShowDialog();
        }

        private void 猜大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 說明 = new Form2();
            說明.tab顯示玩法.SelectedTab = 說明.tab顯示玩法.TabPages[2];
            說明.ShowDialog();
        }

        private void 猜單雙ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 說明 = new Form2();
            說明.tab顯示玩法.SelectedTab = 說明.tab顯示玩法.TabPages[3];
            說明.ShowDialog();
        }

        private void 按鈕說明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 說明 = new Form2();
            說明.tab顯示玩法.SelectedTab = 說明.tab顯示玩法.TabPages[4];
            說明.ShowDialog();
        }
        #endregion

        #region 金額
        internal void 錢包金額()
        {
            int 金額;
            if (int.TryParse(textMoney.Text, out 金額) == true)
            {
                if (金額 < 25)
                {
                    MessageBox.Show("金額不夠");
                    textMoney.Text = "10000";
                }
                textMoney.Text = Convert.ToString(金額 + Globar.全部總金額);
                listBoxInformation.Items.Add($"此次投注{Globar.全部總金額}元");
            }
            else
            {
                MessageBox.Show("請輸入正確錢包金額");
                textMoney.Text = "10000";
            }
        }


        #endregion

        
    }


}
