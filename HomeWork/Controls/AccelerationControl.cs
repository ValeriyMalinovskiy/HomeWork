using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal static class AccelerationControl
    {
        private const int KeyPressed = 0x8000;

        public static bool IsKeyDown(int keyCode)
        {
            return (GetKeyState(keyCode) & KeyPressed) != 0;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]

        private static extern short GetKeyState(int key);
    }
}
