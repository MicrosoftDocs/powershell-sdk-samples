Events Sample 02
==========================
     This sample shows how to receive notifications of Windows PowerShell events that are 
     generated on remote computers. It uses the PSEventReceived event exposed through the 
     Runspace class.

     For Windows PowerShell information on MSDN, see http://go.microsoft.com/fwlink/?LinkID=178145 


Sample Language Implementations
===============================
     This sample is available in the following language implementations:

     - C#


To build the sample using Visual Studio:
=======================================
     1. Open Windows Explorer and navigate to the Events02 directory under the samples directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     The executable will be built in the default \bin or \bin\Debug directory.


To run the sample:
=================
     1. Verify that Windows PowerShell remoting is enabled; you can run the the following command 
        for additional information about how to enable this feature: help about_remote.
     2. Start the command prompt.
     2. Navigate to the folder containing the sample executable.
     3. Run the executable.
     
     See the output results and the corresponding code.


Demonstrates
============
     This sample demonstrates the following:

     1. How to use the PSEventReceived event to receive notification of Windows PowerShell events that are 
        generated on remote computers.


