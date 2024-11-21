using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsionControl : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("EnemyBullet")){
            float _damage = other.gameObject.GetComponent<EnemyBulletBehavior>().Damage;
            UIPlayerController.Instance.DecreaseHealth(_damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Enemy")){
            UIPlayerController.Instance.DecreaseHealth(2);
        }
        if (other.gameObject.CompareTag("BaseEnemy")){
            UIPlayerController.Instance.DecreaseHealth(5);
        }
    }
}
