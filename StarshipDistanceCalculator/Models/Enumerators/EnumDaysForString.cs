using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipDistanceCalculator.Models.Enumerators
{
    public enum EnumDaysForString
    {
        [StringValue("Years")]
        year = 365,
        [StringValue("Years")]
        years = 365,
        [StringValue("Month")]
        month = 30,
        [StringValue("Months")]
        months = 30,
        [StringValue("Week")]
        week = 7,
        [StringValue("Weeks")]
        weeks = 7,
        [StringValue("Day")]
        day = 1,
        [StringValue("Days")]
        days = 1

    }
}
