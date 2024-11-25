using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using NavMeshPlus.Components;
using UnityEngine.UI;

public class EDestructorBehavior : MonoBehaviour
{
    private Transform _playerBase;//transform del player a perseguir
    private NavMeshAgent _navMeshAgent;//para trabajar con el navmesh
    private Vector3 _lookPosition;//direccion a la que mira el enemigo
    private float _playerBaseMaxDistance;//maxima distancia a la que alcanzara al jugador
    private bool _shooting;//controlador si el enemigo dispara o no
    void Start()
    {
        //evita que tome la rotacion del navmesh
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;

        _playerBase = GameObject.FindGameObjectWithTag("BasePlayer").GetComponent<Transform>();

        _playerBaseMaxDistance = 10;

        StartCoroutine("Shoot", 0f);
    }

    void Update()
    {
        if (_playerBase){
            //si el enemigo se lejos de la base se mueve hacia ella
            if (Vector3.Distance(transform.position, _playerBase.transform.position)>_playerBaseMaxDistance){
            _lookPosition = _playerBase.transform.position - transform.position;
            var lookRotation = Quaternion.LookRotation(Vector3.forward, _lookPosition);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 2f);

            _navMeshAgent.SetDestination(_playerBase.transform.position);
            _shooting = false;
            }
            //si el enemigo se encuentra a la distancia maxima, dispara a la base
           else{
            _lookPosition = _playerBase.transform.position - transform.position;
            var lookRotation = Quaternion.LookRotation(Vector3.forward, _lookPosition);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 2f);

            _navMeshAgent.isStopped = true;
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
        yield return new WaitForSeconds(5f);    
        }
    }
}
