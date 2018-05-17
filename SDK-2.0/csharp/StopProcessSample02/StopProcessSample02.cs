// <copyright file="StopProcessSample02.cs" company="Microsoft Corporation">
// Copyright (c) 2009 Microsoft Corporation. All rights reserved.
// </copyright>
// DISCLAIMER OF WARRANTY: The software is licensed �as-is.� You 
// bear the risk of using it. Microsoft gives no express warranties, 
// guarantees or conditions. You may have additional consumer rights 
// under your local laws which this agreement cannot change. To the extent 
// permitted under your local laws, Microsoft excludes the implied warranties 
// of merchantability, fitness for a particular purpose and non-infringement.

using System;
using System.Diagnostics;
using System.Collections;
using Win32Exception = System.ComponentModel.Win32Exception;
using System.Management.Automation;             //Windows PowerShell namespace
using System.Globalization;

// This sample shows how to write debug (WriteDebug), verbose (WriteVerbose), and 
// warning (WriteWarning) messages.
//
// To test this cmdlet, create a module folder that has the same name as 
// this assembly (StopProcesssample02), save the assembly in the module folder, and then run the 
// following command:
// import-module stopprocesssample02


namespace Microsoft.Samples.PowerShell.Commands
{
   #region StopProcCommand

    /// <summary>
   /// This class implements the stop-proc cmdlet.
   /// </summary>
   [Cmdlet(VerbsLifecycle.Stop, "Proc",
       SupportsShouldProcess = true)]
   public class StopProcCommand : Cmdlet
   {
       #region Parameters

      /// <summary>
      /// This parameter provides the list of process names on 
      /// which the Stop-Proc cmdlet will work.
      /// </summary>
       [Parameter(
          Position = 0,
          Mandatory = true,
          ValueFromPipeline = true,
          ValueFromPipelineByPropertyName = true
       )]
       public string[] Name
       {
          get { return processNames; }
          set { processNames = value; }
       }
       private string[] processNames;

       /// <summary>
       /// This parameter overrides the ShouldContinue call to force 
       /// the cmdlet to stop its operation. This parameter should always 
       /// be used with caution.
       /// </summary>
       [Parameter]
       public SwitchParameter Force
       {
           get { return force; }
           set { force = value; }
       }
       private bool force;

       /// <summary>
       /// This parameter indicates that the cmdlet should return 
       /// an object to the pipeline after the processing has been 
       /// completed.
       /// </summary>
       [Parameter]
       public SwitchParameter PassThru
       {
           get { return passThru; }
           set { passThru = value; }
       }
       private bool passThru;

       #endregion Parameters

       #region Cmdlet Overrides

       /// <summary>
       /// The ProcessRecord method does the following for each of the 
       /// requested process names:
       /// 1) Check that the process is not a critical process.
       /// 2) Attempt to stop that process.
       /// If no process is requested then nothing occurs.
       /// </summary>    
       protected override void ProcessRecord()
       {           
           foreach (string name in processNames)
           {
               string message = null;

               // For every process name passed to the cmdlet, get the associated 
               // processes.  
               // Write a nonterminating error for failure to retrieve 
               // a process.

               // Write a user-friendly verbose message to the pipeline. These 
               // messages are intended to give the user detailed information 
               // on the operations performed by the cmdlet. These messages will
               // appear with the -Verbose option.
               message = String.Format(CultureInfo.CurrentCulture, 
                              "Attempting to stop process \"{0}\".", name);             
               WriteVerbose(message);

               Process[] processes;

               try 
               { 
                   processes = Process.GetProcessesByName(name); 
               }
               catch (InvalidOperationException ioe)
               {
                   WriteError(new ErrorRecord(ioe, 
                                     "UnableToAccessProcessByName",
                                         ErrorCategory.InvalidOperation,
                                             name));
                   continue;
               }

               // Try to stop the processes that have been retrieved.
               foreach (Process process in processes)
               {
                   string processName;

                   try 
                   { 
                       processName = process.ProcessName; 
                   }
                   catch (Win32Exception e)
                   {
                       WriteError(new ErrorRecord(e, "ProcessNameNotFound", 
                                         ErrorCategory.ObjectNotFound, process));
                       continue;
                   }

                   // Write a debug message to the host that can be used when 
                   // troubleshooting a problem. All debug messages will appear 
                   // with the -Debug option.
                   message = String.Format(CultureInfo.CurrentCulture, 
                                 "Acquired name for pid {0} : \"{1}\"", 
                                        process.Id, processName);
                   WriteDebug(message);

                   // Confirm the operation first.
                   // This is always false if the WhatIf parameter is specified.
                   if (!ShouldProcess(string.Format(CultureInfo.CurrentCulture, 
                                        "{0} ({1})",
                                            processName, process.Id)))
                   {
                       continue;
                   }

                   // Make sure that the user really wants to stop a critical
                   // process that can possibly stop the computer.
                   bool criticalProcess = criticalProcessNames.Contains(processName.ToLower(CultureInfo.CurrentCulture));

                   if (criticalProcess && !force)
                   {
                       message = String.Format(CultureInfo.CurrentCulture,
                                    "The process \"{0}\" is a critical process and should not be stopped. Are you sure you wish to stop the process?",
                                        processName);

                       // It is possible that the ProcessRecord method is called 
                       // multiple times when objects are recieved as inputs from 
                       // the pipeline. So to retain YesToAll and NoToAll input that 
                       // the user may enter across mutilple calls to this function, 
                       // they are stored as private members of the cmdlet.
                       if (!ShouldContinue(message, "Warning!",
                                    ref yesToAll, ref noToAll))
                       {
                           continue;
                       }
                   } // if (criticalProcess...

                   // Display a warning message if the cmdlet is stopping a 
                   // critical process.
                   if (criticalProcess)
                   {
                       message = String.Format(CultureInfo.CurrentCulture, 
                                     "Stopping the critical process \"{0}\".",
                                          processName);
                       WriteWarning(message);
                   } // if (criticalProcess...

                   // Stop the named process.
                   try
                   {
                       process.Kill();
                   }
                   catch (Exception e)
                   {
                       if ((e is Win32Exception) || (e is SystemException) ||
                           (e is InvalidOperationException))
                       {
                           // This process could not be stopped so write
                           // a nonterminating error.
                           WriteError(new ErrorRecord(
                                            e, 
                                            "CouldNotStopProcess",
                                            ErrorCategory.CloseError, 
                                            process)
                                      );
                           continue;
                       } // if ((e is...
                           else throw;
                   } // catch 

                   message = String.Format(CultureInfo.CurrentCulture, 
                                  "Stopped process \"{0}\", pid {1}.",
                                        processName, process.Id);

                   WriteVerbose(message);

                   // If the PassThru parameter is specified, 
                   // return the terminated process object to the pipeline.
                   if (passThru)
                   {
                       message = String.Format(CultureInfo.CurrentCulture, 
                                     "Writing process \"{0}\" to pipeline",
                                          processName);
                       WriteDebug(message);
                       WriteObject(process);
                   } // if (passThru...
               } // foreach (Process...
            } // foreach (string...
        } // ProcessRecord

       #endregion Cmdlet Overrides

       #region Private Data
       
       private bool yesToAll, noToAll;

       /// <summary>
       /// Partial list of critical processes that should not be 
       /// stopped.  Lower case is used for case insensitive matching.
       /// </summary>
       private ArrayList criticalProcessNames = new ArrayList(
          new string[] { "system", "winlogon", "spoolsv" }
       );

       #endregion Private Data

   } // StopProcCommand

   #endregion StopProcCommand
} 

