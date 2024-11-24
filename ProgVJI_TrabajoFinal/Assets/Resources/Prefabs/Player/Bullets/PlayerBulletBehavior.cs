using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    private Vector3 _direction;
    private Rigidbody2D _rb;
    private float _lifeTime;
    private float _speed;
    private float _damage;



    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lifeTime = 5f;
        _speed = 5f;
        _damage = 1f;

    }

    public void FixedUpdate()
    {
        if (_rb == null) Debug.Log("a�ade el rigidbody a la bala");

        if (_rb != null && _direction != Vector3.zero) 
        {
            _rb.MovePosition( transform.position + _direction * _speed);
        }
    }

    public void SetDirection(Vector3 newDirection)
    {
        this._direction = newDirection.normalized;
    }

    private void OnEnable()
    {
        //que la bala regrese al pool terminado su tiempo de vida
        Invoke(nameof(ReturnToPool), _lifeTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision) { 
        //cancelar la invocacion si es que el game object colisiona
        CancelInvoke(nameof(ReturnToPool));

        ReturnToPool();

    }

    private void ReturnToPool()//devolver la bala al pool
    {
        CancelInvoke();//cancelar cualquier otra invocacion pa que no genere errores

        PlayerBulletPool.Instance.ReturnBullet(gameObject);
    }
    
    /*private void OnTriggerEnter2D(Collider2D other){ 

        String _tag = other.gameObject.tag;

        if (_tag != "Player" && _tag != "EnemyBullet" && _tag != "Limit"){

            ReturnToPool();
        }      
    }*/

    public float Damage { get => _damage; set => _damage = value; }
}
