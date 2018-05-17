Runspace Sample 08
==========================
     This sample shows how to use a PowerShell object to run commands. The  
     PowerShell object builds a pipeline that include the get-process cmdlet, 
     which is then piped to the sort-object cmdlet. Parameters are added to the 
     sort-object cmdlet to sort the HandleCount property in descending order.

     For Windows PowerShell information on MSDN, 
     see http://go.microsoft.com/fwlink/?LinkID=178145 


===============================
     This sample is available in the following language implementations:
     - C#

To build the sample using Visual Studio:
=======================================
     1. Open Windows Explorer and navigate to Runspace08 under the samples directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     The library will be built in the default \bin or \bin\Debug directory.


To run the sample:
=================
     1. Start a command prompt.
     2. Navigate to the folder containing the sample executable.
     3. Run the executable.

Demonstrates
============
     This sample demonstrates the following:
     1. Creating a PowerShell object
     2. Adding individual commands to the PowerShell object.
     3. Adding parameters to the commands. 
     4. Running the commands synchronously.
     5. Working with PSObject objects to extract properties 
        from the objects returned by the commands.
