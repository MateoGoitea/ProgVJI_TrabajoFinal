using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsionControl : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("EnemyBullet")){
            float _damage = other.gameObject.GetComponent<EnemyBulletBehavior>().Damage;
            HUDPlayerController.Instance.DecreaseHealth(_damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Enemy")){
            HUDPlayerController.Instance.DecreaseHealth(2);
        }
        if (other.gameObject.CompareTag("BaseEnemy")){
            HUDPlayerController.Instance.DecreaseHealth(5);
        }
    }
}
