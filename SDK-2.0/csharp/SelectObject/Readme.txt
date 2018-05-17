Select-Obj Sample
==========================
     This Cmdlet is a filter to select only certain objects to process or pass 
     down the pipeline. It is most effectively used as a pipeline receiver from 
     other Cmdlets such as get-service or get-process. The -First, -Last, and 
     -Unique arguments select which objects to process. The Cmdlet works with 
     files, modules, registry keys, and other objects. 

     For Windows PowerShell information on MSDN, 
     see http://go.microsoft.com/fwlink/?LinkID=178145 



Sample Language Implementations
===============================
     This sample is available in the following language implementations:

     - C#


To build the sample using Visual Studio:
=======================================
     1. Open Windows Explorer and navigate to SelectObject under the samples directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     The library will be built in the default \bin or \bin\Debug directory.


To run the sample:
=================
     1. Start command prompt.
     2. Navigate to the folder containing the sample dll.
     3. Start PowerShell.
     4. Run Import-Module .\SelectObjSample.dll (this adds the PowerShell binary module to the shell)
     5. Now type "select-obj" to run the cmdlet that this sample contains.

  

Demonstrates
============
     This sample demonstrates the following:
     
     1.Creating an advanced cmdlet.
	



