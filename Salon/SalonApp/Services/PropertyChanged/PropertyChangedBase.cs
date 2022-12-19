using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SalonApp.Services.PropertyChanged
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        protected virtual bool Set<T>(ref T field,T value, [CallerMemberName] string prop = null)
        {
            if (Equals(field, value))
                return false;
            else
            {
                field = value;
                OnPropertyChanged(prop);
                return true;
            }
        }
        public virtual void Dispose() { }
    }
}
