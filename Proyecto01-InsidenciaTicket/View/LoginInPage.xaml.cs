using Proyecto01_InsidenciaTicket.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto01_InsidenciaTicket.View
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class LoginInPage : Page
    {
        private WindowManager _windowManager;

        public LoginInPage()
        {
            InitializeComponent();
            DataContext = new UserViewModel();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _windowManager = new WindowManager(Window.GetWindow(this));
        }
        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _windowManager?.Window_MouseDown(sender, e);
        }
        private void IconBOff_Loaded(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var closeIcon = new BitmapImage(new Uri("pack://application:,,,/Proyecto01-InsidenciaTicket;component/Resourses/Icon/CloseIcon.jpg"));
            button.Tag = closeIcon;
        }
        private void IconBMin_Loaded(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var minIcon = new BitmapImage(new Uri("pack://application:,,,/Proyecto01-InsidenciaTicket;component/Resourses/Icon/MinIcon.jpg"));
            button.Tag = minIcon;
        }

        private void Off_Button(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Minimize_Button(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }
    }
}
