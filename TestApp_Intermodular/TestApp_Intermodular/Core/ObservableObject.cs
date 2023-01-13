using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestApp_Intermodular.Core
{
    internal class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //Se utiliza para actualizar el UI durante el Binding

        protected void OnProppertyChanged([CallerMemberName] string name = null) { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
