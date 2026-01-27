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
        public string? BusinessName
        {
            get; init;
        } = string.Empty;  

        [Name("Business day start", "SERVER_OPTION_BUSINESS_DAY_START_NAME")]
        [ExtendedDescription("Business day start", "SERVER_OPTION_BUSINESS_DAY_START_NAME_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_DAY_START")]
        [TimeSpanValidation(true, 0, 1440)]
        [MessagePack.Key(1)]
        public string? BusinessDayStart
        {
            get; init;
        }

        [Name("Business day end", "SERVER_OPTION_BUSINESS_DAY_END_NAME")]
        [ExtendedDescription("Business day end", "SERVER_OPTION_BUSINESS_DAY_END_NAME_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_DAY_END")]
        [TimeSpanValidation(true, 0, 1440)]
        [MessagePack.Key(2)]
        public string? BusinessDayEnd
        {
            get; init;
        }

        [Name("Business start week day", "SERVER_OPTION_BUSINESS_START_WEEK_DAY_NAME")]
        [ExtendedDescription("Business start week day", "SERVER_OPTION_BUSINESS_DAY_END_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_START_WEEK_DAY")]
        [MessagePack.Key(3)]
        [Range(0,6)]
        public DayOfWeek? BusinessStartWeekDay
        {
            get; init;
        }

        [Name("Business email", "SERVER_OPTION_BUSINESS_EMAIL_NAME")]
        [ExtendedDescription("Business email", "SERVER_OPTION_BUSINESS_EMAIL_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_EMAIL")]
        [EmailNullEmptyValidation()]
        [MessagePack.Key(4)]
        public string? BusinessEmail
        {
            get; set;
        }

        [Name("Business web site", "SERVER_OPTION_BUSINESS_WEB_SITE_NAME")]
        [ExtendedDescription("Business web site", "SERVER_OPTION_BUSINESS_WEB_SITE_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_WEB_SITE")]
        [UrlNullEmptyValidation()]
        [MessagePack.Key(5)]
        public string? BusinessWebSite
        {
            get;set;
        }

        [Name("Business end week day", "SERVER_OPTION_BUSINESS_END_WEEK_DAY_NAME")]
        [ExtendedDescription("Business end week day", "SERVER_OPTION_BUSINESS_END_DAY_DESCRIPTION")]
        [StoreOptionKey("BUSINESS_END_WEEK_DAY")]
        [MessagePack.Key(6)]
        [Range(0, 6)]
        public DayOfWeek? BusinessEndWeekDay { get; set; }

        [Name("Enable business schedule", "SERVER_OPTION_BUSINESS_HAS_BUSINESS_SCHEDULE_NAME")]
        [ExtendedDescription("Specifies if business schedule is enabled", "SERVER_OPTION_BUSINESS_HAS_BUSINESS_SCHEDULE_DESCRIPTION")]
        [StoreOptionKey("HAS_BUSINESS_SCHEDULE")]
        [MessagePack.Key(7)]
        public bool HasBusinessSchedule { get; set; }
    }
}
