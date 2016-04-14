using System;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Singleton implementation of <see cref="IScheduler"/> which uses <see cref="Task.Delay"/>
    /// and <see cref="Task.Run"/> internally.
    /// </summary>
    public sealed class SystemScheduler : IScheduler
    {
        public static SystemScheduler Instance { get; } = new SystemScheduler();

        private SystemScheduler() {}

        public Task Delay(TimeSpan timeSpan) => Task.Delay(timeSpan);

        public void Sleep(TimeSpan timeSpan) => Thread.Sleep(timeSpan);

        public Task Schedule(Action action, TimeSpan timeSpan) =>
            Task.Run(async () =>
            {
                await Delay(timeSpan);
                action();
            });
    }
}
