PowerShell Sample 02
==========================
     This sample uses a RunspacePool to run multiple commands concurrently.

     For Windows PowerShell information on MSDN, 
     see http://go.microsoft.com/fwlink/?LinkID=178145 


Sample Language Implementations
===============================
     This sample is available in the following language implementations:

     - C#


To build the sample using Visual Studio:
=======================================
     1. Open Windows Explorer and navigate to PowerShell01 under the samples directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     The executable will be built in the default \bin or \bin\Debug directory.


To run the sample:
=================
     1. Start command prompt.
     2. Navigate to the folder containing the sample executable.
     3. Run the executable
     
     See the output results and the corresponding code.


Demonstrates
============
     This sample demonstrates the following:

     1. Creating a RunspacePool with a minimum and maximum number of Runspaces.
     2. Creating many PowerShell commands with the same RunspacePool.
     3. Running the commands concurrently.
     4. Calling GetAvailableRunspaces to see how many Runspaces are free.
     5. Capturing the command output with EndInvoke.



