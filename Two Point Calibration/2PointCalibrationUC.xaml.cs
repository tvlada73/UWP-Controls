using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace LabiMS.Controls
{
    public class CalibrationEventArgs : EventArgs
    {
        public string Temperatura { get; set; }
    
        public CalibrationEventArgs(string _Temperatura) : base()
        {
            Temperatura = _Temperatura;
        }
    }

    public sealed partial class _2PointCalibrationUC : UserControl
    {
        public string CurrentTemperature
        {
            get { return GetValue(CurrentTemperatureProperty) as string; }
            set { SetValue(CurrentTemperatureProperty, value); }
        }
        public static readonly DependencyProperty CurrentTemperatureProperty = DependencyProperty.Register("CurrentTemperature", typeof(string), typeof(_2PointCalibrationUC), new PropertyMetadata(null));


        public string Header
        {
            get { return GetValue(HeaderProperty) as string; }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(_2PointCalibrationUC), new PropertyMetadata(null));


        public _2PointCalibrationUC()
        {
            this.InitializeComponent();
            keyboard.RegisterTarget(TxbT1min);
            keyboard.RegisterTarget(TxbT2max);
        }

        public event EventHandler<CalibrationEventArgs> ClickT1;
        public event EventHandler<CalibrationEventArgs> ClickT2;

        private void SaveT1Click(object sender, RoutedEventArgs e) => ClickT1?.Invoke(this, new CalibrationEventArgs(TxbT1min.Text));
        private void SaveT2Click(object sender, RoutedEventArgs e) => ClickT2?.Invoke(this, new CalibrationEventArgs(TxbT2max.Text));
    }
}
