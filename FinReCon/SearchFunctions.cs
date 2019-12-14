using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinReCon
{
    public class SearchFunctions
    {
        public static DataTable readToDataTable(List<string> dataString, string headerLine)
        {
            // This code was an approach i was testing to 
            // dynamically populate DataTable headers. However 
            // due to time contraints, i opted to rather focus 
            // on proof of concept.

                //string[] headerArray = new string[] {""};
                //string[] columnDataValues = new string[] { "" };
                //string listStringTemp;

                //headerArray = headerLine.Split(',');
                //listStringTemp = string.Join("\n", dataString.ToArray());
                //columnDataValues = listStringTemp.Split(',');

                //foreach (var header in headerArray)
                //{
                //    dt.Columns.Add(header);
                //}

            DataTable dt = new DataTable("MyDataTable");
            dt.Columns.Add("MyColumn");
            foreach (string value in dataString)
            {
                //DataRow row = dt.NewRow();
                dt.Rows.Add(value);
            }
            return dt;
        }

        // Gets "WalletReference" field from data string to act as compare 
        // point between rows since it is a unique value.
        public static string GetID(string inputData)
        {
            // Reads all data from final string index
            // per row till the delimiter is found.

            string delimiter = ",";

            int posA = inputData.LastIndexOf(delimiter);
            if (posA == -1)
            {
                return "";
            }

            int adjustedPosA = posA + delimiter.Length;
            if (adjustedPosA >= inputData.Length)
            {
                return "";
            }
            return inputData.Substring(adjustedPosA);
        }

        // Trims kvp.keys to remove unused delimiters
        public static string dataTrimmer(string keyInput)
        {
            string convertedKey = (keyInput.Trim(','));

            return convertedKey;
        }

        // Displays unmatchable items that cannot be partially matched to other records
        public static List<string> noMatchingItem(List<string> listA, List<string> listB)
        {
            // The "WalletReference" field is used as a unique ID 
            // to find all other occurrences of the ID within  the 
            // lists provided. The items are then removed from lists 
            // and displayed for quick reference.

            List<string> finalList = new List<string>();

            string listAItemID = "";
            
            foreach (string value in listB.ToList())
            {

                listAItemID = GetID(value);

                if (listAItemID != "0")
                {
                    
                    listB.RemoveAll(u => u.Contains(listAItemID));
                    listA.RemoveAll(u => u.Contains(listAItemID));
                }
                else
                {
                    continue;
                }
            }

            finalList.AddRange(listA);
            finalList.AddRange(listB);

            return finalList;
        }
    }
}
