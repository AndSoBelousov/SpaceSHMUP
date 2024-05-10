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
    /// �������� ������� ���� _type � ������������� ���� ����� �������;
    /// ��� ���������� � WeaponDefinition.
    ///</summary>
    ///<param ����="�����">��� WeaponType ������������� ������.</param>
public void SetType(WeaponType eType)
    { 
      // ���������� _type
        _type = eType;
        WeaponDefinition def = Main.GetWeaponDefinition( _type);  
        rend.material.color = def.projekctileColor;
    }
}
