using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    [Header("Set in inspector: Enemy_1")]
    //число сек полного цикла синусоиды
    public float waveFrequency = 2;
    //ширина синусоиды в метрах
    public float waveWidth = 4;
    public float waveRotY = 4;

    private float xZero; // начальное значение координаты Х
    private float birthTime;

    private void Start()
    {
        xZero = pos.x;

        birthTime = Time.time;
    }

    public override void Move()
    {
        Vector3 tempPos = pos;

        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = xZero + waveWidth * sin;
        pos = tempPos;

        //повернуть немного относительно оси Y
        Vector3 rot= new Vector3(0,sin*waveRotY,0);
        this.transform.rotation = Quaternion.Euler(rot);

        //движение вниз из родительского класса 
        base.Move();

        //print(boundsCheck.isOnScreen);
    }
}
