using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher
{
    public class JustExecuter
    {
        private IConsoleLogger _consoleLogger;

        public JustExecuter(IConsoleLogger consoleLogger)
        {
            _consoleLogger = consoleLogger;
        }

        public void Execute()
        {
            _consoleLogger.Log("im new message 1");
            _consoleLogger.Log("im new message 2");
        }
    }
}
