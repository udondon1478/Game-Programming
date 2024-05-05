using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    private AudioClip brakeSound;
    void Start()
    {
        //AudioSourceコンポーネントを取得
        brakeSound = Resources.Load<AudioClip>("SE/machine-hit3");
    }
    //割り当てたオブジェクトがPlayerに当たったら破片を飛ばす
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //音を再生
            GetComponent<AudioSource>().PlayOneShot(brakeSound);
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
