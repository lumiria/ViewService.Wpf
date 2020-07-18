using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sample.Model
{
    public sealed class SampleModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private string _inputFile;
        public string InputFile
        {
            get => _inputFile;
            set => Set(ref _inputFile, value);
        }

        private string _outputFolder;
        public string OutputFolder
        {
            get => _outputFolder;
            set => Set(ref _outputFolder, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Save(string file)
        {
        }

        private bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
