using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static float getFloatFromString(string str)
        {
            float retVal;
            try
            {
                retVal = System.Convert.ToInt32(str);
            }
            catch
            {
                retVal = 0.0f;
            }
            return retVal;
        }
    }
}
