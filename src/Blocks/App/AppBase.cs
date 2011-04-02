using System;
using System.Collections.Generic;

using Rovidi.Blocks.Core;
using Rovidi.Blocks.Log;
using Rovidi.Blocks.App.Arguments;

namespace Rovidi.Blocks.App
{
    public class App : IApp, IDisposable
    {

        #region Static

        public static IResult RunApp(IApp application)
        {
            if (application == null)
                throw new ArgumentNullException("application", "The application to be runned was not supplied.");

            IResult appResult = null;

            try
            {
                //TODO: Argument Validation...if !success return??

                //Application Initialization
                application.Initialization();
                application.OnInitialized();

                //Application Execution
                appResult = application.Run();
                application.OnExecuted();
            }
            catch (Exception)
            {
                //TODO: some kind of execption handling here...option to throw??
            }
            finally
            {
                application.ShutDown();
            }



            return appResult;
        }

        #endregion


        #region Fields

        private IResult appResult;

        private AppInfo appInfo;

        private Logger appLog;

        private IAppConfig appConfig;

        private List<AppArgument> appArguments;

        private AppBootstrapper appBootstrapper;

        #endregion


        #region Properties

        public IResult AppResult
        {
            get { return appResult; }
            set { appResult = value; }
        }

        public AppInfo AppInfo
        {
            get { return appInfo; }
            set { appInfo = value; }
        }

        public Logger AppLog
        {
            get { return appLog; }
            set { appLog = value; }
        }

        public IAppConfig AppConfig
        {
            get { return appConfig; }
            set { appConfig = value; }
        }

        public List<AppArgument> AppArguments
        {
            get { return appArguments; }
            set { appArguments = value; }
        }

        #endregion


        #region Constructors

        public App()
        {

        }

        ~App()
        {
            // Call Dispose with false, because we know that this was called by the GC, so we don't
            // need to call it explicity, just do some Dispose work that is needed .
            // (maybe defined by subclass, Dispose(bool) is virtual...)
            Dispose(false);
        }

        #endregion


        #region Public Methods

        public virtual void Initialization()
        {
            if (this.appBootstrapper != null)
                appBootstrapper.Initialization();
        }

        public virtual void OnInitialized()
        {
            throw new NotImplementedException();
        }

        public virtual IResult Run()
        {
            throw new NotImplementedException();
        }

        public virtual void OnExecuted()
        {
            throw new NotImplementedException();
        }

        public virtual void ShutDown()
        {
            if (this.appBootstrapper != null)
                appBootstrapper.Shutdown();
        }


        #region Bootstrapper

        public void AddInitializationTask(AppTask task)
        {
            this.InitBootstrapper();
            this.appBootstrapper.AddInitializationTask(task);
        }

        public void AddShutDownTask(AppTask task)
        {
            this.InitBootstrapper();
            this.appBootstrapper.AddShutdownTask(task);
        }

        #endregion


        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            // As this was not called by the GC, we want to free the memory,  but first we want
            // to ensure a clean exit...
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool wasCalledExplicity)
        {
            if (wasCalledExplicity)
                ShutDown();
        }

        #endregion


        #region Private Methods

        private void InitBootstrapper()
        {
            if (this.appBootstrapper == null)
                this.appBootstrapper = new AppBootstrapper();
        }

        #endregion

    }
}
