using System;
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
    public float _gameRestartDelay = 2f;
    public GameObject _projectilePrefab;
    public float _projectileSpeed = 40;

    [Header("Set Dynamically"), SerializeField]
    private float _shieldLevel = 1;

    private GameObject lastTriggerGO = null;

    public float ShieldLevel
    {
        get { return _shieldLevel;}
        set
        {
            _shieldLevel = Mathf.Min(value, 4);
            if (value < 0)
            {
                Destroy(this.gameObject);
                Main.singlton.DelayedRestart(_gameRestartDelay);
            }
        }
    }

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TempFire();
        }
    }

    private void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(_projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.up * _projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        print("Triggered: " + go.name);

        if(go == lastTriggerGO) { return; }

        lastTriggerGO = go;

        if(go.tag == "Enemy")
        {
            ShieldLevel--;
            Destroy(go);
        }
        else
        {
            print("Triggered by non-Enemy: " + go.name);
        }
    }

}
