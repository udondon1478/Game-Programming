using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Create_Color_blocks : MonoBehaviour
{
    // Start is called before the first frame update

    public const int VERT_NUM = 7;
    public const int HORI_NUM = 16;
    void Start()
    {
        int ColorIndex = 0;
        // Object_Bタグを持つCubeを生成
        // Object_Bsという名前の空オブジェクトを親にして、Cubeを生成
        GameObject parent = new GameObject("Object_Bs");
        float padding = 0.2f; // 余白の大きさ
        float startX = -9.0f; // 開始X座標
        float startY = 67.55f; // 開始Y座標
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
/* 
以下の色のリストで虹色を表現
赤 (#FF0000)
橙 (#FF6600)
黄 (#FFCC00)
緑 (#FFFF00)
黄緑 (#CCFF00)
緑青 (#66FF00)
青 (#00FF00)
水色 (#00CCFF)
青紫 (#0066FF)
紫 (#0000FF)
赤紫 (#6600FF)
桃色 (#CC00FF)
ピンク (#FF00FF)
深紅 (#FF00CC)
緋色 (#FF0066)
真赤 (#FF0000)*/
/*
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
            */