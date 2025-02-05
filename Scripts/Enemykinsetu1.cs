//using RPGCharacterAnims.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemykinsetu1 : MonoBehaviour, ICharaAttack
{
    Animator anim;
    int Hcount;   //UŒ‚ƒqƒbƒg‰ñ”
    bool Attacktime;   //UŒ‚’†

    public int HitCount()
    {
        return Hcount;
    }

    public void HitCountdown()
    {
        --Hcount;
    }
    public bool Attacktimekanshi()
    {
        return Attacktime;
    }


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void AttackStart()
    {
        Hcount = 1;
        Attacktime = true;
    }
    void Hit()
    {
        Hcount = 0;
        Attacktime = false;
    }
    void AttackEnd()
    {
        anim.SetInteger("Attack", 0);
    }
}