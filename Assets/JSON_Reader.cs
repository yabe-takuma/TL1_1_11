using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class JsonScene
{
    public string name;
    public Object[] objects;
}

[System.Serializable]
public class Object
{
    public string type;
    public string name;
    public Transform transform;
}
[System.Serializable]
public class Transform
{
    public float[] translation;
    public float[] rotation;
    public float[] scaling;
}

public class JSON_Reader : MonoBehaviour
{
    public GameObject cude;
    // Start is called before the first frame update
    void Start()
    {
        //入力データパス名「Assets/Resources/out.json」
        string json_string = Resources.Load<TextAsset>("out").ToString();
        JsonScene jsonScene = new JsonScene();

        JsonUtility.FromJsonOverwrite(json_string, jsonScene);
        Debug.Log(jsonScene.name);

        foreach(Object one in jsonScene.objects)
        {
            
            float[] t = one.transform.translation;
            Vector3 position = new Vector3(t[0], t[1], t[2]);

            float[] r = one.transform.rotation;
            Vector3 rotation = new Vector3(r[0], r[1], r[2]);
            
            float[] s = one.transform.scaling;
            Vector3 scaling = new Vector3(s[0], s[1], s[2]);
           
            Debug.Log($"type : {one.type}");
            Debug.Log($"name : {one.name}");
            Debug.Log("<transform>");
            Debug.Log($" translation : {position}");
            Debug.Log($" rotation    : {rotation}");
            Debug.Log($"scaling      : {scaling}");

            Instantiate(cude, position, Quaternion.identity);
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
