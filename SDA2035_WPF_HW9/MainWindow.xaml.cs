using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SDA2035_WPF_HW9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox.TextDecorations = null;
            style.IsChecked = false; //Установлен по умолчанию базовый стиль
        }
        private void style_Checked(object sender, RoutedEventArgs e)
        {
            bool styleChecks = style.IsChecked.Value;
            Uri uriTheme = new Uri("LightTheme.xaml", UriKind.Relative);
            Uri uriFonts = new Uri("Dictionary_Fonts.xaml", UriKind.Relative);
            if (styleChecks)
            {
                uriTheme = new Uri("DarkTheme.xaml", UriKind.Relative);
            }
            ResourceDictionary resourceTheme = Application.LoadComponent(uriTheme) as ResourceDictionary;
            ResourceDictionary resourceFonts = Application.LoadComponent(uriFonts) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceTheme);
            Application.Current.Resources.MergedDictionaries.Add(resourceFonts);
        }
        // 1 - Панель: Шрифт и размеры
        #region Font_FamilySize 
        private void ComboBox_SelectionChanged_Font(object sender, SelectionChangedEventArgs e)
        {
            string fontNameCurrent = ((sender as ComboBox).SelectedItem).ToString();
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontNameCurrent);
            }
        }
        private void ComboBox_SelectionChanged_Size(object sender, SelectionChangedEventArgs e)
        {
            int sizeFontCurrent = Convert.ToInt32(((sender as ComboBox).SelectedItem).ToString());
            if (textBox != null)
            {
                textBox.FontSize = sizeFontCurrent;
            }
        }
        #endregion

        #region BoldItalicUnderline
        // 2 - Панель: Выделение текста
        private void Button_Click_Bold(object sender, RoutedEventArgs e)
        {
            string weightFontCurrent = (textBox.FontWeight).ToString();
            if (textBox != null)
            {
                if (weightFontCurrent == "Normal")
                {
                    textBox.FontWeight = System.Windows.FontWeights.Bold;
                }
                else
                {
                    textBox.FontWeight = System.Windows.FontWeights.Normal;
                }
            }
        }

        private void Button_Click_Italic(object sender, RoutedEventArgs e)
        {
            string styleFontCurrent = (textBox.FontStyle).ToString();
            if (textBox != null)
            {
                if (styleFontCurrent == "Normal")
                {
                    textBox.FontStyle = System.Windows.FontStyles.Italic;
                }
                else
                {
                    textBox.FontStyle = System.Windows.FontStyles.Normal;
                }
            }
        }

        private void Button_Click_Underline(object sender, RoutedEventArgs e)
        {
            bool underlineFontCurrent;
            if (textBox.TextDecorations == null)
            {
                underlineFontCurrent = false;
            }
            else
            {
                underlineFontCurrent = true;
            }

            if (textBox != null)
            {
                if (!underlineFontCurrent)
                {
                    textBox.TextDecorations = TextDecorations.Underline;
                }
                else
                {
                    textBox.TextDecorations = null;
                }
            }
        }
        #endregion

        #region Text_Color
        // 3 - Панель: Цвет текста
        private void RadioButton_Checked_Black(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Checked_Red(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }
        #endregion

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }
    }
}
