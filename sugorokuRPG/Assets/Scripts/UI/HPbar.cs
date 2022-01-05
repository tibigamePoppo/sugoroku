using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using main.game;
using UniRx;
using UnityEngine.UI;

namespace main.UI
{
    public class HPbar : MonoBehaviour
    {

        [SerializeField]
        komaStatus status;
        [SerializeField]
        Image HPbarImage;
        private float nowHP = 1f;
        private float maxHP = 1f;
        void Start()
        {
            status.MyHP//自分のターンかどうかを確認する。
                .Subscribe(count =>
                {
                    nowHP = count;
                    if (maxHP < nowHP) maxHP = nowHP;//現在のHPが最大HPより多かったら最大HPを更新。
                    HPbarImage.fillAmount = nowHP / maxHP;
                    Debug.Log(count);
                });
        }
    }

}