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
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace gallery
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.LoadImageFilePaths();
            Application.Current.Exit += Current_Exit;
        }

        private void Current_Exit(object sender, ExitEventArgs e)
        {
            ViewModel.SaveImageFilePaths();
        }
    }



    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();
    }

    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public partial class MainWindow : Window
    {
        public class ImageModel : ObservableObject
        {
            private string _filePath;
            public string FilePath
            {
                get => _filePath;
                set => SetProperty(ref _filePath, value);
            }
        }

        public class MainViewModel : ObservableObject
        {
            public ObservableCollection<ImageModel> Images { get; set; } = new ObservableCollection<ImageModel>();
            public ImageModel SelectedImage { get; set; }

            public ICommand AddImageCommand => new RelayCommand(AddImage);

            public ICommand DeleteImageCommand => new RelayCommand(DeleteImage, CanDeleteImage);

            private bool CanDeleteImage()
            {
                return SelectedImage != null;
            }

            private void DeleteImage()
            {
                Images.Remove(SelectedImage);
            }

            private void AddImage()
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    Images.Add(new ImageModel { FilePath = openFileDialog.FileName });
                }
            }
            public void SaveImageFilePaths()
            {
                List<string> filePaths = Images.Select(image => image.FilePath).ToList();

                using (FileStream fs = new FileStream("imagePaths.dat", FileMode.Create))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<string>));
                    serializer.WriteObject(fs, filePaths);
                }
            }

            public void LoadImageFilePaths()
            {
                if (File.Exists("imagePaths.dat"))
                {
                    using (FileStream fs = new FileStream("imagePaths.dat", FileMode.Open))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(List<string>));
                        List<string> filePaths = (List<string>)serializer.ReadObject(fs);

                        foreach (string filePath in filePaths)
                        {
                            Images.Add(new ImageModel { FilePath = filePath });
                        }
                    }
                }
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel.SelectedImage != null)
            {
                SelectedImageView.Source = new BitmapImage(new Uri(ViewModel.SelectedImage.FilePath));
                FileInfo fileInfo = new FileInfo(ViewModel.SelectedImage.FilePath);
                ImageInfoLabel.Content = $"Name: {fileInfo.Name}\nSize: {fileInfo.Length} bytes\nResolution: {GetImageResolution(ViewModel.SelectedImage.FilePath)}";
            }
        }

        private string GetImageResolution(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();

            return $"{bitmap.PixelWidth}x{bitmap.PixelHeight}";
        }

        public MainViewModel ViewModel { get; } = new MainViewModel();
    }
}