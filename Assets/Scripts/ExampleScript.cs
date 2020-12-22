using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public MyGenericClass<int> myInt = new MyGenericClass<int>(0, false);

    private static Transform t;
    public MyGenericClass<Transform> myTransform = new MyGenericClass<Transform>(t, false);

    [System.Serializable]
    public class MyGenericClass<T>
    {
        public T myVariable;
        public bool toDisplay;

        public MyGenericClass(T variable, bool toDisplay)
        {
            this.myVariable = variable;
            this.toDisplay = toDisplay;
        }
    }
}
