using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
// You'll need to create and import your own DLL from the WinPE Media.
// See my blog for details: http://wp.me/p4bOHR-E
using TSEnvironmentLib_x86;

namespace MyWpfOsdWizard.Classes
{
    /// <summary>
    /// Creates an instance of the running Task Sequence Environment.
    /// Used as a helper class for dealing with Task Sequence Variables.
    /// </summary>
    class TaskSequenceEnvironment
    {
        ITSEnvClass TsEnvVar = new TSEnvClass();

        /// <summary>
        /// Sets a specific task Sequence variable
        /// </summary>
        /// <param name="variableName">The variable name to set.</param>
        /// <param name="variableValue">The value to set the variable to.</param>
        public bool SetTaskSequenceVariable(string variableName, string variableValue)
        {
            try
            {
                TsEnvVar[variableName] = variableValue;
            }
            catch
            {
                MessageBox.Show("Unable to set Variable:\n" + variableName + "\n" + variableValue);
                return false;
            }

            return true;

        }

        /// <summary>
        /// Gets the value of a specific Task Sequence Variable
        /// </summary>
        /// <param name="variableName">The name of the variable who's value you are getting</param>
        /// <returns>Value of the variableName parameter.</returns>
        public string GetTaskSequenceVariable(string variableName)
        {
            return TsEnvVar[variableName];
        }

        /// <summary>
        /// Returns a Dictionary object of each task sequence Variable Name and Value
        /// </summary>
        /// <returns>Dictionay object of all Task Sequence variables. Key is the Variable Name. Value is the variable Value.</returns>
        public Dictionary<string, string> GetAllTsVariables()
        {
            Dictionary<string, string> tsVars = new Dictionary<string, string>();

            object[] x = (object[])TsEnvVar.GetVariables();

            for (int i = 0; i < x.Length; i++)
            {
                tsVars.Add(x[i].ToString(), tsVars[x[i].ToString()]);
            }

            return tsVars;
        }

    }
}