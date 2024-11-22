using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDPlayerController : MonoBehaviour
{
    private Image _MaxHealth;//namas estara de fondo pa que se vea llena/vaciandose
    private Image _health;//esta se reducira/aumentara dependiendo el daño/recuperacion

    private Image _MaxDefense;//igual que las de vida
    private Image _defense;
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
        _MaxHealth = GetComponentInChildren<Image>();//como ambos son hijos del Hud controller
        _health = GetComponentInChildren<Image>();

        _MaxDefense = GetComponentInChildren<Image>();
        _defense = GetComponentInChildren<Image>();
    }

    public void DecreaseHealth(float damage) //sera llamado cuando el player resiba disparos de los enemigos
    { 

    }

    public void IncreaseHealth(float increase) //sera llamado cuando el player recoja meteoritos
    { 

    }

    public void DecreaseDefense(float damage) //lo mismo que con la vida
    { 

    }

    public void IncreaseDefense(float increase) //igual que con la vida
    {

    }
}
