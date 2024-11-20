using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    private Vector3 _direction;
    private float _lifeTime;
    private float _speed;

    private float _timer;

    private void OnEnable()//lo cambie a onEnable para reiniciar el timer cuando la bala vuelva a estar disponible
    {
        _lifeTime = 5f;
        _speed = 10f;

        _timer = 0f;
    }

    public void Update()
    {
        //!!!!!
        //no se mueve al aparecer la bala, se le envia la direccion pero no pasa nada
        //transform.position += _direction * _speed * Time.deltaTime;

        //estoy usando un timer para regresar las balas al pool pq tampoco estaba funcionando el invoke
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if(_timer>=200){
            gameObject.SetActive(false);
        }
        _timer++;
    }

/*
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

        PlayerBulletPool.Instance.ReturnBullet(gameObject);
    }
    */
}
