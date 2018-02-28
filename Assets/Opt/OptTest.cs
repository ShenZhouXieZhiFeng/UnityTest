using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptTest : MonoBehaviour {

    Material _mat;
	void Start () {
        _mat = GetComponent<MeshRenderer>().sharedMaterial;
	}

    private void OnGUI()
    {
        if (GUILayout.Button("change mat"))
        {
            _mat.SetColor("_Color", Color.red);
        }
    }
}
