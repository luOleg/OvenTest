using Microsoft.Win32;
using Newtonsoft.Json;
using OvenTest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace OvenTest.ViewModel
{
    public class FlightsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Flight> Flights { get; set; }


        public ICommand LoadJsonCommand { get; set; }

        public FlightsVM()
        {
            LoadJsonCommand = new RelayCommand(LoadJson);
        }


        private void LoadJson()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                var json = File.ReadAllText(openFileDialog.FileName);

                var flights = JsonConvert.DeserializeObject<List<Flight>>(json);
                Flights = new ObservableCollection<Flight>(flights);
            }
            OnPropertyChanged("Flights");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
