using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;

namespace main.game
{
    public class komaMove : randomDice
    {
        [SerializeField]
        private bool myTurn;
        [SerializeField]
        private GameObject startPoint;
        private GameObject nowPoint;
        private GameObject nextPoint;
        private Vector3 WorldSpaceCanvas;

        eventManager Event;

        komaStatus status;
        
        void Start()
        {
            Event = GameObject.Find("Event").GetComponent<eventManager>();
            WorldSpaceCanvas = GameObject.Find("WorldSpaceCanvas").transform.position;
            nowPoint = startPoint;
            status = GetComponent<komaStatus>();//コマの情報を読み取る

            status.MyTurn//自分のターンかどうかを確認する。
                .Subscribe(count =>
                {
                    Debug.Log(count);
                    myTurn = count;
                });
        }
        public void MoveDice()//ダイスを振るbuttonを押したときに動作する。
        {
            if(myTurn == true)
                Move(diceRoll(6));

        }

        private void Move(int moveCount)//移動ダイスの結果からコマを移動させる。
        {
            Debug.Log(moveCount);
            Vector3[] points = new Vector3[moveCount + 1];
            points[0] = nowPoint.transform.position - WorldSpaceCanvas;
            for (int i = 1; i <= moveCount; i++)
            {
                nowPoint.TryGetComponent(out masu point);
                if (point.MynextMasu != null)//次に行くマスがあれば
                {
                    nextPoint = point.MynextMasu;
                    nowPoint = nextPoint;
                    
                }
                points[i] = nowPoint.transform.position - WorldSpaceCanvas;
            }

            transform.DOLocalPath(points, 0.5f * moveCount, PathType.CatmullRom)
                .SetEase(Ease.Linear)
                .SetOptions(false, AxisConstraint.Z);
            Event.checkEvent(nowPoint.GetComponent<masu>().MyMasuNum,this.gameObject);
        }
    }
}