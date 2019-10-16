using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atest : MonoBehaviour
{
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        GameObject obj = GameObject.Find("Dice");
        obj.transform.Translate(1.0f,0.0f,0.0f);
    }
}
