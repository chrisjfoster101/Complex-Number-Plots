using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Forms_Implicits
{
    public partial class QuestionPicker : Form
    {
        Revision main;
        public QuestionPicker(Revision mainForm)
        {
            InitializeComponent();
            main = mainForm;
        }

        private void QuestionPicker_Load(object sender, EventArgs e)
        {
            main.questions = new GenerateQuestion[10];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!LineBox.Checked & !CircleBox.Checked & !HalfLineBox.Checked)
            {
                label4.Visible = true;
                return;
            }
            else
            {
                int boxesChecked = (LineBox.Checked ? 1 : 0) + (CircleBox.Checked ? 1 : 0) + (HalfLineBox.Checked ? 1 : 0);
                int currentIndex = 0;
                if (CircleBox.Checked)
                {
                    for (int i = 0; i < 6/boxesChecked; i++)
                    {
                        main.questions[currentIndex] = new GenerateQuestion("Circle",InequalityBox.Checked);
                        currentIndex++;
                    }
                }
                if (HalfLineBox.Checked)
                {
                    for (int i = 0; i < 6 / boxesChecked; i++)
                    {
                        main.questions[currentIndex] = new GenerateQuestion("Half-line", InequalityBox.Checked);
                        currentIndex++;
                    }
                }
                if (LineBox.Checked)
                {
                    for (int i = 0; i < 6 / boxesChecked; i++)
                    {
                        main.questions[currentIndex] = new GenerateQuestion("Line", InequalityBox.Checked);
                        currentIndex++;
                    }
                }
                Random rnd = new Random();
                for (int i = currentIndex; i < 10; i++)
                {
                    main.questions[i] = new GenerateQuestion(new string[] { "Circle", "Half-line", "Line" }[rnd.Next(0, 3)], new bool[] { true, false }[rnd.Next(0, 2)]);
                }
            }
            Close();
        }

        private void RecommendButton_Click(object sender, EventArgs e)
        {
            CircleBox.Checked = false;
            HalfLineBox.Checked = false;
            LineBox.Checked = false;
            DateTime twoWeeksAgo = DateTime.Today.AddDays(-14);
            string dateInput = $"{twoWeeksAgo.Day}/{twoWeeksAgo.Month}/{twoWeeksAgo.Year}";
            SQLiteConnection sqliteConn = new SQLiteConnection("Data Source = RevisionData.db; Version = 3; New = True; Compress = True;");
            sqliteConn.Open();

            SQLiteCommand sqlcmd = sqliteConn.CreateCommand();
            sqlcmd.CommandText = $"SELECT CircleScore,HalflineScore,LineScore,CircleTotal,HalflineTotal,LineTotal " +
                $"FROM Results " +
                $"WHERE Name = '{main.getUsername()}' AND Date > '{twoWeeksAgo}'";
            SQLiteDataReader sqldr = sqlcmd.ExecuteReader();
            int[] Correct = { 0, 0, 0 };
            int[] Total = { 0, 0, 0 };
            bool[] pick = { false, false, false };
            try
            {
                sqldr.Read();
                for (int i = 0; i < 3; i++)
                {
                    Correct[i] += sqldr.GetInt32(i);
                    Total[i] += sqldr.GetInt32(i+3);
                }
            }
            catch
            {
                CircleBox.Checked = true;
                HalfLineBox.Checked = true;
                LineBox.Checked = true;
                sqliteConn.Close();
                return;
            }

            while (sqldr.Read())
            {
                for (int i = 0; i < 3; i++)
                {
                    Correct[i] += sqldr.GetInt32(i);
                    Total[i] += sqldr.GetInt32(i + 3);
                }
            }
            bool close = false;
            for (int i = 0; i < 3; i++)
            {
                if (Total[i] < 10)
                {
                    close = true;
                    if (i == 0) CircleBox.Checked = true;
                    else if (i == 1) HalfLineBox.Checked = true;
                    else LineBox.Checked = true;
                }
            }
            if (close)
            {
                sqliteConn.Close();
                return;
            }

            sqlcmd.CommandText = $"SELECT CircleScore,HalflineScore,LineScore,CircleTotal,HalflineTotal,LineTotal " +
                $"FROM Results " +
                $"WHERE Name = '{main.getUsername()}'";
            sqldr = sqlcmd.ExecuteReader();
            Correct = new int[] { 0, 0, 0 };
            Total = new int[] { 0, 0, 0 };
            while (sqldr.Read())
            {
                for (int i = 0; i < 3; i++)
                {
                    Correct[i] += sqldr.GetInt32(i);
                    Total[i] += sqldr.GetInt32(i + 3);
                }
            }

            List<double> proportionCorrect = new List<double>();
            for (int i = 0; i < 3; i++)
            {
                proportionCorrect.Add((double)Correct[i] / Total[i]);
            }

            if (proportionCorrect[0] == proportionCorrect[1] & proportionCorrect[0] == proportionCorrect[2])
            {
                CircleBox.Checked = true;
                HalfLineBox.Checked = true;
                LineBox.Checked = true;
            }
            else
            {
                double max = 0;
                int indexOfMax = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (proportionCorrect[i] > max)
                    {
                        max = proportionCorrect[i];
                        indexOfMax = i;
                    }
                }
                if (indexOfMax != 0) CircleBox.Checked = true;
                if (indexOfMax != 1) HalfLineBox.Checked = true;
                if (indexOfMax != 2) LineBox.Checked = true;
            }
            sqliteConn.Close();
        }
    }
}
