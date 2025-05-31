using System.ComponentModel;
using System.Reflection;

namespace LojaApi.Domain.Core
{
    public static class MetodosExtensao
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }

    }

}
