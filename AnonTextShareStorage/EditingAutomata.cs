using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonTextShareStorage
{
    public class EditingAutomata
    {
        public enum State
        {
            Locked,
            UnLocked
        }

        public enum Trigger
        {
            Editing,
            NotEditing
        }

        class transition
        {
            public State prevState;
            public State nextState;
            public Trigger trigger;

            public transition(State prevState, State nextState, Trigger trigger)
            {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
            }
        }

        static transition[] tr = {
            new transition(State.Locked, State.Locked, Trigger.Editing),
            new transition(State.UnLocked, State.Locked, Trigger.Editing),
            new transition(State.Locked, State.UnLocked, Trigger.NotEditing),
            new transition(State.UnLocked, State.UnLocked, Trigger.NotEditing)
        };

        public static State current;

        public static State getNextState(State prevState, Trigger trigger)
        {
            State nextState = prevState;
            for (int i = 0; i < tr.Length; i++)
            {
                if (tr[i].prevState == prevState && tr[i].trigger == trigger)
                {
                    nextState = tr[i].nextState;
                }
            }
            current = nextState;
            return current;
        }// Method untuk berganti state

        //public void SwitchAutomata(string command)
        //{
        //    EditingAutomata edit = new EditingAutomata();
        //    edit.current = State.UnLocked;

        //    switch (edit.current)
        //    {
        //        case State.Locked:
        //            if (command == "Editing")
        //                edit.getNextState(State.Locked, Trigger.Editing);
        //            else if (command == "NotEditing")
        //                edit.getNextState(State.UnLocked, Trigger.NotEditing);
        //            break;
        //        case State.UnLocked:
        //            if (command == "Editing")
        //                edit.getNextState(State.Locked, Trigger.Editing);
        //            else if (command == "NotEditing")
        //                edit.getNextState(State.UnLocked, Trigger.NotEditing);
        //            break;
        //    }
        //}// Switch Case Automata, return state saat Editing atau tidak
    }
}
