using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Design;

namespace RoverControl_v3
{
    public partial class AlarmButton : UserControl
    {
        // the base color
        private Color           DefaultColor            = Color.Black;
        // the priority level colors
        private Color           ExtremeColorActive      = Color.FromArgb(0xEC, 0x3E, 0x40);
        private Color           ExtremeColorInactive    = Color.FromArgb(0xC9, 0x13, 0x15);
        private Color           SevereColorActive       = Color.FromArgb(0xFF, 0x9B, 0x2B);
        private Color           SevereColorInactive     = Color.FromArgb(0xDD, 0x75, 0x00);
        private Color           HighColorActive         = Color.FromArgb(0xF5, 0xD8, 0x00);
        private Color           HighColorInactive       = Color.FromArgb(0xA8, 0x94, 0x00);
        private Color           MediumColorActive       = Color.FromArgb(0x37, 0x7F, 0xC7);
        private Color           MediumColorInactive     = Color.FromArgb(0x26, 0x58, 0x8B);
        private Color           LowColorActive          = Color.FromArgb(0x01, 0xA4, 0x6D);
        private Color           LowColorInactive        = Color.FromArgb(0x00, 0x71, 0x4B);
        // the alarm enabled event
        public event EventHandler AlarmEnabledChanged;
        // the active color
        private Color           ActiveColor             = SystemColors.Control;
        private Color           InactiveColor           = SystemColors.Control;
        /* background variables */
        private PriorityLevel   _priority_level         = PriorityLevel.None;
        private Boolean         _alarm_enabled          = false;
        private Boolean         _enable_flash           = false;
        private String          _alarm_text             = String.Empty;
        private DateTime?       _alarm_enabled_time     = null;
        public AlarmCode        AlarmCode { get; set; }
        public PriorityLevel    AlarmPriority
        {
            get
            {
                // return the underlying value
                return _priority_level;
            }
            set
            {
                // save the new value
                _priority_level = value;
                // update the flash timer interval
                FlashTimer.Interval = (_priority_level == PriorityLevel.Low)      ? 300  : FlashTimer.Interval;
                FlashTimer.Interval = (_priority_level == PriorityLevel.Medium)   ? 250   : FlashTimer.Interval;
                FlashTimer.Interval = (_priority_level == PriorityLevel.High)     ? 200   : FlashTimer.Interval;
                FlashTimer.Interval = (_priority_level == PriorityLevel.Severe)   ? 150   : FlashTimer.Interval;
                FlashTimer.Interval = (_priority_level == PriorityLevel.Extreme)  ? 100   : FlashTimer.Interval;
                // update the active colors
                ActiveColor         = (_priority_level == PriorityLevel.Low)      ? LowColorActive        : ActiveColor;
                ActiveColor         = (_priority_level == PriorityLevel.Medium)   ? MediumColorActive     : ActiveColor;
                ActiveColor         = (_priority_level == PriorityLevel.High)     ? HighColorActive       : ActiveColor;
                ActiveColor         = (_priority_level == PriorityLevel.Severe)   ? SevereColorActive     : ActiveColor;
                ActiveColor         = (_priority_level == PriorityLevel.Extreme)  ? ExtremeColorActive    : ActiveColor;
                // update the inactive colors
                InactiveColor       = (_priority_level == PriorityLevel.Low)      ? LowColorInactive      : InactiveColor;
                InactiveColor       = (_priority_level == PriorityLevel.Medium)   ? MediumColorInactive   : InactiveColor;
                InactiveColor       = (_priority_level == PriorityLevel.High)     ? HighColorInactive     : InactiveColor;
                InactiveColor       = (_priority_level == PriorityLevel.Severe)   ? SevereColorInactive   : InactiveColor;
                InactiveColor       = (_priority_level == PriorityLevel.Extreme)  ? ExtremeColorInactive  : InactiveColor;
            }
        }
        public Boolean          AlarmSilenced
        {
            get;
            set;
        }
        public DateTime?        AlarmEnabledTime { get { return _alarm_enabled_time; } private set { } }
        public Button AlarmInterface
        {
            get { return button; }
            private set { }
        }
        public Boolean          AlarmEnabled
        {
            get
            {
                // return the underlying value
                return _alarm_enabled;
            }
            set
            {
                // clear the silenced flag
                AlarmSilenced       = false;
                // clear the button's color
                button.ForeColor    = Color.FromArgb(50, 50, 50);
                button.BackColor    = Color.Black;
                // determine if the value is true
                if (value == true)
                {
                    // attach the button event handler
                    button.Click       += button_Click;
                    // set the color of the alarm
                    button.BackColor    = ActiveColor;
                }
                else
                {
                    // it is not
                    // detach the button event handler
                    button.Click       -= button_Click;
                }
                // determine if the value has changed
                if (value != _alarm_enabled && value == true)
                {
                    // it has
                    // save the time
                    _alarm_enabled_time = DateTime.Now;
                    // determine if there is an event handler
                    if (AlarmEnabledChanged != null)
                    {
                        // there is
                        // raise the event 
                        AlarmEnabledChanged(this, new EventArgs());
                    }
                }
                // save the new value
                _alarm_enabled      = value;
            }
        }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public String AlarmText 
        {
            get
            {
                // return the underlying value
                return _alarm_text;
            }
            set
            {
                // save the new value
                _alarm_text         = value;
                // change the text of the alarm button
                button.Text         = value;
            }
        }
        private Timer           FlashTimer              = new Timer();
        private Boolean         FlashState              = false;

        public AlarmButton()
        {
            // required for designer support
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            // toggle the silenced flag
            AlarmSilenced = !AlarmSilenced;
        }
    }
    [Flags]
    public enum PriorityLevel
    {
        None        = 0x00,
        Low         = 0x01,
        Medium      = 0x02,
        High        = 0x04,
        Severe      = 0x08,
        Extreme     = 0x10
    }

    [Flags]
    public enum AlarmCode
    {
        None                        = 0x00000000,
        CommunicationFailure        = 0x00000001,
        BatteryFailure              = 0x00000002,
        OvercurrentLeft             = 0x00000004,
        OvercurrentRight            = 0x00000008,
        HighVoltageBusUndervolt     = 0x00000010,
        LowVoltageBusUndervolt      = 0x00000020,
        OvercurrentImminentLeft     = 0x00000040,
        OvercurrentImminentRight    = 0x00000080,
        StallLeft                   = 0x00000100,
        StallRight                  = 0x00000200,
        CollisionImminentFront      = 0x00000400,
        OvercurrentWarningLeft      = 0x00000800,
        OvercurrentWarningRight     = 0x00001000,
        CollisionWarningFront       = 0x00002000,
        FrontLeftPowerCutoff        = 0x00004000,
        FrontRightPowerCutoff       = 0x00008000,
        RearLeftPowerCutoff         = 0x00010000,
        RearRightPowerCutoff        = 0x00020000,
        CollisionAvoidanceActive    = 0x00040000,
        RoverOff                    = 0x00080000,
        RoverIdle                   = 0x00100000,
        RoverError                  = 0x00200000,
        RoverRun                    = 0x00400000,
    }
}
