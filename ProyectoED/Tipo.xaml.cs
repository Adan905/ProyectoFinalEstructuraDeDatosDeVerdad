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

namespace ProyectoED
{
    /// <summary>
    /// Lógica de interacción para Tipo.xaml
    /// </summary>
    public partial class Tipo : UserControl
    {
        public Tipo()
        {
            InitializeComponent();
            rbtPelicula.IsChecked = true;
        }

        private void RbtPelicula_Checked(object sender, RoutedEventArgs e)
        {
            if(rbtPelicula.IsChecked == true)
            {
                lTemporada.Visibility = Visibility.Hidden;
                tbTemporadas.Visibility = Visibility.Hidden;
            }
        }

        private void RbtSerie_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtSerie.IsChecked == true)
            {
                lTemporada.Visibility = Visibility.Visible;
                lRating.Visibility = Visibility.Visible;
                tbTemporadas.Visibility = Visibility.Visible;
                tbRating.Visibility = Visibility.Visible;
            }
        }
    }
}
