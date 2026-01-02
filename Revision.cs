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
    public partial class Revision : Form
    {
        private bool answerScreen = false;
        private string username = "";
        public GenerateQuestion[] questions;
        private int currentQuestion = 0;
        private Random rnd = new Random();
        private bool drawQuestion;
        private int[] questionsCorrect = {0,0,0};
        private int[] totalQuestions = {0,0,0};
        private List<ComplexNum> workingPoints = new List<ComplexNum>();
        private ComplexNum[] drawingAnswerPoints= new ComplexNum[2];
        private int drawingStage = 0;
        private LociGenerator loci;
        private Bitmap currentGraph;
        private string drawnEquation;
        private string drawnEquationType;
        private string drawnInequality;
        public bool returnToMenu = false;
        private bool showingCorrectDrawingAnswer = false;

        public void setUsername(string name) => username = name;
        public string getUsername() => username;

        public Revision()
        {
            InitializeComponent();
        }

        private void Revision_Load(object sender, EventArgs e)
        {
            Login loginform = new Login(this);
            loginform.ShowDialog();
            if (username == "") Close();
            Text = "Revision - " + username;
            if (username != "")
            {
                QuestionPicker QP = new QuestionPicker(this);
                QP.ShowDialog();
                if (questions[0] == null) Close();
                else
                {
                    setUpQuestion();
                }
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (answerScreen)
            {
                CorrectLabel.Hide();
                CorrectAnswerLabel1.Hide();
                CorrectAnswerLabel2.Hide();
                SwitchAnswerButton.Hide();
                DrawButton.Enabled = true;
                ClearButton.Enabled = true;
                drawnEquation = null;
                if (currentQuestion < 9)
                {
                    answerScreen = false;
                    currentQuestion++;
                    setUpQuestion();
                    NextButton.Text = "Enter";
                }
                else
                {
                    SaveResult();
                    EndScreenForm results = new EndScreenForm(questionsCorrect.Sum(), this);
                    results.ShowDialog();
                    if (returnToMenu)
                    {
                        Close();
                    }
                    else
                    {
                        answerScreen = false;
                        answerScreen = false;
                        currentQuestion = 0;
                        questionsCorrect = new int[] { 0, 0, 0 };
                        totalQuestions = new int[] { 0, 0, 0 };
                        drawnEquation = null;
                        showingCorrectDrawingAnswer = false;
                        NextButton.Text = "Enter";
                        QuestionPicker QP = new QuestionPicker(this);
                        QP.ShowDialog();
                        if (questions[0] == null) Close();
                        else
                        {
                            setUpQuestion();
                        }
                    }
                }
            }
            else
            {
                answerScreen = true;
                DrawButton.Enabled = false;
                ClearButton.Enabled = false;
                InstructionLabel.Hide();
                switch (questions[currentQuestion].type)
                {
                    case "Circle":
                        totalQuestions[0]++;
                        break;
                    case "Half-line":
                        totalQuestions[1]++;
                        break;
                    case "Line":
                        totalQuestions[2]++;
                        break;
                }
                bool correct = mark();
                if (correct)
                {
                    CorrectLabel.Text = "Correct!";
                    switch (questions[currentQuestion].type)
                    {
                        case "Circle":
                            questionsCorrect[0]++;
                            break;
                        case "Half-line":
                            questionsCorrect[1]++;
                            break;
                        case "Line":
                            questionsCorrect[2]++;
                            break;
                    }
                }
                else
                {
                    CorrectLabel.Text = "That's wrong";
                    if (drawQuestion)
                    {
                        SwitchAnswerButton.Show();
                        SwitchAnswerButton.Text = "See correct answer";
                    }
                    else
                    {
                        CorrectAnswerLabel1.Show();
                        CorrectAnswerLabel2.Show();
                        CorrectAnswerLabel2.Text = questions[currentQuestion].ToString();
                    }
                }
                CorrectLabel.Show();
                NextButton.Text = "Next";
            }
        }

        private void setUpQuestion()
        {
            QuestionNumLabel.Text = "Question " + (currentQuestion + 1);
            if (rnd.Next(0,2) == 0)
            {
                AnswerLHS.Show();
                AnswerInequality.Show();
                AnswerRHS.Show();
                AnswerLHS.Text = "";
                AnswerRHS.Text = "";
                AnswerInequality.SelectedIndex = 0;

                ShapeBox.Hide();
                StyleBox.Hide();
                DrawButton.Hide();
                ClearButton.Hide();
                label1.Hide();
                label2.Hide();

                drawQuestion = false;
                QuestionBox.Text = "Find the equation for the complex loci\n" +
                    "Give your answer as simply as possible using mod or arg and the complex variable z\n" +
                    "You should give your answer as a decimal or a fraction of pi where appropriate";
                loci = new LociGenerator(new ComplexNum(0, 0), 20);
                currentGraph = loci.Generate(questions[currentQuestion].equation, questions[currentQuestion].inequality);
                if (questions[currentQuestion].type == "Line")
                {
                    QuestionBox.Text += "\nYou should use the blue point given to you";
                    int x = loci.scaleX(questions[currentQuestion].keyPoint.GetRe())-2;
                    int y = loci.scaleY(questions[currentQuestion].keyPoint.GetIm())-2;
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            currentGraph.SetPixel(x + i, y + j, Color.Blue);
                        }
                    }
                }
                GraphBox.Image = currentGraph;
            }
            else
            {
                AnswerLHS.Hide();
                AnswerInequality.Hide();
                AnswerRHS.Hide();

                ShapeBox.Show();
                StyleBox.Show();
                DrawButton.Show();
                ClearButton.Show();
                ShapeBox.SelectedIndex = 0;
                StyleBox.SelectedIndex = 0;
                label1.Show();
                label2.Show();

                workingPoints = new List<ComplexNum>();
                drawingAnswerPoints = new ComplexNum[2];
                drawQuestion = true;
                loci = new LociGenerator(new ComplexNum(0,0), 20);
                currentGraph = loci.GetGraph();
                GraphBox.Image = currentGraph;
                QuestionBox.Text = $"Plot the loci for this equation:\n{questions[currentQuestion]}\nYou can place points for workings that won't be marked";
            }
        }

        private void plotPoints()
        {
            foreach (ComplexNum c in workingPoints)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        try
                        {
                            currentGraph.SetPixel(i + loci.scaleX(c.GetRe()) - 2, j + loci.scaleY(c.GetIm()) - 2, Color.Blue);
                        }
                        catch { }
                    }
                }
            }
            foreach(ComplexNum c in drawingAnswerPoints)
            {
                if (c != null)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            try
                            {
                                currentGraph.SetPixel(i + loci.scaleX(c.GetRe()) - 2, j + loci.scaleY(c.GetIm()) - 2, Color.Blue);
                            }
                            catch { }
                        }
                    }
                }
            }
        }
        
        private bool mark()
        {
            Dictionary<string, string> swapInequality = new Dictionary<string, string>()
                {
                    {"=","="},{"<",">"},{">","<"},{"≤","≥"},{"≥","≤"}
                };
            if (drawQuestion)
            {
                if (drawnEquation == null)
                {
                    return false;
                }
                if (questions[currentQuestion].type == "Circle" & drawnEquationType == "Circle")
                {
                    string correctRHS = questions[currentQuestion].equation.Substring(questions[currentQuestion].equation.IndexOf(")") + 2);

                    if (ComplexNum.Mod(ComplexNum.Add(questions[currentQuestion].keyPoint,ComplexNum.Mul(new ComplexNum(-1,0), drawingAnswerPoints[0]))) > 0.25) return false;
                    if (Math.Abs(ComplexNum.Mod(ComplexNum.Add(drawingAnswerPoints[0], ComplexNum.Mul(new ComplexNum(-1, 0), drawingAnswerPoints[1]))) - double.Parse(correctRHS)) > 0.25) return false;
                    if (questions[currentQuestion].inequality != drawnInequality) return false;
                }
                else if (questions[currentQuestion].type == "Half-line" & drawnEquationType == "Half-line")
                {
                    double correctRHSNum;
                    string correctRHS = questions[currentQuestion].equation.Substring(questions[currentQuestion].equation.IndexOf(")") + 1);
                    if (correctRHS[0] == '-') correctRHS = correctRHS.Substring(1);
                    else correctRHS = "-" + correctRHS.Substring(1);
                    correctRHS = correctRHS.Replace("*", "").Replace("pi", "");
                    if (correctRHS[0] == '/')
                    {
                        correctRHSNum = Math.PI / double.Parse(correctRHS.Substring(1));
                    }
                    else if (correctRHS.StartsWith("-/"))
                    {
                        correctRHSNum = -Math.PI / double.Parse(correctRHS.Substring(2));
                    }
                    else
                    {
                        correctRHSNum = Math.PI * double.Parse(correctRHS.Split('/')[0]) / double.Parse(correctRHS.Split('/')[1]);
                    }

                    if (ComplexNum.Mod(ComplexNum.Add(questions[currentQuestion].keyPoint, ComplexNum.Mul(new ComplexNum(-1, 0), drawingAnswerPoints[0]))) > 0.25)
                    {
                        return false;
                    }
                    if (Math.Abs(ComplexNum.Arg(ComplexNum.Add(drawingAnswerPoints[1], ComplexNum.Mul(new ComplexNum(-1, 0), drawingAnswerPoints[0]))) - correctRHSNum) > 0.25)
                    {
                        return false;
                    }
                    if (questions[currentQuestion].inequality != drawnInequality)
                    {
                        return false;
                    }
                }
                else if (questions[currentQuestion].type == "Line" & drawnEquationType == "Line")
                {
                    string[] rpn = LociGenerator.ToRPN(questions[currentQuestion].equation);
                    LociGenerator correctLoci = new LociGenerator(new ComplexNum(0, 0), 20);
                    Bitmap correctGraph = correctLoci.Generate(questions[currentQuestion].equation, questions[currentQuestion].inequality);
                    Bitmap guessGraph = correctLoci.Generate(drawnEquation, drawnInequality);
                    if (questions[currentQuestion].inequality == "=" & drawnInequality != "=")
                    {
                        return false;
                    }
                    if (questions[currentQuestion].inequality == "<" | questions[currentQuestion].inequality == ">")
                    {
                        if (drawnInequality != "<" & drawnInequality != ">")
                        {
                            return false;
                        }
                    }
                    if (questions[currentQuestion].inequality == "≤" | questions[currentQuestion].inequality == "≥")
                    {
                        if (drawnInequality != "≤" & drawnInequality != "≥")
                        {
                            return false;
                        }
                    }
                    if (Math.Abs(LociGenerator.EvaluateRPN(rpn, drawingAnswerPoints[0].GetRe(), drawingAnswerPoints[0].GetIm())) > 0.5)
                    {
                        return false;
                    }
                    if (Math.Abs(LociGenerator.EvaluateRPN(rpn, drawingAnswerPoints[1].GetRe(), drawingAnswerPoints[1].GetIm())) > 0.5)
                    {
                        return false;
                    }

                    if (guessGraph.GetPixel(1,1).R != correctGraph.GetPixel(1, 1).R)
                    {
                        return false;
                    }
                    if (guessGraph.GetPixel(1, 510).R != correctGraph.GetPixel(1, 510).R)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (AnswerLHS.Text == null | AnswerRHS.Text == null)
                {
                    return false;
                }
                string correctEquation = questions[currentQuestion].equation.Replace("*", "").Replace("1i","i");
                string correctInequality = questions[currentQuestion].inequality;
                string CorrectLHS = correctEquation.Substring(0, correctEquation.IndexOf(')') + 1);
                string CorrectRHS = correctEquation.Substring(correctEquation.IndexOf(')') + 1);
                if (CorrectRHS[0] == '-') CorrectRHS = CorrectRHS.Substring(1);
                else CorrectRHS = "-" + CorrectRHS.Substring(1);
                if (AnswerLHS.Text.Replace(" ", "") == CorrectLHS)
                {
                    if ((string)AnswerInequality.SelectedItem != correctInequality | AnswerRHS.Text.Replace(" ", "").Replace("*", "").Replace("1i", "i") != CorrectRHS)
                    {
                        return false;
                    }
                }
                else if (AnswerLHS.Text.Replace(" ", "") == CorrectRHS)
                {
                    if ((string)AnswerInequality.SelectedItem != swapInequality[correctInequality] | AnswerRHS.Text.Replace(" ", "").Replace("*", "").Replace("1i", "i") != CorrectLHS)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        
        private void GraphBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawingStage == 0) return;
            double x = (double)e.X * 20 / 512 - 10;
            double y = 10 - (double)e.Y * 20 / 512;
            if ((string)ShapeBox.SelectedItem != "Point")
            {
                loci = new LociGenerator(new ComplexNum(0, 0), 20);
            }
            if (drawingStage == 1)
            {
                if ((string)ShapeBox.SelectedItem == "Point")
                {
                    workingPoints.Add(new ComplexNum(x, y));
                    drawingStage = 0;
                    ShapeBox.Enabled = true;
                    StyleBox.Enabled = true;
                    InstructionLabel.Hide();
                    plotPoints();
                    GraphBox.Image = currentGraph;
                    return;
                }
                else if ((string)ShapeBox.SelectedItem == "Circle")
                {
                    InstructionLabel.Text = "Click a point on the edge of the circle";
                }
                else
                {
                    InstructionLabel.Text = "Click another point on the line";
                }
                drawingStage = 2;
                drawingAnswerPoints[0] = new ComplexNum(x, y);
                plotPoints();
                GraphBox.Image = currentGraph;
            }
            else if (drawingStage == 2)
            {
                bool anotherStep = (string)StyleBox.SelectedItem != "Line";
                drawingAnswerPoints[1] = new ComplexNum(x, y);
                ComplexNum O = drawingAnswerPoints[0];
                string insert = O.GetRe() < 0 ? "+" + -O.GetRe() : ("-" + O.GetRe());
                insert += (O.GetIm() < 0 ? "+" + -O.GetIm() : ("-" + O.GetIm())) + "i";
                if ((string)ShapeBox.SelectedItem == "Circle")
                {
                    drawnEquation = $"mod(z{insert})-{ComplexNum.Mod(ComplexNum.Add(drawingAnswerPoints[1], ComplexNum.Mul(new ComplexNum(-1, 0), drawingAnswerPoints[0])))}";
                }
                else if ((string)ShapeBox.SelectedItem == "Half-line")
                {
                    drawnEquation = $"arg(z{insert})-{ComplexNum.Arg(ComplexNum.Add(drawingAnswerPoints[1], ComplexNum.Mul(new ComplexNum(-1, 0), drawingAnswerPoints[0])))}";
                }
                else if ((string)ShapeBox.SelectedItem == "Line")
                {
                    ComplexNum midpoint = ComplexNum.Mul(ComplexNum.Add(O, drawingAnswerPoints[1]),new ComplexNum(0.5,0));
                    ComplexNum dif = ComplexNum.Add(drawingAnswerPoints[1], ComplexNum.Mul(new ComplexNum(-1, 0), drawingAnswerPoints[0]));
                    double tempIm = dif.GetRe() * -1;
                    dif.SetRe(dif.GetIm());
                    dif.SetIm(tempIm);
                    ComplexNum C1 = ComplexNum.Add(midpoint, dif);
                    ComplexNum C2 = ComplexNum.Add(midpoint,ComplexNum.Mul(dif,new ComplexNum(-1,0)));
                    insert = C1.GetRe() < 0 ? "+" + -C1.GetRe() : ("-" + C1.GetRe());
                    insert += (C1.GetIm() < 0 ? "+" + -C1.GetIm() : ("-" + C1.GetIm())) + "i";
                    string insert2 = C2.GetRe() < 0 ? "+" + -C2.GetRe() : ("-" + C2.GetRe());
                    insert2 += (C2.GetIm() < 0 ? "+" + -C2.GetIm() : ("-" + C2.GetIm())) + "i";
                    drawnEquation = $"mod(z{insert})-mod(z{insert2})";
                }
                loci.Generate(drawnEquation, "=");
                currentGraph = loci.GetGraph();
                plotPoints();
                GraphBox.Image = currentGraph;

                if (anotherStep)
                {
                    drawingStage = 3;
                    InstructionLabel.Text = "Click a point in the desired region";
                }
                else
                {
                    drawnInequality = "=";
                    drawingStage = 0;
                    ShapeBox.Enabled = true;
                    StyleBox.Enabled = true;
                    InstructionLabel.Hide();
                }
            }
            else if (drawingStage == 3)
            {
                if ((string)StyleBox.SelectedItem == "Line with fill")
                {
                    if (LociGenerator.EvaluateRPN(LociGenerator.ToRPN(drawnEquation),x,y) < 0)
                    {
                        drawnInequality = "≤";
                    }
                    else
                    {
                        drawnInequality = "≥";
                    }
                }
                else
                {
                    if (LociGenerator.EvaluateRPN(LociGenerator.ToRPN(drawnEquation), x, y) < 0)
                    {
                        drawnInequality = "<";
                    }
                    else
                    {
                        drawnInequality = ">";
                    }
                }
                drawingStage = 0;
                ShapeBox.Enabled = true;
                StyleBox.Enabled = true;
                loci.Generate(drawnEquation, drawnInequality);
                currentGraph = loci.GetGraph();
                plotPoints();
                GraphBox.Image = currentGraph;
                InstructionLabel.Hide();
            }
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            if (drawingStage == 0)
            {
                ShapeBox.Enabled = false;
                StyleBox.Enabled = false;
                drawingStage = 1;
                InstructionLabel.Show();
                drawnEquationType = (string)ShapeBox.SelectedItem;
                if (drawnEquationType == "Circle")
                {
                    InstructionLabel.Text = "Click the centre of the circle";
                }
                else if (drawnEquationType == "Half-line")
                {
                    InstructionLabel.Text = "Click the start of the half-line";
                }
                else if (drawnEquationType == "Line")
                {
                    InstructionLabel.Text = "Click any point on the line";
                }
                else if (drawnEquationType == "Point")
                {
                    InstructionLabel.Text = "Click the point";
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            loci = new LociGenerator(new ComplexNum(0, 0), 20);
            currentGraph = loci.GetGraph();
            GraphBox.Image = currentGraph;
            drawingAnswerPoints = new ComplexNum[2];
            workingPoints = new List<ComplexNum>();
            InstructionLabel.Hide();
            ShapeBox.Enabled = true;
            StyleBox.Enabled = true;
            drawingStage = 0;
            drawnEquation = "";
        }

        private void SwitchAnswerButton_Click(object sender, EventArgs e)
        {
            if (!showingCorrectDrawingAnswer)
            {
                SwitchAnswerButton.Text = "See your answer";
                showingCorrectDrawingAnswer = true;
                LociGenerator correctLoci = new LociGenerator(new ComplexNum(0,0), 20);
                GraphBox.Image = correctLoci.Generate(questions[currentQuestion].equation, questions[currentQuestion].inequality);
            }
            else
            {
                SwitchAnswerButton.Text = "See correct answer";
                showingCorrectDrawingAnswer = false;
                GraphBox.Image = loci.GetGraph();
            }
        }



        private void SaveResult()
        {
            DateTime today = DateTime.Today;
            string dateInput = $"{today.Day}/{today.Month}/{today.Year}";
            SQLiteConnection sqliteConn = new SQLiteConnection("Data Source = RevisionData.db; Version = 3; New = True; Compress = True;");
            sqliteConn.Open();

            SQLiteCommand sqlcmd = sqliteConn.CreateCommand();
            sqlcmd.CommandText = $"INSERT INTO Results VALUES ('{username}','{questionsCorrect[0]}','{questionsCorrect[1]}','{questionsCorrect[2]}','{totalQuestions[0]}','{totalQuestions[1]}','{totalQuestions[2]}','{dateInput}')";
            sqlcmd.ExecuteNonQuery();
            sqliteConn.Close();
        }
    }
}