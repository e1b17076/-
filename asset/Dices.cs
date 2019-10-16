using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dices : MonoBehaviour {
    private bool m_dice;
    private bool m_s;
    private int m_Vcnt;
    public int m_dice_num { get; set; }
    private int m_EnterCnt;
    public int tflag=0;
    public GameObject[] Num;
    private GameObject num;
    private GameObject camera;
    private Quaternion m_InitRotaion;
    //public ParticleSystem m_smoke;
    //public ParticleSystem m_smoke_2;

    void Start () {
        m_dice = false;
        m_Vcnt = 0;
        m_EnterCnt = 0;
        m_InitRotaion = transform.rotation;
        camera = GameObject.FindWithTag("MainCamera");
        this.transform.position = new Vector3(GetComponent<Camera>().transform.position.x, GetComponent<Camera>().transform.position.y, GetComponent<Camera>().transform.position.z + 5);
	}
	
	void Update () {

        /*
         * ダイスを振るフラグを立てる
         */
        if (Input.GetKeyDown(KeyCode.V) && m_Vcnt % 2 == 0) {
            m_Vcnt++;
            m_dice = true;
        }

        /*
         * ダイスを振るのをキャンセルするフラグを立てる
         */
        else if (Input.GetKeyDown(KeyCode.V) && m_Vcnt % 2 != 0) {
            m_Vcnt++;
            m_dice = false;
        }

        /*
         * ダイスを回転させる
         */
        if (m_dice) transform.Rotate(new Vector3(Mathf.Cos(Time.time * 4), 1, 0), 5);
        

        /*
         * ダイスを振るのをキャンセル
         */
        if (!m_dice) transform.rotation = m_InitRotaion;

        /*
         * ダイスの結果表示(エンターを押された、かつ、ダイスが振られている)
         */ 
        if (Input.GetKeyDown(KeyCode.Return) && m_dice && m_EnterCnt == 0) {
            //エンターを押した回数をカウント
            m_EnterCnt++;
            //サイコロを非表示に
            //this.GetComponent<Renderer>().enabled = false;

            //サイコロを振って出た数字
            m_dice_num = UnityEngine.Random.Range(1, 6);

            //煙のエフェクトを発生させる
            //m_smoke.Play();
            //m_smoke_2.Play();
            
            //Smokeコルーチンを起動
            StartCoroutine("Smoke");

            Debug.Log(m_dice_num);
            tflag=1;

        }
        /*
         * サイコロど出た数字を消去
         * 出た数字を反映させる
         */
        else if (Input.GetKeyDown(KeyCode.Return) && m_dice && m_EnterCnt == 1) {
            Destroy(this.gameObject);
            Console.WriteLine(m_dice_num);
            //Destroy(num);
        }


    

    }

    IEnumerator Smoke() {
        //サイコロの座標を保存(数字を生成するための座標)
        Vector3 dice_pos = this.transform.position;
        yield return new WaitForSeconds(0.2f);
        //出た数字のプレハブを生成
        //num = Instantiate(Num[m_dice_num]) as GameObject;
        //num.transform.localPosition = new Vector3(dice_pos.x - 3, dice_pos.y - 1.5f, dice_pos.z - 1);
  
    }
}