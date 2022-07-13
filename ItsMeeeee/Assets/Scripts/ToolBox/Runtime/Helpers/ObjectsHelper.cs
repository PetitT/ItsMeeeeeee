using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class ObjectsHelper
{
    public static void CopyFieldsFrom<T>(this T source, T copy) where T : class
    {
        FieldInfo[] fields = source.GetType().GetFields();
        for (int i = 0; i < fields.Length; i++)
        {
            source.GetType().GetField(fields[i].Name).SetValue(source, fields[i].GetValue(copy));
        }
    }
}
