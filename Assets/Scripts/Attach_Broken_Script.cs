using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach_Broken_Script : MonoBehaviour
{
    //スクリプトとPhysics MaterialをObject_Bにアタッチする
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] poles = GameObject.FindGameObjectsWithTag("Object_A");
        //全てのオブジェクトにA_Trailスクリプトをアタッチ
        foreach (GameObject pole in poles)
        {
            pole.AddComponent<Sphere>();
        }

        //Object_Bタグのオブジェクトを全て取得
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Object_B");
        //全てのオブジェクトにBrokenスクリプトをアタッチ
        foreach (GameObject cube in cubes)
        {
            cube.AddComponent<Broken>();
            cube.AddComponent<Brake>();
            //Physics Materialを割り当てる
            cube.GetComponent<BoxCollider>().material = Resources.Load<PhysicMaterial>("floor");
        }



        //cubesのBox ColliderのMaterialに"floor"と名付けたPhysics Materialを割り当て
        foreach (GameObject cube in cubes)
        {
            cube.GetComponent<BoxCollider>().material = Resources.Load<PhysicMaterial>("floor");
        }
    }
}
