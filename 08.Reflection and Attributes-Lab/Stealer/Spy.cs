using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
 public   class Spy
    {
        public string StealFieldInfo(string className,params string[] namesOfFileds)
        {
            
            Type geтType=Type.GetType(className);
            FieldInfo[] classFields = geтType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();
            Object classInstance = Activator.CreateInstance(geтType, new object[] { });
            sb.AppendLine($"Class under investigation: {className}");
            foreach (var field in classFields.Where(f => namesOfFileds.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type getType = Type.GetType(className);
            FieldInfo[] classFields = getType.GetFields(BindingFlags.Instance|BindingFlags.Static|BindingFlags.Public);
            MethodInfo[] classPublicMethods = getType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = getType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb=new StringBuilder();

            foreach (var fields in classFields)
            {
                sb.AppendLine($"{fields.Name} must be private!");
            }

            foreach (var metod in classNonPublicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{metod.Name} have be public!");
            }
            foreach (var metod in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{metod.Name} have be private!");
            }

            return sb.ToString().Trim();
        }

       public string RevealPrivateMethods(string className)
       {
           var targetType = Type.GetType(className);
           var sb = new StringBuilder();
           sb.AppendLine($"All Private Methods of Class: {targetType}");

           var baseType = targetType.BaseType;
           sb.AppendLine($"Base Class: {baseType.Name}");

           var privateMethods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
           foreach (var method in privateMethods)
           {
               sb.AppendLine(method.Name);
           }

           return sb.ToString().Trim();

       }
       public string CollectGettersAndSetters(string className)
       {
           var targetType = Type.GetType(className);
           var methods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
           var sb = new StringBuilder();

           foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
           {
               sb.AppendLine($"{method.Name} will return {method.ReturnType}");
           }

           foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
           {
               sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
           }

           return sb.ToString().Trim();
       }
    }
}
