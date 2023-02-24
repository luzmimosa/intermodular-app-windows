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
using TestApp_Intermodular.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestApp_Intermodular.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para FavoritesView.xaml
    /// </summary>
    public partial class FavoritesView : UserControl
    {
        public FavoritesView()
        {
            InitializeComponent();
            var stackPanel = new StackPanel();

            for (int i = 0; i < 10; i++)
            {
                var sp = new UserList();
                var ul = sp.DisplayList();
                stackPanel.Children.Add(ul);
            }

            scrollViewer.Content = stackPanel;

        }
        //private void DisplayRoutes(int number)
        //{
        //    int cont = 0;
        //    for (int i = 0; i < number; i++)
        //    {
        //        //Grid grid = Commentary.CommentGrid();
        //        StackPanel grid = UserList.DisplayList();
        //        if (cont % 2 == 0)
        //        {
        //            ColumnA.Children.Add(grid);
        //            cont++;
        //        }
        //        else
        //        {
        //            ColumnA.Children.Add(grid);
        //            cont++;
        //        }
        //    }
        //}
    }
}
