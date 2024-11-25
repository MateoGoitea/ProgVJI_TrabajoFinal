using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseController : MonoBehaviour
{
    private Image _health;//estas se reduciran/aumentaran dependiendo el da�o/recuperacion
    private Image _defense;

    private float _MaxHealth = 100f;
    private float _MaxDefense = 100f;

    private float _currentHealth;
    private float _currentDefense;


    private void Start()
    {
        //como ambos son hijos del canvas los busca por el nombre (podria mejorarse)
        _health = transform.Find("HudBaseP/BarHealth/Fill").GetComponentInChildren<Image>();
        _defense = transform.Find("HudBaseP/BarDefense/Fill").GetComponentInChildren<Image>();

        if (_health == null || _defense == null)//por si los nombres estan mal
        {
            Debug.LogError("revisar el nombre de la barra de vida y defensa");
            return;
        }

        _currentHealth = _MaxHealth;
        _currentDefense = _MaxDefense;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            float _damage = other.gameObject.GetComponent<EnemyBulletBehavior>().Damage;

            _currentDefense -= _damage;

            UpdateDefense();
            FallOfShields();
        }
        
    }

    public void OnCollisionStay2D(Collision2D collision) //si los enemy llegan a la base y se mantienen ahi
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _currentDefense -= 0.1f;

            UpdateDefense();
            FallOfShields();

        }

        //si contacta con el player toma la cantidad de minerales agarrados y los suma a la vida
        if (collision.gameObject.CompareTag("Player"))
        {
            float _mineralAmount = MineralCount.Instance.Count;

            _currentHealth += _mineralAmount;

            MineralCount.Instance.Count = 0;//resetea el contador de minerales a 0

            UpdateHealth();
        }
    }

    private void FallOfShields() //pa cuandso se acabe las defensas
    {
        if (_currentDefense <= 0f)
        {
            _currentHealth -= 0.1f;
            UpdateHealth();

            if (_currentHealth <= 0f)//se destruye al acabarse la vida
            {
                Destroy(gameObject);
            }
        }
    }


    private void UpdateHealth()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _MaxHealth);

        float newHealth = _currentHealth / _MaxHealth;

        float maxHealth = _health.rectTransform.parent.GetComponent<RectTransform>().sizeDelta.x;//pa obtener el ancho del emply obj padre

        float WidthHealth = newHealth * maxHealth; // para el ancho actualizado de la imagen

        _health.rectTransform.sizeDelta = new Vector2(WidthHealth, _health.rectTransform.sizeDelta.y);//de este modo no se afecta a la altura de la img

    }

    private void UpdateDefense()
    {
        _currentDefense = Mathf.Clamp(_currentDefense, 0, _MaxDefense);

        float newDefense = _currentDefense / _MaxDefense;

        float maxDefense = _defense.rectTransform.parent.GetComponent<RectTransform>().sizeDelta.x;//pa obtener el ancho del emply obj padre

        float WidthDefense = newDefense * maxDefense; // para el ancho actualizado de la imagen

        _defense.rectTransform.sizeDelta = new Vector2(WidthDefense, _defense.rectTransform.sizeDelta.y);//de este modo no se afecta a la altura de la img

    }

}
