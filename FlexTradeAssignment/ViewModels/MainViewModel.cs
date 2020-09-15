using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccess;
using FlexTradeAssignment.Services;
using Models;

namespace FlexTradeAssignment.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DataProvider _dP;
        private SecurityModel _selected;
        private SecurityModel _selectedOnGrid;
        private ICommand _addCommand;
        private ICommand _deleteCommand;
        
        public MainViewModel()
        {
            _dP = new DataProvider();
            Securities = new ObservableCollection<SecurityModel>(_dP.GetSecuritiesList());
            SecuritiesOnGrid = new ObservableCollection<SecurityModel>();
        } 

        public ObservableCollection<SecurityModel> Securities { get; }

        public ObservableCollection<SecurityModel> SecuritiesOnGrid { get; set; }

        public SecurityModel Selected
        {
            get => _selected;
            set
            {
                if (value != _selected)
                {
                    _selected = value;
                    OnPropertyChanged(nameof(Selected));
                }
            }
        }
        public SecurityModel SelectedOnGrid
        {
            get => _selectedOnGrid;
            set
            {
                if (value != _selectedOnGrid)
                {
                    _selectedOnGrid = value;
                    OnPropertyChanged(nameof(SelectedOnGrid));
                }
            }
        }

        public ICommand AddCommand => _addCommand ?? (_addCommand = new ReusableCommand(AddExecute, CanAdd));

        public ICommand DeleteCommand => _deleteCommand ??
                                         (_deleteCommand = new ReusableCommand(DeleteExecute,
                                             () => SelectedOnGrid != null));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool CanAdd()
        {
            return Selected != null;
        }

        public void AddExecute()
        {
            SecuritiesOnGrid.Add(Selected);
        }

        public void DeleteExecute()
        {
            SecuritiesOnGrid.Remove(SelectedOnGrid);
            SelectedOnGrid = SecuritiesOnGrid.FirstOrDefault();
        }
    }
}
