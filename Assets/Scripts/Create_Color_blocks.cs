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
        int i = 0, j = 0;
        int colorIndex = 0;

        //cubesという配列を初期化
        GameObject[] cubes = new GameObject[HORI_NUM * VERT_NUM];
        //cubesの中にオブジェクトを格納
        for (i = 0; i < HORI_NUM * VERT_NUM; i++)
        {
            cubes[i] = GameObject.FindGameObjectsWithTag("Object_B")[i];
        }
        //一行のブロック数のループと、全体の列数のループ
        for (i = 0; i <= VERT_NUM; i++)
        {
            for (j = 0; j <= HORI_NUM; j++)
            {
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
                //現在のColorIndexの色にcubesを塗る
                cubes[0].GetComponent<Renderer>().material.color = colors[colorIndex];
                //上で塗ったものをログに表示
                Debug.Log(cubes[0].name + " : " + colors[colorIndex]);

                //色を変える
                colorIndex++;

                if (colorIndex >= colors.Length)
                {
                    colorIndex = 0;
                }

                /*colors.lengthの値をデバッグログに表示


                //色を
                int colorIndex = Random.Range(0, colors.Length);
                //ランダムでブロックを選択
                int cubeIndex = Random.Range(0, cubes.Length);
                //ブロックの色を変更
                cubes[cubeIndex].GetComponent<Renderer>().material.color = colors[colorIndex];
                */

            }

        }


    }


}