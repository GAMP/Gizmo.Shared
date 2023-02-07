using System;

namespace Gizmo.Client
{
    public sealed class Rating
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new rating instance.
        /// </summary>
        /// <param name="appId">Application id.</param>
        /// <param name="value">Rating value.</param>
        /// <param name="ratesCount">Total rates.</param>
        /// <param name="lr">Last rating date.</param>
        public Rating(int appId, double value, int ratesCount, DateTime lr)
        {
            LastRated = lr;
            Value = value;
            ApplicationId = appId;
            RatesCount = ratesCount;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets the rates application id.
        /// </summary>
        public int ApplicationId
        {
            get; init;
        }
        /// <summary>
        /// Gets the rating value.
        /// </summary>
        public double Value
        {
            get; init;
        }
        /// <summary>
        /// Gets the last rate date.
        /// </summary>
        public DateTime LastRated
        {
            get; init;
        }
        /// <summary>
        /// Gets the amount of rates for this rating.
        /// </summary>
        public int RatesCount
        {
            get; init;
        }
        #endregion

        #region OVERRIDES
        public override string ToString()
        {
            return String.Format("Application Id:{0} Value:{1} Total Ratings:{2}", this.ApplicationId, this.Value, this.RatesCount);
        }
        #endregion
    }
}
