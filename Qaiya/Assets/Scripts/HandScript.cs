using Unity.Mathematics;
using UnityEngine;


public class HandScript : MonoBehaviour
{
    private GameObject hand;
    private Transform item;
    public bool equipped = false;

    private void Start()
    {
        hand = GameObject.Find("Hand");
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.transform.parent = hand.transform;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (item)
            {
                item.transform.parent = null; 
                equipped = false;
                item.GetComponent<GunHandler>().active = false;
            }
        }
        if (hand.transform.childCount > 0 && equipped == false)
        {
            item = hand.transform.GetChild(0);
            item.SetLocalPositionAndRotation(new Vector3(0f, 0.5f,0f), quaternion.identity);
            equipped = true;
            item.GetComponent<GunHandler>().active = true;
        }
    }
    
}
