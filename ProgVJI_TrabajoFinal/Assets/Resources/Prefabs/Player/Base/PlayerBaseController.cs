using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseController : MonoBehaviour
{
    private int _health;
    private int _defence;
    
    private void Start()
    {
        _health = 100;
        _defence = 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)//de momento probemos que onda con la consola
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            _defence -= 1;
            Debug.Log("La base esta siendo atacada!! Defensa al %" + _defence);
        }
        if (_defence == 0)
        {
            _health -= 1;
            Debug.Log("Cayeron los escudos!! La base esta en peligro!! Vida al %" + _health);
        }
    }
}
