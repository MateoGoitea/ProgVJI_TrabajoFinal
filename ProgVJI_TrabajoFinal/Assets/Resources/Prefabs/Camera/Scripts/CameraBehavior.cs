using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private PlayerMovement _player;
    private Vector3 _offset;
    

    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _offset = new Vector3 (0,0,-10);
    }


    private void LateUpdate()
    {
        if(_player != null) //si existe el player entonces mueve la camara
        {
            gameObject.transform.position = _player.transform.position + _offset;

        }
    }
 

}
