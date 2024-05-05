using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGrid : MonoBehaviour
{
    // キューブのプレハブ
    public GameObject cubePrefab;

    // グリッドのサイズ
    public int gridSize = 5;

    // キューブのリスト
    private List<GameObject> cubes = new List<GameObject>();

    // Start メソッド
    void Start()
    {
        // グリッドを作成
        CreateGrid();

        // キューブに色をつける
        ColorCubes();
    }

    // グリッドを作成する
    void CreateGrid()
    {
        // キューブを配置する位置
        Vector3 position = Vector3.zero;

        // グリッド内の各位置に対して
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                // キューブをインスタンス化
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);

                // キューブの位置を設定
                cube.transform.parent = transform;
                position.x += 1f;

                // キューブのリストに追加
                cubes.Add(cube);
            }

            // 次の行に移動
            position.z += 1f;
            position.x = 0f;
        }
    }

    // キューブに色をつける
    void ColorCubes()
    {
        // 左列から順番に色をつける
        for (int i = 0; i < cubes.Count; i++)
        {
            // 色を取得
            Color color = GetColor(i);

            // キューブの色を設定
            cubes[i].GetComponent<Renderer>().material.color = color;
        }
    }

    // 色を取得する
    Color GetColor(int index)
    {
        int row = index / gridSize;
        int col = index % gridSize;

        // 左列から順番に色を割り当てる
        switch (col)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.blue;
            case 2:
                return Color.yellow;
            case 3:
                return Color.green;
            default:
                return Color.white;
        }
    }
}

