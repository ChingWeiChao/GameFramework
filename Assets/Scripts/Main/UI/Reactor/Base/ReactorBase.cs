using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReactorBase
{
    public void Run();
}

public class ReactorBase: IReactorBase
{
    public void Run() {
        if (GameConfig.EnableReactorLog)
        {
            GM.Instance.Log.Write(string.Format("Reactor {0} is run.", this.ToString()));
        }

        Main();
    }

    protected virtual void Main() { }
}
