using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_from_ekvip_automation_GmbH.Interface
{
    /// <summary>
    /// Commands for executing arithmetic solution
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute Command
        /// </summary>
        /// <param name="value"> The value is of type double, because the type is not mentioned in the task sheet</param>
        /// <returns></returns>
        Double Execute(double value);
        Double Undo(double value);
    }
}
