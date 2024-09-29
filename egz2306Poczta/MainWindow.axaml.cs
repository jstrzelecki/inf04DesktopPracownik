using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace egz2306Poczta;

public partial class MainWindow : Window
{
    private readonly RadioButton[] _radiobuttonsGroup;
    public MainWindow()
    {
        InitializeComponent();
        _radiobuttonsGroup =
        [
            PostcardRadioButton,
            LetterRadioButton,
            PackageRadioButton
        ];
    }

    private void OnCheckPriceButton(object? sender, RoutedEventArgs e)
    {
        var selectedRadioButton = _radiobuttonsGroup.FirstOrDefault(rb=>rb.IsChecked == true);
        if (selectedRadioButton != null)
        {
            (string imagePath, string priceInfo) = selectedRadioButton.Tag switch
            {
                "Postcard" => ("avares://egz2306Poczta/Assets/postcard.png", "Cena 1 zł"),
                "Letter" => ("avares://egz2306Poczta/Assets/letter.png", "Cena 1,5 zł"),
                "Package" => ("avares://egz2306Poczta/Assets/postcard.png", "Cena 10 zł"),
                _ => ("Assets/letter.png", "Cena: 1,5 zł")
            };

            PriceTextBlock.Text = priceInfo;
            using var stream = AssetLoader.Open(new Uri(imagePath));
            ParcelImage.Source = new Bitmap(stream);
        }
        
    }
}