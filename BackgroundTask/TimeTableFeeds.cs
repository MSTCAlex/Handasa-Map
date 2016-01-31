using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.ApplicationModel.Background;

namespace BackgroundTask
{
    public sealed class TimeTableFeeds : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            throw new NotImplementedException();
        }

        public static async void Register()
        {
            var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();
            if (backgroundAccessStatus == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                backgroundAccessStatus == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks)
                {
                    if (task.Value.Name == nameof(TimeTableFeeds))
                    {
                        task.Value.Unregister(true);
                    }
                }

                BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();
                taskBuilder.Name = nameof(TimeTableFeeds);
                taskBuilder.TaskEntryPoint = "BackgroundTask.TimeTableFeeds";
                taskBuilder.SetTrigger(new TimeTrigger(15, false));
                var registration = taskBuilder.Register();
            }
        }


    }
}
