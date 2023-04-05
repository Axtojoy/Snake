using Snake.Logic.Models;
using System.Drawing;

namespace Snake.Models.Game
{
    public class GameViewModel
    {
        public class Line
        {
            public Point Start { get; set; }
            public Point End { get; set; }
        }
        public GameViewModel() { }

        public int x1 { get; set; }

        public int y1 { get; set; }

        public int x2 { get; set; }

        public int y2 { get; set; }
        public List<Line> Lines { get; set; }
        public GameGetAllCoordinateDTO Game { get; set; }

        public GameViewModel(GameGetAllCoordinateDTO game)
        {

            Game = game;
            Lines = new List<Line>();
        }
    }
}
