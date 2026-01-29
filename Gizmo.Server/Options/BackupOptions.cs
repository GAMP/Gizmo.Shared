
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("BACKUP")]
    [StoreOptionsGroup("BACKUP")]
    [MessagePack.MessagePackObject()]
    public sealed class BackupOptions : IStoreOptions
    {
        [Name("Enable backup", "SERVER_OPTION_BACKUP_ENABLED_NAME")]
        [ExtendedDescription("Specifies if backups are enabled", "SERVER_OPTION_BACKUP_ENABLED_DESCRIPTION")]
        [StoreOptionKey("ENABLED")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool IsEnabled
        {
            get; set;
        }

        [Name("Backup folder", "SERVER_OPTION_BACKUP_FOLDER_NAME")]
        [ExtendedDescription("Specifies backup folder", "SERVER_OPTION_BACKUP_FOLDER_DESCRIPTION")]
        [StoreOptionKey("BACKUP_FOLDER")]
        [DefaultValue(null)]
        [StringLength(255)]
        [MessagePack.Key(1)]
        public string? BackupFolderPath
        {
            get; set;
        }

        [Name("Max files", "SERVER_OPTION_BACKUP_MAX_FILES_NAME")]
        [ExtendedDescription("Specifies max files", "SERVER_OPTION_BACKUP_MAX_FILES_DESCRIPTION")]
        [StoreOptionKey("MAX_FILES")]
        [Range(1, 100)]
        [DefaultValue(10)]
        [MessagePack.Key(2)]
        public int MaxFiles
        {
            get; set;
        }

        /// <remarks>
        /// Default value will be equal to 00:00:00 since Timespan is struct.
        /// </remarks>
        [Name("Time", "SERVER_OPTION_BACKUP_TIME_NAME")]
        [ExtendedDescription("Specifies backup time", "SERVER_OPTION_BACKUP_TIME_DESCRIPTION")]
        [StoreOptionKey("TIME")]
        [MessagePack.Key(3)]
        public TimeSpan Time
        {
            get; set;
        }
    }
}
