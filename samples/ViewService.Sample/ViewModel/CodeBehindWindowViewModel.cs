using System.Windows.Input;
using Lumiria.ViewServices;
using Sample.Model;

namespace Sample.ViewModel
{
    public sealed class CodeBehindWindowViewModel : BaseViewModel
    {
        private readonly SampleModel _model;

        public CodeBehindWindowViewModel()
        {
            _model = new SampleModel();

            _model.PropertyChanged += (_, e) =>
               OnPropertyChanged(e.PropertyName);
        }

        public string Name
        {
            get => _model.Name;
            set => _model.Name = value;
        }

        public string InputFile
        {
            get => _model.InputFile;
            set => _model.InputFile = value;
        }

        private IWindowActionService WindowActionService =>
            ViewServiceProvider.Get<IWindowActionService>();

        private IMessageBoxService MessageBoxService =>
            ViewServiceProvider.Get<IMessageBoxService>();

        private IOpenFileDialogService OpenFileDialogService =>
            ViewServiceProvider.Get<IOpenFileDialogService>();

        private ISaveFileDialogService SaveFileDialogService =>
            ViewServiceProvider.Get<ISaveFileDialogService>();

        private RelayCommand _openFileCommand;
        public ICommand OpenFileCommand =>
            _openFileCommand ?? (_openFileCommand = new RelayCommand(
                () =>
                {
                    var (result, fileName, _) = OpenFileDialogService.ShowDialog(
                        filter: "Text file|*.txt|All Files|*.*",
                        filterIndex: 0
                        );
                    if (result)
                    {
                        InputFile = fileName;
                    }
                }));

        private RelayCommand _saveFileCommand;
        public ICommand SaveFileCommand =>
            _saveFileCommand ?? (_saveFileCommand = new RelayCommand(
                () =>
                {
                    var (result, fileName, _) = SaveFileDialogService.ShowDialog(
                        filter: "Text file|*.txt|All Files|*.*",
                        filterIndex: 0
                        );
                    if (result)
                    {
                        _model.Save(fileName);
                    }
                }));

        private RelayCommand _closeCommand;
        public ICommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new RelayCommand(
                () =>
                {
                    var result = MessageBoxService.Show("Do you want to save?");

                    WindowActionService.Close();
                }));
    }
}
