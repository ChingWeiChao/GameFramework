namespace JWCore
{
    public class StateMachineManager
    {
        private IMachine _CurrentMachine;

        public void Init(IMachine machine)
        {
            _CurrentMachine = machine;
        }

        public void SwitchMachine(IMachine machine)
        {
            _CurrentMachine.Exit();
            _CurrentMachine = machine;
            _CurrentMachine.Run();
        }

        public void Run(string stateName = null)
        {
            _CurrentMachine.Run(stateName);
        }
    }
}
