using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masu : MonoBehaviour
{
    [SerializeField]
    private int masuNum;//コマの番号
    public int MyMasuNum { get => masuNum; }

    [SerializeField]
    private GameObject nextMasu;
    public GameObject MynextMasu { get => nextMasu; }
}
