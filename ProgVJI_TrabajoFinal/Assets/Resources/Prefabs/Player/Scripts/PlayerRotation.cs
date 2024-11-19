using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Vector3 _mousePosition; //para la posicion del mouse
    private Vector3 _direction; //para calcular la direccion hacia el puntero 
    private Quaternion _targetRotation; //para la rotacion basada en la direccion
    

    void Update()
    {
        //obtener la posicion del mouse en el mundo
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //ignorar el eje z
        _mousePosition.z = 0;

        //calcular la distancia hacia el mouse
        _direction = _mousePosition - transform.position;

        //rotacion basada en la direccion
        _targetRotation = Quaternion.LookRotation(Vector3.forward, _direction);

        //aplicar la rotacion al player
        transform.rotation = _targetRotation;
    }
}
