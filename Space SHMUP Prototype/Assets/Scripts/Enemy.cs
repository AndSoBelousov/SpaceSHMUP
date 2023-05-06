using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;

    private BoundsCheck boundsCheck;

    private void Awake()
    {
        boundsCheck = GetComponent<BoundsCheck>();
    }
    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }

    private void Update()
    {
        Move();

        if ( boundsCheck != null && boundsCheck.offDown)//убедится что карабль вышел за нижнюю границу экрана 
        {
            //корабль за нижней границей, его нужно уничтожить 
            Destroy(gameObject);
            
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
