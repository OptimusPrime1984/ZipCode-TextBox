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
using System.Text.RegularExpressions;

namespace ZipCode_TextBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        public string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

        private bool IsUsorCanadianZipCode(string zipCode)
        {
            bool validZipCode = true;
            if ((!Regex.Match(zipCode, _usZipRegEx).Success) && (!Regex.Match(zipCode, _caZipRegEx).Success))
            {
                validZipCode = false;
            }
            return validZipCode;
        }


        private void ZipCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubmitButton.IsEnabled = false;

            if (IsUsorCanadianZipCode(ZipCodeTextBox.Text))
            {
                SubmitButton.IsEnabled = true;
            }
        }
    }
}
