using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Bankrekening.Pages;

namespace Bankrekening
{
    // Bronnen:
    // https://docs.telerik.com/devtools/xamarin/knowledge-base/datagrid-add-button-inside-column
    // https://learn.microsoft.com/en-us/windows/communitytoolkit/controls/datagrid_guidance/datagrid_basics

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            GridData.ItemsSource = Bank.bankrekeningen;
            string[] voornamen = { "Niels", "Henk", "Piet", "Jasper", "Max", "Kees", "Sjaak", "Jan", "Justin", "Joey" };
            string[] achternamen = { "Van de genk", "Van der pas", "Schouten", "Verhagen" };

            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                string name = voornamen[random.Next(0, voornamen.Length - 1)] + " " + achternamen[random.Next(0, achternamen.Length - 1)];
                Bankrekening rekening = Bank.MaakRekening(name);

                rekening.Storten(Math.Round(Convert.ToDecimal(random.NextDouble() * random.Next(1, 100)), 2));
            }

            foreach (Bankrekening rekening in Bank.bankrekeningen)
            {
                rekening.Storten(random.Next(1, 10000));
            }
        }

        private async void BtnOpnemen_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Bankrekening rekening = (Bankrekening)btn.DataContext;

            OpnemenDialog dialog = new OpnemenDialog();
            await dialog.ShowAsync();

            rekening.Opnemen(dialog.result);
        }

        private async void BtnStorten_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Bankrekening rekening = (Bankrekening)btn.DataContext;

            StortenDialog dialog = new StortenDialog();
            await dialog.ShowAsync();

            rekening.Storten(dialog.result);
        }

        private async void BtnOvermaken_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Bankrekening rekening = (Bankrekening)btn.DataContext;

            OvermakenDialog dialog = new OvermakenDialog();
            await dialog.ShowAsync();

            rekening.Overmaken(dialog.result);
        }
    }
}
