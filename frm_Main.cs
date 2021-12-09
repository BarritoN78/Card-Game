using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barry_Norton_CPT_185_Final_Project
{
    public partial class frm_Main : Form
    {

        int[] pic1 = { 0, 0 }, pic2 = { 0, 0 }, pic3 = { 0, 0 }, pic4 = { 0, 0 }, pic5 = { 0, 0 }, pic6 = { 0, 0 }, pic7 = { 0, 0 },//In-Hand Cards Image Values
            match1_1 = { 0, 0 }, match1_2 = { 0, 0 }, match1_3 = { 0, 0 }, match2_1 = { 0, 0 }, match2_2 = { 0, 0 }, match2_3 = { 0, 0 }, match3_1 = { 0, 0 }, match3_2 = { 0, 0 }, match3_3 = { 0, 0 },//Matched Cards Image Values
            match4_1 = { 0, 0 }, match4_2 = { 0, 0 }, match4_3 = { 0, 0 }, match5_1 = { 0, 0 }, match5_2 = { 0, 0 }, match5_3 = { 0, 0 }, match6_1 = { 0, 0 }, match6_2 = { 0, 0 }, match6_3 = { 0, 0 },//Matched Cards Image Values
            score = { 0, 0 }, pointloss = { 0, 0 }, subscore = { 0, 0 };//Point Values
        int matchID1 = 0, matchID2 = 0, matchID3 = 0,//Match Testing Card Image Values
            check1 = 56, check2 = 56, check3 = 56, check4 = 56, check5 = 56, check6 = 56, check7 = 56,//Checked Card Image Values
            seq = 0, icon = 0, PV = 0, test = 0, turn = 0, draw = 0, discard = 0,//Test Values
            lastDis = 0, lastDisUsed = 0;

        int[] CV1 = { 0, 0, 0 }, CV2 = { 0, 0, 0 }, CV3 = { 0, 0, 0 };//Match Testing Test Values
        Random drawrng = new Random();//RNG for Draw Function
        string[] picID = { "Cards/Backface_Blue.bmp","Cards/2_Clubs.bmp","Cards/2_Hearts.bmp","Cards/2_Spades.bmp","Cards/2_Diamonds.bmp", //Image links
                    "Cards/3_Clubs.bmp", "Cards/3_Hearts.bmp", "Cards/3_Spades.bmp", "Cards/3_Diamonds.bmp",
                    "Cards/4_Clubs.bmp", "Cards/4_Hearts.bmp", "Cards/4_Spades.bmp", "Cards/4_Diamonds.bmp",
                    "Cards/5_Clubs.bmp", "Cards/5_Hearts.bmp", "Cards/5_Spades.bmp", "Cards/5_Diamonds.bmp",
                    "Cards/6_Clubs.bmp", "Cards/6_Hearts.bmp", "Cards/6_Spades.bmp", "Cards/6_Diamonds.bmp",
                    "Cards/7_Clubs.bmp", "Cards/7_Hearts.bmp", "Cards/7_Spades.bmp", "Cards/7_Diamonds.bmp",
                    "Cards/8_Clubs.bmp", "Cards/8_Hearts.bmp", "Cards/8_Spades.bmp", "Cards/8_Diamonds.bmp",
                    "Cards/9_Clubs.bmp", "Cards/9_Hearts.bmp", "Cards/9_Spades.bmp", "Cards/9_Diamonds.bmp",
                    "Cards/10_Clubs.bmp", "Cards/10_Hearts.bmp", "Cards/10_Spades.bmp", "Cards/10_Diamonds.bmp",
                    "Cards/Jack_Clubs.bmp", "Cards/Jack_Hearts.bmp", "Cards/Jack_Spades.bmp", "Cards/Jack_Diamonds.bmp",
                    "Cards/Queen_Clubs.bmp", "Cards/Queen_Hearts.bmp", "Cards/Queen_Spades.bmp", "Cards/Queen_Diamonds.bmp",
                    "Cards/King_Clubs.bmp", "Cards/King_Hearts.bmp", "Cards/King_Spades.bmp", "Cards/King_Diamonds.bmp",
                    "Cards/Ace_Clubs.bmp", "Cards/Ace_Hearts.bmp", "Cards/Ace_Spades.bmp", "Cards/Ace_Diamonds.bmp",
                    "Cards/Joker_Black.bmp", "Cards/Joker_Red.bmp"};
       //
       // General Methods
       //
        private void ImgDraw(int turn)
        {
            if (pic1[turn] == 0)
            {
                draw++;
                pic1[turn] = test;
                pic_Card1.Image = Image.FromFile(picID[pic1[turn]]);
            }
            else if (pic2[turn] == 0)
            {
                draw++;
                pic2[turn] = test;
                pic_Card2.Image = Image.FromFile(picID[pic2[turn]]);
            }
            else if (pic3[turn] == 0)
            {
                draw++;
                pic3[turn] = test;
                pic_Card3.Image = Image.FromFile(picID[pic3[turn]]);
            }
            else if (pic4[turn] == 0)
            {
                draw++;
                pic4[turn] = test;
                pic_Card4.Image = Image.FromFile(picID[pic4[turn]]);
            }
            else if (pic5[turn] == 0)
            {
                draw++;
                pic5[turn] = test;
                pic_Card5.Image = Image.FromFile(picID[pic5[turn]]);
            }
            else if (pic6[turn] == 0)
            {
                draw++;
                pic6[turn] = test;
                pic_Card6.Image = Image.FromFile(picID[pic6[turn]]);
            }
            else if (pic7[turn] == 0)
            {
                draw++;
                pic7[turn] = test;
                pic_Card7.Image = Image.FromFile(picID[pic7[turn]]);
            }
            else
                MessageBox.Show("Your hand is currently full");
        }

        private void ClearHand()
        {
            chk_Card1.Checked = true;
            chk_Card2.Checked = true;
            chk_Card3.Checked = true;
            chk_Card4.Checked = true;
            chk_Card5.Checked = true;
            chk_Card6.Checked = true;
            chk_Card7.Checked = true;
            Discard(0);
            Discard(1);
        }
        public frm_Main()
        {
            int count = 0;
            turn = 0;
            InitializeComponent();
            grp_Player.Text = "Player 1's Cards";
            while (count < 7)
            {
                Draw(1);
                Draw(0);
                count++;
                draw = 0; //Sets the draw back to 0 due to the load giving it a value
            }
        }

        private int PicToSeq(int picNum)
        {
            switch (picNum)
            {
                //For seq: 2-10 = Number Cards, 11 = Jack, 12 = Queen, 13 = King, 14 = Ace, 15 = Joker
                case 1:
                case 2:
                case 3:
                case 4: seq = 2; break;
                case 5:
                case 6:
                case 7:
                case 8: seq = 3; break;
                case 9:
                case 10:
                case 11:
                case 12: seq = 4; break;
                case 13:
                case 14:
                case 15:
                case 16: seq = 5; break;
                case 17:
                case 18:
                case 19:
                case 20: seq = 6; break;
                case 21:
                case 22:
                case 23:
                case 24: seq = 7; break;
                case 25:
                case 26:
                case 27:
                case 28: seq = 8; break;
                case 29:
                case 30:
                case 31:
                case 32: seq = 9; break;
                case 33:
                case 34:
                case 35:
                case 36: seq = 10; break;
                case 37:
                case 38:
                case 39:
                case 40: seq = 11; break;
                case 41:
                case 42:
                case 43:
                case 44: seq = 12; break;
                case 45:
                case 46:
                case 47:
                case 48: seq = 13; break;
                case 49:
                case 50:
                case 51:
                case 52: seq = 14; break;
                case 53:
                case 54: seq = 15; break;
            }
            return seq;
        }
        private int PicToIcon(int picNum)
        {
            switch (picNum)
            {
                //For icon: 1 = Clubs, 2 = Hearts, 3 = Spades, 4 = Diamonds, 5 = Joker Black, 6 = Joker Red
                case 1: icon = 1; break;
                case 2: icon = 2; break;
                case 3: icon = 3; break;
                case 4: icon = 4; break;
                case 5: icon = 1; break;
                case 6: icon = 2; break;
                case 7: icon = 3; break;
                case 8: icon = 4; break;
                case 9: icon = 1; break;
                case 10: icon = 2; break;
                case 11: icon = 3; break;
                case 12: icon = 4; break;
                case 13: icon = 1; break;
                case 14: icon = 2; break;
                case 15: icon = 3; break;
                case 16: icon = 4; break;
                case 17: icon = 1; break;
                case 18: icon = 2; break;
                case 19: icon = 3; break;
                case 20: icon = 4; break;
                case 21: icon = 1; break;
                case 22: icon = 2; break;
                case 23: icon = 3; break;
                case 24: icon = 4; break;
                case 25: icon = 1; break;
                case 26: icon = 2; break;
                case 27: icon = 3; break;
                case 28: icon = 4; break;
                case 29: icon = 1; break;
                case 30: icon = 2; break;
                case 31: icon = 3; break;
                case 32: icon = 4; break;
                case 33: icon = 1; break;
                case 34: icon = 2; break;
                case 35: icon = 3; break;
                case 36: icon = 4; break;
                case 37: icon = 1; break;
                case 38: icon = 2; break;
                case 39: icon = 3; break;
                case 40: icon = 4; break;
                case 41: icon = 1; break;
                case 42: icon = 2; break;
                case 43: icon = 3; break;
                case 44: icon = 4; break;
                case 45: icon = 1; break;
                case 46: icon = 2; break;
                case 47: icon = 3; break;
                case 48: icon = 4; break;
                case 49: icon = 1; break;
                case 50: icon = 2; break;
                case 51: icon = 3; break;
                case 52: icon = 4; break;
                case 53: icon = 5; break;
                case 54: icon = 6; break;
            }
            return icon;
        }
        private int PicToPV(int picNum)
        {
            switch (picNum)
            {
                //For seq: 2-10 = Number Cards, 11 = Jack, 12 = Queen, 13 = King, 14 = Ace, 15 = Joker
                case 0: PV = 0; break;
                case 1:
                case 2:
                case 3:
                case 4: 
                case 5:
                case 6:
                case 7:
                case 8: 
                case 9:
                case 10:
                case 11:
                case 12: 
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32: PV = 5; break;
                case 33:
                case 34:
                case 35:
                case 36:
                case 37: 
                case 38:
                case 39:
                case 40:
                case 41:
                case 42:
                case 43:
                case 44: 
                case 45:
                case 46:
                case 47:
                case 48: PV = 10; break;
                case 49:
                case 50:
                case 51:
                case 52: PV = 15; break;
                case 53:
                case 54: PV = 5; break;
            }
            return PV;
        }

        private void MatchIDSet(int PicNum)
        {
            if (matchID1 == 0)
            {
                matchID1 = PicNum;
            }
            else if (matchID2 == 0)
            {
                matchID2 = PicNum;
            }
            else if (matchID3 == 0)
            {
                matchID3 = PicNum;
            }
        }

        private void CVSet(int PicNum)
        {
            seq = PicToSeq(PicNum);
            icon = PicToIcon(PicNum);
            PV = PicToPV(PicNum);
            if (CV1[0] == 0)
            {
                CV1[0] = seq;
                CV1[1] = icon;
                CV1[2] = PV;
                matchID1 = PicNum;
            }
            else if (CV2[0] == 0)
            {
                CV2[0] = seq;
                CV2[1] = icon;
                CV2[2] = PV;
                matchID2 = PicNum;
            }
            else if (CV3[0] == 0)
            {
                CV3[0] = seq;
                CV3[1] = icon;
                CV3[2] = PV;
                matchID3 = PicNum;
            }
        }

        private void MatchVarReset()
        {
            check1 = 56;
            check2 = 56;
            check3 = 56;
            check4 = 56;
            check5 = 56;
            check6 = 56;
            check7 = 56;
            CV1[0] = 0;
            CV1[1] = 0;
            CV1[2] = 0;
            CV2[0] = 0;
            CV2[1] = 0;
            CV2[2] = 0;
            CV3[0] = 0;
            CV3[1] = 0;
            CV3[2] = 0;
            matchID1 = 0;
            matchID2 = 0;
            matchID3 = 0;
        }

        private void DeselectChkbx()
        {
            chk_Card1.Checked = false;
            chk_Card2.Checked = false;
            chk_Card3.Checked = false;
            chk_Card4.Checked = false;
            chk_Card5.Checked = false;
            chk_Card6.Checked = false;
            chk_Card7.Checked = false;
        }
        private void CheckCount()
        {
            test = 0;
            if (chk_Card1.Checked == true)
                test++;
            if (chk_Card2.Checked == true)
                test++;
            if (chk_Card3.Checked == true)
                test++;
            if (chk_Card4.Checked == true)
                test++;
            if (chk_Card5.Checked == true)
                test++;   
            if (chk_Card6.Checked == true)
                test++;
            if (chk_Card7.Checked == true)
                test++;
        }

        private void  Draw(int turn)
        {
          test = drawrng.Next(1, 55);
          while (test == pic1[0] || test == pic2[0] || test == pic3[0] || test == pic4[0] || test == pic5[0] || test == pic6[0] || test == pic7[0] || test == match1_1[0] || test == match1_2[0] || test == match1_3[0] || test == match2_1[0] || test == match2_2[0] || test == match2_3[0] ||
            test == match3_1[0] || test == match3_2[0] || test == match3_3[0] || test == match4_1[0] || test == match4_2[0] || test == match4_3[0] || test == match5_1[0] || test == match5_2[0] || test == match5_3[0] || test == match6_1[0] || test == match6_2[0] || test == match6_3[0] ||
            test == pic1[1] || test == pic2[1] || test == pic3[1] || test == pic4[1] || test == pic5[1] || test == pic6[1] || test == pic7[1] || test == match1_1[1] || test == match1_2[1] || test == match1_3[1] || test == match2_1[1] || test == match2_2[1] || test == match2_3[1] ||
            test == match3_1[1] || test == match3_2[1] || test == match3_3[1] || test == match4_1[1] || test == match4_2[1] || test == match4_3[1] || test == match5_1[1] || test == match5_2[1] || test == match5_3[1] || test == match6_1[1] || test == match6_2[1] || test == match6_3[1] || test == lastDis)
            {
                if (test != 54)
                    test++;
                else
                    test = 1;
            }
            ImgDraw(turn);
        }

        private void ChkbxCheck(int turn)
        {
            if (chk_Card1.Checked == true)
                check1 = pic1[turn];
            if (chk_Card2.Checked == true)
                check2 = pic2[turn];
            if (chk_Card3.Checked == true)
                check3 = pic3[turn];
            if (chk_Card4.Checked == true)
                check4 = pic4[turn];
            if (chk_Card5.Checked == true)
                check5 = pic5[turn];
            if (chk_Card6.Checked == true)
                check6 = pic6[turn];
            if (chk_Card7.Checked == true)
                check7 = pic7[turn];
        }
        private void Discard(int turn)
        {
            if (chk_Card1.Checked == true)
            {
                pic1[turn] = 0;
                pic_Card1.Image = Image.FromFile(picID[0]);
            }
            if (chk_Card2.Checked == true)
            {
                pic2[turn] = 0;
                pic_Card2.Image = Image.FromFile(picID[0]);
            }
            if (chk_Card3.Checked == true)
            {
                pic3[turn] = 0;
                pic_Card3.Image = Image.FromFile(picID[0]);
            }
            if (chk_Card4.Checked == true)
            {
                pic4[turn] = 0;
                pic_Card4.Image = Image.FromFile(picID[0]);
            }
            if (chk_Card5.Checked == true)
            {
                pic5[turn] = 0;
                pic_Card5.Image = Image.FromFile(picID[0]);
            }
            if (chk_Card6.Checked == true)
            {
                pic6[turn] = 0;
                pic_Card6.Image = Image.FromFile(picID[0]);
            }
            if (chk_Card7.Checked == true)
            {
                pic7[turn] = 0;
                pic_Card7.Image = Image.FromFile(picID[0]);
            }
        }

        private int NearestCard(int turn, int empty)
        {
            int picShift = 0;
            if (pic2[turn] != 0 && empty == 1)
            {
                picShift = pic2[turn];
                pic2[turn] = 0;
                pic_Card2.Image = Image.FromFile(picID[0]);
            }
            else if (pic3[turn] != 0 && empty <= 2)
            {
                picShift = pic3[turn];
                pic3[turn] = 0;
                pic_Card3.Image = Image.FromFile(picID[0]);
            }
            else if (pic4[turn] != 0 && empty <= 3)
            {
                picShift = pic4[turn];
                pic4[turn] = 0;
                pic_Card4.Image = Image.FromFile(picID[0]);
            }
            else if (pic5[turn] != 0 && empty <= 4)
            {
                picShift = pic5[turn];
                pic5[turn] = 0;
                pic_Card5.Image = Image.FromFile(picID[0]);
            }
            else if (pic6[turn] != 0 && empty <= 5)
            {
                picShift = pic6[turn];
                pic6[turn] = 0;
                pic_Card6.Image = Image.FromFile(picID[0]);
            }
            else if (pic7[turn] != 0 && empty <= 6)
            {
                picShift = pic7[turn];
                pic7[turn] = 0;
                pic_Card7.Image = Image.FromFile(picID[0]);
            }
            return picShift;
        }

        private void ImgShift(int turn)
        {
            if (pic1[turn] == 0)
            {
                pic1[turn] = NearestCard(turn, 1);
                pic_Card1.Image = Image.FromFile(picID[pic1[turn]]);
            }
            else if(pic2[turn] == 0)
            {
                pic2[turn] = NearestCard(turn, 2);
                pic_Card2.Image = Image.FromFile(picID[pic2[turn]]);
            }
            else if (pic3[turn] == 0)
            {
                pic3[turn] = NearestCard(turn, 3);
                pic_Card3.Image = Image.FromFile(picID[pic3[turn]]);
            }
            else if (pic4[turn] == 0)
            {
                pic4[turn] = NearestCard(turn, 4);
                pic_Card4.Image = Image.FromFile(picID[pic4[turn]]);
            }
            else if (pic5[turn] == 0)
            {
                pic5[turn] = NearestCard(turn, 5);
                pic_Card5.Image = Image.FromFile(picID[pic5[turn]]);
            }
            else if (pic6[turn] == 0)
            {
                pic6[turn] = NearestCard(turn, 6);
                pic_Card6.Image = Image.FromFile(picID[pic6[turn]]);
            }
        }

        private void MatchTrue(int turn)
        {
            int count = 0;
            Discard(turn);
            MatchShow(turn);
            while (count <= 6)
            {
                count++;
                ImgShift(turn);
            }
            DeselectChkbx();
            MatchVarReset();
            MessageBox.Show("Match Successful");
            btn_Discard.Focus();
            if (pic1[turn] == 0 && pic2[turn] == 0 && pic3[turn] == 0 && pic4[turn] == 0 && pic5[turn] == 0 && pic6[turn] == 0 && pic7[turn] == 0)
                GameEnd();
            else if (grp_P1_Match6.Visible == false && grp_P2_Match6.Visible == false)
            {
                Draw(turn);
                draw--;
            }
        }

        private void MatchFalse()
        {
            DeselectChkbx();
            MatchVarReset();
            MessageBox.Show("The cards you selected do not match");
            btn_Discard.Focus();
        }

        private void MatchShow(int turn)
        {
            int Points = 0;
            Points = (CV1[2] + CV2[2] + CV3[2]);
            score[turn] += Points;
            if (turn == 0)
            {
                if (grp_P1_Match1.Visible == false)
                {
                    grp_P1_Match1.Visible = true;
                    grp_P1_Match1.Text = "Match #1: " + Points.ToString() + " Points";
                    match1_1[turn] = matchID1;
                    match1_2[turn] = matchID2;
                    match1_3[turn] = matchID3;
                    pic_P1_Match1_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P1_Match1_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P1_Match1_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P1_Match2.Visible == false)
                {
                    grp_P1_Match2.Visible = true;
                    grp_P1_Match2.Text = "Match #2: " + Points.ToString() + " Points";
                    match2_1[turn] = matchID1;
                    match2_2[turn] = matchID2;
                    match2_3[turn] = matchID3;
                    pic_P1_Match2_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P1_Match2_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P1_Match2_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P1_Match3.Visible == false)
                {
                    grp_P1_Match3.Visible = true;
                    grp_P1_Match3.Text = "Match #3: " + Points.ToString() + " Points";
                    match3_1[turn] = matchID1;
                    match3_2[turn] = matchID2;
                    match3_3[turn] = matchID3;
                    pic_P1_Match3_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P1_Match3_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P1_Match3_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P1_Match4.Visible == false)
                {
                    grp_P1_Match4.Visible = true;
                    grp_P1_Match4.Text = "Match #4: " + Points.ToString() + " Points";
                    match4_1[turn] = matchID1;
                    match4_2[turn] = matchID2;
                    match4_3[turn] = matchID3;
                    pic_P1_Match4_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P1_Match4_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P1_Match4_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P1_Match5.Visible == false)
                {
                    grp_P1_Match5.Visible = true;
                    grp_P1_Match5.Text = "Match #5: " + Points.ToString() + " Points";
                    match5_1[turn] = matchID1;
                    match5_2[turn] = matchID2;
                    match5_3[turn] = matchID3;
                    pic_P1_Match5_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P1_Match5_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P1_Match5_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P1_Match6.Visible == false)
                {
                    grp_P1_Match6.Visible = true;
                    grp_P1_Match6.Text = "Match #6: " + Points.ToString() + " Points";
                    match6_1[turn] = matchID1;
                    match6_2[turn] = matchID2;
                    match6_3[turn] = matchID3;
                    pic_P1_Match6_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P1_Match6_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P1_Match6_3.Image = Image.FromFile(picID[matchID3]);
                    GameEnd();
                }
            }
            else if (turn == 1)
            {
                if (grp_P2_Match1.Visible == false)
                {
                    grp_P2_Match1.Visible = true;
                    grp_P2_Match1.Text = "Match #1: " + Points.ToString() + " Points";
                    match1_1[turn] = matchID1;
                    match1_2[turn] = matchID2;
                    match1_3[turn] = matchID3;
                    pic_P2_Match1_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P2_Match1_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P2_Match1_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P2_Match2.Visible == false)
                {
                    grp_P2_Match2.Visible = true;
                    grp_P2_Match2.Text = "Match #2: " + Points.ToString() + " Points";
                    match2_1[turn] = matchID1;
                    match2_2[turn] = matchID2;
                    match2_3[turn] = matchID3;
                    pic_P2_Match2_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P2_Match2_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P2_Match2_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P2_Match3.Visible == false)
                {
                    grp_P2_Match3.Visible = true;
                    grp_P2_Match3.Text = "Match #3: " + Points.ToString() + " Points";
                    match3_1[turn] = matchID1;
                    match3_2[turn] = matchID2;
                    match3_3[turn] = matchID3;
                    pic_P2_Match3_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P2_Match3_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P2_Match3_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P2_Match4.Visible == false)
                {
                    grp_P2_Match4.Visible = true;
                    grp_P2_Match4.Text = "Match #4: " + Points.ToString() + " Points";
                    match4_1[turn] = matchID1;
                    match4_2[turn] = matchID2;
                    match4_3[turn] = matchID3;
                    pic_P2_Match4_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P2_Match4_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P2_Match4_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P2_Match5.Visible == false)
                {
                    grp_P2_Match5.Visible = true;
                    grp_P2_Match5.Text = "Match #5: " + Points.ToString() + " Points";
                    match5_1[turn] = matchID1;
                    match5_2[turn] = matchID2;
                    match5_3[turn] = matchID3;
                    pic_P2_Match5_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P2_Match5_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P2_Match5_3.Image = Image.FromFile(picID[matchID3]);
                }
                else if (grp_P2_Match6.Visible == false)
                {
                    grp_P2_Match6.Visible = true;
                    grp_P2_Match6.Text = "Match #6: " + Points.ToString() + " Points";
                    match6_1[turn] = matchID1;
                    match6_2[turn] = matchID2;
                    match6_3[turn] = matchID3;
                    pic_P2_Match6_1.Image = Image.FromFile(picID[matchID1]);
                    pic_P2_Match6_2.Image = Image.FromFile(picID[matchID2]);
                    pic_P2_Match6_3.Image = Image.FromFile(picID[matchID3]);
                    GameEnd();
                }
            }
        }

        private void PointsEnd(int turn)
        {
            pointloss[turn] = PicToPV(pic1[turn]) + PicToPV(pic2[turn]) + PicToPV(pic3[turn]) + PicToPV(pic4[turn]) + PicToPV(pic5[turn]) + PicToPV(pic6[turn]) + PicToPV(pic7[turn]);
            subscore[turn] = score[turn];
            score[turn] -= pointloss[turn];
        }

        private void GameEnd()
        {
            PointsEnd(0);
            PointsEnd(1);
            btn_Draw.Enabled = false;
            btn_Discard.Enabled = false;
            btn_Match.Enabled = false;
            btn_Next.Enabled = false;
            btn_Take.Enabled = false;
            btn_Replay.Visible = true;
            frm_Score frm_Score = new frm_Score();
            frm_Score.lbl_P1_Subscore.Text = "Subscore: " + subscore[0] + " pts";
            frm_Score.lbl_P2_Subscore.Text = "Subscore: " + subscore[1] + " pts";
            frm_Score.lbl_P1_PointLoss.Text = "Points Lost: " + pointloss[0] + " pts";
            frm_Score.lbl_P2_PointLoss.Text = "Points Lost: " + pointloss[1] + " pts";
            frm_Score.lbl_P1_Final.Text = "Final Score: " + score[0] + " pts";
            frm_Score.lbl_P2_Final.Text = "Final Score: " + score[1] + " pts";
            if (score[0] > score[1])
                frm_Score.lbl_Verdict.Text = "Player 1 Wins!";
            else if (score[1] > score[0])
                frm_Score.lbl_Verdict.Text = "Player 2 Wins!";
            else if (score[0] == score[1])
                frm_Score.lbl_Verdict.Text = "It was a Tie!";
            frm_Score.ShowDialog();
        }

        //
        //Button methods
        //

        private void btn_Replay_Click(object sender, EventArgs e)
        {
            int count = 0;
            btn_Draw.Enabled = true;
            btn_Discard.Enabled = true;
            btn_Match.Enabled = true;
            btn_Next.Enabled = true;
            btn_Take.Enabled = true;
            grp_Discard.Visible = false;
            pic_Discard.Image = Image.FromFile(picID[0]);
            lastDis = 0;
            lastDisUsed = 0;
            ClearHand();
            turn = 0;
            draw = 0;
            discard = 0;
            match1_1[0] = 0;
            match1_1[1] = 0;
            pic_P1_Match1_1.Image = Image.FromFile(picID[0]);
            pic_P2_Match1_1.Image = Image.FromFile(picID[0]);
            match1_2[0] = 0;
            match1_2[1] = 0;
            pic_P1_Match1_2.Image = Image.FromFile(picID[0]);
            pic_P2_Match1_2.Image = Image.FromFile(picID[0]);
            match1_3[0] = 0;
            match1_3[1] = 0;
            pic_P1_Match1_3.Image = Image.FromFile(picID[0]);
            pic_P2_Match1_3.Image = Image.FromFile(picID[0]);
            match2_1[0] = 0;
            match2_1[1] = 0;
            pic_P1_Match2_1.Image = Image.FromFile(picID[0]);
            pic_P2_Match2_1.Image = Image.FromFile(picID[0]);
            match2_2[0] = 0;
            match2_2[1] = 0;
            pic_P1_Match2_2.Image = Image.FromFile(picID[0]);
            pic_P2_Match2_2.Image = Image.FromFile(picID[0]);
            match2_3[0] = 0;
            match2_3[1] = 0;
            pic_P1_Match2_3.Image = Image.FromFile(picID[0]);
            pic_P2_Match2_3.Image = Image.FromFile(picID[0]);
            match3_1[0] = 0;
            match3_1[1] = 0;
            pic_P1_Match3_1.Image = Image.FromFile(picID[0]);
            pic_P2_Match3_1.Image = Image.FromFile(picID[0]);
            match3_2[0] = 0;
            match3_2[1] = 0;
            pic_P1_Match3_2.Image = Image.FromFile(picID[0]);
            pic_P2_Match3_2.Image = Image.FromFile(picID[0]);
            match3_3[0] = 0;
            match3_3[1] = 0;
            pic_P1_Match3_3.Image = Image.FromFile(picID[0]);
            pic_P2_Match3_3.Image = Image.FromFile(picID[0]);
            match4_1[0] = 0;
            match4_1[1] = 0;
            pic_P1_Match4_1.Image = Image.FromFile(picID[0]);
            pic_P2_Match4_1.Image = Image.FromFile(picID[0]);
            match4_2[0] = 0;
            match4_2[1] = 0;
            pic_P1_Match4_2.Image = Image.FromFile(picID[0]);
            pic_P2_Match4_2.Image = Image.FromFile(picID[0]);
            match4_3[0] = 0;
            match4_3[1] = 0;
            pic_P1_Match4_3.Image = Image.FromFile(picID[0]);
            pic_P2_Match4_3.Image = Image.FromFile(picID[0]);
            match5_1[0] = 0;
            match5_1[1] = 0;
            pic_P1_Match5_1.Image = Image.FromFile(picID[0]);
            pic_P2_Match5_1.Image = Image.FromFile(picID[0]);
            match5_2[0] = 0;
            match5_2[1] = 0;
            pic_P1_Match5_2.Image = Image.FromFile(picID[0]);
            pic_P2_Match5_2.Image = Image.FromFile(picID[0]);
            match5_3[0] = 0;
            match5_3[1] = 0;
            pic_P1_Match5_3.Image = Image.FromFile(picID[0]);
            pic_P2_Match5_3.Image = Image.FromFile(picID[0]);
            match6_1[0] = 0;
            match6_1[1] = 0;
            pic_P1_Match6_1.Image = Image.FromFile(picID[0]);
            pic_P2_Match6_1.Image = Image.FromFile(picID[0]);
            match6_2[0] = 0;
            match6_2[1] = 0;
            pic_P1_Match6_2.Image = Image.FromFile(picID[0]);
            pic_P2_Match6_2.Image = Image.FromFile(picID[0]);
            match6_3[0] = 0;
            match6_3[1] = 0;
            pic_P1_Match6_3.Image = Image.FromFile(picID[0]);
            pic_P2_Match6_3.Image = Image.FromFile(picID[0]);
            grp_P1_Match1.Visible = false;
            grp_P1_Match2.Visible = false;
            grp_P1_Match3.Visible = false;
            grp_P1_Match4.Visible = false;
            grp_P1_Match5.Visible = false;
            grp_P1_Match6.Visible = false;
            grp_P2_Match1.Visible = false;
            grp_P2_Match2.Visible = false;
            grp_P2_Match3.Visible = false;
            grp_P2_Match4.Visible = false;
            grp_P2_Match5.Visible = false;
            grp_P2_Match6.Visible = false;
            while (count < 7)
            {
                Draw(1);
                Draw(0);
                count++;
            }
            btn_Replay.Visible = false;
            DeselectChkbx();
            btn_Discard.Focus();
        }

        private void btn_ExitMain_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                if (draw >= 1 && discard == 1)
                {
                    MatchVarReset();
                    DeselectChkbx();
                    lastDisUsed = 0;
                    draw = 0;
                    discard = 0;
                    if (turn == 0)
                    {
                        turn = 1;
                        pic_Card1.Image = Image.FromFile(picID[pic1[1]]);
                        pic_Card2.Image = Image.FromFile(picID[pic2[1]]);
                        pic_Card3.Image = Image.FromFile(picID[pic3[1]]);
                        pic_Card4.Image = Image.FromFile(picID[pic4[1]]);
                        pic_Card5.Image = Image.FromFile(picID[pic5[1]]);
                        pic_Card6.Image = Image.FromFile(picID[pic6[1]]);
                        pic_Card7.Image = Image.FromFile(picID[pic7[1]]);
                        grp_Player.Text = "Player 2's Cards";
                    }
                    else if (turn == 1)
                    {
                        turn = 0;
                        pic_Card1.Image = Image.FromFile(picID[pic1[0]]);
                        pic_Card2.Image = Image.FromFile(picID[pic2[0]]);
                        pic_Card3.Image = Image.FromFile(picID[pic3[0]]);
                        pic_Card4.Image = Image.FromFile(picID[pic4[0]]);
                        pic_Card5.Image = Image.FromFile(picID[pic5[0]]);
                        pic_Card6.Image = Image.FromFile(picID[pic6[0]]);
                        pic_Card7.Image = Image.FromFile(picID[pic7[0]]);
                        grp_Player.Text = "Player 1's Cards";
                    }
                }
                else
                {
                    MessageBox.Show("You must draw and discard once per turn");
                }
            }
            catch
            {
                MessageBox.Show("Nani");
            }
        }

        private void btn_Take_Click(object sender, EventArgs e)
        {
            if (lastDisUsed == 0)
            {
                if (discard == 0)
                {
                    if (draw < 2)
                    {
                        lastDisUsed++;
                        test = lastDis;
                        ImgDraw(turn);
                    }
                    else
                        MessageBox.Show("You may only draw up to two times per turn");
                }
                else
                    MessageBox.Show("You cannot take back your own discard");
            }
            else
                MessageBox.Show("You have already taken this card on this turn");
        }

        private void btn_Rules_Click(object sender, EventArgs e)
        {
            try
            {
                new frm_Rules().ShowDialog();
            }
            catch
            {
                MessageBox.Show("I'm not even sure this is necessary");
            }
        }


        private void btn_Discard_Click(object sender, EventArgs e)
        {
            try
            {
                CheckCount();
                if (test != 1)
                {
                    MessageBox.Show("Select one card to be discarded");
                    DeselectChkbx();
                }
                else if (discard == 0)
                {
                    int count = 0;
                    discard = 1;
                    ChkbxCheck(turn);
                    if (check1 != 56)
                        lastDis = check1;
                    if (check2 != 56)
                        lastDis = check2;
                    if (check3 != 56)
                        lastDis = check3;
                    if (check4 != 56)
                        lastDis = check4;
                    if (check5 != 56)
                        lastDis = check5;
                    if (check6 != 56)
                        lastDis = check6;
                    if (check7 != 56)
                        lastDis = check7;
                    pic_Discard.Image = Image.FromFile(picID[lastDis]);
                    Discard(turn);
                    while (count <= 6)
                    {
                        count++;
                        ImgShift(turn);
                    }
                    DeselectChkbx();
                    if (grp_Discard.Visible == false)
                        grp_Discard.Visible = true;
                    if (pic1[turn] == 0 && pic2[turn] == 0 && pic3[turn] == 0 && pic4[turn] == 0 && pic5[turn] == 0 && pic6[turn] == 0 && pic7[turn] == 0)
                        GameEnd();
                }
                else
                {
                    MessageBox.Show("You may only discard once per turn");
                    DeselectChkbx();
                }
            }
            catch
            {
                MessageBox.Show("WTF");
            }
        }

        private void btn_Match_Click(object sender, EventArgs e)
        {
            try
            {
                CheckCount();
                if (test != 3)
                {
                    MessageBox.Show("Select 3 Cards to match them");
                    DeselectChkbx();
                }
                else
                {
                    ChkbxCheck(turn);
                    if (check1 == 0 || check2 == 0 || check3 == 0 || check4 == 0 || check5 == 0 || check6 == 0 || check7 == 0)
                    {
                        MessageBox.Show("One of your selections was a blank card");
                        DeselectChkbx();
                        MatchVarReset();
                    }
                    else
                    {
                        if (check1 != 56)
                        {
                            CVSet(pic1[turn]);
                            MatchIDSet(pic1[turn]);
                        }
                        if (check2 != 56)
                        {
                            CVSet(pic2[turn]);
                            MatchIDSet(pic2[turn]);
                        }
                        if (check3 != 56)
                        {
                            CVSet(pic3[turn]);
                            MatchIDSet(pic3[turn]);
                        }
                        if (check4 != 56)
                        {
                            CVSet(pic4[turn]);
                            MatchIDSet(pic4[turn]);
                        }
                        if (check5 != 56)
                        {
                            CVSet(pic5[turn]);
                            MatchIDSet(pic5[turn]);
                        }
                        if (check6 != 56)
                        {
                            CVSet(pic6[turn]);
                            MatchIDSet(pic6[turn]);
                        }
                        if (check7 != 56)
                        {
                            CVSet(pic7[turn]);
                            MatchIDSet(pic7[turn]);
                        }
                    }    //Testing for matching seq values w/o a Joker
                    if (CV1[0] == CV2[0] && CV2[0] == CV3[0])
                    {
                        MatchTrue(turn);
                    }
                    //Test for matching seq values with 1 or 2 Jokers
                    else if (CV1[0] == CV2[0] && CV3[0] == 15 || CV1[0] == CV3[0] && CV2[0] == 15 || CV2[0] == CV3[0] && CV1[0] == 15 || //1 Joker
                            CV1[0] == CV2[0] && CV1[0] == 15 || CV1[0] == CV3[0] && CV1[0] == 15 || CV2[0] == CV3[0] && CV2[0] == 15) //2 Jokers
                    {
                        MatchTrue(turn);
                    }
                    //Test for matching icon values w/o Joker
                    else if (CV1[1] == CV2[1] && CV2[1] == CV3[1])
                    {
                        //Testing for correct order
                        //Testing for difference of 1 b/w seq values of Card #1 and #2 
                        if (CV1[0] == (CV2[0] - 1) || CV1[0] == (CV2[0] + 1))
                        {
                            //Testing for difference of 1 b/w seq values of Card #2 and #3
                            if (CV2[0] == (CV3[0] - 1) || CV2[0] == (CV3[0] + 1) || CV1[0] == (CV3[0] - 1) || CV1[0] == (CV3[0] + 1))
                            {
                                MatchTrue(turn);
                            }
                            //Testing for matches with Ace used as a 1 in Card #3  
                            else if (CV3[0] == 14 && CV1[0] == 2 && CV2[0] == 3 || CV3[0] == 14 && CV2[0] == 2 && CV1[0] == 3)
                            {
                                MatchTrue(turn);
                            }
                            else
                            {
                                MatchFalse();
                            }
                        }
                        //Testing for difference of 1 b/w seq values of Card #2 and Card #3
                        else if (CV2[0] == (CV3[0] - 1) || CV2[0] == (CV3[0] + 1))
                        {
                            //Testing for difference of 1 b/w seq values of Card #1 and Card #2
                            if (CV1[0] == (CV2[0] - 1) || CV1[0] == (CV2[0] + 1) || CV1[0] == (CV3[0] - 1) || CV1[0] == (CV3[0] + 1))
                            {
                                MatchTrue(turn);
                            }
                            //Testing for matches with Ace used as a 1 in Card #1  
                            else if (CV1[0] == 14 && CV2[0] == 2 && CV3[0] == 3 || CV1[0] == 14 && CV3[0] == 2 && CV2[0] == 3)
                            {
                                MatchTrue(turn);
                            }
                            else
                            {
                                MatchFalse();
                            }
                        }
                        //Testing for difference of 1 b/w seq values of Card #1 and Card #3
                        else if (CV1[0] == (CV3[0] - 1) || CV1[0] == (CV3[0] + 1))
                        {
                            //Testing for difference of 1 b/w seq values of Card #2 and Card #3
                            if (CV3[0] == (CV2[0] - 1) || CV3[0] == (CV2[0] + 1) || CV1[0] == (CV2[0] - 1) || CV1[0] == (CV2[0] + 1))
                            {
                                MatchTrue(turn);
                            }
                            //Testing for matches with Ace used as a 1 in Card #2  
                            else if (CV2[0] == 14 && CV1[0] == 2 && CV3[0] == 3 || CV2[0] == 14 && CV3[0] == 2 && CV1[0] == 3)
                            {
                                MatchTrue(turn);
                            }
                            else
                            {
                                MatchFalse();
                            }
                        }
                    }
                    //Testing for Joker_Black
                    else if (CV1[1] == 5 && CV2[1] == CV3[1])// Card#1 is Joker_Black
                    {
                        if (CV2[1] == 1 || CV2[1] == 3)
                        {
                            if (CV2[0] == (CV3[0] + 1) || CV2[0] == (CV3[0] - 1) || CV2[0] == (CV3[0] + 2) || CV2[0] == (CV3[0] - 2))//Card #2 and #3 are Clubs in seq order
                            {
                                MatchTrue(turn);
                            }
                            else if (CV2[0] == 14)//Ace used as 1 in Card #2
                            {
                                if (CV3[0] == 2 || CV3[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else if (CV3[0] == 14)//Ace used as 1 in Card #3
                            {
                                if (CV2[0] == 2 || CV2[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else
                            {
                                MatchFalse();
                            }
                        }
                        else
                        {
                            MatchFalse();
                        }
                    }
                    else if (CV3[1] == 5 && CV2[1] == CV1[1])//Card #3 is Joker_Black
                    {
                        if (CV2[1] == 1 || CV2[1] == 3)
                        {
                            if (CV2[0] == (CV1[0] + 1) || CV2[0] == (CV1[0] - 1) || CV2[0] == (CV1[0] + 2) || CV2[0] == (CV1[0] - 2))//Card #2 and #3 are Clubs in seq order
                            {
                                MatchTrue(turn);
                            }
                            else if (CV2[0] == 14)//Ace used as 1 in Card #2
                            {
                                if (CV1[0] == 2 || CV1[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else if (CV1[0] == 14)//Ace used as 1 in Card #1
                            {
                                if (CV2[0] == 2 || CV2[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else
                            {
                                MatchFalse();
                            }
                        }
                        else
                        {
                            MatchFalse();
                        }
                    }
                    else if (CV2[1] == 5 && CV1[1] == CV3[1])//Card#2 is Joker_Black
                    {
                        if (CV1[1] == 1 || CV1[1] == 3)
                        {
                            if (CV1[0] == (CV3[0] + 1) || CV1[0] == (CV3[0] - 1) || CV1[0] == (CV3[0] + 2) || CV1[0] == (CV3[0] - 2))//Card #2 and #3 are Clubs in seq order
                            {
                                MatchTrue(turn);
                            }
                            else if (CV1[0] == 14)//Ace used as 1 in Card #1
                            {
                                if (CV3[0] == 2 || CV3[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else if (CV3[0] == 14)//Ace used as 1 in Card #3
                            {
                                if (CV1[0] == 2 || CV1[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else
                            {
                                MatchFalse();
                            }
                        }
                        else
                        {
                            MatchFalse();
                        }
                    }
                    //Testing for Joker_Red
                    else if (CV1[1] == 6 && CV2[1] == CV3[1])// Card#1 is Joker_Red
                    {
                        if (CV2[1] == 2 || CV2[1] == 4)
                        {
                            if (CV2[0] == (CV3[0] + 1) || CV2[0] == (CV3[0] - 1) || CV2[0] == (CV3[0] + 2) || CV2[0] == (CV3[0] - 2))//Card #2 and #3 are Clubs in seq order
                            {
                                MatchTrue(turn);
                            }
                            else if (CV2[0] == 14)//Ace used as 1 in Card #2
                            {
                                if (CV3[0] == 2 || CV3[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else if (CV3[0] == 14)//Ace used as 1 in Card #3
                            {
                                if (CV2[0] == 2 || CV2[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else
                            {
                                MatchFalse();
                            }
                        }
                        else
                        {
                            MatchFalse();
                        }
                    }
                    else if (CV3[1] == 6 && CV1[1] == CV2[1])//Card #3 is Joker_Red
                    {
                        if (CV2[1] == 2 || CV2[1] == 4)
                        {
                            if (CV2[0] == (CV1[0] + 1) || CV2[0] == (CV1[0] - 1) || CV2[0] == (CV1[0] + 2) || CV2[0] == (CV1[0] - 2))//Card #2 and #3 are Clubs in seq order
                            {
                                MatchTrue(turn);
                            }
                            else if (CV2[0] == 14)//Ace used as 1 in Card #2
                            {
                                if (CV1[0] == 2 || CV1[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else if (CV1[0] == 14)//Ace used as 1 in Card #1
                            {
                                if (CV2[0] == 2 || CV2[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else
                            {
                                MatchFalse();
                            }
                        }
                        else
                        {
                            MatchFalse();
                        }
                    }
                    else if (CV2[1] == 6 && CV1[1] == CV3[1])//Card#2 is Joker_Red
                    {
                        if (CV2[1] == 2 || CV2[1] == 4)
                        {
                            if (CV1[0] == (CV3[0] + 1) || CV1[0] == (CV3[0] - 1) || CV1[0] == (CV3[0] + 2) || CV1[0] == (CV3[0] - 2))//Card #2 and #3 are Clubs in seq order
                            {
                                MatchTrue(turn);
                            }
                            else if (CV1[0] == 14)//Ace used as 1 in Card #1
                            {
                                if (CV3[0] == 2 || CV3[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else if (CV3[0] == 14)//Ace used as 1 in Card #3
                            {
                                if (CV1[0] == 2 || CV1[0] == 3)
                                {
                                    MatchTrue(turn);
                                }
                                else
                                {
                                    MatchFalse();
                                }
                            }
                            else
                            {
                                MatchFalse();
                            }
                        }
                        else
                        {
                            MatchFalse();
                        }
                    }
                    else
                    {
                        MatchFalse();
                    }
                }
            }
            catch
            {
                MessageBox.Show("OOf");
            }

        }
        private void btn_Draw_Click(object sender, EventArgs e)
        {
            try
            {
                if (draw < 2)
                {
                    Draw(turn);
                }
                else
                    MessageBox.Show("You may only draw up to two cards per turn");
            }
            catch
            {
                MessageBox.Show("Hmm, it crashed");
            }
        }
        //
        //Checkbox link methods
        //
        private void pic_Card1_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_Card1.Checked == true)
                    chk_Card1.Checked = false;
                else
                    chk_Card1.Checked = true;
            }
            catch
            {
                MessageBox.Show("This part shouldn't be able to crash, but somehow it did");
            }
        }

        private void pic_Card2_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_Card2.Checked == true)
                    chk_Card2.Checked = false;
                else
                    chk_Card2.Checked = true;
            }
            catch
            {
                MessageBox.Show("This part shouldn't be able to crash, but somehow it did");
            }
        }

        private void pic_Card3_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_Card3.Checked == true)
                    chk_Card3.Checked = false;
                else
                    chk_Card3.Checked = true;
            }
            catch
            {
                MessageBox.Show("This part shouldn't be able to crash, but somehow it did");
            }
        }

        private void pic_Card4_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_Card4.Checked == true)
                    chk_Card4.Checked = false;
                else
                    chk_Card4.Checked = true;
            }
            catch
            {
                MessageBox.Show("This part shouldn't be able to crash, but somehow it did");
            }
        }

        private void pic_Card5_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_Card5.Checked == true)
                    chk_Card5.Checked = false;
                else
                    chk_Card5.Checked = true;
            }
            catch
            {
                MessageBox.Show("This part shouldn't be able to crash, but somehow it did");
            }
        }

        private void pic_Card6_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_Card6.Checked == true)
                    chk_Card6.Checked = false;
                else
                    chk_Card6.Checked = true;
            }
            catch
            {
                MessageBox.Show("This part shouldn't be able to crash, but somehow it did");
            }
        }

        private void pic_Card7_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_Card7.Checked == true)
                    chk_Card7.Checked = false;
                else
                    chk_Card7.Checked = true;
            }
            catch
            {
                MessageBox.Show("This part shouldn't be able to crash, but somehow it did");
            }
        }

    }
}
