using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float rotationsPerSecond = 0.1f;

    [Header("Set Dynamically")]
    public int levelShown = 0;

    // скрытые переменные
    private Material mat;
    [SerializeField]
    private int currLevel;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        //прочитать текущую мощность защитного поля 
        currLevel = Mathf.FloorToInt(Hero.Singleton.ShieldLevel);
        // если она отличается от levelShown
        if( levelShown != currLevel)
        {
            levelShown = currLevel;

            //скоррекстировать смещение в текстуре
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }

        float rotationsZ = -(rotationsPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rotationsZ);
    }
}
