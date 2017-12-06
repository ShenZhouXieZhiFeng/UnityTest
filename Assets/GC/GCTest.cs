using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}

    private void OnGUI()
    {
        if (GUILayout.Button("TestGc")) {
            gcTest();
        }
        if (GUILayout.Button("TestCreate1"))
        {
            createTest1();
        }
        if (GUILayout.Button("TestCreate2"))
        {
            createTest2();
        }
        if (GUILayout.Button("CountAvg"))
        {
            float[] data1 = { 0.7685061f, 0.7633057f, 0.7393112f, 0.7613335f, 0.777298f, 0.7597656f, 0.7634964f, 0.7791367f, 0.7482529f, 0.7563629f };
            float[] data2 = { 0.7763367f, 0.8036652f, 0.8019104f, 0.7970886f, 0.7703552f, 0.79422f, 0.7891388f, 0.8479614f, 0.7830505f, 0.7962189f };
            Debug.Log(countAvg(data1));
            Debug.Log(countAvg(data2));
        }
    }

    float countAvg(float[] data) {
        float sum = 0;
        foreach (float f in data) {
            sum += f;
        }
        return sum / data.Length;
    }

    //预先定义引用或名称
    void createTest1() {
        float curTime = Time.realtimeSinceStartup;
        Mesh x;
        for (int i = 0; i < 100000; i++) {
            x = new Mesh();
        }
        Debug.Log(Time.realtimeSinceStartup - curTime);
        System.GC.Collect();
    }
    void createTest2() {
        float curTime = Time.realtimeSinceStartup;
        for (int i = 0; i < 100000; i++)
        {
            Mesh x = new Mesh();
        }
        Debug.Log(Time.realtimeSinceStartup - curTime);
        System.GC.Collect();
    }

    void gcTest() {
        GcObj A = new GcObj("A");
        GcObj B = new GcObj("B");
        GcObj C = new GcObj("C");
        Debug.Log("执行结束");
        System.GC.Collect();
    }

    public class GcObj{

        public string name;

        public GcObj(string _n) {
            name = _n;
        }

        ~GcObj()
        {
            Debug.Log(name + "被回收");
        }
    }

}
