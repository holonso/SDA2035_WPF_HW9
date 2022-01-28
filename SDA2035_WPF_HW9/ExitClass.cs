using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace SDA2035_WPF_HW9
{
    class ExitClass
    {
        public static RoutedUICommand Exit { get; set; }

        static ExitClass()
        {
            InputGestureCollection input = new InputGestureCollection();
            input.Add(new KeyGesture(Key.E, ModifierKeys.Alt, "Alt+E"));
            Exit = new RoutedUICommand("Выход", "Exit", typeof(ExitClass), input);
        }
    }
}
