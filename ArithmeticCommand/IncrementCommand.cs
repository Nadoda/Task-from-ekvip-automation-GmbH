using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_from_ekvip_automation_GmbH.Interface;

namespace Task_from_ekvip_automation_GmbH.ArithmeticCommand
{
    public class IncrementCommand : ICommand
    {
        public double Execute(double value)
        {
            return value + 1;
        }

        public double Undo(double value)
        {
            return value - 1;
        }
    }
}
