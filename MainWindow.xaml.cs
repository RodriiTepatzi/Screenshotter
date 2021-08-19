using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GlobalHotkeys;

namespace Screenshotter
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string folderOutput;
        private Boolean singleKeyActive = false;
        private Int32 key_1;

        KeyboardHookManager keyboardHookManager = new KeyboardHookManager();

        public MainWindow()
        {
            InitializeComponent();
            ApplySettings();


            keyboardHookManager.Start();

            keyboardHookManager.RegisterHotkey(key_1, () =>
            {
                Debug.WriteLine("NumPad0 detected");
            });
            keyboardHookManager.RegisterHotkey(GlobalHotkeys.ModifierKeys.Control, key_1, () =>
            {
                Debug.WriteLine("Ctrl+NumPad0 detected");
            });
        }
        private void ApplySettings()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Keys));
            key_1 = (Int32) KeyInterop.VirtualKeyFromKey((Key)converter.ConvertFromString(Properties.Settings.Default.Hotkey_1));
            Console.WriteLine(key_1);
        }

        private void CapturarImagen()
        {
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                               Screen.PrimaryScreen.Bounds.Height))
            using (Graphics g = Graphics.FromImage(bmpScreenCapture))
            {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 bmpScreenCapture.Size,
                                 CopyPixelOperation.SourceCopy);
                bmpScreenCapture.Save("test.jpg", ImageFormat.Jpeg);
                Console.WriteLine("xd");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            keyboardHookManager.UnregisterAll();
        }

        private void takepic_Click(object sender, RoutedEventArgs e)
        {
            CapturarImagen();
        }

        private void selectFolderBtn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                folderOutput = folderBrowserDialog.SelectedPath;
                selectedFolderLabel.Content = folderOutput;
                selectedFolderLabel.ToolTip = folderOutput;
            }
        }

        private void selectedFolderLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectFolderBtn.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent));
        }

        private void singleKeyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (singleKeyActive)
            {
                singleKeyActive = false;
                keyMessage.Content = "";
            }
            else if(!singleKeyActive)
            {
                singleKeyActive = true;
                keyMessage.Content = "Presione una tecla.";
            }
        }

        private void singleKeyBtn_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (singleKeyActive)
            {
                singleKeyActive = false;
                singleKeyBtn.Content = e.Key;
                keyMessage.Content = "";
            }
        }
    }
}
