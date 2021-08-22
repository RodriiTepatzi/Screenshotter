using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        NotifyIcon notifyIcon = new NotifyIcon();

        private Key Key1, Key2;
        private string folderOutput;
        private Boolean singleKeyActive = false;
        private int virtualKey1;
        private string path;
        private bool simpleMode = true;

        private System.Windows.Controls.ContextMenu contextMenu = new System.Windows.Controls.ContextMenu();
        private System.Windows.Controls.MenuItem menuItem = new System.Windows.Controls.MenuItem();

        private bool sound;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern short VkKeyScan(Key key);

        KeyboardHookManager keyboardHookManager = new KeyboardHookManager();

        public MainWindow()
        {
            InitializeComponent();
            ApplySettings();
            keyboardHookManager.Start();
        }
        private void ApplySettings()
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Key));

            Key1 = (Key)converter.ConvertFromString(Properties.Settings.Default.Hotkey_1);

            virtualKey1 = KeyInterop.VirtualKeyFromKey(Key1);

            singleKeyBtn.Content = Properties.Settings.Default.Hotkey_1;
            path = Properties.Settings.Default.Path;
            sound = Properties.Settings.Default.Sound;
            notifyIcon.Icon = Properties.Resources.camera_ico;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Salir", null, menuItem1_Click);

            modeToggle.Checked += modeToggle_Checked;
            modeToggle.Unchecked += modeToggle_Unchecked;
            modeToggle.IsChecked = Properties.Settings.Default.Mode;

            RegisterKeys();

            if (string.IsNullOrEmpty(path))
            {
                selectedFolderLabel.Content = "Selecciona una ruta.";
                selectedFolderLabel.ToolTip = "Selecciona una ruta.";
            }
            else
            {
                selectedFolderLabel.Content = path;
                selectedFolderLabel.ToolTip = path;
            }

            if (sound)
            {
                soundToggle.IsChecked = true;
            }
            else
            {
                soundToggle.IsChecked = false;
            }
        }

        private void CapturarImagen()
        {
            CheckPath();
            string filename = path + "\\" + DateTime.Now.ToString("dd-MMMM-yyyy HH-mm") + ".jpg";
            //Console.WriteLine(filename);
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                               Screen.PrimaryScreen.Bounds.Height))
            using (Graphics g = Graphics.FromImage(bmpScreenCapture))
            {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                 Screen.PrimaryScreen.Bounds.Y,
                                 0, 0,
                                 bmpScreenCapture.Size,
                                 CopyPixelOperation.SourceCopy);
                bmpScreenCapture.Save(filename, ImageFormat.Jpeg);
            }
            PlaySound();
        }

        private void PlaySound()
        {
            if (sound)
            {
                Stream str = Properties.Resources.photoSound;
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                snd.Play();
            }
        }

        private void CheckPath()
        {
            if (Directory.Exists(path))
            {
                //Something here :p
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void selectFolderBtn_Click(object sender, RoutedEventArgs e)
        {
            UnregisterKeys();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                folderOutput = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Path = folderOutput;
                Properties.Settings.Default.Save();
                selectedFolderLabel.Content = folderOutput;
                selectedFolderLabel.ToolTip = folderOutput;
            }
            RegisterKeys();
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
            UnregisterKeys();
            if (singleKeyActive)
            {
                singleKeyActive = false;
                singleKeyBtn.Content = e.Key;
                keyMessage.Content = "";
                virtualKey1 = KeyInterop.VirtualKeyFromKey(e.Key);
                Properties.Settings.Default.Hotkey_1 = e.Key + "";
                Properties.Settings.Default.Save();
            }
            RegisterKeys();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!singleKeyActive)
            {
                Keyboard.ClearFocus();
            }
        }

        private void soundToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            sound = false;
            Properties.Settings.Default.Sound = false;
            Properties.Settings.Default.Save();
        }

        private void soundToggle_Checked(object sender, RoutedEventArgs e)
        {
            sound = true;
            Properties.Settings.Default.Sound = true;
            Properties.Settings.Default.Save();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

            keyboardHookManager.UnregisterAll();
        }

        private void UnregisterKeys()
        {
            keyboardHookManager.UnregisterAll();
        }

        private void RegisterKeys()
        {
            if (virtualKey1 != 0 && simpleMode)
            {
                UnregisterKeys();
                keyboardHookManager.RegisterHotkey(virtualKey1, () =>
                {
                    CapturarImagen();
                });
            }
            else if (virtualKey1 != 0 && !simpleMode)
            {
                UnregisterKeys();
                keyboardHookManager.RegisterHotkey(GlobalHotkeys.ModifierKeys.Control, virtualKey1, () =>
                {
                    CapturarImagen();
                });
            }
        }

        private void modeToggle_Checked(object sender, RoutedEventArgs e)
        {
            singleKeyBtn.Margin = new Thickness(10, 29, 0, 0);
            ctrlKey_btn.Visibility = Visibility.Hidden;
            simpleMode = true;
            RegisterKeys();
        }

        private void modeToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            singleKeyBtn.Margin = new Thickness(67, 29, 0, 0);
            ctrlKey_btn.Visibility = Visibility.Visible;
            simpleMode = false;
            RegisterKeys();
        }

        private void notifyIcon_DoubleClick(object Sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            this.Show();
            this.WindowState = WindowState.Normal;
        }

        private void menuItem1_Click(object Sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            System.Windows.Application.Current.Shutdown();
        }
    }
}
