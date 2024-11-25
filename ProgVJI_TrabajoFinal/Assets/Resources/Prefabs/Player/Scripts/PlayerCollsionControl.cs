using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsionControl : MonoBehaviour
{
    private float _controlHealth;
    private float _controlDefense;

    private void Start()
    {
        ResetControlDamage();
    }

    private void OnTriggerEnter2D(Collider2D other)//negativos para restar en el hud del player
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            float _damage = other.gameObject.GetComponent<EnemyBulletBehavior>().Damage;
            HUDPlayerController.Instance.ChangeDefense(-_damage);
            _controlDefense -= _damage;

            ControlDestroy(_damage);
        }
    }




  private void OnCollisionStay2D(Collision2D other)
    {
        /*if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("BaseEnemy"))
        {
            float _damage = other.gameObject.GetComponent<EDefenderBehavior>().Damage;
            HUDPlayerController.Instance.ChangeDefense(-_damage);
            _controlDefense -= _damage;

            ControlDestroy(_damage);
        }*/

        if (other.gameObject.CompareTag("BasePlayer")){
            HUDPlayerController.Instance.ChangeHealth(0.1f);
        }
    }

    private void ControlDestroy(float damage)
    {
        if (_controlDefense <= 0f)
        {
            HUDPlayerController.Instance.ChangeHealth(-damage);
            _controlHealth -= damage;
            
            if (_controlHealth <= 0f)
            {
                Destroy(gameObject);
                ResetControlDamage();
            }
        }

        
    }

    private void ResetControlDamage()
    {
        _controlHealth = 100f;
        _controlDefense = 100f;

        // Sincronizar con el HUD
        HUDPlayerController.Instance.ChangeHealth(100f - _controlHealth);
        HUDPlayerController.Instance.ChangeDefense(100f - _controlDefense);
    }
}
