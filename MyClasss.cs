using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace StackFrameMy
{
    public static class StackFrameExtensions
    {
      public static Dictionary<string, object> GetLocalVariables(this StackFrame frame) // получает все локальные переменные из метода, связанного с переданным объектом StackFrame,
                                                                                        // и возвращает словарь, где ключами являются индексы локальных переменных, а значениями - их типы.
        {
    var localVariables = new Dictionary<string, object>();
    var method = frame.GetMethod();
    var locals = method.GetMethodBody()?.LocalVariables;

    if (locals != null)
    {
        foreach (var local in locals)
        {
            localVariables[local.LocalIndex.ToString()] = local.LocalType;
        }
    }

    return localVariables;
}



        public static Dictionary<string, object> GetLocalVariables<T>(this StackFrame frame) // работает так же, но только
                                                                                             //возвращает только те локальные переменные, которые имеют тип T.
        {
            var localVariables = new Dictionary<string, object>();
            var method = frame.GetMethod();
            var locals = method.GetMethodBody()?.LocalVariables;

            if (locals != null)
            {
                foreach (var local in locals)
                {
                    if (local.LocalType == typeof(T))
                    {
                        localVariables[local.LocalIndex.ToString()] = frame.GetMethod().Module.ResolveSignature(local.LocalType.MetadataToken);
                    }
                }
            }

            return localVariables;
        }
    }
    public static class MyClasss // содержит метод GetCurrentStackFrame(), который возвращает верхний элемент стека вызовов, используя класс StackTrace.
    {
       
        public static StackFrame GetCurrentStackFrame() // возвращает верхний элемент стека вызовов, используя класс StackTrace.
        {

            StackTrace trace = new StackTrace(); //создаю класс StackTrace 
            //StackTrace trac = new StackTrace(1);  //предоставляет методы и свойства, которые позволяют получить информацию о каждом элементе стека вызовов
            StackFrame frame =trace.GetFrame(0); //верхний элемент стека

            return frame;

        } 
    }
}
