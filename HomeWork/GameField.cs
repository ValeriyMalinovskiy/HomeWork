namespace HomeWork
{
    internal class GameField
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public GameField(int width = 10, int height = 20)
        {
            this.Width = width;
            this.Height = height;
        }

        public bool CheckIsOnField(RacingGameObject gameObject)
        {
            foreach (Node point in gameObject.Nodes)
            {
                if (point.X <= this.Width && point.X >= 0 && point.Y <= this.Height && point.Y >= 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

