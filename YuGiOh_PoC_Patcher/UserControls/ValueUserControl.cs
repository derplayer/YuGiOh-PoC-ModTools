﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuGiOh_PoC_Patcher.YuGi;
using YuGiOh_PoC_Patcher.YuGi.Values;

namespace YuGiOh_PoC_Patcher
{
    public partial class ValueUserControl : UserControl
    {
        private YuGiValue _value;

        public YuGiValue Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value!= null) UpdateBinding();
            }
        }

        public string ValueText
        {
            get { return label_ValueText.Text; }
            set { label_ValueText.Text = value; }
        }


        public ValueUserControl()
        {
            InitializeComponent();
        }

        private void UpdateBinding()
        {
            _value.PropertyChanged += Value_PropertyChanged;

            if (_value.IsReadOnly)
            {
                numericUpDown_Value.Enabled = false;
            }
            else
            {
                numericUpDown_Value.Enabled = true;
            }

            double length = Math.Pow(2, Value.Length * 8);
            numericUpDown_Value.Maximum = (decimal)length / 2 - 1;
            numericUpDown_Value.Minimum = (decimal)length / 2 * -1;

            switch (Value.Length)
            {
                case 4:
                    numericUpDown_Value.Value = Value.ValueInt32;
                    break;
                case 2:
                    numericUpDown_Value.Value = Value.ValueInt16;
                    break;
                case 1:
                    numericUpDown_Value.Value = Value.ValueUInt8;
                    break;
                default:
                    numericUpDown_Value.Value = 0;
                    break;
            }
            
        }

        private void Value_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (Value.Length)
            {
                case 4:
                    numericUpDown_Value.Value = Value.ValueInt32;
                    break;
                case 2:
                    numericUpDown_Value.Value = Value.ValueInt16;
                    break;
                case 1:
                    numericUpDown_Value.Value = Value.ValueUInt8;
                    break;
                default:
                    numericUpDown_Value.Value = 0;
                    break;
            }
        }

        private void numericUpDown_Value_ValueChanged(object sender, EventArgs e)
        {
            switch (Value.Length)
            {
                case 4:
                    Value.ValueInt32 = (int)numericUpDown_Value.Value;
                    break;
                case 2:
                    Value.ValueInt16 = (short)numericUpDown_Value.Value;
                    break;
                case 1:
                    Value.ValueUInt8 = (byte)numericUpDown_Value.Value;
                    break;
                default:
                    break;
            }
            
        }
    }
}
