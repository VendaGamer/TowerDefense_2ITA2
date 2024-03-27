using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPsystem : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private int MaxHp= 100;
    private int hp;

    private void Start()
    {
        hp = MaxHp;
    }
    public void TakeDamage(float damage)
    {
        hp -= (int)damage;
    }
}
