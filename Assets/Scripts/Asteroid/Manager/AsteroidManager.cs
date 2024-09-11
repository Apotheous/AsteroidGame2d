using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AsteroidManager : MonoBehaviour, IMoveable
{

    public float moveSpeed;
    //public float moveRightSpeed;

    public List<Asteroid> myAsteroids = new List<Asteroid>();
    public GameObject enemyShip;

    public Transform mySpawnPoint;

    private float spawnTimer;
    public float spawnTimerLate;
    private int currentSpawnAst;
    private int currentSpawnPoint;

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0f, 0.5f);
    }

    void Update()
    {
        IMoveable(moveSpeed);

    }

    private void SpawnAsteroid()
    {
        Asteroid ast = Instantiate(myAsteroids[currentSpawnAst], mySpawnPoint);
        ast.transform.position = new Vector3(Random.Range(-8f, 8f), mySpawnPoint.position.y, 0);
        ast.transform.SetParent(null);
 
        currentSpawnAst++;
        currentSpawnPoint++;
        if (currentSpawnAst >= myAsteroids.Count)
        {
            GameObject enemyS = Instantiate(enemyShip, mySpawnPoint);
            enemyS.transform.SetParent(null);
            currentSpawnAst = 0;
        }

    }

    public void IMoveable(float MoveSpeed)
    {
        transform.Translate(transform.up * MoveSpeed * Time.deltaTime);
    }
}
