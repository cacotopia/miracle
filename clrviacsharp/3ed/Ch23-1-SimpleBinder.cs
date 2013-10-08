/******************************************************************************
Module:  SimpleBinder.cs
Notices: Copyright (c) 2002-2010 Jeffrey Richter
Thanks:  To Dario Russi for supplying the initial version of this code.
******************************************************************************/


using System;
using System.Reflection;
using System.Collections;
using CultureInfo = System.Globalization.CultureInfo;
    

///////////////////////////////////////////////////////////////////////////////


public sealed class SimpleBinder : Binder {	

   // Type.InvokeMember calls this method if more than 1 field matches.
   // This code performs uses simple conversion rules to bind.
   public override FieldInfo BindToField(
      BindingFlags bindingAttr,       // Flags to restrict options
      FieldInfo[] fields,             // Field subset selected by reflection
      Object value,                   // The value to set 
      CultureInfo culture) {          // Culture (usually ignored)

      // Get the type of the value that is to be assigned to the field
      Type valueType = value.GetType();

      // If any fields exactly match the value's type, return that field
      foreach (FieldInfo f in fields)
         if (valueType == f.FieldType) return f;

      // If any fields have a "compatible" type, return that field
      foreach (FieldInfo f in fields) {
         // Get the type of the field
         Type formalType = f.FieldType;

         // If the value's type is compatible with the field's type, return it
         if (CanConvertPrimitiveType(valueType, formalType)) return f;

         // Consider a match if the value can be assigned to the field's type
         if (!formalType.IsValueType) {
            // It must be some sort of "compatible" reference type
            if (formalType.IsAssignableFrom(valueType)) return f;
         }
      }

      // No compatible field was found
      throw new MissingFieldException("Field not found.");
   }
    								   
    	
   // Type.InvokeMember and Activator.CreateInstance call this method to
   // select a specific method. 
   // This code performs uses simple conversion rules to bind.
   public override MethodBase BindToMethod(
      BindingFlags bindingAttr,       // Flags to restrict options
      MethodBase[] methods,           // Method subset selected by reflection
      ref Object[] args,              // Arguments provided by the caller 
                                      // (BindToMethod can modify this array)
      ParameterModifier[] modifiers,  // Modifiers (usually ignored)
      CultureInfo culture,            // Culture (usually ignored)
      String[] names,                 // Named arguments (if any)
      out Object state) {             // If 'args' is changed, this object can
                                      // be used to get back the original 
                                      // array by calling ReorderArgumentArray

      // This binder doesn't support argument re-ordering
      state = null;  

      // Construct array of method argument types.
      Type[] argType = new Type[args.Length];
      for (Int32 i = 0; i < args.Length; i++) {
         if (args[i] != null) {
            argType[i] = args[i].GetType();
         }
      }

      // A more sophisticated binder would have code here to deal with methods
      // that accept a variable number of arguments (ParamArrayAttribute) and 
      // with methods that accept optional arguments and named parameters.

      // Select a method that matches type argument's types.
      return SelectMethod(bindingAttr, methods, argType, modifiers);
   }


   // Flags indicating how to compare the specified argument types 
   // with the method's parameter types.
   [Flags]
   private enum CompareParamAndArgTypesFlags {
      Exact            = 0x0000,
      CoerceValueTypes = 0x0001,
      AllowBaseTypes   = 0x0002,
   }


   // This method returns true if the specified argument types match
   // the method's parameter types
   private static Boolean CompareParamAndArgTypes(
      ParameterInfo[] paramTypes, 
      Type[] argTypes, 
      CompareParamAndArgTypesFlags flags) {

      // This binder requires that the number of arguments and parameters match
      if (paramTypes.Length != argTypes.Length) return false;

      Int32 i = 0;
      for (; i < paramTypes.Length; i++) {

         // If the argument has a type, compare it against the parameter's type
         // This can be null if Type.InvokeMember is passed null for an argument
         if (argTypes[i] != null) {
            Type formalType = paramTypes[i].ParameterType;

            // If argument and parameter types match exactly, try next pair
            if (formalType == argTypes[i]) continue;

            // Compare the primitive, value type, or enumerated type parameter
            if (formalType.IsValueType) {

               if (((flags & CompareParamAndArgTypesFlags.CoerceValueTypes) != 0) && 
                   CanConvertPrimitiveType(argTypes[i], formalType)) continue;
               break; // Can't coerce argument type to parameter type

            } else {

               // Compare the reference type parameter
               if (((flags & CompareParamAndArgTypesFlags.AllowBaseTypes) != 0) && 
                   formalType.IsAssignableFrom(argTypes[i])) continue;
               break; // Can't implicitly cast argument type to parameter type

            }
         }
      }

      // Return true if all argument and parameter types match
      return (i == paramTypes.Length);
   }


   // Called to change a type during invocation.
   // There must have been a type mismatch and we are asked to intervene.
   public override Object ChangeType(Object value, Type type, CultureInfo culture) {
      // We only do primitive conversions.
      if (CanConvertPrimitiveType(value.GetType(), type)) {
         return DoConvertPrimitiveType(value, type);
      }
      throw new ArgumentException("No conversion allowed for one of the arguments");
   }


   // Called to restore the args array back to that passed to BindToMethod.
   // This code does nothing because we don't handle named or optional arguments
   public override void ReorderArgumentArray(
      ref Object[] args,      // Arguments provided by the caller 
      Object state) {         // This object can is used to get back
                              // the original array

      // Here's the scenario where this method comes in useful...
      // Say InvokeMember is called passing some named arguments. The elements
      // in this array must be reordered so that arguments are in the correct 
      // position before invoking the method. For optional arguments, the
      // array must grow to accommodate the unspecified arguments.

      // Note: If an argument is marked as 'out' or 'ref', the return value 
      // will be updated in this array. These array element values must be 
      // copied back to the reflection caller's original array so that they 
      // can get the 'returned' values.

      // For example, let's say that Class Foo defines the following method:
      // class Foo {
      //    public static void m(Int32 i, ref Object o) { ... }
      // }

      // Now, let's invoke this method using a named parameter as follows:
      // Object[] args = new Object[] { obj, 3 };
      // typeof(Foo).InvokeMember("m", 
      //    BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public,
      //    new SimpleBinder(),  // The binder
      //    null,                // No object; static method
      //    args,                // The arguments to pass (Object followed by Int32)
      //    null,                // No ParamterModifier array
      //    null,                // No Culture
      //    new String[] {"o"}); // The first argument should be the 'o' parameter

      // Notice the Object and Int32 arguments are passed in reverse order. 
      // This is OK if the binder can deal with named parameters.

      // In BindToMethod, the argument array must be reordered in order to 
      // sucessfully invoke the method. This array can't be returned to the 
      // caller since the caller would have no knowledge what was where. 
      // Also, the caller needs to fetch the 'ref' value out of the array.

      // This ReorderArgumentArray method must transform the array used to 
      // invoke the method back to the array expected by the caller.

      // BindToMethod should save any information required to restore the 
      // argument array in the state parameter passed to this method.
   }
      
   
   // GetMethod calls this method to select a specific method. 
   // This code performs uses simple conversion rules to bind.
   public override MethodBase SelectMethod(
      BindingFlags bindingAttr,        // Flags to restrict options
      MethodBase[] methods,            // Method subset selected by reflection
      Type[] argTypes,                 // Set of argument types
      ParameterModifier[] modifiers) { // Modifiers (usually ignored)

      // This ArrayList contains the set of possible methods
      ArrayList candidates = new ArrayList();

      // Build the set of candidate methods removing any method that
      // doesn't have the specified number of arguments.

      // A more sophisticated binder would have code here to deal with methods
      // that accept a variable number of arguments (ParamArrayAttribute) and 
      // with methods that accept optional arguments and named parameters.

      Int32 argCount = argTypes.Length;
      foreach (MethodBase m in methods) {
         if (m.GetParameters().Length == argCount)
            candidates.Add(m);
      }

      // If no exact match was found and the caller wants an exact match, throw
      Int32 numTests = ((BindingFlags.ExactBinding & bindingAttr) != 0) ? 1 : 3;

      for (Int32 test = 0; test < numTests; test++) {
         CompareParamAndArgTypesFlags flags = CompareParamAndArgTypesFlags.Exact;
         
         // Look for methods whose parameter types exactly match the argument types
         if (test == 0) 
            flags = CompareParamAndArgTypesFlags.Exact;

         // Look for methods that can accomodate the parameters passed.
         if (test == 1) 
            flags = CompareParamAndArgTypesFlags.AllowBaseTypes;
         
         // Check whether any conversion could be applied on primitives as well. 
         // NOTE: We bind to the first matching method; not the best matching method.
         // Look for methods that can accomodate the parameters passed.
         if (test == 2) 
            flags = CompareParamAndArgTypesFlags.AllowBaseTypes | 
               CompareParamAndArgTypesFlags.CoerceValueTypes;

         // Assume that no method matches the argument's parameters
         MethodBase match = null;

         // Check ALL of the methods
         foreach (MethodBase m in candidates) {

            if (CompareParamAndArgTypes(m.GetParameters(), argTypes, flags)) {
               // A matching method was found

               // If we found a matching method previously, then we don't know
               // how to select one of them.
               if (match != null) {
                  // Note, when doing an exact match this can occur if multiple 
                  // methods differ only by return type
                  throw new AmbiguousMatchException("Multiple methods match the specified parameter types.");
               }

               // Save the matching method
               match = m;
            }
         }

         // One matching method was found, return it
         if (match != null) return match;
      }

      // No matching method was found, throw
      throw new MissingMethodException("Member not found.");
   }

   
   // Called to return the parameters of a property
   private static ParameterInfo[] GetPropertyParams(PropertyInfo p) {

      // If a get accessor method exists, return its parameters
      MethodInfo m = p.GetGetMethod();
      if (m != null) return m.GetParameters();

      // No get accessor method exists, use the set access method
      m = p.GetSetMethod();
      ParameterInfo[] setParams = m.GetParameters();

      // Copy all elements but the last (the property's type) to a new array
      ParameterInfo[] paramTypes = new ParameterInfo[setParams.Length - 1];
      Array.Copy(setParams, paramTypes, paramTypes.Length);

      // Return the copy
      return paramTypes;
   }


   // GetProperty calls this method to select a specific property. 
   // This code performs uses simple conversion rules to bind.
   public override PropertyInfo SelectProperty(
      BindingFlags bindingAttr,        // Flags to restrict options
      PropertyInfo[] properties,       // Property subset selected by reflection
      Type returnType,                 // Property's return type
      Type[] argTypes,                 // Set of argument types
      ParameterModifier[] modifiers) { // Modifiers (usually ignored)
      
      // This ArrayList contains the set of possible properties
      ArrayList candidates = new ArrayList();

      // Build the set of candidate properties removing any property that 
      // doesn't have the specified number of arguments.

      // Only consider properties that have the same number of arguments and type
      Int32 argCount = (argTypes == null) ? 0 : argTypes.Length;
      foreach (PropertyInfo p in properties) {
         if (GetPropertyParams(p).Length == argCount)
            // Check the property's type
            if ((returnType == null) || (returnType == p.PropertyType))
               candidates.Add(p);
      }

      // If no exact match was found and the caller wants an exact match, throw
      Int32 numTests = ((BindingFlags.ExactBinding & bindingAttr) != 0) ? 1 : 3;

      for (Int32 test = 0; test < numTests; test++) {
         CompareParamAndArgTypesFlags flags = CompareParamAndArgTypesFlags.Exact;
         
         // Look for properties whose parameter types exactly match the argument types
         if (test == 0) 
            flags = CompareParamAndArgTypesFlags.Exact;

         // Look for properties that can accomodate the parameters passed.
         if (test == 1) 
            flags = CompareParamAndArgTypesFlags.AllowBaseTypes;
         
         // Check whether any conversion could be applied on primitives as well. 
         // NOTE: We bind to the first matching property; not the best matching property.
         // Look for properties that can accomodate the parameters passed.
         if (test == 2) 
            flags = CompareParamAndArgTypesFlags.AllowBaseTypes | 
               CompareParamAndArgTypesFlags.CoerceValueTypes;

         // Assume that no property matches the argument's parameters
         PropertyInfo match = null;

         // Check ALL of the properties
         foreach (PropertyInfo p in candidates) {

            if (CompareParamAndArgTypes(GetPropertyParams(p), argTypes, flags)) {
               // A matching property was found

               // If we found a matching property previously, then we don't know
               // how to select one of them.
               if (match != null) {
                  // Note, when doing an exact match this can occur if multiple 
                  // properties differ only by type
                  throw new AmbiguousMatchException("Multiple properties match the specified parameter types.");
               }

               // Save the matching property
               match = p;
            }
         }

         // One matching property was found, return it
         if (match != null) return match;
      }

      // No matching property was found, throw
      throw new MissingMemberException("Member not found.");
   }
   
 	
///////////////////////////////////////////////////////////////////////////////


   // This table indicates what conversions this binder allows
   static readonly TypeCode[][] AllowedConversions = new TypeCode[19][];

   // This static constructor initializes the conversion table
   static SimpleBinder() {
      // For example, Char can be convert to SByte, Byte, or UInt16
      AllowedConversions[(Int32) TypeCode.Char]   = new TypeCode[] 
         { TypeCode.SByte, TypeCode.Byte, TypeCode.UInt16 };

      AllowedConversions[(Int32) TypeCode.Int16]  = new TypeCode[] 
         { TypeCode.SByte, TypeCode.Byte };

      AllowedConversions[(Int32) TypeCode.UInt16] = new TypeCode[] 
         { TypeCode.Char,  TypeCode.SByte, TypeCode.Byte };

      AllowedConversions[(Int32) TypeCode.Int32]  = new TypeCode[] 
         { TypeCode.Char,  TypeCode.SByte, TypeCode.Byte, TypeCode.Int16, TypeCode.UInt16 };

      AllowedConversions[(Int32) TypeCode.UInt32] = new TypeCode[] 
         { TypeCode.Char,  TypeCode.SByte, TypeCode.Byte, TypeCode.Int16, TypeCode.UInt16 };

      AllowedConversions[(Int32) TypeCode.Int64]  = new TypeCode[] 
         { TypeCode.Char,  TypeCode.SByte, TypeCode.Byte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32 };
      
      AllowedConversions[(Int32) TypeCode.UInt64] = new TypeCode[] 
         { TypeCode.Char,  TypeCode.SByte, TypeCode.Byte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32 };
      
      AllowedConversions[(Int32) TypeCode.Single] = new TypeCode[] 
         { TypeCode.Char,  TypeCode.SByte, TypeCode.Byte, TypeCode.Int16, TypeCode.UInt16 };
      
      AllowedConversions[(Int32) TypeCode.Double] = new TypeCode[] 
         { TypeCode.Char,  TypeCode.SByte, TypeCode.Byte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.Single };
   }


   // Returns 'true' if the binder can convert from fromType to toType
   private static Boolean CanConvertPrimitiveType(Type fromType, Type toType) {
      // If the types are the same, of course we can convert
      if (fromType == toType) return true;

      // Check table to see if fromType can be converted to anything
      TypeCode fromTypeCode = Type.GetTypeCode(fromType);
      if (AllowedConversions[(Int32) fromTypeCode] == null) 
         return false;

      // Check table to see if conversion from fromType to toType is allowed
      TypeCode toTypeCode = Type.GetTypeCode(toType);
      if (Array.IndexOf(AllowedConversions[(Int32) toTypeCode], fromTypeCode) != -1)
         return true;

      // Conversion is not allowed
      return false;
   }


   // Returns new object converted from original type
   private static Object DoConvertPrimitiveType(Object value, Type toType) {
      // If conversion isn't allowed, throw
      if (!CanConvertPrimitiveType(value.GetType(), toType))
         throw new InvalidCastException();

      // Conversion is allowed, convert and return the new object
      return Convert.ChangeType(value, toType);
   }
}


//////////////////////////////// End of File //////////////////////////////////
