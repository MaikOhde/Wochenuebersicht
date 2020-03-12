﻿using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace wochenuebersicht_2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Wochenansicht> KW_Week { get; set; }
        public ObservableCollection<DayViewList> DayList { get; set; }

        public string CurrentWeek { get; set; }
    

        // Button Command to oben Days for Selected Week
        public ICommand Open_KW { get; set; }

        public int Selected_KW_Idx { get; set; }

        // make a weekly list for the year (Range 1 => 52)
        public void CreatWeeks()
        {
            IEnumerable<int> weekRange = Enumerable.Range(1, 52);

            foreach (int kw_num in weekRange)
            {
                KW_Week.Add(new Wochenansicht() {  Woche = " Woche " + kw_num });
            }
        }

        public void CreatDay()
        {
            IEnumerable<int> dayRange = Enumerable.Range(0, 5);

            string[] days = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag" };

            foreach (int range in dayRange)
            {
                DayList.Add(new DayViewList() { WeekDay = days[range] });
            }
        }

        // ToDo Daten Binden
        private void Open_Day()
        {
            Wochenansicht e = KW_Week[Selected_KW_Idx];
            string pstring = JsonConvert.SerializeObject(e);
            Debug.WriteLine("Hallo");
            Debug.WriteLine(pstring);
            Debug.WriteLine(Selected_KW_Idx);

           
        }

        

        // MainViewModel
        public MainViewModel()
        {
            KW_Week = new ObservableCollection<Wochenansicht>();
            DayList = new ObservableCollection<DayViewList>();
            Open_KW = new RelayCommand(Open_Day, () => true);

            
            CreatWeeks();
            CreatDay();
          
        }

       

      
    }
}