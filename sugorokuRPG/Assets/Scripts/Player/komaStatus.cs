using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace main.game
{
    public class komaStatus : MonoBehaviour
    {

        public ReactiveProperty<bool> MyTurn = new ReactiveProperty<bool>(true);//自分のターンかどうか

        [SerializeField]
        private int HP;
        public ReactiveProperty<int> MyHP = new ReactiveProperty<int>();

        void Start()
        {
            MyHP.Value = HP;
        }
    }
}
