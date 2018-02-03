using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetBundleLoadTest : MonoBehaviour {

    string bundleUrl = "G:/Work/Project/Github/UnityTest/AssetBundles/StandaloneWindows/";
    string cube = "cube.assetbundle";
    string sphere = "sphere.assetbundle";
    string mats = "mats.assetbundle";

    private void OnGUI()
    {
        if (GUILayout.Button("LoadAsync"))
        {
            StartCoroutine(loadAsync());
        }
    }

    IEnumerator loadAsync()
    {
        AssetBundleCreateRequest request =
                AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(bundleUrl + cube));
        yield return request;
        AssetBundleCreateRequest re2 = 
            AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(bundleUrl + mats));
        yield return re2;

        AssetBundle ab = request.assetBundle;

        GameObject cubeG = ab.LoadAsset("Cube") as GameObject;
        Instantiate(cubeG);
    }
}
