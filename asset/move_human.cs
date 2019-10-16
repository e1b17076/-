using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move_human : MonoBehaviour
{

    public Dices dices;
    private Vector3 character;
    public int tflag=0;
    public int s_num=0;
    private int s2_num=0;

    // Start is called before the first frame update
    void Start()
    {        
        character=transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        tflag=dices.tflag;
        if(tflag==1&&s2_num==0){
        s_num=dices.m_dice_num;
        s2_num=1;
        }
        if(Input.GetKeyDown(KeyCode.M)){
            Debug.Log(s_num);
            Debug.Log(tflag);
        }

        if(Input.GetKeyDown(KeyCode.L)&&s_num!=0){
            s_num=s_num-1;
            character.x+=5f;
            transform.localPosition=character;
        }
    }
}
