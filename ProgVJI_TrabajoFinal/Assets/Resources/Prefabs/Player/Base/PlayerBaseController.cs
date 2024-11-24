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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            _currentDefense -= 1f;

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
    }

    private void FallOfShields() //pa cuandso se acabe las defensas
    {
        if (_currentDefense <= 0)
        {
            _currentHealth -= 0.1f;
            UpdateHealth();
        }
    }


    private void UpdateHealth()
    {
        float newHealth = _currentHealth / _MaxHealth;

        float maxHealth = _health.rectTransform.parent.GetComponent<RectTransform>().sizeDelta.x;//pa obtener el ancho del emply obj padre

        float WidthHealth = newHealth * maxHealth; // para el ancho actualizado de la imagen

        _health.rectTransform.sizeDelta = new Vector2(WidthHealth, _health.rectTransform.sizeDelta.y);//de este modo no se afecta a la altura de la img

    }

    private void UpdateDefense()
    {
        float newDefense = _currentDefense / _MaxDefense; //

        float maxDefense = _defense.rectTransform.parent.GetComponent<RectTransform>().sizeDelta.x;//pa obtener el ancho del emply obj padre

        float WidthDefense = newDefense * maxDefense; // para el ancho actualizado de la imagen

        _defense.rectTransform.sizeDelta = new Vector2(WidthDefense, _defense.rectTransform.sizeDelta.y);//de este modo no se afecta a la altura de la img

    }

}
