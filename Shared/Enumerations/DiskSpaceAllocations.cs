using System.ComponentModel.DataAnnotations;

namespace Gizmo
{ 
    public enum DiskSpaceAllocations
    {
        /// <summary>
        /// Zero.
        /// </summary>
        [Name("0%", "DISK_SPACE_ALLOCATIONS_ZERO")]
        Zero = 0,

        /// <summary>
        /// Five percent.
        /// </summary>
        [Name("5%", "DISK_SPACE_ALLOCATIONS_FIVE")]
        Five = 5,

        /// <summary>
        /// Ten percent.
        /// </summary>
        [Name("10%", "DISK_SPACE_ALLOCATIONS_TEN")]
        Ten = 10,

        /// <summary>
        /// Fifteen percent.
        /// </summary>
        [Name("15%", "DISK_SPACE_ALLOCATIONS_FIFTEEN")]
        FifTeen = 15,

        /// <summary>
        /// Twenty percent.
        /// </summary>
        [Name("20%", "DISK_SPACE_ALLOCATIONS_TWENTY")]
        Twenty = 20,

        /// <summary>
        /// Twenty five percent.
        /// </summary>
        [Name("25%", "DISK_SPACE_ALLOCATIONS_TWENTY_FIVE")]
        TwentyFive = 25,

        /// <summary>
        /// Thirty percent.
        /// </summary>
        [Name("30%", "DISK_SPACE_ALLOCATIONS_THIRTY")]
        Thirty = 30
    }
}
