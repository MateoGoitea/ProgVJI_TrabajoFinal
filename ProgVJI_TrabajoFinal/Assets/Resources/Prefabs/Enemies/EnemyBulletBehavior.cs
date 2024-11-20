using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{
    private float _speed;
    private float _timer;
    void OnEnable()
    {
        _speed = 10f;
        _timer = 0f;
    }

    void Update()
    {
        MoveBullet();
    }
    public void MoveBullet(){
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if(_timer>=500){
            gameObject.SetActive(false);
        }
        _timer++;
    }
        
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            gameObject.SetActive(false);
        }
    }
}
