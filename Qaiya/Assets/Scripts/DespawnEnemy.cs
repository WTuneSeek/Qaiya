using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEnemy : MonoBehaviour
{
    public float despawnRadius;
    private List<GameObject> enemiesList;
    private CircleCollider2D circle;
    public bool despawned;
    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        circle.radius = despawnRadius;
    }

    private void OnDrawGizmos()
    {
        Vector3 centerpoint = transform.position;
        Gizmos.color = new Color(255, 255, 0, 0.2f);
        Gizmos.DrawSphere(centerpoint, despawnRadius);
    }

    private void Update()
    {
        enemiesList = GetComponentInParent<EnemySpawner>().enemies;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (var enemy in enemiesList)
        {
            Destroy(enemy);
        }

        despawned = true;
    }
}
