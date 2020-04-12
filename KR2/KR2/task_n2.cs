using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace KR2
{
    class task_n2
    {
        public int[] M1;
        string str = "";
        RichTextBox rtb;
        public task_n2(RichTextBox rtb)
        {
            this.rtb = rtb;
        }

        int[] Cnum;
        string str1 = "";
        public void MCH() //Метод ДП
        {
            

            for (int i = 0; i < M1.Length; i++)
            {
                str += $"{M1[i]} ";
            }

            rtb.Text += "исходный массив: "+ str;
            str = "\n";
            int res = CIK(1, M1.Length, 0);
            str += $"\nМинимальная цена: {res}";
            rtb.Text += str;


            str = "\n";
            for (int i = 0; i < Cnum.Length; i++)
            {
                str += $"{Cnum[i]} ";
            }
            str += $"\n(C{Cnum[0]}{Cnum[1]})+(C{Cnum[2]}{Cnum[3]})";
            rtb.Text += str;
            str += $"\n(C{CIK_2(Cnum[0], Cnum[1])}+({CIK_2(Cnum[2], Cnum[3])})";
            rtb.Text += str;
            rtb.Text += "\n-----"+ str1;
        }
        public int CIK(int v1, int v2, int ik) //Метод ДП
        {
            string tabul = "";
            for (int i = 0; i < ik; i++)
            {
                tabul += "\t";
            }
            int temp;
            int cotemp;
            if (v1 == v2) return 0;
            if (Math.Abs(v1 - v2) == 1) return M1[v1 - 1] + M1[v2 - 1];
            int[] S = new int[Math.Abs(v1 - v2)];
            Cnum = new int[4];
            str += $"{tabul}C({v1},{v2}) = min(";

            for (int i = 0; i < Math.Abs(v1 - v2); i++)
            {
                str += $"C({v1},{v1+i}) + C({v1 + i + 1},{v2}); ";
            }
            str += $") + W({v1},{v2})  // W({v1},{v2}) = {SUMM(v1,v2, M1)}\n";
            for (int i = 0; i < Math.Abs(v1 - v2); i++)
            {
                S[i] = CIK(v1, v1 + i, ik+1);
                str += $"{tabul}C({v1},{v1 + i}) = {S[i]}  \n";                    
                temp = S[i] += CIK(v1 + i + 1, v2, ik+1);
                str += $"{tabul}C({v1+i+1},{v2}) = {temp}  \n";
                str += $"{tabul}:  C({v1},{v1 + i}) +  C({v1 + i + 1},{v2}) = {S[i]}  \n";
            }
            str += $"    ОТКАТ\n";

            cotemp = Array.IndexOf(S, S.Min());
            Cnum[0] = v1;
            Cnum[1] = v1 + cotemp;
            Cnum[2] = v1 + cotemp + 1;
            Cnum[3] = v2;


            /*
            for (int i = 0; i < S.Length; i++)
            {
                str += $"{S[i]} ";
            }
            rtb.Text += "\n";
            rtb.Text += S.Min();
            rtb.Text += "\n";
            rtb.Text += SUMM(v1, v2, M1);
            str += "\n";
            */
            return S.Min() + SUMM(v1,v2, M1);
        }

        public int CIK_2(int v1, int v2) //Метод ДП
        {
            int temp;
            int cotemp;
            
            if (v1 == v2) return 0;
            if (Math.Abs(v1 - v2) == 1) return M1[v1 - 1] + M1[v2 - 1];
            int[] S = new int[Math.Abs(v1 - v2)];
            Cnum = new int[4];
            for (int i = 0; i < Math.Abs(v1 - v2); i++)
            {
                S[i] = CIK_2(v1, v1 + i);
                temp = S[i] += CIK_2(v1 + i + 1, v2);
            }

            cotemp = Array.IndexOf(S, S.Min());
            Cnum[0] = v1;
            Cnum[1] = v1 + cotemp;
            Cnum[2] = v1 + cotemp + 1;
            Cnum[3] = v2;
            str1 += $"\n(C{Cnum[0]}{Cnum[1]})+(C{Cnum[2]}{Cnum[3]})";
            return S.Min() + SUMM(v1, v2, M1);
        }


        public int SUMM(int v1, int v2, int[] MAS)
        {
            int summ = 0;
            for (int i = v1-1; i <= v2-1; i++)
            {
                summ += MAS[i];
            }
            return summ;
        }

    }
}
