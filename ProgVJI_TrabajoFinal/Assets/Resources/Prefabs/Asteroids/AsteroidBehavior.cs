using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    private GameObject _mineral;
    void Start()
    {
        _mineral = Resources.Load<GameObject>("Prefabs/Mineral/Mineral");
    }

    void Update()
    {
        this.transform.Rotate(0,0,0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("PlayerBullet")){
            Instantiate(_mineral,transform.position,transform.rotation);
            //devolver al pool
        }
    }
}
