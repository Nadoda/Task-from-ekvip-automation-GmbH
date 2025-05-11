using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_from_ekvip_automation_GmbH.Interface;

namespace Task_from_ekvip_automation_GmbH.ArithmeticCommand
{
    public class RandAddCommand : ICommand
    {
        private double addedValue;

        public double Execute(double value)
        {
            Random rand = new Random();
            addedValue = rand.Next(1, 11); // Taken random number from 1 to 10
            return value + addedValue;
        }

        public double Undo(double value) => value - addedValue;

        
    }
}
