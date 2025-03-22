using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public AlienPrototype AlienPrefab; 
    public float SpawnInterval = 1f; 
    private float[] _spawnPositions = { -3f, 0f, 3f };

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAlien), 0f, SpawnInterval); 
    }

    private void SpawnAlien()
    {
        if (GameEvents.IsGameStarted)
        {
            
            float randomPositionX = _spawnPositions[UnityEngine.Random.Range(0, _spawnPositions.Length)];
            Vector3 spawnPosition = new Vector3(randomPositionX, 1.0f, transform.position.z);

           
            AlienPrototype newAlien = AlienPrefab.Clone();
            newAlien.transform.position = spawnPosition;
            newAlien.transform.rotation = Quaternion.identity;
            newAlien.gameObject.SetActive(true); 
        }
    }

    private void OnDrawGizmosSelected()
    {   
        Gizmos.color = Color.green;
        foreach (float x in _spawnPositions)
        {
            Gizmos.DrawWireCube(new Vector3(x, transform.position.y, transform.position.z), new Vector3(1f, 1f, 1f));
        }
    }
}