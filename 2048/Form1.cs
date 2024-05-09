/*
    2048 by Jakub Namyślak
    v1.0 as of 05/09/2024 (DD/MM/RRRR)
    All rights reserved
    Visit [https://shatterwares.com] and [https://github.com/jakubekgranie] for more programming solutions.
*/

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool able = true, first = true;
        private async void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
            {
                if (able)
                {
                    Label[,] assets = { { label1, label2, label3, label4 }, { label5, label6, label7, label8 }, { label9, label10, label11, label12 }, { label13, label14, label15, label16 } };
                    int[,] colors = { { 247, 194, 103 }, { 246, 186, 84 }, { 245, 179, 66 }, { 220, 161, 59 }, { 196, 143, 52 }, { 171, 125, 46 }, { 147, 107, 39 }, { 122, 89, 33 }, { 98, 71, 26 }, { 73, 53, 19 }, { 143, 206, 0 }, { 128, 185, 0 }, { 114, 164, 0 }, { 100, 144, 0 }, { 85, 123, 0 }, { 71, 103, 0 }, { 57, 82, 0 } };
                    bool[,] merged = new bool[4, 4]; // evade merges like 0 2 2 4 -> A -> 8 0 0 0 (4 4 0 0)
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                            merged[i, j] = false;
                    int points = 0;
                    switch (e.KeyCode)
                    {
                        case Keys.W:

                            for (int col = 0; col < 4; col++)
                                for (int row = 1; row < 4; row++)
                                    for (int row2 = row; row2 > 0; row2--)
                                    {
                                        if (assets[row2 - 1, col].Text == " " && assets[row2, col].Text != " ")
                                        {
                                            (assets[row2, col].Text, assets[row2 - 1, col].Text) = (assets[row2 - 1, col].Text, assets[row2, col].Text);
                                            (tableLayoutPanel1.GetControlFromPosition(col, row2 - 1).BackColor, tableLayoutPanel1.GetControlFromPosition(col, row2).BackColor) = (tableLayoutPanel1.GetControlFromPosition(col, row2).BackColor, tableLayoutPanel1.GetControlFromPosition(col, row2 - 1).BackColor);
                                            (merged[row2, col], merged[row2 - 1, col]) = (merged[row2 - 1, col], merged[row2, col]);
                                        }
                                        else if (assets[row2 - 1, col].Text == assets[row2, col].Text && !merged[row2 - 1, col] && !merged[row2, col] && assets[row2 - 1, col].Text != " ")
                                        {
                                            int sqrValue = Int32.Parse(assets[row2 - 1, col].Text) * 2;
                                            points += sqrValue;
                                            assets[row2 - 1, col].Text = sqrValue.ToString();
                                            merged[row2 - 1, col] = true;
                                            int log = ((int)Math.Log(Int32.Parse(assets[row2 - 1, col].Text), 2) - 1) % 17;
                                            tableLayoutPanel1.GetControlFromPosition(col, row2 - 1).BackColor = Color.FromArgb(255, colors[log, 0], colors[log, 1], colors[log, 2]);
                                            assets[row2, col].Text = " ";
                                            tableLayoutPanel1.GetControlFromPosition(col, row2).BackColor = default;
                                            break;
                                        }
                                    }
                            if (!first) wCount.Text = Int32.Parse(wCount.Text) + 1 + "";
                            else first = false;
                            keyFlavor.Text = "Key: " + e.KeyCode;
                            break;
                        case Keys.A:
                            for (int row = 0; row < 4; row++)
                                for (int col = 1; col < 4; col++)
                                    for (int col2 = col; col2 > 0; col2--)
                                    {
                                        if (assets[row, col2 - 1].Text == " " && assets[row, col2].Text != " ")
                                        {
                                            (assets[row, col2].Text, assets[row, col2 - 1].Text) = (assets[row, col2 - 1].Text, assets[row, col2].Text);
                                            (tableLayoutPanel1.GetControlFromPosition(col2 - 1, row).BackColor, tableLayoutPanel1.GetControlFromPosition(col2, row).BackColor) = (tableLayoutPanel1.GetControlFromPosition(col2, row).BackColor, tableLayoutPanel1.GetControlFromPosition(col2 - 1, row).BackColor);
                                            (merged[row, col2], merged[row, col2 - 1]) = (merged[row, col2 - 1], merged[row, col2]);
                                        }
                                        else if (assets[row, col2 - 1].Text == assets[row, col2].Text && !merged[row, col2 - 1] && !merged[row, col2] && assets[row, col2 - 1].Text != " ")
                                        {
                                            int sqrValue = Int32.Parse(assets[row, col2 - 1].Text) * 2;
                                            points += sqrValue;
                                            assets[row, col2 - 1].Text = sqrValue.ToString();
                                            merged[row, col2 - 1] = true;
                                            int log = ((int)Math.Log(Int32.Parse(assets[row, col2 - 1].Text), 2) - 1) % 17;
                                            tableLayoutPanel1.GetControlFromPosition(col2 - 1, row).BackColor = Color.FromArgb(255, colors[log, 0], colors[log, 1], colors[log, 2]);
                                            assets[row, col2].Text = " ";
                                            tableLayoutPanel1.GetControlFromPosition(col2, row).BackColor = default;
                                            break;
                                        }
                                    }
                            if (!first) aCount.Text = Int32.Parse(aCount.Text) + 1 + "";
                            else first = false;
                            keyFlavor.Text = "Key: " + e.KeyCode;
                            break;
                        case Keys.S:
                            for (int col = 0; col < 4; col++)
                                for (int row = 3; row > 0; row--)
                                    for (int row2 = row; row2 < 4; row2++)
                                    {
                                        if (assets[row2 - 1, col].Text != " " && assets[row2, col].Text == " ")
                                        {
                                            (assets[row2, col].Text, assets[row2 - 1, col].Text) = (assets[row2 - 1, col].Text, assets[row2, col].Text);
                                            (tableLayoutPanel1.GetControlFromPosition(col, row2 - 1).BackColor, tableLayoutPanel1.GetControlFromPosition(col, row2).BackColor) = (tableLayoutPanel1.GetControlFromPosition(col, row2).BackColor, tableLayoutPanel1.GetControlFromPosition(col, row2 - 1).BackColor);
                                            (merged[row2, col], merged[row2 - 1, col]) = (merged[row2 - 1, col], merged[row2, col]);
                                        }
                                        else if (assets[row2 - 1, col].Text == assets[row2, col].Text && !merged[row2 - 1, col] && !merged[row2, col] && assets[row2 - 1, col].Text != " ")
                                        {
                                            int sqrValue = Int32.Parse(assets[row2, col].Text) * 2;
                                            points += sqrValue;
                                            assets[row2, col].Text = sqrValue.ToString();
                                            merged[row2, col] = true;
                                            int log = ((int)Math.Log(Int32.Parse(assets[row2, col].Text), 2) - 1) % 17;
                                            tableLayoutPanel1.GetControlFromPosition(col, row2).BackColor = Color.FromArgb(255, colors[log, 0], colors[log, 1], colors[log, 2]);
                                            assets[row2 - 1, col].Text = " ";
                                            tableLayoutPanel1.GetControlFromPosition(col, row2 - 1).BackColor = default;
                                            break;
                                        }
                                    }
                            if (!first) sCount.Text = Int32.Parse(sCount.Text) + 1 + "";
                            else first = false;
                            keyFlavor.Text = "Key: " + e.KeyCode;
                            break;
                        case Keys.D:
                            for (int row = 0; row < 4; row++)
                                for (int col = 3; col > 0; col--)
                                    for (int col2 = col; col2 < 4; col2++)
                                    {
                                        if (assets[row, col2 - 1].Text != " " && assets[row, col2].Text == " ")
                                        {
                                            (assets[row, col2].Text, assets[row, col2 - 1].Text) = (assets[row, col2 - 1].Text, assets[row, col2].Text);
                                            (tableLayoutPanel1.GetControlFromPosition(col2 - 1, row).BackColor, tableLayoutPanel1.GetControlFromPosition(col2, row).BackColor) = (tableLayoutPanel1.GetControlFromPosition(col2, row).BackColor, tableLayoutPanel1.GetControlFromPosition(col2 - 1, row).BackColor);
                                            (merged[row, col2], merged[row, col2 - 1]) = (merged[row, col2 - 1], merged[row, col2]);
                                        }
                                        else if (assets[row, col2 - 1].Text == assets[row, col2].Text && !merged[row, col2 - 1] && !merged[row, col2] && assets[row, col2].Text != " ")
                                        {
                                            int sqrValue = Int32.Parse(assets[row, col2].Text) * 2;
                                            points += sqrValue;
                                            assets[row, col2].Text = sqrValue.ToString();
                                            merged[row, col2] = true;
                                            int log = ((int)Math.Log(Int32.Parse(assets[row, col2].Text), 2) - 1) % 17;
                                            tableLayoutPanel1.GetControlFromPosition(col2, row).BackColor = Color.FromArgb(255, colors[log, 0], colors[log, 1], colors[log, 2]);
                                            assets[row, col2 - 1].Text = " ";
                                            tableLayoutPanel1.GetControlFromPosition(col2 - 1, row).BackColor = default;
                                            break;
                                        }
                                    }
                            if (!first) dCount.Text = Int32.Parse(dCount.Text) + 1 + "";
                            else first = false;
                            keyFlavor.Text = "Key: " + e.KeyCode;
                            break;
                    }
                    scoreValue.Text = Int32.Parse(scoreValue.Text) + points + "";
                    bool isPossible, hasZeroes;
                    isPossible = hasZeroes = false;
                    if (assets[3, 3].Text == assets[3, 2].Text || assets[3, 3].Text == assets[2, 3].Text) // square (3,3) always excluded from the lookup (!(j = 3, j + 1 < 4))
                        isPossible = true;
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                        {
                            if ((i + 1 < 4 && assets[i, j].Text == assets[i + 1, j].Text) || (j + 1 < 4 && assets[i, j].Text == assets[i, j + 1].Text)) 
                                isPossible = true;
                            if (assets[i, j].Text == " ")
                            {
                                isPossible = hasZeroes = true;
                                break;
                            }
                        }
                    if (!isPossible)
                        able = false;
                    if (hasZeroes)
                    {
                        Random rnd = new Random();
                        int i, j;
                        do
                        {
                            i = rnd.Next(0, 4);
                            j = rnd.Next(0, 4);
                        } while (assets[i, j].Text != " ");
                        int chance = rnd.Next(1, 101);
                        if (chance < 71)
                        {
                            assets[i, j].Text = "2";
                            tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.FromArgb(255, colors[0, 0], colors[0, 1], colors[0, 2]);
                        }
                        else if (chance < 86)
                        {
                            assets[i, j].Text = "4";
                            tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.FromArgb(255, colors[1, 0], colors[1, 1], colors[1, 2]);
                        }
                        else if (chance < 96)
                        {
                            assets[i, j].Text = "8";
                            tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.FromArgb(255, colors[2, 0], colors[2, 1], colors[2, 2]);
                        }
                        else if (chance < 101)
                        {
                            assets[i, j].Text = "16";
                            tableLayoutPanel1.GetControlFromPosition(j, i).BackColor = Color.FromArgb(255, colors[3, 0], colors[3, 1], colors[3, 2]);
                        }
                    }
                }
                else
                {
                    title.Text = "END!";
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    Point p = new Point(40, 38);
                    Control sqr;
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                        {
                            sqr = tableLayoutPanel1.GetControlFromPosition(i, j);
                            sqr.GetChildAtPoint(p).Text = " ";
                            sqr.BackColor = default;
                        }
                    title.Text = "2048";
                    scoreValue.Text = wCount.Text = aCount.Text = sCount.Text = dCount.Text = "0";
                    able = true;
                }
            }
        }
    }
}
