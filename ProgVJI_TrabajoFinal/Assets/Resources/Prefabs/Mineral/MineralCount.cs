using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
public class MineralCount : MonoBehaviour
{
    private float _count;
    public float Count { get => _count; set => _count = value; }
    private TextMeshProUGUI _textMesh;
    public static MineralCount Instance { get; private set;  }
    private AudioSource _mineralFX;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(gameObject);
            return;
        }

    }

    void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        _mineralFX = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        _textMesh.text = _count.ToString("0");
    }

    public void IncreaseCount(float value){
        _count += value;
        _mineralFX.Play();
    }
}
