using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private GameObject _enemyTracker;
    private GameObject _enemyDefender;
    private GameObject _enemyDestructor;
    private List<GameObject> _enemies;
    private int _minEnemies;
    private int _maxEnemies;
    private float _posY;
    private float _posX;


    void Start()
    {
        _enemyTracker= Resources.Load<GameObject>("Prefabs/Enemies/EnemyTracker/EnemyTracker");
        _enemyDefender= Resources.Load<GameObject>("Prefabs/Enemies/EnemyDefender/EnemyDefender");
        _enemyDestructor= Resources.Load<GameObject>("Prefabs/Enemies/EnemyDestructor/EnemyDestructor");

        _enemies = new List<GameObject>();
        _enemies.Add(_enemyTracker);
        _enemies.Add(_enemyDefender);
        _enemies.Add(_enemyDestructor);

        _minEnemies = 3;
        _maxEnemies = 6;

        InvokeRepeating("GenerateEnemies", 10f, 60f);
    }

    public void GenerateEnemies(){
        int numberOfEnemies = UnityEngine.Random.Range(_minEnemies,_maxEnemies);
            for(int x=0;x<=numberOfEnemies;x++){
                int typeOfEnemy = UnityEngine.Random.Range(0,3);
                _posY = UnityEngine.Random.Range(transform.position.y+10f,transform.position.y-10f);
                _posX = UnityEngine.Random.Range(transform.position.x+10f,transform.position.x-10f);
                Vector3 _enemyPosition = new Vector3(_posX,_posY,0);
            
                Instantiate(_enemies[typeOfEnemy],_enemyPosition,transform.rotation);
            }
    }
}
