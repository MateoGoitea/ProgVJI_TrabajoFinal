using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsionControl : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            float _damage = other.gameObject.GetComponent<EnemyBulletBehavior>().Damage;
            HUDPlayerController.Instance.ChangeDefense(-_damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)//negativos para restar en el hud del player
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HUDPlayerController.Instance.ChangeDefense(-2);
        }
        if (other.gameObject.CompareTag("BaseEnemy"))
        {
            HUDPlayerController.Instance.ChangeDefense(-5);
        }
    }
}
