using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace NonogramSolver
{
    public partial class Form1 : Form
    {
        List<int>[] columnHint =
        {
            new List<int>() { 5, 19 }, new List<int>() { 4, 4, 6 }, new List<int>() { 5, 4, 5, 7 },new List<int>() { 10, 4, 8 },new List<int>() { 9, 5, 9 },
            new List<int>() { 4, 4 }, new List<int>() { 2, 2, 9, 1, 3 }, new List<int>() { 1, 4, 9, 6 },new List<int>() { 5, 4, 2 },new List<int>() { 5, 4, 6, 3, 1 },
            new List<int>() { 5, 4, 6, 6 }, new List<int>() { 5, 4, 3 }, new List<int>() { 1, 4, 4, 1, 6, 6 },new List<int>() { 2, 2, 9, 1, 3 },new List<int>() { 4, 4},
            new List<int>() { 9, 5, 7 }, new List<int>() { 2, 7, 4, 8 }, new List<int>() { 1, 6, 5, 7 },new List<int>() { 2, 8, 6 },new List<int>() { 25 }
        };

        List<int>[] rowHint =
        {
            new List<int>() { 8, 8 }, new List<int>() { 1, 4, 4, 2 }, new List<int>() { 6, 6, 2, 1 },new List<int>() { 6, 6, 3, 2 },new List<int>() { 1, 3, 8, 5 },
            new List<int>() { 2, 8, 5 }, new List<int>() { 1, 3, 5 }, new List<int>() { 5, 8, 5 },new List<int>() { 5, 6, 1, 5 },new List<int>() { 4, 6, 1, 4 },
            new List<int>() { 2, 1, 8, 1, 2 }, new List<int>() { 1, 2, 2, 2, 2, 1 }, new List<int>() { 1, 3, 2, 2, 2, 3, 1 },new List<int>() {1, 3, 2, 2, 2, 3, 1  },new List<int>() {1, 3, 2, 2, 2, 3, 1 },
            new List<int>() { 1, 1, 2, 2, 2, 1, 1  }, new List<int>() { 1, 1, 2, 2, 2, 1, 1  }, new List<int>() { 1, 5, 2, 5, 1 },new List<int>() { 1, 4, 2, 2, 4, 1 },new List<int>() { 6, 6, 6},
            new List<int>() { 6, 1, 4, 6 }, new List<int>() { 5, 1, 2, 1, 5 }, new List<int>() { 5, 2, 1, 2, 5},new List<int>() { 5, 1, 1, 1, 4},new List<int>() { 5, 1, 2, 1, 4 }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Board b = new Board(columnHint.Length, rowHint.Length);

            b.Location = new Point(120, 120);

            this.Controls.Add(b);

            for (int x = 0; x < columnHint.Length; x++)
            {
                Label l = new Label();

                l.Text = string.Join("\r\n", columnHint[x]);
                l.Size = new Size(Board.GridSize, 100);
                l.Font = new Font("Times New Roman", 10);
                l.TextAlign = ContentAlignment.BottomCenter;
                l.Location = new Point(b.Location.X + x * Board.GridSize, b.Location.Y - 100);

                this.Controls.Add(l);
            }

            for (int y = 0; y < rowHint.Length; y++)
            {
                Label l = new Label();

                l.Text = string.Join(" ", rowHint[y]);
                l.Size = new Size(100, Board.GridSize);
                l.Font = new Font("Times New Roman", 10);
                l.TextAlign = ContentAlignment.MiddleRight;
                l.Location = new Point(b.Location.X - 100, b.Location.Y + y * Board.GridSize);

                this.Controls.Add(l);
            }
        }
    }

    public class Board : Panel
    {
        public const int GridSize = 24;

        private Button[,] Grids { get; set; }

        public Board(int width, int height)
        {
            this.Size = new Size(width * GridSize, height * GridSize);
            this.Grids = new Button[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    this[x, y] = new Button();
                    this[x, y].Enabled = false;
                    this[x, y].BackColor = Color.White;
                    this[x, y].Size = new Size(GridSize, GridSize);
                    this[x, y].Location = new Point(x * GridSize, y * GridSize);

                    this.Controls.Add(this[x, y]);
                }
        }

        public Button this[int x, int y]
        {
            get
            {
                return this.Grids[x, y];
            }
            set
            {
                this.Grids[x, y] = value;
            }
        }
    }
}