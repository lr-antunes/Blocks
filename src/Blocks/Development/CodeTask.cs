namespace Rovidi.Blocks.Development
{
    using System;
    using System.Linq;
    using Rovidi.Blocks.Log.Loggers;
    using Rovidi.Blocks.Log;

    /// <summary>
    /// Priority for CodeTask items.
    /// </summary>
    public enum CodeTaskPriority
    {
        /// <summary>
        /// Low priority for CodeTask
        /// </summary>
        Low,

        /// <summary>
        /// Normal priority
        /// </summary>
        Normal,

        /// <summary>
        /// High priority
        /// </summary>
        High
    }

    /// <summary>
    /// CodeTask: Provide summary section in the documentation header.
    /// </summary>
    public class CodeTask
    {
        #region Constants

        private const string CODE_TASK_BUGFIX = "BugFix Needed";
        private const string CODE_TASK_REFACTOR = "Refactor Needed";
        private const string CODE_TASK_OPTIMIZATION = "Optimization Needed";
        private const string CODE_TASK_IMPLEMENTATION = "Implementation Needed";

        #endregion

        #region Variables

        /// <summary>
        /// The lamda logger for the Code Tasks.
        /// </summary>
        private static Logger logger = new ConsoleLogger() { IsEnabled = true };

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the lamda logger.
        /// </summary>
        /// <param name="logger"></param>
        public static Logger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Logs the specified action for optimization.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="author">The author.</param>
        /// <param name="description">The description.</param>
        /// <param name="action">The action.</param>
        public static void Optimize(CodeTaskPriority priority, string author, string description, Action action)
        {
            TaskAction(CODE_TASK_OPTIMIZATION, priority, author, description, action);
        }

        /// <summary>
        /// Logs the specified action as an area for a bugfix
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="author">The author.</param>
        /// <param name="description">The description.</param>
        /// <param name="action">The action.</param>
        public static void BugFix(CodeTaskPriority priority, string author, string description, Action action)
        {
            TaskAction(CODE_TASK_BUGFIX, priority, author, description, action);
        }

        /// <summary>
        /// Logs the specified action as an area for refactoring.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="author">The author.</param>
        /// <param name="description">The description.</param>
        /// <param name="action">The action.</param>
        public static void Refactor(CodeTaskPriority priority, string author, string description, Action action)
        {
            TaskAction(CODE_TASK_REFACTOR, priority, author, description, action);
        }

        /// <summary>
        /// Implementation the specified action.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <param name="author">The author.</param>
        /// <param name="description">The description.</param>
        /// <param name="action">The action.</param>
        public static void Implement(CodeTaskPriority priority, string author, string description, Action action)
        {
            TaskAction(CODE_TASK_IMPLEMENTATION, priority, author, description, action);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Does the specified action while logging contextual information.
        /// </summary>
        /// <param name="tag">The tag of the codetask.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="author">The author.</param>
        /// <param name="description">The description.</param>
        /// <param name="action">The action.</param>
        private static void TaskAction(string tag, CodeTaskPriority priority, string author, string description, Action action)
        {
            if (logger != null && logger.IsEnabled)
            {
                var stackTrace = new System.Diagnostics.StackTrace();
                string methodName = stackTrace.GetFrame(2).GetMethod().Name;
                string className = stackTrace.GetFrame(2).GetMethod().DeclaringType.FullName;
                int lineNumber = stackTrace.GetFrame(2).GetFileLineNumber();
                string fileName = stackTrace.GetFrame(2).GetFileName();
                string format = "{0} [Priority: {1}] [Author: {2}] [Description: {3}] [@ {4}.{5} : {6} : line {7}]" + Environment.NewLine;
                string message = string.Format(format, tag, priority.ToString(), author, description, className, methodName, fileName, lineNumber);
                logger.LogInfo(message);
            }

            // Now Run the action.
            action();
        }

        #endregion
    }
}

