namespace System.Threading.Tasks
{
    public static class ValueTaskExtensions
    {
        /// <summary>
        /// Executes value task synchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vt">Value task.</param>
        /// <returns>Task result.</returns>
        public static T RunSync<T>(this ValueTask<T> vt)
        {
            if (vt.IsCompletedSuccessfully)
                return vt.Result;

            return vt.AsTask().GetAwaiter().GetResult();
        }
    }
}
