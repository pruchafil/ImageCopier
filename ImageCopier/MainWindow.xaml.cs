using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ImageCopier
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1d, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            TextBox tb;

            grid.Children.Add
            (
                tb = new TextBox()
                {
                    Margin = new Thickness(4d),
                    Padding = new Thickness(2d),
                    VerticalAlignment = VerticalAlignment.Center
                }
            );

            Button b;

            grid.Children.Add
            (
                b = new Button()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Content = "Zkurvit",
                    Margin = new Thickness(4d),
                    Padding = new Thickness(4d, 2d, 4d, 2d)
                }
            );

            Grid.SetColumn(tb, 0);
            Grid.SetColumn(b, 1);

            Copier c = new Copier(null, null);

            b.Click += (s, args) =>
            {
                const string start = "Zkurvit",
                             stop  = "Přestat kurvit";

                if (b.Content.ToString() == stop)
                {
                    c.IsActive = false;
                }
                else
                {
                    c = new Copier(File.ReadAllBytes(tb_path.Text), tb_path.Text);
                }

                b.Content = b.Content.ToString() == start ? stop : start;                

                Task.Run(() =>
                {
                    c.Proceed();
                });
            };

            stack.Children.Add(grid);
        }
    }
}