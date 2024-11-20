using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDefenderBehavior : MonoBehaviour
{
    private Transform _player;//transform del player a perseguir
    private Vector3 _lookPosition;//direccion a la que mira el enemigo
     private float _playerMaxDistance;//maxima distancia a la que detectara al jugador
    private bool _shooting;//controlador si el enemigo dispara o no
    void Start()
    {
        //_player= Resources.Load<GameObject>(Player/player);// activar cuando exista un prefab del player
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        _playerMaxDistance = 20f;

        StartCoroutine("Shoot", 0f);
    }

    void Update()
    {
        EnemyLooking();
    }

    public void EnemyLooking(){
        if (_player){
            //si no detecta al jugador no hace nada
            if (Vector3.Distance(transform.position, _player.transform.position)>_playerMaxDistance){
            _shooting = false;
            }
            //si detecta al jugador apunta a el y dispara
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
        yield return null;    
        }
    }
}
