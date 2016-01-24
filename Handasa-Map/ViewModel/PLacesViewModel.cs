using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handasa_Map.Model;
using System.ComponentModel;

namespace Handasa_Map.ViewModel
{
    public class PlacesViewModel : INotifyPropertyChanged
    {

        public PlacesViewModel()
        {
            Places = new ObservableCollection<Place>();
            //seeding some data for test purpose
            for (int i = 0; i < 40; i++)
            {
                AllPlaces.Add(new Place() { Name = "l4", Building = "e3dady", Floor = "first", Description = "Don't go there" });
                AllPlaces.Add(new Place() { Name = "k6", Building = "khraba", Floor = "second", Description = "Don't go there, also" });
            }

            PreformFiltering();
        }

        //All Places to be filtered
        public List<Place> AllPlaces = new List<Place>();

        public event PropertyChangedEventHandler PropertyChanged;

        //PLaces to Bound to..
        public ObservableCollection<Place> Places { get; set; }

        // used to search for a place
        private string _filter;

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value == _filter)
                    return;

                _filter = value;
                RaisePropertyChanged("Filter");
                PreformFiltering();
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //used to filter the places list
        private void PreformFiltering()
        {
            if (_filter == null)
                _filter = "";


            var lowerCaseFilter = Filter.ToLower().Trim();
            var result =
                AllPlaces.Where(d => d.Name.ToLower()
                .Contains(lowerCaseFilter)).ToList();

            var toRemove = Places.Except(result).ToList();

            foreach (var x in toRemove)
                Places.Remove(x);


            var resultCount = result.Count;
            for (int i = 0; i < resultCount; i++)
            {
                var resultItem = result[i];
                if (i + 1 > Places.Count || !Places[i].Equals(resultItem))
                    Places.Insert(i, resultItem);

            }
        }


    }
}
