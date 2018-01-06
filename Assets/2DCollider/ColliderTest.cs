using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour {

    public Transform Begin, End;
    public Transform Point;

	void Start () {
		
	}

    [ContextMenu("CheckPointOnLine")]
    void CheckPointOnLine()
    {
        Vector3 start = Begin.position;
        Vector3 end = End.position;
        Vector3 point = Point.position;

        float A = end.y - start.y;
        float B = start.x - end.x;
        float C = end.x * start.y - start.x * end.y;

        float res = A * point.x + B * point.y + C;
        Debug.Log(res);
    }
}
