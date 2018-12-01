using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace NonogramSolver
{
    public partial class Form1 : Form
    {
        Problem problem;
        Board board;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            problem = new Problem("Rocket");

            board = new Board(problem.ColumnHint.Length, problem.RowHint.Length);
            board.Location = new Point(120, 120);

            this.Controls.Add(board);

            for (int x = 0; x < problem.ColumnHint.Length; x++)
            {
                Label l = new Label();

                l.Text = string.Join("\r\n", problem.ColumnHint[x]);
                l.Size = new Size(Board.GridSize, 100);
                l.Font = new Font("Times New Roman", 10);
                l.TextAlign = ContentAlignment.BottomCenter;
                l.Location = new Point(board.Location.X + x * Board.GridSize, board.Location.Y - 100);

                this.Controls.Add(l);
            }

            for (int y = 0; y < problem.RowHint.Length; y++)
            {
                Label l = new Label();

                l.Text = string.Join(" ", problem.RowHint[y]);
                l.Size = new Size(100, Board.GridSize);
                l.Font = new Font("Times New Roman", 10);
                l.TextAlign = ContentAlignment.MiddleRight;
                l.Location = new Point(board.Location.X - 100, board.Location.Y + y * Board.GridSize);

                this.Controls.Add(l);
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            this.bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.Solve((BackgroundWorker)sender, e);
        }

        private void Solve(BackgroundWorker worker, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(300);

            while (!problem.IsSolved)
            {
                problem.Solve();

                worker.ReportProgress(0);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            for (int x = 0; x < problem.ColumnHint.Length; x++)
                for (int y = 0; y < problem.RowHint.Length; y++)
                {
                    switch (problem.Blocks[x, y])
                    {
                        case null:
                            break;
                        case true:
                            board[x, y].Text = "";
                            board[x, y].BackColor = Color.Black;
                            break;
                        case false:
                            board[x, y].Text = "X";
                            board[x, y].BackColor = Color.White;
                            break;
                    }
                }

            this.Refresh();
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int x = 0; x < problem.ColumnHint.Length; x++)
                for (int y = 0; y < problem.RowHint.Length; y++)
                {
                    switch (problem.Blocks[x, y])
                    {
                        case null:
                            break;
                        case true:
                            board[x, y].Text = "";
                            board[x, y].BackColor = Color.Black;
                            break;
                        case false:
                            board[x, y].Text = "";
                            board[x, y].BackColor = Color.White;
                            break;
                    }
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