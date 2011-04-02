using System;
using Rovidi.Blocks.App;
using System.Collections.Generic;

namespace Rovidi.Blocks.App
{
    public class AppBootstrapper
    {

        #region Variables

        private AppTaskManager appTaskManager;

        private List<AppTask> initializationTasks;
        private List<AppTask> shutdownTasks;

        #endregion


        #region Properties

        public Func<bool> FirstBootCondition { get; set; }

        #endregion


        #region Public Methods

        public void Initialization()
        {
            this.InitTaskManager();
            appTaskManager.RunAppTasks(initializationTasks, false);
        }

        public void Shutdown()
        {
            this.InitTaskManager();
            appTaskManager.RunAppTasks(shutdownTasks, false);
        }


        public void AddInitializationTask(AppTask task)
        {
            if (this.initializationTasks == null)
                this.initializationTasks = new List<AppTask>();

            this.initializationTasks.Add(task);
        }

        public void AddShutdownTask(AppTask task)
        {
            if (this.shutdownTasks == null)
                this.shutdownTasks = new List<AppTask>();

            this.shutdownTasks.Add(task);
        }

        public bool IsFirstBoot()
        {
            if (this.FirstBootCondition == null)
                return false;

            return this.FirstBootCondition();
        }

        #endregion


        #region Private Methods

        private void InitTaskManager()
        {
            if (this.appTaskManager == null)
                this.appTaskManager = new AppTaskManager();
        }

        #endregion

    }
}
