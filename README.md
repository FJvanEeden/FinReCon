## Financial reconciliation

##### A functional financial reconciliation project that compares / reconciles two loaded CSV Files.

The goal of this project was to create an application that:

* Select local CSV files
* Simple compare the two selected files
  * Find partial matches where records cant compare 1:1
  * Find all unmatchable records that cant be simply or partially matched
* Display records that dont match

#### User guide
##### Main window
The entire application is currently displayed on a single window. (Subject to change)

![Main](screenshots/Main_2.png)

The first step would be to use the browse function to retrieve the local CSV files.

![LoadCSV](screenshots/LoadCSV.png)

![LoadCSV_2](screenshots/LoadCSV_2.png)

Once the files are selected, click the "Compare" button to start the reconciliation process.

Comparison information will be displayed at the bottom of the window.

![ComparisonInformation_2](screenshots/ComparisonInformation_2.png)

The two selected files will be compared and all records that cant be matched 1:1 will be displayed in their respective table.

![SelectedFilesData_2](screenshots/SelectedFilesData_2.png)

These lists are then compared again to find any partial match within the lists. The result will be displayed in its respective table.

![Unmatchable_2](screenshots/Unmatchable_2.png)

This table will display all records that have no found matches, 1:1 or partial.

