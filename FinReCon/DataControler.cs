using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FinReCon
{
    public class DataControler
    {
        public static string firstSelectedPath = "null";
        public static string secondSelectedPath = "null";

        public static void DataProcessor()
        {
            // This process will compare the contents of two selected  
            // files to find any records that are in one file but not 
            // in the other file.

            Dictionary<string, int> Comparer = new Dictionary<string, int>();
            string line;
            string headerLineA = "No Headers available";
            string headerLineB = "No Headers available";
            int countA = 0;
            int countB = 0;

            // Load the first file into the dictionary
            if(firstSelectedPath == "null")
            {
                // Error message if path string is empty
                MessageBox.Show("ERR: first null\n No path designated for second CSV.");
            } else
            {
                var firPath = firstSelectedPath;
                
                // Reads CSV file line by line and compares the loaded data 
                // of the dictionary to find matching strings, removing if 
                // found. This approach removes the need to order the records.

                using var firstFileStream = new FileStream(firPath, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(firstFileStream))
                {
                    headerLineA = sr.ReadLine();
                    while (sr.Peek() >= 0)
                    {
                        countA++;
                        line = sr.ReadLine();
                        if (Comparer.ContainsKey(line))
                        {
                            Comparer[line]++;
                        }
                        else
                        {
                            Comparer[line] = 1;
                        }
                    }
                }
            }

            // Positive values within the dictionary points to a 
            // record found in the first file (A) & and a negative 
            // value points at the second file (B)


            // Load the second file, hopefully zeroing out the dictionary values
            if(secondSelectedPath == "null")
            {
                // Error message if path string is empty
                MessageBox.Show("ERR: second null\n No path designated for second CSV.");
            } else
            {
                var secPath = secondSelectedPath;

                using var secondFileStream = new FileStream(secPath, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(secondFileStream))
                {
                    headerLineB = sr.ReadLine();
                    while (sr.Peek() >= 0)
                    {
                        countB++;
                        line = sr.ReadLine();
                        if (Comparer.ContainsKey(line))
                        {
                            Comparer[line]--;
                        }
                        else
                        {
                            Comparer[line] = -1;
                        }
                    }
                }
            }

            // List count for any mismatches
            int mismatches = 0;

            // count removels in the loops
            int loopAMatches = 0;
            int loopBMatches = 0;
            int countFinalRecords = 0;

            // New lists are created to store the new data sets.
            List<string> dataListA = new List<string>();
            List<string> dataListB = new List<string>();
            List<string> dataListFinal = new List<string>();

            foreach (KeyValuePair<string, int> kvp in Comparer)
            {
                if (kvp.Value != 0)
                {
                    mismatches++;
                    // countFinalRecords++;

                    // Determains whether item was loaded from list A or B,
                    // and then combines item with list origin designation.
                    string InWhich = kvp.Value > 0 ? "A" : "B";
                    string test = InWhich + " : " + kvp.Key;
                    
                    // *** Insert counters ***
                    int listCount = dataListFinal.Count;

                    // Splits items into seperate lists by designation.
                    if (InWhich == "A")
                    {
                        loopAMatches++;
                        dataListA.Add(SearchFunctions.dataTrimmer(test));
                    } 
                    else if (InWhich == "B")
                    {
                        loopBMatches++;
                        dataListB.Add(SearchFunctions.dataTrimmer(test));
                    } 
                    
                }
            }
            // Insert line of headers into lists
            dataListA.Insert(0, headerLineA);
            dataListB.Insert(0, headerLineB);

            // Note: This could be improved on, since lists display as one colomn,
            // instead of celled items.
            // Adds lists to data table.
            DataTable listADataTable = SearchFunctions.readToDataTable(dataListA, headerLineA);
            MainWindow.AppWindow.dataGridListA.SetBinding(ItemsControl.ItemsSourceProperty, 
                new System.Windows.Data.Binding { Source = listADataTable });

            DataTable listBDataTable = SearchFunctions.readToDataTable(dataListB, headerLineB);
            MainWindow.AppWindow.dataGridListB.SetBinding(ItemsControl.ItemsSourceProperty, 
                new System.Windows.Data.Binding { Source = listBDataTable });


            // Creates combined list of all entries with no close matches,
            // then adds lists to data table.
            dataListFinal = SearchFunctions.noMatchingItem(dataListA, dataListB);

            countFinalRecords = dataListFinal.Count();

            var text = string.Join(Environment.NewLine, dataListFinal);
            MainWindow.AppWindow.unmatchedResualtsTextBox.AppendText(text);

            DataTable listFinalDataTable = SearchFunctions.readToDataTable(dataListFinal, headerLineA);
            MainWindow.AppWindow.unmatchableResuaktsDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, 
                new System.Windows.Data.Binding { Source = listFinalDataTable });


            if (mismatches == 0)
            {
                // Or display to text box
                // MainWindow.AppWindow.UpdateTextBoxListA("No mismatches found");

                MessageBox.Show("No mismatches found");
            }

            MainWindow.AppWindow.UpdateTextBoxListA("Total records : " + countA + "\n" + "Total Unmatched records : " + loopAMatches);
            MainWindow.AppWindow.UpdateTextBoxListB("Total records : " + countB + "\n" + "Total Unmatched records : " + loopBMatches);
            MainWindow.AppWindow.UpdateTextBoxListFinal("Total unmatchable records : " + countFinalRecords);

            // Clears components memory
            Comparer.Clear();
            Comparer = null;
        }
    }
}
