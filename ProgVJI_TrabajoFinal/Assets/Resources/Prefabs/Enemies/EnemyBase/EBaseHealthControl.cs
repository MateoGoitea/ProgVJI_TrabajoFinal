using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EBaseHealthControl : MonoBehaviour
{
    [SerializeField] private Image _baseHealthImage;
    private float _baseHealth;
    private float _baseHealthMax;

    void Start()
    {
        _baseHealthMax = 200;
        _baseHealth = _baseHealthMax;
    }

    void Update()
    {
        _baseHealthImage.fillAmount = _baseHealth/_baseHealthMax;

        if (_baseHealth <= 0){
            Destroy(gameObject);
        }
    }

    public void DecreaseHealth(float damage){
        _baseHealth = _baseHealth - damage;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("PlayerBullet")){
            float _damage = other.gameObject.GetComponent<PlayerBulletBehavior>().Damage;
            DecreaseHealth(_damage);
        }
    }
}
