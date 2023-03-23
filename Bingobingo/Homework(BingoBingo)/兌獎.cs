using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_BingoBingo_
{

    public class 兌獎 : Form1
    {
        #region 兌獎
        internal static void 幾星以及數目()
        {
            if ((Globar.星數 == 1)|| (Globar.包牌星數 == 1)){ 一星(Globar.winTimes); }
            else if ((Globar.星數 == 2)|| (Globar.包牌星數 == 2)) { 二星(Globar.winTimes); }
            else if ((Globar.星數 == 3)|| (Globar.包牌星數 == 3)) { 三星(Globar.winTimes); }
            else if ((Globar.星數 == 4)|| (Globar.包牌星數 == 4)) { 四星(Globar.winTimes); }
            else if ((Globar.星數 == 5) || (Globar.包牌星數 == 5)) { 五星(Globar.winTimes); }
            else if ((Globar.星數 == 6)|| (Globar.包牌星數 == 6)) { 六星(Globar.winTimes); }
            else if ((Globar.星數 == 7)|| (Globar.包牌星數 == 7)) { 七星(Globar.winTimes); }
            else if ((Globar.星數 == 8) || (Globar.包牌星數 == 8)) { 八星(Globar.winTimes); }
            else if ((Globar.星數 == 9) || (Globar.包牌星數 == 9)) { 九星(Globar.winTimes); }
            else if ((Globar.星數 == 10)|| (Globar.包牌星數 == 10)) { 十星(Globar.winTimes); }
            else{ MessageBox.Show("很不幸似乎出錯了..."); }
            猜大小金額();
            猜單雙金額();
            賺錢賠錢();
        }
        #endregion

        #region 十星
        internal static void 十星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 10)
                {
                    Globar.總金額 = Globar.投注金額 * 200000;
                }
                else if (Globar.winTimes == 5)
                {
                    Globar.總金額 = Globar.投注金額;
                }
                else if (Globar.winTimes == 6)
                {
                    Globar.總金額 = Globar.投注金額*10;
                }
                else if (Globar.winTimes == 7)
                {
                    Globar.總金額 = Globar.投注金額 * 100;
                }
                else if (Globar.winTimes == 8)
                {
                    Globar.總金額 = Globar.投注金額 * 1000;
                }
                else if (Globar.winTimes == 9)
                {
                    Globar.總金額 = Globar.投注金額 * 10000;
                }
                else if(Globar.winTimes == 0)
                { Globar.總金額 = 25; }
                else{Globar.總金額 = -25;}
            }
            else 
            {
                if (Globar.winTimes == 10)
                {Globar.總金額 = Globar.投注金額 * 500000;}
                else if (Globar.winTimes == 9)
                {Globar.總金額 = Globar.投注金額 * 25000;}
                else if (Globar.winTimes == 8)
                { Globar.總金額 = Globar.投注金額 * 2500; }
                else if (Globar.winTimes == 7)
                { Globar.總金額 = Globar.投注金額 * 250; }
                else if (Globar.winTimes == 6)
                { Globar.總金額 = Globar.投注金額 * 30; }
                else if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 3; }
                else if (Globar.winTimes == 0)
                { Globar.總金額 = -25; }
                else { Globar.總金額 = Globar.投注金額; }
            }
        }
        #endregion

        #region 九星
        internal static void 九星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 9)
                {Globar.總金額 = Globar.投注金額 * 40000;}
                else if (Globar.winTimes == 8)
                {Globar.總金額 = Globar.投注金額 * 4000;}
                else if (Globar.winTimes == 7)
                {Globar.總金額 = Globar.投注金額 * 120;}
                else if (Globar.winTimes == 6)
                {Globar.總金額 = Globar.投注金額 * 20;}
                else if (Globar.winTimes == 5)
                {Globar.總金額 = Globar.投注金額 * 4;}
                else if (Globar.winTimes == 4)
                {Globar.總金額 = Globar.投注金額;}
                else if (Globar.winTimes == 0)
                { Globar.總金額 = 25; }
                else { Globar.總金額 = -25; }
            }
            else
            {
                if (Globar.winTimes == 10)
                { Globar.總金額 = Globar.投注金額 * 100000; }
                else if (Globar.winTimes == 9)
                { Globar.總金額 = Globar.投注金額 * 10000; }
                else if (Globar.winTimes == 8)
                { Globar.總金額 = Globar.投注金額 * 300; }
                else if (Globar.winTimes == 7)
                { Globar.總金額 = Globar.投注金額 * 50; }
                else if (Globar.winTimes == 6)
                { Globar.總金額 = Globar.投注金額 * 30; }
                else if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 3; }
                else if (Globar.winTimes == 0)
                { Globar.總金額 = -25; }
                else { Globar.總金額 = Globar.投注金額; }
            }
        }
        #endregion

        #region 八星
        internal static void 八星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 8)
                { Globar.總金額 = Globar.投注金額 * 20000; }
                else if (Globar.winTimes == 7)
                { Globar.總金額 = Globar.投注金額 * 800; }
                else if (Globar.winTimes == 6)
                { Globar.總金額 = Globar.投注金額 * 40; }
                else if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 8; }
                else if ((Globar.winTimes == 4)|| (Globar.winTimes == 0))
                { Globar.總金額 = Globar.投注金額; }
                else { Globar.總金額 = -25; }
            }
            else
            {
                if (Globar.winTimes == 8)
                { Globar.總金額 = Globar.投注金額 * 50000; }
                else if (Globar.winTimes == 7)
                { Globar.總金額 = Globar.投注金額 * 2000; }
                else if (Globar.winTimes == 6)
                { Globar.總金額 = Globar.投注金額 * 100; }
                else if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 20; }
                else if (Globar.winTimes == 4)
                { Globar.總金額 = Globar.投注金額 * 3; }
                else if (Globar.winTimes == 0)
                { Globar.總金額 = -25; }
                else { Globar.總金額 = Globar.投注金額; }
            }
        }
        #endregion

        #region 七星
        internal static void 七星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 7)
                { Globar.總金額 = Globar.投注金額 * 3200; }
                else if (Globar.winTimes == 6)
                { Globar.總金額 = Globar.投注金額 * 120; }
                else if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 12; }
                else if (Globar.winTimes == 4)
                { Globar.總金額 = Globar.投注金額 * 2; }
                else if (Globar.winTimes == 3)
                { Globar.總金額 = 25; }
                else { Globar.總金額 = -25; }
            }
            else
            {
                if (Globar.winTimes == 7)
                { Globar.總金額 = Globar.投注金額 * 8000; }
                else if (Globar.winTimes == 6)
                { Globar.總金額 = Globar.投注金額 * 300; }
                else if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 30; }
                else if (Globar.winTimes == 4)
                { Globar.總金額 = Globar.投注金額 * 5; }
                else if (Globar.winTimes == 3)
                { Globar.總金額 = Globar.投注金額 * 3; }
                else if (Globar.winTimes == 0)
                { Globar.總金額 = -25; }
                else { Globar.總金額 = Globar.投注金額; }
            }
        }
        #endregion

        #region 六星
        internal static void 六星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 6)
                { Globar.總金額 = Globar.投注金額 * 1000; }
                else if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 40; }
                else if (Globar.winTimes == 4)
                { Globar.總金額 = Globar.投注金額 * 8; }
                else if (Globar.winTimes == 3)
                { Globar.總金額 = 25; }
                else { Globar.總金額 = -25; }
            }
            else
            {
                if (Globar.winTimes == 6)
                { Globar.總金額 = Globar.投注金額 * 2500; }
                else if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 100; }
                else if (Globar.winTimes == 4)
                { Globar.總金額 = Globar.投注金額 * 20; }
                else if (Globar.winTimes == 0)
                { Globar.總金額 = -25; }
                else { Globar.總金額 = Globar.投注金額; }
            }
        }
        #endregion

        #region 五星
        internal static void 五星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 300; }
                else if (Globar.winTimes == 4)
                { Globar.總金額 = Globar.投注金額 * 20; }
                else if (Globar.winTimes == 3)
                { Globar.總金額 = Globar.投注金額 * 2; }
                else { Globar.總金額 = -25; }
            }
            else
            {
                if (Globar.winTimes == 5)
                { Globar.總金額 = Globar.投注金額 * 800; }
                else if (Globar.winTimes == 4)
                { Globar.總金額 = Globar.投注金額 * 60; }
                else if (Globar.winTimes == 3)
                { Globar.總金額 = Globar.投注金額 * 6; }
                else if (Globar.winTimes == 0)
                { Globar.總金額 = -25; }
                else { Globar.總金額 = Globar.投注金額; }
            }
        }
        #endregion

        #region 四星
        internal static void 四星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 4)
                { Globar.總金額 = Globar.投注金額 * 40; }
                else if (Globar.winTimes == 3)
                { Globar.總金額 = Globar.投注金額 * 4; }
                else if (Globar.winTimes == 2)
                { Globar.總金額 = Globar.投注金額; }
                else { Globar.總金額 = -25; }
            }
            else
            {
                if (Globar.winTimes == 4)
                { Globar.總金額 = Globar.投注金額 * 120; }
                else if (Globar.winTimes == 3)
                { Globar.總金額 = Globar.投注金額 * 12; }
                else if (Globar.winTimes == 2)
                { Globar.總金額 = Globar.投注金額 * 3; }
                else if (Globar.winTimes == 0)
                { Globar.總金額 = -25; }
                else { Globar.總金額 = Globar.投注金額; }
            }
        }
        #endregion

        #region 三星
        internal static void 三星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 3)
                { Globar.總金額 = Globar.投注金額 * 20; }
                else if (Globar.winTimes == 2)
                { Globar.總金額 = Globar.投注金額 * 2; }
                else { Globar.總金額 = -25; }
            }
            else
            {
                if (Globar.winTimes == 3)
                { Globar.總金額 = Globar.投注金額 * 60; }
                else if (Globar.winTimes == 2)
                { Globar.總金額 = Globar.投注金額 * 6; }
                else if (Globar.winTimes == 0)
                { Globar.總金額 = -25; }
                else { Globar.總金額 = Globar.投注金額; }
            }
        }
        #endregion

        #region 二星
        internal static void 二星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 2)
                { Globar.總金額 = Globar.投注金額 * 3; }
                else if (Globar.winTimes == 1)
                { Globar.總金額 = Globar.投注金額 * 1; }
                else { Globar.總金額 = -25; }
            }
            else
            {
                if (Globar.winTimes == 2)
                { Globar.總金額 = Globar.投注金額 * 8; }
                else if (Globar.winTimes == 1)
                { Globar.總金額 = Globar.投注金額 * 3; }
                else if (Globar.winTimes == 0)
                { Globar.總金額 = -25; }
            }
        }
        #endregion

        #region 一星
        internal static void 一星(int 數目)
        {
            if (Globar.超級獎項 == false)
            {
                if (Globar.winTimes == 1)
                { Globar.總金額 = Globar.投注金額 * 2; }
                else { Globar.總金額 = -25; }
            }
            else
            {
                if (Globar.winTimes == 1)
                { Globar.總金額 = Globar.投注金額 * 6; }
                else { Globar.總金額 = -25; }
            }
        }
        #endregion

        #region 猜大小
        internal static void 猜大小金額()
        {
            if (Globar.猜大 == true)
            {Globar.猜大小金額 = Globar.投注金額 * 6;}
            else if (Globar.猜小 == true)
            { Globar.猜大小金額 = Globar.投注金額 * 6; }
            else if((Globar.猜大 == false)&& (Globar.猜小 == false))
            { Globar.猜大小金額 = 0; }
        }
        #endregion

        #region 猜單雙
        internal static void 猜單雙金額()
        {
            if (Globar.猜單 == true)
            { Globar.猜單雙金額 = Globar.投注金額 * 6; }
            else if (Globar.猜小單 == true)
            { Globar.猜單雙金額 = Globar.投注金額 * 1.8; }
            else if (Globar.猜小雙 == true)
            { Globar.猜單雙金額 = Globar.投注金額 * 1.8; }
            else if (Globar.猜雙 == true)
            { Globar.猜單雙金額 = Globar.投注金額 * 6; }
            else if (Globar.猜和 == true)
            { Globar.猜單雙金額 = Globar.投注金額 * 2.8; }
            else if ((Globar.猜單 == false) && (Globar.猜小單 == false) && (Globar.猜小雙 == false) && (Globar.猜雙 == false) && (Globar.猜和 == false))
            { Globar.猜單雙金額 = 0; }

        }
        #endregion

        #region 賺錢賠錢
        internal static void 賺錢賠錢()
        {
            Globar.全部總金額 = Globar.猜單雙金額 + Globar.猜大小金額 + Globar.總金額;
            Globar.利潤 += Globar.全部總金額;
        }
        #endregion
    }

}


