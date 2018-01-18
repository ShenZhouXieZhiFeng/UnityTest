using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Assertions.Must;

public class AssertTest : MonoBehaviour {

    public bool Flag = true;

    [ContextMenu("MyAssert")]
    void MyAssert()
    {
        Assert.AreEqual(true,Flag, "Flag != true");
        Debug.Log(Flag);
    }
}
