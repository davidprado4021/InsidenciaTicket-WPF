using Proyecto01_InsidenciaTicket.View;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace Proyecto01_InsidenciaTicket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WindowManager _windowManager;
        private readonly List<Page> _pages; 
        private int _currentPageIndex;

        public MainWindow()
        {
            InitializeComponent();
            _windowManager = new WindowManager(this);

            _pages = new List<Page>
            {
                new LoginInPage(),
              /*new SecondPage(),
                new ThirdPage() */
            };

            _currentPageIndex = 0;

            ShowPage(_pages[_currentPageIndex]);
        }
        private void ShowPage(Page page)
        {
            MainFrame.Navigate(page);
        }
       /* private void NextPage()
        {
            _currentPageIndex++;
            if (_currentPageIndex < _pages.Count)
            {
                ShowPage(_pages[_currentPageIndex]);
            }
            else
            {
                // Si el índice supera el número de páginas, cierra la aplicación o realiza otra acción
                Close();
            }
        }*/
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _windowManager.Window_MouseDown(sender, e);
        }
    }
}