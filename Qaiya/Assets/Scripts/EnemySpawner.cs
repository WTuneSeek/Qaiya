using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemies;
    public int currentEnemies;
    
    public float delayTime;
    public GameObject enemy;
    public float detectionRadius;
    public float spawnRadius;
    public bool timerActive;
    public float timer;
    public List<GameObject> enemies;

    private CircleCollider2D detectionCollider;
    private DespawnEnemy _despawnEnemy;
   

    private void Start()
    {
        detectionCollider = GetComponent<CircleCollider2D>();
        detectionCollider.radius = detectionRadius;
        timer = delayTime;

        _despawnEnemy = GetComponentInChildren<DespawnEnemy>();
    }

    private void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0 && currentEnemies < maxEnemies)
        {
            SpawnEnemy();
        } else if (currentEnemies >= maxEnemies)
        {
            timerActive = false;
        }

        if (_despawnEnemy.despawned == true)
        {
            enemies = new List<GameObject>();
            _despawnEnemy.despawned = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        timerActive = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        timerActive = false;
        timer = delayTime;
        currentEnemies = 0;
    }


    private void SpawnEnemy()
    {
        Vector2 centerpoint = new Vector2(transform.position.x, transform.position.y);
        Vector2 randomSpawnPoint = centerpoint + Random.insideUnitCircle * spawnRadius * 0.5f;
        // Debug.Log(randomSpawnPoint);

        GameObject currentEnemy = Instantiate(enemy, randomSpawnPoint, quaternion.identity);
        enemies.Add(currentEnemy);
        currentEnemies += 1;
        timer = delayTime;
    }


    private void OnDrawGizmos()
    {
        Vector3 spawnPoint = transform.position;
        // DetectionGizmo Gizmo
        Gizmos.color = new Color(255, 0, 255, 0.2f);
        Gizmos.DrawSphere(spawnPoint, detectionRadius); 
        // SpawnRadius Gizmo   
        Gizmos.color = new Color(0, 255, 0, 0.2f);
        Gizmos.DrawSphere(spawnPoint, spawnRadius);
        
    }
}
