using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWCore;

public class GM: MonoSingleton<GM>
{
    public AppManager Application;
    public StateMachineManager StateMachine;
    public ResourceManager Res;
    public LogManager Log;
    public EventManager Event;

    public void Start()
    {
        Application = new AppManager();
        StateMachine = new StateMachineManager();
        Res = gameObject.AddComponent<ResourceManager>();
        Log = new LogManager();
        Event = new EventManager();

        StateMachine.Init(new AwakeMachine());
        StateMachine.Run();
    }
}
