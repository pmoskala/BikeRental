﻿using BikeRental.Notifications;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BikeRental.ViewModels
{
    public class MainViewModel : Screen
    {
        //uchwyt referencji event aggregatora
        private readonly IEventAggregator _eventAggregator;
        private string _roomNumber;

        public MainViewModel(IEventAggregator eventAggregator)
        {
            //referencja eventAggregatora
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        #region public properties
        public string RoomNumber
        {
            get
            {
                return _roomNumber;
            }
            set
            {
                if(_roomNumber!=value)
                {
                    _roomNumber = value;
                    NotifyOfPropertyChange(() => RoomNumber);  
                    if(_roomNumber.Length!=3)
                    {
                        ButtonEnableState = true;
                    }
                    else
                    {
                        ButtonEnableState = false;
                        SelectRoom();
                    }
                }
            }
        }   
          
        private void SelectRoom()
        {
            var _simpleMessage = new SimpleMessageBox();
            _simpleMessage.ShowMessage("Hi", "OK");

        }

        private bool _buttonEnableState = true;
        public bool ButtonEnableState
        {
            get
            {
                return _buttonEnableState;
            }
            set
            {
                _buttonEnableState = value;
                NotifyOfPropertyChange(() => ButtonEnableState);
            }
        }
        #endregion

        #region button bindings
        public void AddNumber(string number)
        {           
            if (number.Length>0)
            {
                RoomNumber += number;
            }           
        }
        public void ClearNumber()
        {
            RoomNumber = "";
        }
        #endregion
    }
}
