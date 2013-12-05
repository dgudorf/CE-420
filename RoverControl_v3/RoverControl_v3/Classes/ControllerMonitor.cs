using SlimDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoverControl_v3
{
    public class ControllerStateChangedEventArgs : EventArgs
    {
        public ControllerState          State   { get; set; }
        public ControllerChangeFlags    Flags   { get; set; }
    }
    
    public static class ControllerMonitor
    {
        // the controller's user index
        public static UserIndex
            UserIndex           { get; set; }
        // the active controller
        public static Controller
            ActiveController    { get; set; }
        // the "is connected" flag
        public static Boolean
            IsConnected         { get { return ActiveController != null && ActiveController.IsConnected; } private set { } }
        // the polling timer
        public static Timer
            PollingTimer        { get; set; }
        // the state buffer
        public static ControllerStateBuffer
            StateBuffer         { get; set; }
        public static Boolean
            CanRead             { get { return (StateBuffer.Count == 2) ? true : false; } private set { } }
        public static ControllerState
            CurrentState        { get { return (StateBuffer.Count == 2) ? StateBuffer[1] : null; } private set { } }
        public static event EventHandler<ControllerStateChangedEventArgs>
            ControllerStateChanged;

        public static void
            SetVibration(UInt16 left_speed, UInt16 right_speed)
        {
            // determine if the controller is connected
            if (IsConnected)
            {
                // it is
                // set the vibration
                //ActiveController.SetVibration(new Vibration { LeftMotorSpeed = left_speed, RightMotorSpeed = right_speed });
            }
        }

        public static void
            SetVibration(Double left_speed, Double right_speed)
        {
            // the adjusted values
            UInt16 adj_left_speed   = 0;
            UInt16 adj_right_speed  = 0;
            // determine if the values are within the right range
            if (left_speed  >= 0.00 && left_speed  <= 100.00 &&
                right_speed >= 0.00 && right_speed <= 100.00)
            {
                // they are
                // map the values
                adj_left_speed      = Convert.ToUInt16((left_speed  / 100.00) * UInt16.MaxValue);
                adj_right_speed     = Convert.ToUInt16((right_speed / 100.00) * UInt16.MaxValue);
            }
            else
            {
                // they are not
                // map the values
                adj_left_speed      = Convert.ToUInt16((left_speed  / 100.00) * UInt16.MaxValue);
                adj_right_speed     = Convert.ToUInt16((right_speed / 100.00) * UInt16.MaxValue);
                // determine which of the values is invalid
                if (left_speed < 0.000)
                {
                    // the left speed is below zero percent
                    // map the value
                    adj_left_speed  = 0;
                }
                if (left_speed > 100.0)
                {
                    // the left speed is above one-hundred percent
                    // map the value
                    adj_left_speed  = 65535;
                }
                if (right_speed < 0.000)
                {
                    // the right speed is below zero percent
                    adj_right_speed = 0;
                }
                if (right_speed > 100.00)
                {
                    // the right speed is above one-hundred percent
                    adj_right_speed = 65535;
                }
            }
            // set the vibration
            SetVibration(adj_left_speed, adj_right_speed);
        }

        public static Boolean
            Initialize()
        {
            // the result
            Boolean result = false;
            // a temporary controller
            Controller  controller  = null;
            // create a new polling timer
            PollingTimer            = new Timer();
            // attach the timer's tick event handler
            PollingTimer.Tick      += PollingTimer_Tick;
            // loop through the user indicies
            for (int user_index = 0; user_index < 4; user_index++)
            {
                // get this controller
                controller              = new Controller((UserIndex)(user_index));
                // determine if this controller is available
                if (controller.IsConnected)
                {
                    // it is
                    // save the controller
                    ActiveController    = controller;
                    // save the user index
                    UserIndex           = ((UserIndex)(user_index));
                    // save the result
                    result              = true;
                }
            }
            // create the state buffer
            StateBuffer                 = new ControllerStateBuffer();
            // return the result
            return result;
        }

        public static void 
            EnablePolling(Int32 period)
        {
            // set the properties of the timer
            PollingTimer.Interval       = period;
            PollingTimer.Enabled        = true;
        }

        public static void 
            EnablePolling()
        {
            // set the properties of the timer
            PollingTimer.Enabled        = true;
        }

        public static void 
            DisablePolling()
        { 
            // set the properties of the timer
            PollingTimer.Enabled        = false;
        }

        private static void 
            PollingTimer_Tick(object sender, EventArgs e)
        {
            // the controller change flags
            ControllerChangeFlags
                result      = ControllerChangeFlags.NoChange;
            // the controller state changed event arguments
            ControllerStateChangedEventArgs
                event_args  = null;
            // determine if there is an active controller
            if (IsConnected)
            {
                // remove the oldest item from the state buffer
                if (StateBuffer.Count > 1) { StateBuffer.RemoveAt(0); }
                // save the newest state
                StateBuffer.Add(new ControllerState(ActiveController.GetState()));
                // compare the states
                result      = StateBuffer.Compare();
                // determine if the controller state has changed
                if (result != ControllerChangeFlags.NoChange)
                {
                    // it has
                    // determine if the state buffer has enough states in it
                    if (StateBuffer.Count == 2)
                    {
                        // it does
                        // determine if there is an event handler
                        if (ControllerStateChanged != null)
                        {
                            // it does
                            // create the event arguments
                            event_args = new ControllerStateChangedEventArgs
                            {
                                State = StateBuffer[1],
                                Flags = result
                            };
                            // raise the event
                            ControllerStateChanged(ActiveController, event_args);
                        }
                    }
                }
            }
        }
    }
    public class ControllerStateBuffer
        : List<ControllerState>
    {
        public ControllerStateBuffer()
        {
            // set the capacity
            this.Capacity = 2;
        }
        public ControllerChangeFlags Compare()
        {
            // the result
            ControllerChangeFlags result = ControllerChangeFlags.NoChange;
            // determine if there enough states in the buffer
            if (this.Count == 2)
            {
                // there are
                // compare the two states
                result = this[1] - this[0];
            }
            // return the result
            return result;
        }
    }

    public class ControllerState
    {
        /* the gamepad state */
        private State               RawState;
        private Gamepad             Gamepad;
        private GamepadButtonFlags  ButtonFlags;

        public ControllerState(State state)
        {
            // save the controller state
            RawState    = state;
            // get the underlying gamepad
            Gamepad     = state.Gamepad;
            // get the button flags
            ButtonFlags = Gamepad.Buttons;
        }

        public static ControllerChangeFlags operator - (ControllerState a, ControllerState b)
        {
            // the result
            ControllerChangeFlags result = ControllerChangeFlags.NoChange;
            /* determine how the state has changed */
            // determine if button a has changed
            result |= (a.A != b.A) 
                        ? ControllerChangeFlags.A
                        : ControllerChangeFlags.NoChange;
            // determine if button b has changed
            result |= (a.B != b.B)
                        ? ControllerChangeFlags.B
                        : ControllerChangeFlags.NoChange;
            // determine if button x has changed
            result |= (a.X != b.X)
                        ? ControllerChangeFlags.X
                        : ControllerChangeFlags.NoChange;
            // determine if button y has changed
            result |= (a.Y != b.Y)
                        ? ControllerChangeFlags.Y
                        : ControllerChangeFlags.NoChange;
            // determine if the start button has changed
            result |= (a.Start != b.Start)
                        ? ControllerChangeFlags.Start
                        : ControllerChangeFlags.NoChange;
            // determine if the back button has changed
            result |= (a.Back != b.Back)
                        ? ControllerChangeFlags.Back
                        : ControllerChangeFlags.NoChange;
            // determine if the left joystick button has changed
            result |= (a.LeftJoystick != b.LeftJoystick)
                        ? ControllerChangeFlags.LeftJoystick
                        : ControllerChangeFlags.NoChange;
            // determine if the right joystick button has changed
            result |= (a.RightJoystick != b.RightJoystick)
                        ? ControllerChangeFlags.RightJoystick
                        : ControllerChangeFlags.NoChange;
            // determine if the left shoulder button has changed
            result |= (a.LeftShoulder != b.LeftShoulder)
                        ? ControllerChangeFlags.LeftShoulder
                        : ControllerChangeFlags.NoChange;
            // determine if the right shoulder button has changed
            result |= (a.RightShoulder != b.RightShoulder)
                        ? ControllerChangeFlags.RightShoulder
                        : ControllerChangeFlags.NoChange;
            // determine if the pov up button has changed
            result |= (a.Up != b.Up)
                        ? ControllerChangeFlags.Up
                        : ControllerChangeFlags.NoChange;
            // determine if the pov down button has changed
            result |= (a.Down != b.Down)
                        ? ControllerChangeFlags.Down
                        : ControllerChangeFlags.NoChange;
            // determine if the pov left button has changed
            result |= (a.Left != b.Left)
                        ? ControllerChangeFlags.Left
                        : ControllerChangeFlags.NoChange;
            // determine if the pov right button has changed
            result |= (a.Right != b.Right)
                        ? ControllerChangeFlags.Right
                        : ControllerChangeFlags.NoChange;
            // determine if the left trigger has changed
            result |= (a.LeftTrigger != b.LeftTrigger)
                        ? ControllerChangeFlags.LeftTrigger
                        : ControllerChangeFlags.NoChange;
            // determine if the right trigger has changed
            result |= (a.RightTrigger != b.RightTrigger)
                        ? ControllerChangeFlags.RightTrigger
                        : ControllerChangeFlags.NoChange;
            // determine if the left joystick's x-axis has changed
            result |= (a.LeftJoystickX != b.LeftJoystickX)
                        ? ControllerChangeFlags.LeftJoystickX
                        : ControllerChangeFlags.NoChange;
            // determine if the left joystick's y-axis has changed
            result |= (a.LeftJoystickY != b.LeftJoystickY)
                        ? ControllerChangeFlags.LeftJoystickY
                        : ControllerChangeFlags.NoChange;
            // determine if the right joystick's x-axis has changed
            result |= (a.RightJoystickX != b.RightJoystickX)
                        ? ControllerChangeFlags.RightJoystickX
                        : ControllerChangeFlags.NoChange;
            // determine if the right joystick's y-axis has changed
            result |= (a.RightJoystickY != b.RightJoystickY)
                        ? ControllerChangeFlags.RightJoystickY
                        : ControllerChangeFlags.NoChange;
            // return the result
            return result;
        }

        public Boolean      
            A
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.A); }
            private set { }
        }
        public Boolean
            B
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.B); }
            private set { }
        }
        public Boolean
            X
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.X); }
            private set { }
        }
        public Boolean
            Y
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.Y); }
            private set { }
        }
        public Boolean
            Start
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.Start); }
            private set { }
        }
        public Boolean
            Back
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.Back); }
            private set { }
        }
        public Boolean
            LeftJoystick
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.LeftThumb); }
            private set { }
        }
        public Boolean
            RightJoystick
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.RightThumb); }
            private set { }
        }
        public Boolean
            LeftShoulder
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.LeftShoulder); }
            private set { }
        }
        public Boolean
            RightShoulder
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.RightShoulder); }
            private set { }
        }
        public Boolean
            Up
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.DPadUp); }
            private set { }
        }
        public Boolean
            Down
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.DPadDown); }
            private set { }
        }
        public Boolean
            Left
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.DPadLeft); }
            private set { }
        }
        public Boolean
            Right
        {
            get { return ButtonFlags.HasFlag(GamepadButtonFlags.DPadRight); }
            private set { }
        }
        public Int16
            LeftJoystickX
        {
            get { return Gamepad.LeftThumbX; }
            private set { }
        }
        public Double
            LeftJoystickX_F
        {
            get { return Tools.MapIntToDouble(LeftJoystickX, Int16.MinValue, Int16.MaxValue, -100.00, 100.00, 20.00); }
            private set { }
        }
        public Int16
            LeftJoystickY
        {
            get { return Gamepad.LeftThumbY; }
            private set { }
        }
        public Double
            LeftJoystickY_F
        {
            get { return Tools.MapIntToDouble(LeftJoystickY, Int16.MinValue, Int16.MaxValue, -100.00, 100.00, 20.00); }
            private set { }
        }
        public Int16
            RightJoystickX
        {
            get { return Gamepad.RightThumbX; }
            private set { }
        }
        public Double
            RightJoystickX_F
        {
            get { return Tools.MapIntToDouble(RightJoystickX, Int16.MinValue, Int16.MaxValue, -100.00, 100.00, 20.00); }
            private set { }
        }
        public Int16
            RightJoystickY
        {
            get { return Gamepad.RightThumbY; }
            private set { }
        }
        public Double
            RightJoystickY_F
        {
            get { return Tools.MapIntToDouble(RightJoystickY, Int16.MinValue, Int16.MaxValue, -100.00, 100.00, 20.00); }
            private set { }
        }
        public Byte
            LeftTrigger
        {
            get { return Gamepad.LeftTrigger; }
            private set { }
        }
        public Double
            LeftTrigger_F
        {
            get { return Tools.MapUIntToDouble(LeftTrigger, 0, 255, 0.00, 100.00, 0.00); }
            private set { }
        }
        public Byte
            RightTrigger
        {
            get { return Gamepad.RightTrigger; }
            private set { }
        }
        public Double
            RightTrigger_F
        {
            get { return Tools.MapUIntToDouble(RightTrigger, 0, 255, 0.00, 100.00, 0.00); }
            private set { }
        }
    }

    [Flags]
    public enum ControllerChangeFlags
    {
        NoChange            = 0x00000000,
        A                   = 0x00000001,
        B                   = 0x00000002,
        X                   = 0x00000004,
        Y                   = 0x00000008,
        Start               = 0x00000010,
        Back                = 0x00000020,
        LeftJoystick        = 0x00000040,
        RightJoystick       = 0x00000080,
        LeftShoulder        = 0x00000100,
        RightShoulder       = 0x00000200,
        Up                  = 0x00000400,
        Down                = 0x00000800,
        Left                = 0x00001000,
        Right               = 0x00002000,
        LeftJoystickX       = 0x00004000,
        LeftJoystickY       = 0x00008000,
        RightJoystickX      = 0x00010000,
        RightJoystickY      = 0x00020000,
        LeftTrigger         = 0x00040000,
        RightTrigger        = 0x00080000,
        All                 = 0x000FFFFF
    }
}
