using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace HomeWork
{
    class GamepadHandlerEventArgs : EventArgs
    {
        public GameControl myProperty { get; set; }

        public bool IsKeyPressed { get; set; }

        public event ControlDelegate ControlPressed;

        public virtual void OnControlPressed(GameControl control)
        {
            this.myProperty = control;
            ControlPressed(this);
        }
        public void ProcessButtonPressed()
        {
            while (true)
            {
                ConsoleKeyInfo pressed = Console.ReadKey(true);
                switch (pressed.Key)
                {
                    case ConsoleKey.RightArrow:
                        {
                            this.OnControlPressed(GameControl.ShiftCarRight);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        {
                            this.OnControlPressed(GameControl.ShiftCarLeft);
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            this.OnControlPressed(GameControl.Quit);
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        {
                            this.OnControlPressed(GameControl.Pause);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        {
                            this.IsKeyPressed = !this.IsKeyPressed;
                            this.OnControlPressed(GameControl.GainSpeed);
                        }
                        break;
                }
            }
        }

    }
}
