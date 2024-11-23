using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralBehavior : MonoBehaviour
{
    private float _value;
    void Start(){
        _value = Random.Range(1,6);
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            MineralCount.Instance.IncreaseCount(_value);
            Destroy(gameObject);
        }
    }
}
