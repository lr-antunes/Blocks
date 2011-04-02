using System;
using System.Collections.Generic;
using Rovidi.Blocks.Core;

namespace Rovidi.Blocks.App
{
    class AppTaskManager
    {

        #region Public Methods

        public IResult RunAppTasks(List<AppTask> appTasks, bool priorityOrder)
        {
            IResult result = null;
            string errorMessage = string.Empty;

            if (appTasks == null || appTasks.Count == 0)
                return new Result(0);


            // Tasks should have an order of execution...defined by the developer
            // If 'priorityOrder' is true, then priority defines in each task will define the order of execution.


            // Priority Sort
            //if(priorityOrder)
            //var sortedAppTask = appTasks.OrderBy(m => m.Priority).ThenBy(m => m.Name);


            foreach (var task in appTasks)
            {
                try
                {
                    if (task.Enable)
                    {
                        task.TaskAction(null);
                        task.Success = true;
                    }
                    else
                    {
                        // Log the info about the state of the AppTask
                    }
                }
                catch (Exception exc)
                {
                    //There was an error in one of the tasks...
                    task.Success = false;

                    //TODO: Log the error...

                    if (task.BreakOnFailure)
                    {
                        result = new Result(exc, "");
                        errorMessage = string.Concat(errorMessage, exc.Message, Environment.NewLine);
                        break;
                    }
                    else
                    {
                        errorMessage = string.Concat(errorMessage, exc.Message, Environment.NewLine);
                    }
                }
            }

            // Should return a Result with the resultcode and the error message (errorMessage)...
            // Result Code:
            //  -1 : exception
            //   0 : error in some task
            //   n : number of tasks done successfully
            result.UserMessage = errorMessage;
            return result;
        }

        #endregion
    }
}
