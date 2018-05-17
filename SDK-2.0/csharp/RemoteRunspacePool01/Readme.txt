RemoteRunspacePool Sample 01
==========================
     This sample shows how to construct a remote runspace pool and 
     how to run multiple commands concurrently using this pool.

     For Windows PowerShell information on MSDN, 
     see http://go.microsoft.com/fwlink/?LinkID=178145 

Sample Language Implementations
===============================
     This sample is available in the following language implementations:

     - C#


To build the sample using Visual Studio:
=======================================
     1. Open Windows Explorer and navigate to the RemoteRunspacePool01 directory under the samples directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     The executable will be built in the default \bin or \bin\Debug directory.


To run the sample:
=================
     1. Verify that Windows PowerShell remoting is enabled; you can run the the following command 
        for additional information about how to enable this feature: help about_remote.
     2. Start the command prompt (in elevated mode).
     2. Navigate to the folder containing the sample executable.
     3. Run the executable.
     
     See the output results and the corresponding code.


Demonstrates
============
     This sample demonstrates the following:
     
     1. Creating a WSManConnectionInfo object.
     2. Creating a runsace pool that uses the WSManConnectionInfo object.
     3. Running the commands "get-process" and "get-service" concurrently
        using the remote runspace pool.        
     4. Closing the runspace pool.

