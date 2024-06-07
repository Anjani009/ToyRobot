using ToyRobot.Enums;

namespace ToyRobot.Models
{
    public class TableDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }

    }

    public class PlaceRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction direction { get; set; }
    }
}
