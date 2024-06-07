using ToyRobot.Enums;

namespace ToyRobot.Models
{
    public class Robot
    {
        private readonly int _tableWidth;
        private readonly int _tableHeight;
        public int? X { get; private set; }
        public int? Y { get; private set; }
        public Direction? Facing { get; private set; }

        public Robot(int tableWidth, int tableHeight)
        {
            _tableWidth = tableWidth;
            _tableHeight = tableHeight;
        }
        public void Place(int x, int y, Direction direction)
        {
            if (IsValidPosition(x, y))
            {
                X = x;
                Y = y;
                Facing = direction;
            }
        }

        public void Move()
        {
            if (X.HasValue && Y.HasValue && Facing.HasValue)
            {
                switch (Facing)
                {
                    case Direction.NORTH when IsValidPosition(X.Value, Y.Value + 1):
                        Y++;
                        break;
                    case Direction.EAST when IsValidPosition(X.Value + 1, Y.Value):
                        X++;
                        break;
                    case Direction.SOUTH when IsValidPosition(X.Value, Y.Value - 1):
                        Y--;
                        break;
                    case Direction.WEST when IsValidPosition(X.Value - 1, Y.Value):
                        X--;
                        break;
                }
            }
        }

        public void Left()
        {
            if (Facing.HasValue)
            {
                Facing = (Direction)(((int)Facing + 3) % 4);
            }
        }

        public void Right()
        {
            if (Facing.HasValue)
            {
                Facing = (Direction)(((int)Facing + 1) % 4);
            }
        }

        public string Report()
        {
            if (X.HasValue && Y.HasValue && Facing.HasValue)
            {
                return $"{X},{Y},{Facing}";
            }

            return "Robot is not placed on the table.";
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < _tableWidth && y >= 0 && y < _tableHeight;
        }
    }
}
