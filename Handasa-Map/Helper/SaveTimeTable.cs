using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handasa_Map.Helper
{
    public class SaveTimeTable
    {
        // get day -- priod -- description -- place
        // save them to local folder
        public void SaveValues(string day, string priod, string description, string place)
        {
            Windows.Storage.ApplicationDataContainer timeTableHolder = Windows.Storage.ApplicationData.Current.LocalSettings;

            // save schema 
            // file name will be like that satarday::first
            // string will be like math::k3  

            timeTableHolder.Values[day + "::" + priod] = description + "::" + place;

        }

        //then it will be called like that 
        // for example if I wanna know what i have in Thursday Third period
        // string descriptionAndPlace = timetableholder.values[Thursday::Third];
        //then we can format descriptionAndPlace string to get the place
    }
}
