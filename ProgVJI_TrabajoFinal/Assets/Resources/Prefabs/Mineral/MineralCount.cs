using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MineralCount : MonoBehaviour
{
    private float _count;
    private TextMeshProUGUI _textMesh;
    public static MineralCount Instance { get; private set;  }

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
    }
    
    void Update()
    {
        _textMesh.text = _count.ToString("0");
    }

    public void IncreaseCount(float value){
        _count += value;
    }
}
