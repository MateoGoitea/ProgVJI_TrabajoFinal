using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseController : MonoBehaviour
{
    private Image _health;//estas se reduciran/aumentaran dependiendo el daño/recuperacion
    private Image _defense;

    private float _MaxHealth = 100f;
    private float _MaxDefense = 100f;

    private float _currentHealth = 0;
    private float _currentDefense = 0;


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

        _currentDefense = Mathf.Clamp(_currentDefense + _MaxDefense, 0, _MaxDefense);
        _currentHealth = Mathf.Clamp(_currentHealth + _MaxHealth, 0, _MaxHealth);
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

            //HUDPlayerController.Instance.BaseUnderAttack(true); //activa la img de alerta del hud
        }
    }

    /*public void OnCollisionExit2D(Collision2D collision) //cuando los enemigos salgan de la base
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HUDPlayerController.Instance.BaseUnderAttack(false);//desactiva la alerta de ataque
        }
    }*/

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
