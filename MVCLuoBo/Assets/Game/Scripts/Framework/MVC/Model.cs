using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Model //基类， 不需要被实例化
{
    public abstract string Name { get; }

    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName,data);
    }
}
