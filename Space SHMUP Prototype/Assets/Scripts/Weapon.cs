using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public enum WeaponType
{
    none, // По умолчанию / нет оружия
    blaster, // Простой бластер
    spread, // Веерная пушка, стреляющая несколькими снарядами
    phaser, // [Doit] Волновой фазер
    missile, // [Doit] Самонаводящиеся ракеты
    laser, // [Doit] Наносит повреждения при долговременном воздействии
    shield // Увеличивает shieldLevel
}

[System.Serializable]
public class WeaponDefinition
{
    public WeaponType type = WeaponType.none;
    public string latter;

    public Color color = Color.white;
    public GameObject projectilePrefab;
    public Color projekctileColor = Color.white;
    public float damageOnHit = 0;
    public float conrinuousDamage = 0;

    public float delayBetweenShots = 0;
    public float velocity = 20;
}

public class Weapon : MonoBehaviour
{
 // Определение класса Weapon будет добавлено далее 

}
