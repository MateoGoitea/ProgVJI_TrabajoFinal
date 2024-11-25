using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private float _posX;
    private float _posY;
    private GameObject _limit1;
    private GameObject _limit2;
    private GameObject _limit3;
    private GameObject _limit4;
    private GameObject _enemyBase;
    void Start()
    {
        _enemyBase = Resources.Load<GameObject>("Prefabs/Enemies/EnemyBase/EnemyBase");
        _limit1 = GameObject.Find("Limit1");
        _limit2 = GameObject.Find("Limit2");
        _limit3 = GameObject.Find("Limit3");
        _limit4 = GameObject.Find("Limit4");

        GenerateEnemyBases();
        InvokeRepeating("GenerateAsteroids",0f,90f);
    }

    void Update()
    {
        
    }


    public void GenerateEnemyBases(){
        for (int x=0;x<3;x++){
            //genera una posicion aleatoria entre los limites del mapa
            _posX=Random.Range(_limit1.transform.position.x-20,_limit2.transform.position.x+20);
            _posY=Random.Range(_limit3.transform.position.y+20,_limit4.transform.position.y-20);
            //crea la base enemiga en esa posicion
            Instantiate(_enemyBase,new Vector2(_posX,_posY),new Quaternion(0,0,0,0));
        }
    }

    public void GenerateAsteroids(){
        for(int x=0; x<=20;x++){
            //genera una posicion aleatoria entre los limites del mapa
            _posX=Random.Range(_limit1.transform.position.x,_limit2.transform.position.x);
            _posY=Random.Range(_limit3.transform.position.y,_limit4.transform.position.y);
            //crea los asteroides en las posiciones
            GameObject _asteroid = AsteroidsPool.Instance.RequestAsteroid();
            _asteroid.transform.position = new Vector2(_posX,_posY);
            _asteroid.transform.rotation = new Quaternion(0,0,0,0);
        }
    }
}
