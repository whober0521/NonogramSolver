using System.Windows.Forms;
using System.Drawing;
using System;

namespace NonogramSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Problem problem = new Problem("Rocket");
            Board b = new Board(problem.ColumnHint.Length, problem.RowHint.Length);

            b.Location = new Point(120, 120);

            this.Controls.Add(b);

            for (int x = 0; x < problem.ColumnHint.Length; x++)
            {
                Label l = new Label();

                l.Text = string.Join("\r\n", problem.ColumnHint[x]);
                l.Size = new Size(Board.GridSize, 100);
                l.Font = new Font("Times New Roman", 10);
                l.TextAlign = ContentAlignment.BottomCenter;
                l.Location = new Point(b.Location.X + x * Board.GridSize, b.Location.Y - 100);

                this.Controls.Add(l);
            }

            for (int y = 0; y < problem.RowHint.Length; y++)
            {
                Label l = new Label();

                l.Text = string.Join(" ", problem.RowHint[y]);
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