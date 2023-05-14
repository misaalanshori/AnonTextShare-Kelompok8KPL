using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonTextShareStorage
{
    internal class ReportingHabli
    {
        private enum State
        {
            Safe,
            Warning,
            Dangerous,
            Locked
        }

        private State currentState;

        private const int ReportThreshold1 = 10;
        private const int ReportThreshold2 = 50;
        private const int ReportThreshold3 = 100;

        public void ReportDocument(int reportCount)
        {
            switch (currentState)
            {
                case State.Safe:
                    if (reportCount >= ReportThreshold1 && reportCount < ReportThreshold2)
                    {
                        currentState = State.Warning;
                        Console.WriteLine("Document is now in warning state.");
                    }
                    else if (reportCount >= ReportThreshold2 && reportCount < ReportThreshold3)
                    {
                        currentState = State.Dangerous;
                        Console.WriteLine("Document is now in dangerous state.");
                    }
                    else if (reportCount >= ReportThreshold3)
                    {
                        currentState = State.Locked;
                        Console.WriteLine("Document is now locked.");
                    }
                    break;

                case State.Warning:
                    if (reportCount >= ReportThreshold2 && reportCount < ReportThreshold3)
                    {
                        currentState = State.Dangerous;
                        Console.WriteLine("Document is now in dangerous state.");
                    }
                    else if (reportCount >= ReportThreshold3)
                    {
                        currentState = State.Locked;
                        Console.WriteLine("Document is now locked.");
                    }
                    break;

                case State.Dangerous:
                    if (reportCount >= ReportThreshold3)
                    {
                        currentState = State.Locked;
                        Console.WriteLine("Document is now locked.");
                    }
                    break;

                case State.Locked:
                    Console.WriteLine("Document is locked and cannot be reported.");
                    break;

                default:
                    throw new Exception("Unknown state.");
            }
        }

        public void UnlockDocument()
        {
            if (currentState == State.Locked)
            {
                currentState = State.Safe;
                Console.WriteLine("Document is now unlocked.");
            }
        }

    }
}
