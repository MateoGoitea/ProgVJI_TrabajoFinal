using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Vector3 _initialPosition; //la utilizare para que si el player muere vuelva a la pos inicial
    private float _speedTransition; //velicidad pa una transicion suave

    private PlayerMovement _player;
    private Vector3 _offset;  

    private void Start()
    {
        _initialPosition = transform.position;
        _speedTransition = 0.5f;

        _player = FindObjectOfType<PlayerMovement>();
        _offset = new Vector3 (0,0,-10);
    }


    private void LateUpdate()
    {
        if (_player == null) _player = FindObjectOfType<PlayerMovement>();//pa que busque al player cuando reaparesca si se murio


        if (_player != null) //si existe el player entonces mueve la camara
        {
            gameObject.transform.position = _player.transform.position + _offset;

        }
        else // pa que vuelva a la posicion inicial si el player se muere 
        {
            transform.position = Vector3.Lerp(transform.position,_initialPosition, _speedTransition * Time.deltaTime);
        }
    }
 

}
