using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UnitConverter" in both code and config file together.
   

    public class UnitConverter : IUnitConverter
    {
 
      
        public double ConvertCmToM(double num)
        {
            return num / 100;
        }
        public double ConvertMMToM(double num)
        {
            return num / 1000;
        }

        public double ConvertDegreesToFahrenheit(double t)
        {
            return t *   1.8 + 32;
        }




        public double ConvertClToL(double cl)
        {
            return cl / 100;    

        }
    }
}
