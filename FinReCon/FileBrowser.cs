using Microsoft.Win32;
using System;

namespace FinReCon
{
    public class FileBrowser
    {
        // This is effectively the "Browse for file" function used 
        // to select a CSV file. The type is locked to prohibit any 
        // unwanted formats. The local path is returned as string.
        public static string BrowseFile()
        {
            // Calls the 'Open File Dialog' class
            String path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Sets file type selection to only accept .csv files
            openFileDialog.DefaultExt = ".csv";                     
            openFileDialog.Filter = "Text files (*.csv)|*.csv";     

            // Sets the default folder for the browse function
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Sets the default folder for the browse function
            
            if (openFileDialog.ShowDialog() == true)
            {
                // Opens document and commits the path to a string
                string filename = openFileDialog.FileName;
                path = filename;
            }

            // Returns the file path as a string
            return path;

        }

    }
}
