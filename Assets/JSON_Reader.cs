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
    //試しにJsonデータでCudeを配置してみる
    public GameObject sord;
    public GameObject spear;
    public GameObject ax;
  
   
    // Start is called before the first frame update
    void Start()
    {
        //入力データパス名「Assets/Resources/out.json」
        string json_string = Resources.Load<TextAsset>("out").ToString();
        JsonScene jsonScene = new JsonScene();

        JsonUtility.FromJsonOverwrite(json_string, jsonScene);
        Debug.Log(jsonScene.name);

        Screen.SetResolution(1920, 1080,false);

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

            //試しにJsonデータでCudeを配置してみる
            if (one.name == "Cube"||one.name =="Cube.003")
            {
                Instantiate(sord, position, Quaternion.identity);
            }
            else if (one.name == "Cube.001" || one.name == "Cube.004")
            {
                Instantiate(spear, position, Quaternion.identity);
            }
            else if (one.name == "Cube.002" || one.name == "Cube.005")
            {
                Instantiate(ax, position, Quaternion.identity);
            }
          
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
