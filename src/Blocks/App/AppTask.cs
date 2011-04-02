using System;

namespace Rovidi.Blocks.App
{
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    public class AppTask
    {
        #region Properties

        public string Name { get; set; }

        public TaskPriority Priority { get; set; }
        public Action<object> TaskAction { get; set; }

        public bool Enable { get; set; }
        public bool Success { get; set; }
        public bool BreakOnFailure { get; set; }

        #endregion


        #region Constructors

        public AppTask(string name)
        {
            this.Name = name;
        }

        #endregion
    }
}
