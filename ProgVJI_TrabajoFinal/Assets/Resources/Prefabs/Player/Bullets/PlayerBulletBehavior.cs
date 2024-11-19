using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    private Vector3 _direction;
    private float _lifeTime;
    private float _speed;

    private void Start()
    {
        _lifeTime = 5f;
        _speed = 6f;
    }

    public void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
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
