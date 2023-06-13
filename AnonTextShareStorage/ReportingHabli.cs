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

        public enum Trigger
        {
            Escalate,
            Unlock
        }

        private class Transition
        {
            public State PrevState { get; set; }
            public State NextState { get; set; }
            public Trigger Trigger { get; set; }

            public Transition(State prevState, State nextState, Trigger trigger)
            {
                PrevState = prevState;
                NextState = nextState;
                Trigger = trigger;
            }
        }

        private Transition[] transitions = new Transition[]
        {
        new Transition(State.Safe, State.Warning, Trigger.Escalate),
        new Transition(State.Warning, State.Dangerous, Trigger.Escalate),
        new Transition(State.Dangerous, State.Locked, Trigger.Escalate),
        new Transition(State.Locked, State.Safe, Trigger.Unlock)
        };

        public State GetNextState(State prevState, Trigger trigger)
        {
            foreach (Transition transition in transitions)
            {
                if (transition.PrevState == prevState && transition.Trigger == trigger)
                {
                    return transition.NextState;
                }
            }
            return prevState;
        }


    }
}
