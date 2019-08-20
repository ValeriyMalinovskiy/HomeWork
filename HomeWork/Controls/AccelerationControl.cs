namespace HomeWork
{
    internal static class AccelerationControl
    {
        private const int KeyPressed = 0x8000;

        public static bool IsKeyDown(int keyCode = 38)
        {
            return (GetKeyState(keyCode) & KeyPressed) != 0;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]

        private static extern short GetKeyState(int key);
    }
}
