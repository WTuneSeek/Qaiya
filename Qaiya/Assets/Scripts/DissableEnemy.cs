using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DissableEnemy : MonoBehaviour
{
    private Canvas playerCanvas;
    private TextMeshProUGUI interactionMenu;

    private void Start()
    {
        playerCanvas = gameObject.GetComponentInChildren<Canvas>();
        interactionMenu = playerCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        // Debug.Log("No works");
        if (col.CompareTag("Enemy"))
        {
            interactionMenu.text = "Press 'E' to disable enemy";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(col.transform.parent.gameObject);
            }
        }
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        interactionMenu.text = "";
    }
}

