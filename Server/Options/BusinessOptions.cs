#nullable enable

using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Business options.
    /// </summary>
    [OptionsConfigurationSection("BUSINESS")]
    [StoreOptionsGroup("BUSINESS")]
    [MessagePack.MessagePackObject()]
    public sealed class BusinessOptions : IStoreOptions
    {
        [Name("Business name", "SERVER_OPTION_BUSINESS_NAME_NAME")]
        [ExtendedDescription("Business name", "SERVER_OPTION_BUSINESS_NAME_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_NAME")]
        [MessagePack.Key(0)]
        public string BusinessName
        {
            get; init;
        } = string.Empty;  

        [Name("Business day start", "SERVER_OPTION_BUSINESS_DAY_START_NAME")]
        [ExtendedDescription("Business day start", "SERVER_OPTION_BUSINESS_DAY_START_NAME_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_DAY_START")]
        [MessagePack.Key(1)]
        public string? BusinessDayStart
        {
            get; init;
        }

        [Name("Business day end", "SERVER_OPTION_BUSINESS_DAY_END_NAME")]
        [ExtendedDescription("Business day end", "SERVER_OPTION_BUSINESS_DAY_END_NAME_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_DAY_END")]
        [MessagePack.Key(2)]
        public string? BusinessDayEnd
        {
            get; init;
        }

        [Name("Business start week day", "SERVER_OPTION_BUSINESS_START_WEEK_DAY_NAME")]
        [ExtendedDescription("Business start week day", "SERVER_OPTION_BUSINESS_DAY_END_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_START_WEEK_DAY")]
        [MessagePack.Key(3)]
        public DayOfWeek? BusinessStartWeekDay
        {
            get; init;
        }

        [Name("Business email", "SERVER_OPTION_BUSINESS_EMAIL_NAME")]
        [ExtendedDescription("Business email", "SERVER_OPTION_BUSINESS_EMAIL_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_EMAIL")]
        [MessagePack.Key(4)]
        public string? BusinessEmail
        {
            get; set;
        }
    }
}
