using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    private Vector3 _direction;
    private Rigidbody2D _rb;
    private float _lifeTime;
    private float _speed;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lifeTime = 5f;
        _speed = 20f;
    }

    public void FixedUpdate()
    {
        if (_rb == null) Debug.Log("añade el rigidbody a la bala");

        if (_rb != null && _direction != Vector3.zero) 
        {
            Debug.Log("la bala se mueve");
            _rb.velocity = _direction * _speed;
        }
    }


    public void SetDirection(Vector3 newDirection)
    {
        this._direction = newDirection.normalized;
        Debug.Log("direction calculada" + newDirection);
    }

    private void OnEnable()
    {
        //que la bala regrese al pool terminado su tiempo de vida
        Invoke(nameof(ReturnToPool), _lifeTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cancelar la invocacion si es que el game object colisiona
        CancelInvoke(nameof(ReturnToPool));

        ReturnToPool();

    }

    private void ReturnToPool()//devolver la bala al pool
    {
        CancelInvoke();//cancelar cualquier otra invocacion pa que no genere errores

        PlayerBulletPool.Instance.ReturmBullet(gameObject);
    }
}
