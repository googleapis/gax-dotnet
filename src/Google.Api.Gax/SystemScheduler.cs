using System;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    /// <summary>
    /// Singleton implementation of <see cref="IScheduler"/> which uses <see cref="Task.Delay(TimeSpan)"/>
    /// and <see cref="Task.Run(Action)"/> internally.
    /// </summary>
    public sealed class SystemScheduler : IScheduler
    {
        /// <summary>
        /// Retrieves the singleton instance.
        /// </summary>
        public static SystemScheduler Instance { get; } = new SystemScheduler();

        private SystemScheduler() {}

        /// <inheritdoc />
        public Task Delay(TimeSpan timeSpan) => Task.Delay(timeSpan);

        /// <inheritdoc />
        public void Sleep(TimeSpan timeSpan) => Thread.Sleep(timeSpan);

        /// <inheritdoc />
        public Task Schedule(Action action, TimeSpan timeSpan) =>
            Task.Run(async () =>
            {
                await Delay(timeSpan);
                action();
            });
    }
}
