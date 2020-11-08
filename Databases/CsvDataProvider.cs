using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Databases
{
    public class CsvDataProvider
    {
        public IList<UserDataItem> GetUserData()
        {
            var strData = File.ReadAllText("data\\data.csv");
            var strDataSet = strData.Split(Environment.NewLine).ToList();
            strDataSet.RemoveAt(0);
            List<UserDataItem> data = new List<UserDataItem>();

            foreach (var dataString in strDataSet)
            {
                var convertedData = GetDataFromString(dataString);
                data.Add(convertedData);
            }

            return data;
        }

        public IList<UserAgeItem> GetAgeData()
        {
            var strData = File.ReadAllText("data\\user_age.csv");
            var strDataSet = strData.Split(Environment.NewLine).ToList();
            strDataSet.RemoveAt(0);
            List<UserAgeItem> data = new List<UserAgeItem>();

            foreach (var dataString in strDataSet)
            {
                var convertedData = GetUserAgeFromString(dataString);
                data.Add(convertedData);
            }

            return data;
        }

        private UserDataItem GetDataFromString(string dataLine)
        {
            var lineParts = dataLine.Split(',');
            return new UserDataItem(int.Parse(lineParts[0]), lineParts[1], lineParts[2], lineParts[3], lineParts[4], lineParts[5]);
        }

        private UserAgeItem GetUserAgeFromString(string dataLine)
        {
            var lineParts = dataLine.Split(',');
            return new UserAgeItem(int.Parse(lineParts[0]), int.Parse(lineParts[1]));
        }
    }
}
