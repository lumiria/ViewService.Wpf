﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.DataTypes;

namespace Sample.ViewModel
{
    internal sealed class UtilityTestViewModel : BaseViewModel
    {
        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        private NumberEnum _radioEnum;
        public NumberEnum RadioEnum
        {
            get => _radioEnum;
            set => Set(ref _radioEnum, value);
        }

        private double _itemLeft;
        public double ItemLeft
        {
            get => _itemLeft;
            set => Set(ref _itemLeft, value);
        }

        private double _itemTop;
        public double ItemTop
        {
            get => _itemTop;
            set => Set(ref _itemTop, value);
        }
    }
}