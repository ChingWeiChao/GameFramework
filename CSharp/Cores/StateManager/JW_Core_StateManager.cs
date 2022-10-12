using UnityEngine;

public class JW_Core_StateManager : JW_Base_MonoSingleton<JW_Core_StateManager>
{
    private JW_Base_IMachine _CurrentMachine;

    public void Init(JW_Base_IMachine machine)
    {
        _CurrentMachine = machine;
    }

    public void SwitchMachine(JW_Base_IMachine machine)
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