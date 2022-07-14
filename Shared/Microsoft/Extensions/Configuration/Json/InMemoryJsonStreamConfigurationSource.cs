using System;
using System.IO;

namespace Microsoft.Extensions.Configuration.Json
{
    /// <summary>
    /// In memory Json configura
    /// </summary>
    public class InMemoryJsonStreamConfigurationSource : JsonStreamConfigurationSource
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public InMemoryJsonStreamConfigurationSource() : base()
        {
            Stream = Stream.Null;
        }

        #endregion

        #region EVENTS

        public event EventHandler<EventArgs> StreamChanged;

        #endregion

        #region FUNCTIONS
        public void Load(Stream stream)
        {
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            StreamChanged?.Invoke(this, EventArgs.Empty);
        } 
        #endregion

        #region OVERRIDES

        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new InMemoryJsonStreamConfigurationProvider(this);
        } 

        #endregion      
    }
}
