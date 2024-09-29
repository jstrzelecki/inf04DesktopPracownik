using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace egz2306Poczta;

public partial class MainWindow : Window
{
    private List<RadioButton> _radioButtons;
    public MainWindow()
    {
        InitializeComponent();
        _radioButtons =
        [
            PostcardRadioButton,
            LetterRadioButton,
            PackageRadioButton
        ];
    }

    private void OnCheckPriceButton(object? sender, RoutedEventArgs e)
    {
        var selectedOption = _radioButtons.FirstOrDefault( rb => rb.IsChecked == true );
    }
}