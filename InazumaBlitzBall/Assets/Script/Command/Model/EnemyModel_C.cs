using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

//エネミーの制御(Command)
public class EnemyModel_C : MonoBehaviour
{
    // キャラクターデータ(初期ステータス)
    [Header("キャラクター名")]
    public string charaName; // キャラクター名
    [Header("最大HP(初期HP)")]
    public int maxHP; // 最大HP→ボール持ってると減少、アビリティ使用で減少、なくなるとコマンドバトルは基本敗北.
    [Header("スピード")]
    public int spd; // スピード→移動の速さ.
    [Header("パス")]
    public int pas; // パス→能力が高いほどカットされにくくなる.
    [Header("シュート")]
    public int sht; // シュート → 能力が高いほどシュートの威力が上がる.
    [Header("耐久力")]
    public int phy; // 耐久力 → ドリブルの際、相手のアタックに耐えられるか.
    [Header("パス・シュートカット")]
    public int cut; // カット→パスorシュートを途中でカットする力.
    [Header("アタック")]
    public int atk; // アタック→ドリブルを止める力.
    [Header("キャッチ")]
    public int cat; // キャッチ→シュートを止める力.ランダムで70%-150%で変動.
    [Header("属性")]
    public Attribute attribute; // 属性
    [HideInInspector]
    public int nowHP; // 現在HP

    public enum Attribute
    {
        Water, // 水属性
        Fire,  // 火属性
        Wind,  // 風属性
        Soil,  // 土属性
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
