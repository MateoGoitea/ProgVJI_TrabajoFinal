using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ETrackerBehavior : MonoBehaviour
{
    private Transform _player;//transform del player a perseguir
    private Vector3 _lookPosition;//direccion a la que mira el enemigo
    private float _speed;//velocidad de movimiento
    private float _playerMaxDistance;//maxima distancia a la que alcanzara al jugador
    private bool _shooting;//controlador si el enemigo dispara o no
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _speed = 5f;

        _playerMaxDistance = 10;

        StartCoroutine("Shoot", 0f);
    }

    void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement(){
        if (_player){
            //si el enemigo se encuentra a mayor distancia de la distancia maxima, solo perseguira al jugador
            if (Vector3.Distance(transform.position, _player.transform.position)>_playerMaxDistance){
            _lookPosition = _player.transform.position - transform.position;
            var lookRotation = Quaternion.LookRotation(Vector3.forward, _lookPosition);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 2f);

            transform.Translate(Vector3.up * _speed * Time.deltaTime);
            _shooting = false;
            }
            //si el enemigo se encuentra a la distancia maxima, se queda en su lugar y dispara al jugador
           else{
            _lookPosition = _player.transform.position - transform.position;
            var lookRotation = Quaternion.LookRotation(Vector3.forward, _lookPosition);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 2f);
            _shooting = true;
           }
        }
        else{
            transform.position = transform.position;
            transform.rotation = transform.rotation;
        }
       
    }

    IEnumerator Shoot(){
        //disparo de balas
        while (true){
            if (_shooting == true){
                for(int x=0; x<=5;x++){
                    GameObject _bullet = EnemyBulletPool.Instance.RequestBullet();
                    _bullet.transform.position = transform.position;
                    _bullet.transform.rotation = transform.rotation;
                    yield return new WaitForSeconds(0.5f);
                }
            }  
        yield return new WaitForSeconds (3f);    
        }
    }
}

