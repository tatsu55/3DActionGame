using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharaAttack
{
    public int HitCount();
    public void HitCountdown();
    public bool Attacktimekanshi();
}