using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace main.game
{
    public class eventManager : MonoBehaviour
    {
        public void checkEvent(int pointNum, GameObject target)
        {
            switch (pointNum)
            {
                case 0:
                    break;
                case 1:
                    //大量減少イベントのテスト
                    HPDecrease(5, target);
                    break;
                case 64:
                    Debug.Log("ゲームクリア");
                    SceneManager.LoadScene("title");
                    break;
                default:
                    HPDecrease(1, target);
                    Debug.LogError("設定されていないイベントです");
                    break;

            }
        }
        private void HPDecrease(int Decrease, GameObject target)
        {
            komaStatus targetStatus = target.GetComponent<komaStatus>();
            targetStatus.MyHP.Value -= Decrease;
        }
    }
}
