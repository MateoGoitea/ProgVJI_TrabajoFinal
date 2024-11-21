using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : ICommand
{
    private Transform _weaponPosition;// pa la posici�n del arma desde donde se dispara el rayo
    private bool _input; //pa  el click del mouse
    private Camera _camera; //se bugeaba si le ponia directo la main camera

    public ShootCommand(Transform weaponPosition)
    {
        _weaponPosition = weaponPosition;
        _camera = Camera.main; //de esta manera la direccion de las balas ya no se interpolan con el seguimiento del player
    }

    public void Execute()
    {
        _input = Input.GetMouseButtonDown(0);

        if (_input)
        {
            Shoot();
        }
       
    }
    private void Shoot()
    {
        if (_weaponPosition == null) return; //retornar si no se asigno el arma  

        Debug.Log("esta disparando");

        //pa que el rayo sea desde la posicion de la camara y la profundidad del arma hacia el cursor
        Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _weaponPosition.position.z));

        //pa que sea 1 de eje z
        Vector3 direction = (mouseWorldPosition - _weaponPosition.position).normalized;

        Ray shootingLine = new Ray(_weaponPosition.position, direction);//pa que el orgen del rayo sea la posicion del arma y la direccion hacia el cursor

        //pa dibujar el rayo
        Debug.DrawRay(shootingLine.origin, shootingLine.direction * 100f, Color.red); //ta piolaaa puede verse namas en la ventana de scene


        if (PlayerBulletPool.Instance != null) //asegurarse de que exista la instancia de bullet pool
        {
            //obtener la bala del pool
            GameObject bullet = PlayerBulletPool.Instance.GetBullet(_weaponPosition.position,Quaternion.LookRotation(shootingLine.direction)); //si le pongo la var direccion no muestra las balas ns xq

             //pasar la direccion a la bala
             bullet.GetComponent<PlayerBulletBehavior>().SetDirection(direction);
        }  
    }
}
