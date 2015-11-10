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


        //first we get day/priod data
        public string priodData(string day, string priod)
        {

            //extract data from local settings
            Windows.Storage.ApplicationDataContainer timetableHolder = Windows.Storage.ApplicationData.Current.LocalSettings;
            string priodData = timetableHolder.Values[day + "::" + priod] as string;

            if (priodData == null)
            {
                return "You have nothing in this priod";
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

