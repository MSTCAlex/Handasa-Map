
namespace Handasa_Map.Helper
{
    /// <summary>
    /// Save user's time table to local settings
    /// </summary>
    public class SaveTimeTable
    {
        /// <summary>
        /// Method to actually save the values
        /// </summary>
        /// <param name="day">get the day</param>
        /// <param name="priod">get the priod</param>
        /// <param name="description">get the description</param>
        /// <param name="place">get the place</param>
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



        /// <summary>
        /// first we get day/priod data 
        /// </summary>
        /// <param name="day">Day that you want</param>
        /// <param name="priod">Priod that you want</param>
        /// <returns>priod data formatted like description::place</returns>
        public string GetPriodData(string day, string priod)
        {

            //extract data from local settings
            Windows.Storage.ApplicationDataContainer timetableHolder = Windows.Storage.ApplicationData.Current.LocalSettings;
            string priodData = timetableHolder.Values[day + "::" + priod] as string;

            if (priodData == null)
            {
                return null;
            }

            return priodData;
        }


        //then we format priod data to get description and place
           // --- GET Description
        public string description(string priodData)
        {
            string[] data = priodData.Split(new string[] { "::" },System.StringSplitOptions.None);
            return data[0];
        }

           // --- GET Place
        public string place(string priodData)
        {
            string[] data = priodData.Split(new string[] { "::" }, System.StringSplitOptions.None);
            return data[1];
        }


        // DELETE Priod Data
        public void deletePriodData(string day, string priod)
        {
            Windows.Storage.ApplicationDataContainer timeTableHolder = Windows.Storage.ApplicationData.Current.LocalSettings;
            timeTableHolder.Values.Remove(day + "::" + priod);
        }


    }
}
