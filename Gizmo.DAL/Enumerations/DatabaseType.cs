namespace Gizmo.DAL
{
    /// <summary>
    /// Database types.
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// MYSQL.
        /// </summary>
        MYSQL = 0,

        /// <summary>
        /// MSSQL EXPRESS.
        /// </summary>
        MSSQLEXPRESS = 2,

        /// <summary>
        /// MS SQL.
        /// </summary>
        MSSQL = 1,

        /// <summary>
        /// LOCAL DB.
        /// </summary>
        LOCALDB = 3,

        /// <summary>
        /// SQL LITE.
        /// </summary>
        SQLITE = 4,

        /// <summary>
        /// POSTGRE.
        /// </summary>
        POSTGRE = 5,
    }
}
