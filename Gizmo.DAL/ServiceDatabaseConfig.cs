namespace Gizmo.DAL
{
    /// <summary>
    /// Service database configuration class.
    /// </summary>
    /// <remarks>
    /// This class is used to map database connection configuration in application settings file.
    /// </remarks>
    public class ServiceDatabaseConfig
    {
        /// <summary>
        /// Gets or Sets type of this database.          
        /// </summary>
        public DatabaseType DbType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets database connection string.
        /// </summary>
        public string? DbConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// Database command timeout.
        /// </summary>
        public int? CommandTimeout
        {
            get; set;
        }
    }
}
