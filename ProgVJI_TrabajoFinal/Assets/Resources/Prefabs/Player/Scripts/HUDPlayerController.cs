using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDPlayerController : MonoBehaviour
{
    private Image _health;//estas se reduciran/aumentaran dependiendo el daño/recuperacion
    private Image _defense;

    private float _MaxHealth = 100f;
    private float _MaxDefense = 100f;

    private float _currentHealth;
    private float _currentDefense;


    public static HUDPlayerController Instance { get; private set;  }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(gameObject);//cosa de que se destruya si es que ya existe otra instancia que no sea esta
            return;
        }
    }
    private void Start()
    {
        //como ambos son hijos del Hud controller los busca por el nombre (podria mejorarse)
        _health = transform.Find("HudPlayer/BarHealth/Fill").GetComponentInChildren<Image>();
        _defense = transform.Find("HudPlayer/BarDefense/Fill").GetComponentInChildren<Image>();

        if (_health == null || _defense == null)//por si los nombres estan mal
        {
            Debug.LogError("revisar el nombre de la barra de vida y defensa");
            return;
        }

        _currentDefense = _MaxHealth;
        _currentHealth = _MaxDefense;
    }

    //namas recibirian positivos pa aumentar o negativos disminuir
    public void ChangeHealth(float amount)
    {
        if(amount == 0) return; //por si acaso

        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _MaxHealth);
        UpdateHealth();
    }
    public void ChangeDefence(float amount)
    {
        if (amount == 0) return; //por si acaso

        _currentDefense = Mathf.Clamp(_currentDefense + amount, 0, _MaxDefense);
        UpdateDefense();
    }

    //control y actualizacion 
    private void UpdateHealth()
    {
        float newHealth = _currentHealth / _MaxHealth;

        float maxHealth = _health.rectTransform.parent.GetComponent<RectTransform>().sizeDelta.x;//pa obtener el ancho del emply obj padre

        float WidthHealth = newHealth * maxHealth; // para el ancho actualizado de la imagen

        _health.rectTransform.sizeDelta = new Vector2(WidthHealth,_health.rectTransform.sizeDelta.y);//de este modo no se afecta a la altura de la img

    }
    private void UpdateDefense()
    {
        float newDefense = _currentDefense / _MaxDefense; //

        float maxDefense = _defense.rectTransform.parent.GetComponent<RectTransform>().sizeDelta.x;//pa obtener el ancho del emply obj padre

        float WidthDefense = newDefense * maxDefense; // para el ancho actualizado de la imagen

        _defense.rectTransform.sizeDelta = new Vector2(WidthDefense, _defense.rectTransform.sizeDelta.y);//de este modo no se afecta a la altura de la img

    }
}
