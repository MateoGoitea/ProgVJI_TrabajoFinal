using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDPlayerController : MonoBehaviour
{
    //private GameObject _baseUnderAttack;//se activara como una alerta de que estan atacando la base
    private GameObject _player;

    private Image _health;//estas se reduciran/aumentaran dependiendo el daño/recuperacion
    private Image _defense;

    private float _MaxHealth;
    private float _MaxDefense;

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
        _player = GameObject.FindGameObjectWithTag("Player");

        ResetHUD();
    }

    public void Update()
    {
        if (_player == null) //buscar al player si muere
        {
            _player = GameObject.FindGameObjectWithTag("Player");

            if (_player != null)
            {
                ResetHUD(); // Reiniciar el HUD Cuando lo encuentra
            }
        }
    }


    private void ResetHUD()//de este modo si el player muere se resetea el hud
    {
        _MaxHealth = 100f;
        _MaxDefense = 100f;

        _currentHealth = _MaxHealth;
        _currentDefense = _MaxDefense;

        _health = transform.Find("BarHealth/Fill").GetComponentInChildren<Image>();
        _defense = transform.Find("BarDefense/Fill").GetComponentInChildren<Image>();


        if (_health == null || _defense == null)//por si los nombres estan mal
        {
            Debug.LogError("revisar el nombre de la barra de vida y defensa");
            return;
        }

        UpdateHealth();
        UpdateDefense();
    }


    //namas recibirian positivos pa aumentar o negativos disminuir
    public void ChangeHealth(float amount)
    {
        if(amount == 0) return; //por si acaso

        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _MaxHealth);
        UpdateHealth();
    }
    public void ChangeDefense(float amount)
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
