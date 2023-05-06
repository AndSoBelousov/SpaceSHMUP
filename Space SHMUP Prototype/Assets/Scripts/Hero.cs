using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero Singleton;

    [Header(" Set in Inspector")]
    // поля упровляющие движением корабля
    public float _speed = 30;
    public float _rollMult = -45;
    public float _pitchMult = 30;

    [Header("Set Dynamically")]
    public float _shileldLevel = 1;

    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;//сохраняем ссылку на одиночку
        }
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assing second Hero.Singleton");
        }
    }

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * _speed * Time.deltaTime;
        pos.y += yAxis * _speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(yAxis * _pitchMult, xAxis * _rollMult, 0);
    }
}
