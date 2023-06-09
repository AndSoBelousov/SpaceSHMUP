using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck _boundCheck;

    private void Awake()
    {
        _boundCheck = GetComponent<BoundsCheck>();
    }

    private void Update()
    {
        if (_boundCheck.offUp)
        {
            Destroy(gameObject);
        }
    }
}
