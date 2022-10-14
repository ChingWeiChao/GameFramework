using System;
using System.Linq;
using System.Collections.Generic;

namespace JWCore
{
    public class IMachine
    {
        public virtual string GetCurrentStateName { get; }
        public virtual void Run(string stateName = null) { }
        public virtual void RunNextState() { }
        public virtual void JumpState(string stateName) { }
        public virtual void JumpState(IMachine subMachine, string stateName) { }
        public virtual void OnDestroy() { }
        public virtual void Exit() { }
    }

    public abstract class MachineBase : IMachine
    {
        protected Dictionary<string, IState> stateDict;
        protected IState currentState;
        protected IMachine subMachine;

        public override string GetCurrentStateName
        {
            get
            {
                if (subMachine == null)
                {
                    return currentState.StateName;
                }
                else
                {
                    return subMachine.GetCurrentStateName;
                }
            }
        }

        public override void Run(string stateName = null)
        {
            if (stateName != null)
            {
                if (currentState != null)
                {
                    currentState.Exit();
                }

                currentState = stateDict[stateName];
            }
            else if (currentState == null)
            {
                currentState = stateDict.First().Value;
            }

            currentState.Entry();
        }

        public override void JumpState(string stateName)
        {

            currentState.Exit();

            string lastState = currentState.StateName;

            currentState = stateDict[stateName];

            //DebugW.LogWithColor(String.Format("{0} : pre state = {1}, current state = {2}", this.ToString(), lastState, currentState.StateName));

            currentState.Entry();
        }

        public override void JumpState(IMachine machine, string stateName)
        {

            currentState.Exit();

            if (machine != null)
            {
                subMachine = machine;
                //DebugW.LogWithColor("Jump to " + subMachine.ToString());
                subMachine.Run(stateName);
            }
            else if (stateName != null)
            {
                if (stateDict.ContainsKey(stateName))
                {
                    stateDict[stateName].Entry();
                }
                else
                {
                    //DebugW.ErrorWithColor("Unidentified state : " + stateName);
                }
            }
            else
            {
                //DebugW.LogWithColor("Return to " + this.ToString());
                subMachine = null;
                RunNextState();
            }
        }

        public override void OnDestroy()
        {
            subMachine = null;
            currentState = null;
            stateDict = null;
        }

        public override void Exit()
        {
            currentState.Exit();
        }

        public override void RunNextState() { }

        public void AddState(string stateName, IState state)
        {
            if (stateDict == null)
                stateDict = new Dictionary<string, IState>();

            if (stateDict.ContainsKey(stateName))
                stateDict[stateName] = state;
            else
                stateDict.Add(stateName, state);
        }

        public void RemvoeState(string stateName)
        {
            if (stateDict.ContainsKey(stateName))
                stateDict.Remove(stateName);

        }
    }
}