using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
namespace TasOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        class Cell
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; } = 50;
            public int Height { get; set; } = 50;
            public int Id { get; set; }
            public int Distance { get; set; }
            public List<uint> PathIds { get; set; }
        }
        private static List<Cell> cells = new List<Cell>();
        Graph<Cell, string> graph = new Graph<Cell, string>();
        Cell[] stonesCells = new Cell[7];
        Cell mainStone = new Cell();
        Button[] stonesButton = new Button[7];
        void PanelFill()
        {
            graphics = panel1.CreateGraphics();
            int cellH = 50;
            int cellW = 50;
            int cellX = 0;
            int cellY = 0;
            bool color = true;
            int id = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    color = !color;
                    graphics.FillRectangle(new SolidBrush(color ? Color.Black : Color.White), new Rectangle(cellX, cellY, cellW, cellH));
                    cellX += 50;
                }

                cellY += 50;
                cellX = 0;
                color = !color;
            }
        }
        void CreateConnect()
        {

            cells.Clear();
            int cellX = 0;
            int cellY = 0;
            int id = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    id += 1;
                    var cell = new Cell()
                    {
                        X = cellX,
                        Y = cellY,
                        Id = id
                    };
                    graph.AddNode(cell);
                    cells.Add(cell);
                    cellX += 50;
                }

                cellY += 50;
                cellX = 0;
            }
            for (int i = 1; i < 10; i++)
            {
                graph.Connect((uint)i, (uint)i + 1, 1, "");
                graph.Connect((uint)i + 10, (uint)i + 11, 1, "");
                graph.Connect((uint)i + 20, (uint)i + 21, 1, "");
                graph.Connect((uint)i + 30, (uint)i + 31, 1, "");
                graph.Connect((uint)i + 40, (uint)i + 41, 1, "");
                graph.Connect((uint)i + 50, (uint)i + 51, 1, "");
                graph.Connect((uint)i + 60, (uint)i + 61, 1, "");
                graph.Connect((uint)i + 70, (uint)i + 71, 1, "");
                graph.Connect((uint)i + 80, (uint)i + 81, 1, "");
                graph.Connect((uint)i + 90, (uint)i + 91, 1, "");

                graph.Connect((uint)(i + 1), (uint)i, 1, "");
                graph.Connect((uint)i + 11, (uint)i + 10, 1, "");
                graph.Connect((uint)i + 21, (uint)i + 20, 1, "");
                graph.Connect((uint)i + 31, (uint)i + 30, 1, "");
                graph.Connect((uint)i + 41, (uint)i + 40, 1, "");
                graph.Connect((uint)i + 51, (uint)i + 50, 1, "");
                graph.Connect((uint)i + 61, (uint)i + 60, 1, "");
                graph.Connect((uint)i + 71, (uint)i + 70, 1, "");
                graph.Connect((uint)i + 81, (uint)i + 80, 1, "");
                graph.Connect((uint)i + 91, (uint)i + 90, 1, "");


            }
            for (int i = 0; i < 9; i++)
            {
                graph.Connect((uint)i * 10 + 1, (uint)i * 10 + 11, 1, "");
                graph.Connect((uint)i * 10 + 2, (uint)i * 10 + 12, 1, "");
                graph.Connect((uint)i * 10 + 3, (uint)i * 10 + 13, 1, "");
                graph.Connect((uint)i * 10 + 4, (uint)i * 10 + 14, 1, "");
                graph.Connect((uint)i * 10 + 5, (uint)i * 10 + 15, 1, "");
                graph.Connect((uint)i * 10 + 6, (uint)i * 10 + 16, 1, "");
                graph.Connect((uint)i * 10 + 7, (uint)i * 10 + 17, 1, "");
                graph.Connect((uint)i * 10 + 8, (uint)i * 10 + 18, 1, "");
                graph.Connect((uint)i * 10 + 9, (uint)i * 10 + 19, 1, "");
                graph.Connect((uint)i * 10 + 10, (uint)i * 10 + 20, 1, "");

                graph.Connect((uint)i * 10 + 11, (uint)i * 10 + 1, 1, "");
                graph.Connect((uint)i * 10 + 12, (uint)i * 10 + 2, 1, "");
                graph.Connect((uint)i * 10 + 13, (uint)i * 10 + 3, 1, "");
                graph.Connect((uint)i * 10 + 14, (uint)i * 10 + 4, 1, "");
                graph.Connect((uint)i * 10 + 15, (uint)i * 10 + 5, 1, "");
                graph.Connect((uint)i * 10 + 16, (uint)i * 10 + 6, 1, "");
                graph.Connect((uint)i * 10 + 17, (uint)i * 10 + 7, 1, "");
                graph.Connect((uint)i * 10 + 18, (uint)i * 10 + 8, 1, "");
                graph.Connect((uint)i * 10 + 19, (uint)i * 10 + 9, 1, "");
                graph.Connect((uint)i * 10 + 20, (uint)i * 10 + 10, 1, "");
            }

            button2.Enabled = true;
            button_1.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void stoneButton_Click(object sender, EventArgs e)
        {
            Button currentButton = ((Button)sender);
            Point location = currentButton.Location;
            if (location.X == mainStone.X && location.Y == mainStone.Y)
            {
                currentButton.BackColor = Color.Bisque;

                currentButton.Location = new Point(mainStone.X, mainStone.Y);
                return;
            }
            var currentCell = cells.FirstOrDefault(cell => cell.X == location.X && cell.Y == location.Y);
            var firstcell = currentCell.PathIds.First();
            var nextLocation = cells.FirstOrDefault(cell =>
                cell.Id == (int)firstcell);
            currentButton.Text = nextLocation.Distance.ToString();
            if (nextLocation.X == mainStone.X && nextLocation.Y == mainStone.Y)
            {
                currentButton.BackColor = Color.Bisque;
                currentButton.Location = new Point(mainStone.X, mainStone.Y);
                PanelFill();
                return;
            }
            currentButton.Location = new Point(nextLocation.X, nextLocation.Y);
            PanelFill();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private int idCounter=0;
        private int cellCounter=0;
        private uint[] ids;
        private Button currentButton;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (idCounter == ids.Length)
            {
                timer1.Stop();
                timer2.Start();
                return;
            }
            Point location = currentButton.Location;
            if (location.X == mainStone.X && location.Y == mainStone.Y)
            {
                currentButton.BackColor = Color.LawnGreen;

                currentButton.Location = new Point(mainStone.X, mainStone.Y);
                timer1.Stop();
                timer2.Start();
                return;
            }
            var firstcell = ids[idCounter];
            var nextLocation = cells.FirstOrDefault(cell =>
                cell.Id == (int)firstcell);
            currentButton.Text = nextLocation.Distance.ToString();
            if (nextLocation.X == mainStone.X && nextLocation.Y == mainStone.Y)
            {
                currentButton.BackColor = Color.Bisque;
                currentButton.Location = new Point(mainStone.X, mainStone.Y);
                PanelFill();
                timer1.Stop();
                timer2.Start();
                return;
            }
            currentButton.Location = new Point(nextLocation.X, nextLocation.Y);
            PanelFill();
            idCounter++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cellCounter == 7)
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Oyun Tamamlandı!");
                button4.Enabled = true;
                return;
            }

            currentButton = stonesButton[cellCounter];
            currentButton.BackColor = Color.BlanchedAlmond;
            ids = cells.FirstOrDefault(cell => cell.X == currentButton.Location.X && cell.Y == currentButton.Location.Y).PathIds.ToArray();
            cellCounter++;
            idCounter = 0;
            timer1.Start();
            timer2.Stop();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_1_Click(object sender, EventArgs e)
        {
            PanelFill();
            CreateConnect();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = false;
            var ids = cells.Select(cell => cell.Id).ToList();
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                int id = random.Next(1, ids.Count + 1);
                var cell = cells.Find(cell1 => cell1.Id == id);
                stonesCells[i] = cell;
                Button button = new Button()
                {
                    Location = new Point(cell.X, cell.Y),
                    Size = new Size(cell.Width, cell.Height),
                    BackColor = Color.BlueViolet,
                    Font = new Font(FontFamily.GenericMonospace, 10),
                    ForeColor = Color.White,
                    Enabled = false,
                };
                button.Click += stoneButton_Click;
                stonesButton[i] = button;
                panel1.Controls.Add(button);
                ids.Remove(id);
            }
            int mainId = random.Next(1, ids.Count + 1);
            mainStone = cells.Find(cell1 => cell1.Id == mainId);
            Button mainButton = new Button()
            {
                Location = new Point(mainStone.X, mainStone.Y),
                Size = new Size(mainStone.Width, mainStone.Height),
                BackColor = Color.Maroon,
                Enabled = false,
                Font = new Font(FontFamily.GenericMonospace, 10),
                ForeColor = Color.Aquamarine

            };
            mainButton.Text = "ANA TAŞ";
            panel1.Controls.Add(mainButton);
            ids.Remove(mainId);

            button3.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = true;

            for (int i = 0; i < stonesCells.Length; i++)
            {
                var res = graph.Dijkstra((uint)stonesCells[i].Id, (uint)mainStone.Id);
                stonesCells[i].Distance = res.Distance;
                stonesCells[i].PathIds = res.GetPath().Where(u => u != (uint)stonesCells[i].Id).ToList();
            }
            for (int i = 0; i < cells.Count; i++)
            {
                var res = graph.Dijkstra((uint)cells[i].Id, (uint)mainStone.Id);
                cells[i].Distance = res.Distance;
                cells[i].PathIds = res.GetPath().Where(u => u != (uint)cells[i].Id).ToList();
            }

            for (int i = 0; i < stonesButton.Length; i++)
            {
                stonesButton[i].Text = stonesCells[i].Distance.ToString();
                stonesButton[i].Enabled = true;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            button2.Enabled = true;
            button4.Enabled = false;

            PanelFill();
        }
    }
}
