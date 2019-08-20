namespace HomeWork
{
    internal class Node
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool IsDisabled { get; set; }

        public Node()
        {
            this.X = -1;
            this.Y = -1;
            this.IsDisabled = false;
        }
    }
}
