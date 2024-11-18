using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{
    private float _speed;
    void Start()
    {
        _speed = 15f;
    }

    void Update()
    {
        MoveBullet();
    }
    public void MoveBullet(){
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        Destroy(gameObject,2f);
    }
    
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
