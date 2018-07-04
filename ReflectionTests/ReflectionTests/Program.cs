using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq.Expressions;

namespace ReflectionTests {
    class SkryptMethodAttribute : Attribute {
        public string[] Types;

        public SkryptMethodAttribute(params string[] T) {
            Types = T;
        }
    }


    public class TestClass {
        public static object TestMethod(params object[] input) {
            return null;
        }
    }

    delegate object objectDelegate(params object[] input);

    public class Program {
        public static void Main(string[] args) {
            var M = typeof(TestClass).GetMethod("TestMethod");

            Console.WriteLine(M.ReturnParameter);

            var D = Delegate.CreateDelegate(typeof(objectDelegate), M);

            Console.WriteLine(D.Method.GetParameters().Count());

            Console.WriteLine(D.Method);

            Console.ReadKey();
        }
    }
}


//var Attributes = M.GetCustomAttributes(typeof(SkryptMethodAttribute));
//var HasMethodAttributes = Attributes.Count() > 0;

//Console.WriteLine("Has attribute: " + HasMethodAttributes);

//if (HasMethodAttributes) {    
//    foreach (SkryptMethodAttribute Atr in Attributes) {
//        Console.WriteLine(Atr);
//    }
//}