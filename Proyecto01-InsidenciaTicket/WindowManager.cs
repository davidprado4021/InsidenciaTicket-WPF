using System;
using System.Windows;
using System.Windows.Input;

namespace Proyecto01_InsidenciaTicket
{
    public class WindowManager
    {
        private readonly Window _window;

        public WindowManager(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
            _window.MouseDown += Window_MouseDown;
        }
        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _window.DragMove();
            }
        }
    }
}
