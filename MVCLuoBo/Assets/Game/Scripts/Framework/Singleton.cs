using UnityEngine;
using System.Collections;

public abstract class Singleton<T> :MonoBehaviour
where T : MonoBehaviour //对T进行泛型约束， 必须也继承 MonoBehaviour
{
    private static T m_instance = null;

    public static T Instance
    {
        get { return m_instance; }
    }

    protected virtual void Awake()
    {
        m_instance = this as T;
    }
}
