using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip So;
    public AudioClip Ra;
    public AudioClip Si;
    public AudioClip Do;
    public AudioClip Re;
    public AudioClip Mi;
    public AudioClip Fa;
    //Playerタグのオブジェクトに接触したら
    //色をかえる
    void Start()
    {
        //Resources/SEフォルダから音源を読み込む
        So = Resources.Load<AudioClip>("SE/ソ");
        Ra = Resources.Load<AudioClip>("SE/ラ");
        Si = Resources.Load<AudioClip>("SE/シ");
        Do = Resources.Load<AudioClip>("SE/ド");
        Re = Resources.Load<AudioClip>("SE/レ");
        Mi = Resources.Load<AudioClip>("SE/ミ");
        Fa = Resources.Load<AudioClip>("SE/ファ");
        //Soの中身がnullでない場合ログに出力

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Object_Aの色をPlayerタグのマテリアルの色に変更
            GetComponent<Renderer>().material.color = other.gameObject.GetComponent<Renderer>().material.color;

            //マテリアルの名前に応じて音を再生
            //other.gameObjectのRendererコンポーネントを取得
            //そのRendererコンポーネントのmaterialの名前を取得
            string materialName = other.gameObject.GetComponent<Renderer>().material.name;

            //名前に応じて音を再生
            switch (materialName)
            {
                case "Red (Instance)":
                    GetComponent<AudioSource>().PlayOneShot(So);
                    break;
                case "Green (Instance)":
                    GetComponent<AudioSource>().PlayOneShot(Ra);
                    break;
                case "Blue (Instance)":
                    GetComponent<AudioSource>().PlayOneShot(Si);
                    break;
                case "Yellow (Instance)":
                    GetComponent<AudioSource>().PlayOneShot(Do);
                    break;
                case "Aqua (Instance)":
                    GetComponent<AudioSource>().PlayOneShot(Re);
                    break;
                case "Orange (Instance)":
                    GetComponent<AudioSource>().PlayOneShot(Mi);
                    break;
                case "Purple (Instance)":
                    GetComponent<AudioSource>().PlayOneShot(Fa);
                    break;
            }

            //時間をかけて段階的に色を白に戻す
            StartCoroutine("ChangeColor");

        }
    }

    //色を変更するコルーチン
    IEnumerator ChangeColor()
    {
        //色を段階的に変更
        for (int i = 0; i < 500; i++)
        {
            //色を段階的に変更
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.white, 0.01f);
            //0.01秒待つ
            yield return new WaitForSeconds(0.01f);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
