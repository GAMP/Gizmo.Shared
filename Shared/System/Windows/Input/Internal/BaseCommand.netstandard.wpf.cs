#nullable enable
using System.Threading;

namespace System.Windows.Input
{
	public abstract partial class BaseCommand<TCanExecute>
	{
		readonly SynchronizationContext? synchronizationContext = SynchronizationContext.Current;

		bool IsMainThread => SynchronizationContext.Current == synchronizationContext;

		void BeginInvokeOnMainThread(Action action)
		{
			if (synchronizationContext != null && SynchronizationContext.Current != synchronizationContext)
				synchronizationContext.Post(_ => action(), null);
			else
				action();
		}
	}
}