using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]
public class charadata : ScriptableObject
{
    public string NAME; //キャラ・敵名
    public int MAXHP; //最大HP
    public int MAXMP; //最大MP
    public int ATK; //攻撃力
    public int DEF; //防御力
    public int INT; //魔力
    public int RES; //魔法抵抗力
    public int AGI; //移動速度
    public int LV; //レベル
    public int GETEXP; //取得経験値
    public int GETGOLD; //取得できるお金
    public int ShortAttackRange;
    public float Enemytime;
    public int Haikaikyori;
    public int HJaikaikankaku;
    public int Hakaimin;
    public int Haikaimax;
    public int HaikaiAGI;
}
