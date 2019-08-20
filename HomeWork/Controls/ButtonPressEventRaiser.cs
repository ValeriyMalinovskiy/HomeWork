using System;

namespace HomeWork
{
    internal class ButtonPressEventRaiser
    {
        private readonly GamepadEventArgs gamepad = new GamepadEventArgs();

        public event ControlDelegate ControlPressed;

        public virtual void OnControlPressed(GameControl control)
        {
            this.gamepad.Control = control;
            ControlPressed(this.gamepad);
        }

        public void Watch()
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
                }
            }
        }
    }
}
