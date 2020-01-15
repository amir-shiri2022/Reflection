using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Reflection02
{
    public class ShowInformationOfType
    {
        private Type _type;
        public ShowInformationOfType(Type type)
        {
            _type = type;
        }
        public string LoadInformationOfType()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Full Name: {_type.FullName}");
            str.AppendLine($"Name: {_type.Name}");
            str.AppendLine($"NameSpace: {_type.Namespace}");
            str.AppendLine($"Is Class: {_type.IsClass}");
            str.AppendLine($"Is Public: {_type.IsPublic}");
            str.AppendLine($"Base Type: {_type.BaseType?.Name}");

            return str.ToString();
        }
        public string LoadProperties()
        {
            StringBuilder str = new StringBuilder();
            var personProperties = _type.GetProperties();
            foreach (PropertyInfo personProperty in personProperties)
            {
                str.AppendLine($"Type of property:{personProperty.PropertyType.Name} " +
                               $"Property Name: {personProperty.Name}");
            }
            return str.ToString();
        }
        public string LoadMethods()
        {
            StringBuilder str = new StringBuilder();
            var personMethods = _type.GetMethods(BindingFlags.Public
                                                 | BindingFlags.NonPublic
                                                 | BindingFlags.Instance 
                                                 | BindingFlags.DeclaredOnly);
            foreach (MethodInfo personMethod in personMethods)
            {
                if (personMethod.IsSpecialName)
                    continue;
                str.AppendLine($"Property Name: {personMethod.Name}");
                str.AppendLine($"is Generic?:{personMethod.IsGenericMethod}");
                str.AppendLine("Parameters:");
                foreach (var param in personMethod.GetParameters())
                {
                    str.AppendLine($"  type of params:{param.ParameterType.Name}, params name:{param.Name}");
                }
            }
            return str.ToString();
        }
    }

}
