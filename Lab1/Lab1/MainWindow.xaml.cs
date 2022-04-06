using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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

/*
            string liczba = ""; // tutaj musi być przecinek
            double wynik = 0;
            double.TryParse(liczba, out wynik);

            this.display.Text = wynik.ToString();
*/

namespace Lab1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = sender as Button;

            //if (przycisk.Content.ToString() == ".")
            //{
            //    if (this.display.Text.Contains("."))
            //    {
            //        if (this.display.Text.Contains("+") || this.display.Text.Contains("-") || this.display.Text.Contains("*") || this.display.Text.Contains("/"))
            //        {
            //            if (this.display.Text.EndsWith("0") || this.display.Text.EndsWith("1") || this.display.Text.EndsWith("2") || this.display.Text.EndsWith("3") || this.display.Text.EndsWith("4") || this.display.Text.EndsWith("5") || this.display.Text.EndsWith("6") ||
            //                 this.display.Text.EndsWith("7") || this.display.Text.EndsWith("8") || this.display.Text.EndsWith("9"))
            //            {
            //                return;
            //            }
            //        }
            //    }
            //    this.display.Text += ".";
            //}

            if (przycisk.Content.ToString() == ".")
            {
                if (!this.display.Text.Contains("."))
                {
                    if (this.display.Text == "")
                    {
                        this.display.Text = "0";
                    }
                    this.display.Text += ".";
                }

                if (this.display.Text.EndsWith("."))
                {
                    return;
                }

                if (this.display.Text.Contains("+") || this.display.Text.Contains("-") || this.display.Text.Contains("*") || this.display.Text.Contains("/"))
                {
                    this.display.Text += ".";
                }

            }
            else
            {
                this.display.Text += przycisk.Content.ToString();
            }

        }

        private void Operation_Click(object sender, RoutedEventArgs e)
    {
        Button op = sender as Button;
        string opek = op.Content.ToString();

        if (this.display.Text.EndsWith("+") || this.display.Text.EndsWith("-") || this.display.Text.EndsWith("*") || this.display.Text.EndsWith("/"))
        {
            return;
        }
        else
        {
            this.display.Text += opek;
        }
    }

    private void DeletingAll_Click(object sender, RoutedEventArgs e)
    {
        string del = "";
        this.display.Text = del;
    }

    private void DeletingLast_Click(object sender, RoutedEventArgs e)
    {
        int textLength = display.Text.Length;
        if (textLength > 0)
        {
            this.display.Text = this.display.Text.Substring(0, textLength - 1);
        }
    }

    private void PlusMinus_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (this.display.Text.Contains('.'))
            {
                this.display.Text = this.display.Text.ToString().Replace('.', ',');
            }
            string liczba = this.display.Text;
            double wynik = 0;
            double.TryParse(liczba, out wynik);
            wynik = (-wynik);
            this.display.Text = wynik.ToString().Replace(',', '.');
        }
        catch (Exception)
        {
            MessageBox.Show("Error! You have made something wrong.", "Incorrect operation!");
            this.display.Text = "";
        }
    }

    private void Reverse_Click(object sender, RoutedEventArgs e)
    {
        if (this.display.Text.Contains('.'))
        {
            this.display.Text = this.display.Text.Replace('.', ',');
        }

        string liczba = this.display.Text;
        double wynik = 0;
        double.TryParse(liczba, out wynik);
        if (wynik != 0)
        {
            wynik = 1/wynik;
            this.display.Text = wynik.ToString();
                if (wynik.ToString().Length > 9)
                {
                    this.display.Text = wynik.ToString().Replace(',', '.').Substring(0, 9);
                }
            else if (this.display.Text.Contains('.'))
            {
                this.display.Text = wynik.ToString();
            }
        }
        else if (wynik == 0)
        {
            MessageBox.Show("Error! You have made something wrong.", "Incorrect operation!");
            this.display.Text = "";
        }
    }

    private void Power_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (this.display.Text.Contains('.'))
            {
                this.display.Text = this.display.Text.ToString().Replace('.', ',');
            }
            string liczba = this.display.Text;
            double wynik = 0;
            double.TryParse(liczba, out wynik);
            wynik *= wynik;
            this.display.Text = wynik.ToString().Replace(',', '.');
        }
        catch (Exception)
        {
            MessageBox.Show("Error! You have made something wrong.", "Incorrect operation!");
            this.display.Text = "";
        }
    }

    private void Result_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (this.display.Text.Contains("/0"))
            {
                MessageBox.Show("Error! You have made something wrong.", "Incorrect operation!");
                this.display.Text = "";
            }

                DataTable dt = new DataTable();
            var value = dt.Compute(this.display.Text, "");
            this.display.Text = value.ToString();
            if (this.display.Text.Contains(','))
            {
                this.display.Text = value.ToString().Replace(',', '.');
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Error! You have made something wrong.", "Incorrect operation!");
            this.display.Text = "";
        }

    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MinimalizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void Information_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Simple Calculator" +
            "\n\nCreated by Bartosz Jarzynski" +
            "\nat POLITECHNIKA SLASKA" +
            "\n\nGliwice, 2021", "Calculator info");
    }
}
}


/*
    private void _KeyDown(object sender, KeyEventArgs e)
{
    if (e.Key == Key.Enter || e.Key == Key.Tab)
    {
        //YourCode
    }
}
*/