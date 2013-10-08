using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;

public sealed class Program {
   public static void Main() {
      DynamicLoadFromResource.Go();
      DiscoverTypes.Go();
      ConstructingGenericType.Go();
      MemberDiscover.Go();
      InterfaceDiscover.Go();
      Invoker.Go();
      BindingHandles.Go();
      SimpleBinderTest.Go();
      ExceptionTree.Go();
   }
}

internal static class DynamicLoadFromResource {
   public static void Go() {
      // For testing: delete the DLL from the runtime directory so 
      // that we have to load as a resource from this assembly
      String path = Assembly.GetExecutingAssembly().Location;
      path = Path.GetDirectoryName(path);
      path = Path.Combine(path, @"Ch01-1-SomeLibrary.dll");
      File.Delete(path);

      // Install a callback with this AppDomain's AssemblyResolve event
      AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
         String resourceName = "AssemblyLoadingAndReflection." + new AssemblyName(args.Name).Name + ".dll";
         using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)) {
            Byte[] assemblyData = new Byte[stream.Length];
            stream.Read(assemblyData, 0, assemblyData.Length);
            return Assembly.Load(assemblyData);
         }
      };

      // Call a method that references types in the assembly we wan tto load from resources
      Test();
   }

   private static void Test() {
      var slt = new SomeLibrary.SomeLibraryType();
      Console.WriteLine(slt.Abc());
   }
}

internal static class DiscoverTypes {
   public static void Go() {
      String dataAssembly = "System.Data, version=4.0.0.0, " +
         "culture=neutral, PublicKeyToken=b77a5c561934e089";
      LoadAssemAndShowPublicTypes(dataAssembly);
   }

   private static void LoadAssemAndShowPublicTypes(String assemId) {
      // Explicitly load an assembly in to this AppDomain
      Assembly a = Assembly.Load(assemId);

      // Execute this loop once for each Type 
      // publicly-exported from the loaded assembly 
      foreach (Type t in a.GetExportedTypes()) {
         // Display the full name of the type
         Console.WriteLine(t.FullName);
      }
   }
}

internal static class ExceptionTree {
   public static void Go() {
      // Explicitly load the assemblies that we want to reflect over
      LoadAssemblies();

      // Recursively build the class hierarchy as a hyphen-separated string
      Func<Type, String> ClassNameAndBase = null;
      ClassNameAndBase = t => "-" + t.FullName +
          ((t.BaseType != typeof(Object)) ? ClassNameAndBase(t.BaseType) : String.Empty);

      // Define our query to find all the public Exception-derived types in this AppDomain's assemblies
      var exceptionTree =
          (from a in new[] { typeof(Exception).Assembly } // AppDomain.CurrentDomain.GetAssemblies()
           from t in a.GetExportedTypes()
           where t.IsClass && t.IsPublic && typeof(Exception).IsAssignableFrom(t)
           let typeHierarchyTemp = ClassNameAndBase(t).Split('-').Reverse().ToArray()
           let typeHierarchy = String.Join("-", typeHierarchyTemp, 0, typeHierarchyTemp.Length - 1)
           orderby typeHierarchy
           select typeHierarchy).ToArray();

      // Display the Exception tree
      Console.WriteLine("{0} Exception types found.", exceptionTree.Length);
      foreach (String s in exceptionTree) {
         // For this Exception type, split its base types apart
         String[] x = s.Split('-');

         // Indent based on # of base types and show the most-derived type
         Console.WriteLine(new String(' ', 3 * (x.Length - 1)) + x[x.Length - 1]);
      }
   }


   private static void LoadAssemblies() {
      String[] assemblies = {
            "System,                    PublicKeyToken={0}",
            "System.Core,               PublicKeyToken={0}",
            "System.Data,               PublicKeyToken={0}",
            "System.Design,             PublicKeyToken={1}",
            "System.DirectoryServices,  PublicKeyToken={1}",
            "System.Drawing,            PublicKeyToken={1}",
            "System.Drawing.Design,     PublicKeyToken={1}",
            "System.Management,         PublicKeyToken={1}",
            "System.Messaging,          PublicKeyToken={1}",
            "System.Runtime.Remoting,   PublicKeyToken={0}",
            "System.Security,           PublicKeyToken={1}",
            "System.ServiceProcess,     PublicKeyToken={1}",
            "System.Web,                PublicKeyToken={1}",
            "System.Web.RegularExpressions, PublicKeyToken={1}",
            "System.Web.Services,       PublicKeyToken={1}",
            "System.Windows.Forms,      PublicKeyToken={0}",
            "System.Xml,                PublicKeyToken={0}",
         };

      String EcmaPublicKeyToken = "b77a5c561934e089";
      String MSPublicKeyToken = "b03f5f7f11d50a3a";

      // Get the version of the assembly containing System.Object
      // We'll assume the same version for all the other assemblies
      Version version = typeof(System.Object).Assembly.GetName().Version;

      // Explicitly load the assemblies that we want to reflect over
      foreach (String a in assemblies) {
         String AssemblyIdentity =
            String.Format(a, EcmaPublicKeyToken, MSPublicKeyToken) +
               ", Culture=neutral, Version=" + version;
         Assembly.Load(AssemblyIdentity);
      }
   }
}

internal static class ConstructingGenericType {
   private sealed class Dictionary<TKey, TValue> { }

   public static void Go() {
      // Get a reference to the generic Type 
      Type openType = typeof(Dictionary<,>);

      // Close the generic type using TKey=String, TValue=Int32
      Type closedType = openType.MakeGenericType(typeof(String), typeof(Int32));

      // Construct an instance of the closed type
      Object o = Activator.CreateInstance(closedType);

      // Prove it worked
      Console.WriteLine(o.GetType());
   }
}

internal static class MemberDiscover {
   public static void Go() {
      // Loop through all assemblies loaded in this AppDomain
      Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
      foreach (Assembly a in assemblies) {
         Show(0, "Assembly: {0}", a);

         // Find Types in the assembly
         foreach (Type t in a.GetExportedTypes()) {
            Show(1, "Type: {0}", t);

            // Indicate the kinds of members we want to discover
            const BindingFlags bf = BindingFlags.DeclaredOnly |
               BindingFlags.NonPublic | BindingFlags.Public |
               BindingFlags.Instance | BindingFlags.Static;

            // Discover the type's members
            foreach (MemberInfo mi in t.GetMembers(bf)) {
               String typeName = String.Empty;
               if (mi is Type) typeName = "(Nested) Type";
               if (mi is FieldInfo) typeName = "FieldInfo";
               if (mi is MethodInfo) typeName = "MethodInfo";
               if (mi is ConstructorInfo) typeName = "ConstructoInfo";
               if (mi is PropertyInfo) typeName = "PropertyInfo";
               if (mi is EventInfo) typeName = "EventInfo";

               Show(2, "{0}: {1}", typeName, mi);
            }
         }
      }
   }

   private static void Show(Int32 indent, String format, params Object[] args) {
      Console.WriteLine(new String(' ', 3 * indent) + format, args);
   }
}

internal static class InterfaceDiscover {
   // Define two interfaces for testing
   private interface IBookRetailer : IDisposable {
      void Purchase();
      void ApplyDiscount();
   }

   private interface IMusicRetailer {
      void Purchase();
   }

   // This class implements 2 interfaces defined by this assembly and 1 interface defined by another assembly
   private sealed class MyRetailer : IBookRetailer, IMusicRetailer, IDisposable {
      // IBookRetailer methods
      void IBookRetailer.Purchase() { }
      public void ApplyDiscount() { }

      // IMusicRetailer method
      void IMusicRetailer.Purchase() { }

      // IDisposable method
      public void Dispose() { }

      // MyRetailer method (not an interface method)
      public void Purchase() { }
   }

   public static void Go() {
      // Find interfaces implemented by MyRetailer where the interface is defined in our own assembly.
      // This is accomplished using a delegate to a filter method that we pass to FindInterfaces.
      Type t = typeof(MyRetailer);
      Type[] interfaces = t.FindInterfaces(TypeFilter, typeof(InterfaceDiscover).Assembly);
      Console.WriteLine("MyRetailer implements the following interfaces (defined in this assembly):");

      // Show information about each interface
      foreach (Type i in interfaces) {
         Console.WriteLine("\nInterface: " + i);

         // Get the type methods that map to the interface's methods
         InterfaceMapping map = t.GetInterfaceMap(i);

         for (Int32 m = 0; m < map.InterfaceMethods.Length; m++) {
            // Display the interface method name and which type method implements the interface method.
            Console.WriteLine("   {0} is implemented by {1}",
               map.InterfaceMethods[m], map.TargetMethods[m]);
         }
      }
   }

   // Returns true if type matches filter criteria
   private static Boolean TypeFilter(Type t, Object filterCriteria) {
      // Return true if the interface is defined in the same assembly identified by filterCriteria
      return t.Assembly == (Assembly)filterCriteria;
   }
}

internal static class Invoker {
   // This class is used to demonstrate reflection
   // It has a field, constructor, method, property, and an event
   private sealed class SomeType {
      private Int32 m_someField;
      public SomeType(ref Int32 x) { x *= 2; }
      public override String ToString() { return m_someField.ToString(); }
      public Int32 SomeProp {
         get { return m_someField; }
         set {
            if (value < 1) throw new ArgumentOutOfRangeException("value", "value must be > 0");
            m_someField = value;
         }
      }
      public event EventHandler SomeEvent;
      private void NoCompilerWarnings() {
         SomeEvent.ToString();
      }
   }

   private const BindingFlags c_bf = BindingFlags.DeclaredOnly | BindingFlags.Public |
      BindingFlags.NonPublic | BindingFlags.Instance;

   public static void Go() {
      Type t = typeof(SomeType);
      UseInvokeMemberToBindAndInvokeTheMember(t);
      Console.WriteLine();
      BindToMemberThenInvokeTheMember(t);
      Console.WriteLine();
      BindToMemberCreateDelegateToMemberThenInvokeTheMember(t);
      Console.WriteLine();
      UseDynamicToBindAndInvokeTheMember(t);
      Console.WriteLine();
   }

   private static void UseInvokeMemberToBindAndInvokeTheMember(Type t) {
      Console.WriteLine("UseInvokeMemberToBindAndInvokeTheMember");

      // Construct an instance of the Type
      Object[] args = new Object[] { 12 };  // Constructor arguments
      Console.WriteLine("x before constructor called: " + args[0]);
      Object obj = t.InvokeMember(null, c_bf | BindingFlags.CreateInstance, null, null, args);
      Console.WriteLine("Type: " + obj.GetType().ToString());
      Console.WriteLine("x after constructor returns: " + args[0]);

      // Read and write to a field
      t.InvokeMember("m_someField", c_bf | BindingFlags.SetField, null, obj, new Object[] { 5 });
      Int32 v = (Int32)t.InvokeMember("m_someField", c_bf | BindingFlags.GetField, null, obj, null);
      Console.WriteLine("someField: " + v);

      // Call a method
      String s = (String)t.InvokeMember("ToString", c_bf | BindingFlags.InvokeMethod, null, obj, null);
      Console.WriteLine("ToString: " + s);

      // Read and write a property
      try {
         t.InvokeMember("SomeProp", c_bf | BindingFlags.SetProperty, null, obj, new Object[] { 0 });
      }
      catch (TargetInvocationException e) {
         if (e.InnerException.GetType() != typeof(ArgumentOutOfRangeException)) throw;
         Console.WriteLine("Property set catch.");
      }
      t.InvokeMember("SomeProp", c_bf | BindingFlags.SetProperty, null, obj, new Object[] { 2 });
      v = (Int32)t.InvokeMember("SomeProp", c_bf | BindingFlags.GetProperty, null, obj, null);
      Console.WriteLine("SomeProp: " + v);

      // Add and remove a delegate from the event by invoking the event’s add/remove methods
      EventHandler eh = new EventHandler(EventCallback);
      t.InvokeMember("add_SomeEvent", c_bf | BindingFlags.InvokeMethod, null, obj, new Object[] { eh });
      t.InvokeMember("remove_SomeEvent", c_bf | BindingFlags.InvokeMethod, null, obj, new Object[] { eh });
   }

   private static void BindToMemberThenInvokeTheMember(Type t) {
      Console.WriteLine("BindToMemberThenInvokeTheMember");

      // Construct an instance
      // ConstructorInfo ctor = t.GetConstructor(new Type[] { Type.GetType("System.Int32&") });
      ConstructorInfo ctor = t.GetConstructor(new Type[] { typeof(Int32).MakeByRefType() });
      Object[] args = new Object[] { 12 };  // Constructor arguments
      Console.WriteLine("x before constructor called: " + args[0]);
      Object obj = ctor.Invoke(args);
      Console.WriteLine("Type: " + obj.GetType().ToString());
      Console.WriteLine("x after constructor returns: " + args[0]);

      // Read and write to a field
      FieldInfo fi = obj.GetType().GetField("m_someField", c_bf);
      fi.SetValue(obj, 33);
      Console.WriteLine("someField: " + fi.GetValue(obj));

      // Call a method
      MethodInfo mi = obj.GetType().GetMethod("ToString", c_bf);
      String s = (String)mi.Invoke(obj, null);
      Console.WriteLine("ToString: " + s);

      // Read and write a property
      PropertyInfo pi = obj.GetType().GetProperty("SomeProp", typeof(Int32));
      try {
         pi.SetValue(obj, 0, null);
      }
      catch (TargetInvocationException e) {
         if (e.InnerException.GetType() != typeof(ArgumentOutOfRangeException)) throw;
         Console.WriteLine("Property set catch.");
      }
      pi.SetValue(obj, 2, null);
      Console.WriteLine("SomeProp: " + pi.GetValue(obj, null));

      // Add and remove a delegate from the event
      EventInfo ei = obj.GetType().GetEvent("SomeEvent", c_bf);
      EventHandler eh = new EventHandler(EventCallback); // See ei.EventHandlerType
      ei.AddEventHandler(obj, eh);
      ei.RemoveEventHandler(obj, eh);
   }

   private static void BindToMemberCreateDelegateToMemberThenInvokeTheMember(Type t) {
      Console.WriteLine("BindToMemberCreateDelegateToMemberThenInvokeTheMember");

      // Construct an instance (You can't create a delegate to a constructor)
      Object[] args = new Object[] { 12 };  // Constructor arguments
      Console.WriteLine("x before constructor called: " + args[0]);
      Object obj = Activator.CreateInstance(t, args);
      Console.WriteLine("Type: " + obj.GetType().ToString());
      Console.WriteLine("x after constructor returns: " + args[0]);

      // NOTE: You can't create a delegate to a field

      // Call a method
      MethodInfo mi = obj.GetType().GetMethod("ToString", c_bf);
      var toString = (Func<String>) Delegate.CreateDelegate(typeof(Func<String>), obj, mi);
      String s = toString();
      Console.WriteLine("ToString: " + s);

      // Read and write a property
      PropertyInfo pi = obj.GetType().GetProperty("SomeProp", typeof(Int32));
      var setSomeProp = (Action<Int32>)Delegate.CreateDelegate(typeof(Action<Int32>), obj, pi.GetSetMethod());
      try {
         setSomeProp(0);
      }
      catch (ArgumentOutOfRangeException) {
         Console.WriteLine("Property set catch.");
      }
      setSomeProp(2);
      var getSomeProp = (Func<Int32>)Delegate.CreateDelegate(typeof(Func<Int32>), obj, pi.GetGetMethod());
      Console.WriteLine("SomeProp: " + getSomeProp());

      // Add and remove a delegate from the event
      EventInfo ei = obj.GetType().GetEvent("SomeEvent", c_bf);
      var addSomeEvent = (Action<EventHandler>)Delegate.CreateDelegate(typeof(Action<EventHandler>), obj, ei.GetAddMethod());
      addSomeEvent(EventCallback);
      var removeSomeEvent = (Action<EventHandler>)Delegate.CreateDelegate(typeof(Action<EventHandler>), obj, ei.GetRemoveMethod());
      removeSomeEvent(EventCallback);   
   }

   private static void UseDynamicToBindAndInvokeTheMember(Type t) {
      Console.WriteLine("UseDynamicToBindAndInvokeTheMember");

      // Construct an instance (You can't create a delegate to a constructor)
      Object[] args = new Object[] { 12 };  // Constructor arguments
      Console.WriteLine("x before constructor called: " + args[0]);
      dynamic obj = Activator.CreateInstance(t, args);
      Console.WriteLine("Type: " + obj.GetType().ToString());
      Console.WriteLine("x after constructor returns: " + args[0]);

      // Read and write to a field 
      try {
         obj.m_someField = 5;
         Int32 v = (Int32)obj.m_someField;
         Console.WriteLine("someField: " + v);
      }
      catch (RuntimeBinderException e) {
         // We get here because the field is private
         Console.WriteLine("Failed to access field: " + e.Message);
      }

      // Call a method
      String s = (String)obj.ToString();
      Console.WriteLine("ToString: " + s);

      // Read and write a property
      try {
         obj.SomeProp = 0;
      }
      catch (ArgumentOutOfRangeException) {
         Console.WriteLine("Property set catch.");
      }
      obj.SomeProp = 2;
      Int32 val = (Int32)obj.SomeProp;
      Console.WriteLine("SomeProp: " + val);

      // Add and remove a delegate from the event
      obj.SomeEvent += new EventHandler(EventCallback);
      obj.SomeEvent -= new EventHandler(EventCallback);
   }

   // Callback method added to the event
   private static void EventCallback(Object sender, EventArgs e) { }
}

internal static class BindingHandles {
   private const BindingFlags c_bf = BindingFlags.FlattenHierarchy | BindingFlags.Instance |
      BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

   public static void Go() {
      // Show size of heap before doing any reflection stuff
      Show("Before doing anything");

      // Build cache of MethodInfo objects for all methods in MSCorlib.dll
      List<MethodBase> methodInfos = new List<MethodBase>();
      foreach (Type t in typeof(Object).Assembly.GetExportedTypes()) {
         // Skip over any generic types
         if (t.IsGenericTypeDefinition) continue;

         MethodBase[] mb = t.GetMethods(c_bf);
         methodInfos.AddRange(mb);
      }

      // Show number of methods and size of heap after binding to all methods
      Console.WriteLine("# of methods={0:N0}", methodInfos.Count);
      Show("After building cache of MethodInfo objects");

      // Build cache of RuntimeMethodHandles for all MethodInfo objects
      List<RuntimeMethodHandle> methodHandles =
         methodInfos.ConvertAll<RuntimeMethodHandle>(mb => mb.MethodHandle);

      Show("Holding MethodInfo and RuntimeMethodHandle cache");
      GC.KeepAlive(methodInfos); // Prevent cache from being GC'd early

      methodInfos = null;        // Allow cache to be GC'd now
      Show("After freeing MethodInfo objects");

      methodInfos = methodHandles.ConvertAll<MethodBase>(rmh => MethodBase.GetMethodFromHandle(rmh));
      Show("Size of heap after re-creating MethodInfo objects");
      GC.KeepAlive(methodHandles);  // Prevent cache from being GC'd early
      GC.KeepAlive(methodInfos);    // Prevent cache from being GC'd early

      methodHandles = null;         // Allow cache to be GC'd now
      methodInfos = null;           // Allow cache to be GC'd now
      Show("After freeing MethodInfos and RuntimeMethodHandles");
   }

   private static void Show(String s) {
      Console.WriteLine("Heap size={0,12:N0} - {1}", GC.GetTotalMemory(true), s);
   }
}

internal static class SimpleBinderTest {
   public static void Go() {
      Object o = new SomeType();
      Type t = typeof(SomeType);
      SimpleBinder binder = new SimpleBinder();
      BindingFlags bf = BindingFlags.Public | BindingFlags.Instance;

      Int16 b = 5;

      // Calls Void v(Int32)
      t.InvokeMember("v", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { b });

      // Calls Void m(Int32)
      t.InvokeMember("m", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { 1 });

      // Calls Void m(System.Object)
      t.InvokeMember("m", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { new Object() });

      // Calls Void m(Double)
      t.InvokeMember("m", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { 1.4 });

      // Calls Void m(SomeType)
      t.InvokeMember("m", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { o });

      // Calls Void m(System.Object) since m(String) is private
      t.InvokeMember("m", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { "string" });

      // Calls Void m(System.String) since NonPublic is specified
      t.InvokeMember("m", bf | BindingFlags.NonPublic | BindingFlags.InvokeMethod, binder, o, new Object[] { "string" });

      try {
         // Throws because there is no public method which takes exactly a string 
         t.InvokeMember("m", bf | BindingFlags.InvokeMethod | BindingFlags.ExactBinding, binder, o, new Object[] { "string" });
      }
      catch (MissingMethodException) {
         Console.WriteLine("Invocation failed on m(String), bad binding flags - ExactBinding too restrictive");
      }

      try {
         // Throws because there is no method g which takes only 2 args 
         t.InvokeMember("g", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { 1, "string" });
      }
      catch (MissingMethodException) {
         Console.WriteLine("Invocation failed on g(int, Object, String), wrong number of args");
      }

      // Calls Void g(Int32, System.Object, System.String)
      t.InvokeMember("g", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { 1, "string", "string" });

      // Calls Void h()
      t.InvokeMember("h", bf | BindingFlags.NonPublic | BindingFlags.InvokeMethod, binder, o, new Object[] { });

      try {
         // Throws because BindingFlags.Static has not been specified 
         t.InvokeMember("s", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { });
      }
      catch (MissingMethodException) {
         Console.WriteLine("Invocation failed on static s(), bad binding flags - need Static");
      }

      // Calls Void s()
      t.InvokeMember("s", bf | BindingFlags.InvokeMethod | BindingFlags.Static, binder, o, new Object[] { });

      // Calls Void m(Int32, Double)
      t.InvokeMember("m", bf | BindingFlags.InvokeMethod, binder, o, new Object[] { 1, 1 });

      Console.WriteLine("Press <Enter> to exit.");
      Console.ReadLine();
   }

   // A simple class with a bunch of members to test the Binder
   private sealed class SomeType {
      public void m(Int32 i) {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }

      public void m(Double d) {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }

      public void m(Object o) {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }

      public void m(SomeType s) {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }

      public void m(Int32 i, Double m) {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }

      private void m(String s) {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }

      public void g(Int32 i, Object o, String s) {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }

      private void h() {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }

      static public void s() {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }

      public void v(Int32 s) {
         Console.WriteLine(new StackTrace().GetFrame(0).GetMethod().ToString());
      }
   }
}

