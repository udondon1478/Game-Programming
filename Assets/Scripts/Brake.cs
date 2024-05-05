using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    //割り当てたオブジェクトがPlayerに当たったら破片を飛ばす
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //破片を作成
            for (int i = 0; i < 10; i++)
            {
                GameObject fragment = GameObject.CreatePrimitive(PrimitiveType.Cube);
                fragment.transform.position = transform.position;
                fragment.transform.localScale = transform.localScale / 2;
                fragment.AddComponent<Rigidbody>();
                fragment.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * 1000);
                fragment.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
                //fragmentのコライダーを削除
                Destroy(fragment.GetComponent<BoxCollider>());
                //生成から3秒後に破片を削除
                Destroy(fragment, 3.0f);
            }
        }
    }
}
