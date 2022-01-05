using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace main.game
{
    public class randomDice : MonoBehaviour
    {
        public int diceRoll(int i)//1から指定された数値までをランダムで出す。
        {
            return Random.Range(1, i+1);
        }
    }
}
