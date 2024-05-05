using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_White_Grid : MonoBehaviour
{
    // Start is called before the first frame update
    public const int VERT_NUM = 7;
    public const int HORI_NUM = 16;
    void Start()
    {
        int ColorIndex = 0;
        // Object_Bタグを持つCubeを生成
        // Object_Bsという名前の空オブジェクトを親にして、Cubeを生成
        GameObject parent = new GameObject("Object_Cs");
        float padding = 0.2f; // 余白の大きさ
        float startX = -9.0f; // 開始X座標
        float startY = 60f; // 開始Y座標
        for (int i = 0; i < VERT_NUM; i++)
        {
            for (int j = 0; j < HORI_NUM; j++)
            {
            // オブジェクトの間にパディングを入れる
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(startX + (j + (j * padding)), startY + (i + (i * padding)), -1);
            cube.transform.parent = parent.transform;
            cube.tag = "Object_B";
            cube.name = "Object_B";
            
        
                //色を一列ごとに変える
                Color[] colors = new Color[] {
                    new Color(1.0f, 0.0f, 0.0f, 1.0f),
                    new Color(1.0f, 0.4f, 0.0f, 1.0f),
                    new Color(1.0f, 0.8f, 0.0f, 1.0f),
                    new Color(1.0f, 1.0f, 0.0f, 1.0f),
                    new Color(0.8f, 1.0f, 0.0f, 1.0f),
                    new Color(0.4f, 1.0f, 0.0f, 1.0f),
                    new Color(0.0f, 1.0f, 0.0f, 1.0f),
                    new Color(0.0f, 0.8f, 1.0f, 1.0f),
                    new Color(0.0f, 0.4f, 1.0f, 1.0f),
                    new Color(0.0f, 0.0f, 1.0f, 1.0f),
                    new Color(0.4f, 0.0f, 1.0f, 1.0f),
                    new Color(0.8f, 0.0f, 1.0f, 1.0f),
                    new Color(1.0f, 0.0f, 1.0f, 1.0f),
                    new Color(1.0f, 0.0f, 0.8f, 1.0f),
                    new Color(1.0f, 0.0f, 0.4f, 1.0f),
                    new Color(1.0f, 0.0f, 0.0f, 1.0f)
                };
                //1列進むごとに色を変える
                cube.GetComponent<Renderer>().material.color = colors[ColorIndex];
                ColorIndex++;
                if (ColorIndex == 16)
                {
                    ColorIndex = 0;
                }


            }
            ColorIndex += 1;
            
        }
    }
}
