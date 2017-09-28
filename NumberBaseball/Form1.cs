using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NumberBaseball
{
    public partial class Form1 : Form
    {
        private int number = 0;
        private int[] numbersInts = new int[3];
        int[] insertInts = new int[3];
        int strike;
        int ball;
        public Form1()
        {
            InitializeComponent();
            this.RandomGetNumberMethod();
        }

        private void RandomGetNumberMethod()
        {
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                int randomNumber = 0;
                if (i == 0)
                {
                    randomNumber = random.Next(1, 9);
                }
                else
                {
                    randomNumber = random.Next(0, 9);
                }
                numbersInts[i] = randomNumber;

                if (0 < i)
                {
                    var intersection = numbersInts.Where(w => w == randomNumber).ToArray();
                    if (intersection.Length > 0)
                    {
                        i--;
                    }
                }
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (tb_number.Text.Length == 3)
            {
                number = int.Parse(tb_number.Text.ToString());

                insertInts[0] = number / 100;
                insertInts[1] = (number % 100) / 10;
                insertInts[2] = (number % 100) % 10;

                this.CompareMethod();
            }
            else
            {
                MessageBox.Show("3자리 숫자를 입력해 주세요.");
            }
        }

        private void CompareMethod()
        {
            strike = 0;
            ball = 0;
            
            for(int i = 0; i< 3; i++)
            {
                if(insertInts[i] == numbersInts[i])
                {
                    strike++;
                }
                else
                {
                    var ballnumber = numbersInts.Where(w => w == insertInts[i]).ToArray();
                    if(ballnumber.Length != 0)
                    {
                        ball++;
                    }
                }
            }
            listView1.Items.Add(number.ToString());
            listView1.Items.Add(strike.ToString());
            listView1.Items.Add(ball.ToString());
        }
    }
}
