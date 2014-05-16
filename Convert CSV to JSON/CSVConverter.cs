using System;
using System.Linq;
using System.Text;

namespace Convert_CSV_to_JSON
{
    class CSVConverter
    {
        internal string ConvertToJSON(string csv)
        {
            if(csv == null)
            {
                return null;
            }

            string[] lines = csv.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            string[] headers = lines[0].Split(',');

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("[");

            foreach(string line in lines)
            {
                string[] fields = line.Split(',');

                string[] jsonElements = headers.Zip(fields, (header, field) => string.Format("\"{0}\": \"{1}\"", header, field)).ToArray();

                string jsonObject = "{" + string.Format("{0}", string.Join(",", jsonElements)) + "},";

                stringBuilder.AppendLine(jsonObject);
            }

            int index = stringBuilder.ToString().LastIndexOf(',');

            stringBuilder.Remove(index, 1);
            stringBuilder.AppendLine("]");

            return stringBuilder.ToString();
        }
    }
}
