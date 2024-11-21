using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIPlayerController : MonoBehaviour
{
    [SerializeField] private Image _playerHealthImage;
    private float _healthMax;
    private float _health;
    private float _defense;
    public static UIPlayerController Instance { get; private set;  }

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
    void Start()
    {
        _healthMax = 100;
        _health = _healthMax;
    }

    void Update()
    {
        _playerHealthImage.fillAmount = _health/_healthMax;

        if (_health <= 0){
            Destroy(gameObject);
        }
    }

    public void DecreaseHealth(float damage){
        _health = _health - damage;
    }

    public void IncreaseHealth(float increase){

    }

    public void DecreaseDefense(float damage){

    }
}
