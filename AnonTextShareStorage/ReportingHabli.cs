using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonTextShareStorage
{
    internal class ReportingHabli
    {
        public enum State
        {
            Safe,
            Warning,
            Dangerous,
            Locked
        }

        private State currentState;
        private int reportCount;


        public ReportingHabli()
        {
            currentState = State.Safe;
            reportCount = 0;
        }

        private void TriggerTransition()
        {
            switch (currentState)
            {
                case State.Safe:
                    if (reportCount >= 10)
                    {
                        currentState = State.Warning;
                        Console.WriteLine("Document state transitioned to Warning.");
                    }
                    break;
                case State.Warning:
                    if (reportCount >= 50)
                    {
                        currentState = State.Dangerous;
                        Console.WriteLine("Document state transitioned to Dangerous.");
                    }
                    break;
                case State.Dangerous:
                    if (reportCount >= 100)
                    {
                        currentState = State.Locked;
                        Console.WriteLine("Document state transitioned to Locked.");
                    }
                    break;
                case State.Locked:
                    currentState = State.Safe;
                    reportCount = 0;
                    Console.WriteLine("Document state transitioned to Safe.");
                    break;
            }
        }

        public State GetCurrentState()
        {
            return currentState;
        }

    }
}
