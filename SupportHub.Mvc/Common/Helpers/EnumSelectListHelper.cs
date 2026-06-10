using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SupportHub.Mvc.Common.Helpers;

public static class EnumSelectListHelper
{
    public static List<SelectListItem> Create<TEnum>() where TEnum : struct, Enum
    {
        return Enum.GetValues<TEnum>()
            .Select(value => new SelectListItem
            {
                Value = Convert.ToInt32(value).ToString(),
                Text = GetDisplayName(value)
            })
            .ToList();
    }

    private static string GetDisplayName<TEnum>(TEnum value) where TEnum : struct, Enum
    {
        var member = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();

        return member?
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName()
            ?? value.ToString();
    }
}
