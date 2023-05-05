using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFrameMy
{
    public class Program
    {
        static void Main()
        {
            StackFrame frame = MyClasss.GetCurrentStackFrame();
            var localVariables = frame.GetLocalVariables();
            foreach (var variable in localVariables)
            {
                Console.WriteLine($"{variable.Key} - {variable.Value}");
            }
        /*StackFrame fram = MyClasss.GetCurrentStackFrame();
            Console.WriteLine("Метод:" + frame.GetMethod().Name);
            Console.WriteLine("Строка: " + frame.GetFileLineNumber());
        //    Console.WriteLine("Метод:" + fram.GetMethod().Name);
       //  Console.WriteLine("Строка: " + fram.GetFileLineNumber()); */
            Console.ReadKey();
        }

      
    }
}
