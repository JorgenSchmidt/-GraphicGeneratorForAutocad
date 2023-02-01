using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GraphicGeneratorForAutocad.ViewModelService
{
    /// <summary>
    /// Основной класс описания логики отображения информации.
    /// </summary>
    public class NotifyPropertyChanged: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void CheckChanges([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}