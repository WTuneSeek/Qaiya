using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissableEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("No works");
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("Works");
            Destroy(col.transform.parent.gameObject);
        }
    }

}

