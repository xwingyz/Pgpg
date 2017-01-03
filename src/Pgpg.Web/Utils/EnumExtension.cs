using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pgpg.Web.Utils
{
    public static class EnumExtension
    {
        public static SelectList ToSelectList<TEnum>(
            this Enum enumObj,
            bool markCurrentAsSelected = true,
            string value = "Id",
            string name = "Name")
            where TEnum : struct
        {
            Func<object, string> GetDisplayName = o =>
            {
                var result = null as string;
                var display = o.GetType().
                    GetMember(o.ToString()).
                    First().GetCustomAttributes(false).
                    OfType<DisplayAttribute>().
                    LastOrDefault();
                if (display != null)
                {
                    result = display.GetName();
                }
                return result ?? o.ToString();
            };

            var values = from TEnum enumValue in Enum.GetValues(typeof(TEnum))
                select new {ID = Convert.ToInt32(enumValue), Name = GetDisplayName(enumValue)};
            object selectedValue = null;
            if (markCurrentAsSelected)
                selectedValue = Convert.ToInt32(enumObj);
            return new SelectList(values, value, name, selectedValue);
        }

        public static IList<SelectListItem> ToSelectListItem<TEnum>(
            this TEnum enumObj)
            where TEnum : struct
        {
            Func<object, string> GetDisplayName = o =>
            {
                var result = null as string;
                var display = o.GetType().
                    GetMember(o.ToString()).
                    First().GetCustomAttributes(false).
                    OfType<DisplayAttribute>().
                    LastOrDefault();
                if (display != null)
                {
                    result = display.GetName();
                }
                return result ?? o.ToString();
            };

            var values = from TEnum enumValue in Enum.GetValues(typeof(TEnum))
                select
                new SelectListItem
                {
                    Value = Convert.ToInt32(enumValue).ToString(),
                    Text = GetDisplayName(enumValue),
                    Selected = Convert.ToInt32(enumValue) == Convert.ToInt32(enumObj)
                };
            return values.ToList();
        }
    }
}