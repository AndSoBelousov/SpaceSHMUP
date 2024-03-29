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

    protected BoundsCheck boundsCheck;

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

        if ( boundsCheck != null && boundsCheck.offDown)//�������� ��� ������� ����� �� ������ ������� ������ 
        {
            print("������� ����� �� ������� ������");
            //������� �� ������ ��������, ��� ����� ���������� 
            Destroy(this.gameObject);
            
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherGO = collision.gameObject;
        if(otherGO.tag == "ProjectileHero")
        {
            Destroy(otherGO);
            Destroy(gameObject);
        }
        else { print("Enemy hit by non-ProjectileHero: " + otherGO.name); }
    }
}
