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
using System.Collections.ObjectModel;

namespace ProyectoED
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Conjunto> conjunto = new ObservableCollection<Conjunto>();

        public MainWindow()
        {
            InitializeComponent();
            conjunto.Add(new Serie("Shigatsu no kimi no uso", 2016, "JapAnime", "Suspenso", 2, "Dos chicos que tocan instrumentos se conocen", 5));
            conjunto.Add(new Pelicula("John Wick", 2013, "No sé la verdad", "Acción", "Un hombre que dedicaba al asesinato a sueldo.", 4));
            lstCosas.ItemsSource = conjunto;

            btAgregarelemento.Visibility = Visibility.Visible;
            btmenoMayo.Visibility = Visibility.Visible;
            btAZ.Visibility = Visibility.Visible;
            btMayomeno.Visibility = Visibility.Visible;
            btZA.Visibility = Visibility.Visible;
            btCancelar.Visibility = Visibility.Hidden;
            btGuardarelemento.Visibility = Visibility.Hidden;
            btEditarelemento.Visibility = Visibility.Hidden;
            btEliminarelemento.Visibility = Visibility.Hidden;
            btActualizar.Visibility = Visibility.Hidden;

        }

        private void btAZ_Click(object sender, RoutedEventArgs e)
        {
            bool cambio;
            do
            {
                cambio = false;
                for (int i = 0; i < (conjunto.Count - 1); i++)
                {
                    if (string.Compare(conjunto[i].Titulo, conjunto[i + 1].Titulo) > 0)
                    {
                        var temp = conjunto[i];
                        conjunto[i] = conjunto[i + 1];
                        conjunto[i + 1] = temp;
                        cambio = true;
                    }
                }
            } while (cambio == true);
        }

        private void BtZA_Click(object sender, RoutedEventArgs e)
        {
            bool cambio;
            do
            {
                cambio = false;
                for (int i = 0; i < (conjunto.Count - 1); i++)
                {
                    if (string.Compare(conjunto[i].Titulo, conjunto[i + 1].Titulo) < 0)
                    {
                        var temp = conjunto[i];
                        conjunto[i] = conjunto[i + 1];
                        conjunto[i + 1] = temp;
                        cambio = true;
                    }
                }
            } while (cambio == true);

        }

        private void BtMayomeno_Click(object sender, RoutedEventArgs e)
        {
            bool intercambio = false;
            do
            {
                intercambio = false;
                for (int i = 0; i < conjunto.Count - 1; i++)
                {
                    if (conjunto[i].Año < conjunto[i + 1].Año)
                    {
                        var temp = conjunto[i];
                        conjunto[i] = conjunto[i + 1];
                        conjunto[i + 1] = temp;
                        intercambio = true;
                    }
                }
            } while (intercambio);
        }

        private void BtmenoMayo_Click(object sender, RoutedEventArgs e)
        {
            bool intercambio = false;
            do
            {
                intercambio = false;
                for (int i = 0; i < conjunto.Count - 1; i++)
                {
                    if (conjunto[i].Año > conjunto[i + 1].Año)
                    {
                        var temp = conjunto[i];
                        conjunto[i] = conjunto[i + 1];
                        conjunto[i + 1] = temp;
                        intercambio = true;
                    }
                }
            } while (intercambio);
        }

        private void btAgregarelemento_Click(object sender, RoutedEventArgs e)
        {
            grdInfo.Children.Clear();
            grdInfo.Children.Add(new Tipo());

            btAgregarelemento.Visibility = Visibility.Hidden;
            btmenoMayo.Visibility = Visibility.Hidden;
            btAZ.Visibility = Visibility.Hidden;
            btMayomeno.Visibility = Visibility.Hidden;
            btZA.Visibility = Visibility.Hidden;
            btCancelar.Visibility = Visibility.Visible;
            btGuardarelemento.Visibility = Visibility.Visible;
        }

        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            grdInfo.Children.Clear();

            btAgregarelemento.Visibility = Visibility.Visible;
            btmenoMayo.Visibility = Visibility.Visible;
            btAZ.Visibility = Visibility.Visible;
            btMayomeno.Visibility = Visibility.Visible;
            btZA.Visibility = Visibility.Visible;
            btCancelar.Visibility = Visibility.Hidden;
            btGuardarelemento.Visibility = Visibility.Hidden;
            btEditarelemento.Visibility = Visibility.Hidden;
            btEliminarelemento.Visibility = Visibility.Hidden;
            btActualizar.Visibility = Visibility.Hidden;
        }

        private void LstCosas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCosas.SelectedIndex != -1)
            {
                grdInfo.Children.Clear();
                grdInfo.Children.Add(new Ver());

                btmenoMayo.Visibility = Visibility.Hidden;
                btAZ.Visibility = Visibility.Hidden;
                btMayomeno.Visibility = Visibility.Hidden;
                btZA.Visibility = Visibility.Hidden;
                btGuardarelemento.Visibility = Visibility.Hidden;
                btAgregarelemento.Visibility = Visibility.Hidden;
                btEditarelemento.Visibility = Visibility.Visible;
                btCancelar.Visibility = Visibility.Visible;
                btEliminarelemento.Visibility = Visibility.Visible;
                btActualizar.Visibility = Visibility.Hidden;

                var casting = ((Ver)(grdInfo.Children[0]));
                var casting2 = conjunto[lstCosas.SelectedIndex];

                casting.tbTitulo.Text = casting2.Titulo;
                casting.tbAño.Text = casting2.Año.ToString();
                casting.cbProductor.Text = casting2.Productor;
                casting.cbGenero.Text = casting2.Genero;
                casting.tbSinopsis.Text = casting2.Descripcion;
                casting.lCategoria.Text = casting2.Tipo;
                casting.tbTemporadas.Text = casting2.Temporadas.ToString();
                casting.tbRating.Text = casting2.Rating.ToString();

                if (casting2.Rating <= 0 || casting2.Rating > 5)
                {

                }
                if (casting2.Rating == 1)
                {
                    casting.star1.Visibility = Visibility.Visible;
                }
                if (casting2.Rating == 2)
                {
                    casting.star2.Visibility = Visibility.Visible;
                }
                if (casting2.Rating == 3)
                {
                    casting.star3.Visibility = Visibility.Visible;
                }
                if (casting2.Rating == 4)
                {
                    casting.star4.Visibility = Visibility.Visible;
                }
                if (casting2.Rating == 5)
                {
                    casting.star5.Visibility = Visibility.Visible;
                }
                

                casting.tbTitulo.IsEnabled = false;
                casting.tbAño.IsEnabled = false;
                casting.cbProductor.IsEnabled = false;
                casting.cbGenero.IsEnabled = false;
                casting.tbSinopsis.IsEnabled = false;
                casting.tbTemporadas.IsEnabled = false;
                casting.tbRating.IsEnabled = false;

            }


        }

        private void BtEditarelemento_Click(object sender, RoutedEventArgs e)
        {
            var casting = ((Ver)(grdInfo.Children[0]));
            var casting2 = conjunto[lstCosas.SelectedIndex];

                casting.tbTitulo.IsEnabled = true;
                casting.tbAño.IsEnabled = true;
                casting.cbProductor.IsEnabled = true;
                casting.cbGenero.IsEnabled = true;
                casting.tbSinopsis.IsEnabled = true;
                casting.tbRating.IsEnabled = true;
                casting.tbTemporadas.IsEnabled = true;
                casting.lRating.Visibility = Visibility.Visible;
                casting.tbRating.Visibility = Visibility.Visible;



            if (casting2.Rating <= 0 || casting2.Rating > 5)
            {
            }
            if (casting2.Rating == 1)
            {
                casting.star1.Visibility = Visibility.Hidden;
            }
            if (casting2.Rating == 2)
            {
                casting.star2.Visibility = Visibility.Hidden;
            }
            if (casting2.Rating == 3)
            {
                casting.star3.Visibility = Visibility.Hidden;
            }
            if (casting2.Rating == 4)
            {
                casting.star4.Visibility = Visibility.Hidden;
            }
            if (casting2.Rating == 5)
            {
                casting.star5.Visibility = Visibility.Hidden;
            }
            

            btEditarelemento.Visibility = Visibility.Hidden;
            btActualizar.Visibility = Visibility.Visible;
        }

        private void BtGuardarelemento_Click(object sender, RoutedEventArgs e)
        {
            var casting = ((Tipo)(grdInfo.Children[0]));

            if (casting.rbtPelicula.IsChecked == true)
            {

                if (casting.tbTitulo.Text == string.Empty || casting.tbAño.Text == null ||
                        casting.tbProductor.Text == string.Empty || casting.cbGenero.Text == string.Empty ||
                        casting.tbSinopsis.Text == string.Empty || casting.tbRating.Text == string.Empty)
                {

                }
                else
                {
                    conjunto.Add(new Pelicula(casting.tbTitulo.Text, Convert.ToInt32(casting.tbAño.Text), casting.tbProductor.Text, casting.cbGenero.Text, casting.tbSinopsis.Text, Convert.ToInt32(casting.tbRating.Text)));

                    btAgregarelemento.Visibility = Visibility.Visible;
                    btmenoMayo.Visibility = Visibility.Visible;
                    btAZ.Visibility = Visibility.Visible;
                    btMayomeno.Visibility = Visibility.Visible;
                    btZA.Visibility = Visibility.Visible;
                    btCancelar.Visibility = Visibility.Hidden;
                    btGuardarelemento.Visibility = Visibility.Hidden;
                    btEditarelemento.Visibility = Visibility.Hidden;
                    btEliminarelemento.Visibility = Visibility.Hidden;

                    grdInfo.Children.Clear();

                }


            }
            if (casting.rbtSerie.IsChecked == true)
            {
                if (casting.tbTitulo.Text == string.Empty || casting.tbAño.Text == null ||
                        casting.tbProductor.Text == string.Empty || casting.cbGenero.Text == string.Empty ||
                        casting.tbSinopsis.Text == string.Empty || casting.tbRating.Text == string.Empty ||
                        casting.tbTemporadas.Text == string.Empty)
                {

                }
                else
                {

                    conjunto.Add(new Serie(casting.tbTitulo.Text, Convert.ToInt32(casting.tbAño.Text), casting.tbProductor.Text, casting.cbGenero.Text,
                        Convert.ToInt32(casting.tbTemporadas.Text), casting.tbSinopsis.Text, Convert.ToInt32(casting.tbRating.Text)));

                    btAgregarelemento.Visibility = Visibility.Visible;
                    btmenoMayo.Visibility = Visibility.Visible;
                    btAZ.Visibility = Visibility.Visible;
                    btMayomeno.Visibility = Visibility.Visible;
                    btZA.Visibility = Visibility.Visible;
                    btCancelar.Visibility = Visibility.Hidden;
                    btGuardarelemento.Visibility = Visibility.Hidden;
                    btEditarelemento.Visibility = Visibility.Hidden;
                    btEliminarelemento.Visibility = Visibility.Hidden;

                    grdInfo.Children.Clear();

                }
            }

        }

        private void BtActualizar_Click(object sender, RoutedEventArgs e)
        {
            var casting = ((Ver)(grdInfo.Children[0]));
            var casting2 = conjunto[lstCosas.SelectedIndex];

            if (casting.tbTitulo.Text == string.Empty || casting.tbAño.Text == null ||
                    casting.cbProductor.Text == string.Empty || casting.cbGenero.Text == string.Empty ||
                    casting.tbSinopsis.Text == string.Empty || casting.tbRating.Text == null ||
                    casting.tbTemporadas.Text == null && casting2.Tipo == "Pelicula")
            {
                btEditarelemento.Visibility = Visibility.Hidden;
                btActualizar.Visibility = Visibility.Visible;

            }
            if (casting.tbTitulo.Text == string.Empty || casting.tbAño.Text == string.Empty ||
                    casting.cbProductor.Text == string.Empty || casting.cbGenero.Text == string.Empty ||
                    casting.tbSinopsis.Text == string.Empty || casting.tbRating.Text == string.Empty ||
                    casting.tbTemporadas.Text == string.Empty && casting2.Tipo == "Serie")
            {
                btEditarelemento.Visibility = Visibility.Hidden;
                btActualizar.Visibility = Visibility.Visible;

            }
            else
            {
                casting2.Titulo = casting.tbTitulo.Text;
                casting2.Año = Convert.ToInt32(casting.tbAño.Text);
                casting2.Productor = casting.cbProductor.Text;
                casting2.Genero = casting.cbGenero.Text;
                casting2.Descripcion = casting.tbSinopsis.Text;
                casting2.Rating = Convert.ToInt32(casting.tbRating.Text);
                lstCosas.Items.Refresh();

                casting.tbTitulo.IsEnabled = false;
                casting.tbAño.IsEnabled = false;
                casting.cbProductor.IsEnabled = false;
                casting.cbGenero.IsEnabled = false;
                casting.tbSinopsis.IsEnabled = false;
                casting.tbTemporadas.IsEnabled = false;
                casting.tbRating.IsEnabled = false;

                btActualizar.Visibility = Visibility.Hidden;
                btEditarelemento.Visibility = Visibility.Visible;
            }


        }

        private void BtEliminarelemento_Click(object sender, RoutedEventArgs e)
        {
            if (lstCosas.SelectedIndex != -1)
            {
                conjunto.RemoveAt(lstCosas.SelectedIndex);
            }

            grdInfo.Children.Clear();
            lstCosas.Items.Refresh();

            btAgregarelemento.Visibility = Visibility.Visible;

            btmenoMayo.Visibility = Visibility.Visible;
            btAZ.Visibility = Visibility.Visible;
            btMayomeno.Visibility = Visibility.Visible;
            btZA.Visibility = Visibility.Visible;

            btCancelar.Visibility = Visibility.Hidden;
            btGuardarelemento.Visibility = Visibility.Hidden;

            btEditarelemento.Visibility = Visibility.Hidden;
            btEliminarelemento.Visibility = Visibility.Hidden;

        }

    }


}