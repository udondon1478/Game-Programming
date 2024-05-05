using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    // Start is called before the first frame update

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //コライダーを削除
            Destroy(GetComponent<BoxCollider>());
            //サイズを0.1秒ごとに小さく
            StartCoroutine("ScaleDown");
            //0.05*20秒後に触れたオブジェクトを削除
            Destroy(gameObject, 1.0f);
        }
    }

    IEnumerator ScaleDown()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
