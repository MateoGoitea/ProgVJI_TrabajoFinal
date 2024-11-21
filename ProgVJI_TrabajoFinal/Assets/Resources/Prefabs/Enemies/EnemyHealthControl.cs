using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHealthControl : MonoBehaviour
{
    private float _health;
    private Renderer _enemyRenderer;
    private float _lerpTime;

    void Start(){
        _lerpTime = 0.1f;
        _enemyRenderer = gameObject.GetComponent<Renderer>();
        _health = 5;
    }

    void Update(){
        _enemyRenderer.material.color = Color.Lerp(_enemyRenderer.material.color,Color.white,_lerpTime);
        if(_health<=0){
          Destroy(gameObject); 
        }
        
    }
    public void DecreaseHealth(float damage){
        _enemyRenderer.material.color = Color.red;
        _health = _health - damage;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("PlayerBullet")){
            float _damage = other.gameObject.GetComponent<PlayerBulletBehavior>().Damage;
            DecreaseHealth(_damage);
        }
    }

}
