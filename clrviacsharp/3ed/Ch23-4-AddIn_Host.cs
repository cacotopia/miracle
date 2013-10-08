using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Wintellect.HostSDK;

public sealed class Program {
   public static void Main() {
      // Find the directory that contains the Host exe
      String AddInDir = Path.GetDirectoryName(
         Assembly.GetEntryAssembly().Location);

      // Assume AddIn assemblies are in same directory as host's EXE file
      String[] AddInAssemblies = Directory.GetFiles(AddInDir, "*.dll");

      // Create a collection of usable Add-In Types
      List<Type> AddInTypes = new List<Type>();

      // Load Add-In assemblies; discover which types are usable by the host
      foreach (String file in AddInAssemblies) {
         Assembly AddInAssembly = Assembly.LoadFrom(file);

         // Examine each publicly-exported type
         foreach (Type t in AddInAssembly.GetExportedTypes()) {
            // If the type is a class that implements the IAddIn 
            // interface, then the type is usable by the host
            if (t.IsClass && typeof(IAddIn).IsAssignableFrom(t)) {
               AddInTypes.Add(t);
            }
         }
      }

      // Initialization complete: the host has discovered the usable Add-Ins

      // Here's how the host can construct Add-In objects and use them
      foreach (Type t in AddInTypes) {
         IAddIn ai = (IAddIn) Activator.CreateInstance(t);
         Console.WriteLine(ai.DoSomething(5));
      }
   }
}