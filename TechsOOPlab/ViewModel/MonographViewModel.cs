﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using TechsOOPlab.Annotations;

namespace TechsOOPlab.ViewModel
{
    public class MonographViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}