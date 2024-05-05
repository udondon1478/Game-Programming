using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_White_Grid : MonoBehaviour
{
    // Start is called before the first frame update
    public const int VERT_NUM = 20;
    public const int HORI_NUM = 31;
    void Start()
    {
        // Object_Bタグを持つCubeを生成
        // Object_Bsという名前の空オブジェクトを親にして、Cubeを生成
        GameObject parent = new GameObject("Object_Cs");
        float padding = 0.6f; // 余白の大きさ
        float startX = -9f; // 開始X座標
        float startY = 50f; // 開始Y座標
        for (int i = 0; i < VERT_NUM; i++)
        {
            for (int j = 0; j < HORI_NUM; j++)
            {
                // オブジェクトの間にパディングを入れる
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //Cubeのサイズを1/2にする
                cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                cube.transform.position = new Vector3(startX + (j * padding), startY + (i * padding), -1);
                cube.transform.parent = parent.transform;
                cube.tag = "Object_C";
                cube.name = "Object_C";

                //紫色
                cube.GetComponent<Renderer>().material.color = new Color(0.75f, 0.0f, 0.9f, 1.0f);

                //Rippleをアタッチ
                cube.AddComponent<Ripple_Ver2>();

            }

        }
    }
}
