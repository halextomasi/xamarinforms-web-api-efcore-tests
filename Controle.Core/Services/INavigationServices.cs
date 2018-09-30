﻿using System;
using System.Threading.Tasks;
using Controle.Core.ViewModels.Base;

namespace Controle.Core.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Task NavigateToAsync(Type viewModelType);
        Task NavigateToAsync(Type viewModelType, object parameter);
        Task NavigateBackAsync();
        Task NavigateAndClearBackStackAsync<TViewModel>(object parameter = null) where TViewModel : ViewModelBase;
        Task RemoveLastFromBackStackAsync();
    }
}
