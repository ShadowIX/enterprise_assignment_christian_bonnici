using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUnitConverter" in both code and config file together.
    [ServiceContract]
    public interface IUnitConverter
    {
        /// <summary>
        /// Converts from cm to m
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [OperationContract]
        double ConvertCmToM(double num);
        [OperationContract]
        double ConvertMMToM(double num);
        [OperationContract]
        double ConvertDegreesToFahrenheit(double t);
        [OperationContract]
        double ConvertClToL(double cl);
    }
}
