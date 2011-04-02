using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;

namespace Rovidi.Blocks.IO
{
    public class FileSystemMonitor
    {

        #region Properties

        public Hashtable Watchers { get; set; }

        #endregion


        #region Constructors

        public FileSystemMonitor()
        {
            this.Watchers = new Hashtable();
        }

        public FileSystemMonitor(int limitMax)
        {
            this.Watchers = new Hashtable(limitMax);
        }

        #endregion


        #region Public Methods

        public void AddLocation(string location)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = location;

            /* Watch for changes in LastAccess and LastWrite times, and the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            // Only watch text files.
            watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            this.Watchers.Add(location, watcher);
        }


        public void RemoveLocation(string location)
        {
            if (this.Watchers.ContainsKey(location))
            {
                var watcher = this.Watchers[location] as FileSystemWatcher;

                //Clean the handlers...
                watcher.Changed -= OnChanged;
                watcher.Created -= OnChanged;
                watcher.Deleted -= OnChanged;
                watcher.Renamed -= OnRenamed;

                this.Watchers.Remove(location);
            }
        }

        #endregion


        #region Event Handlers

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
        }

        #endregion

    }
}
