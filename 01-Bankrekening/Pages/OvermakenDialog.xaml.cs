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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Bankrekening.Pages
{
    public sealed partial class OvermakenDialog : ContentDialog
    {
        public Transactie result;

        public OvermakenDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_AnnulerenButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void ContentDialog_OvermakenButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            result = new Transactie(InputRekening.Text, Convert.ToDecimal(InputBedrag.Text));
            this.Hide();
        }

        private void InputBedrag_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsNumber(c));
        }
    }
}
