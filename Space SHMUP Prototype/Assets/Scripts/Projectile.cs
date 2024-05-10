using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck _boundCheck;
    private Renderer rend;

    [Header("Set Dynamically")]
    public Rigidbody rigid;
    [SerializeField]
    private WeaponType _type;

    public WeaponType type
    {
        get
        {
            return (_type);
        }
        set
        {
            SetType(value);
        }
    }
            private void Awake()
    {
        _boundCheck = GetComponent<BoundsCheck>();
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_boundCheck.offUp)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// »змен€ет скрытое поле _type и устанавливает цвет этого снар€да;
    /// как определено в WeaponDefinition.
    ///</summary>
    ///<param пате="е“уре">“ип WeaponType используемого оружи€.</param>
public void SetType(WeaponType eType)
    { 
      // ”становить _type
        _type = eType;
        WeaponDefinition def = Main.GetWeaponDefinition( _type);  
        rend.material.color = def.projekctileColor;
    }
}
