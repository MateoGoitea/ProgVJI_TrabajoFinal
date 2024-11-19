using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : ICommand
{
    private Transform _weaponPosition;
    private Ray _shootingLine;
    private bool _input;

    public ShootCommand(Transform weaponPosition)
    {
        _weaponPosition = weaponPosition;
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

        //pa que el rayo sea desde la camara hacia el cursor
        _shootingLine = Camera.main.ScreenPointToRay(Input.mousePosition); 
         
        if(Physics.Raycast(_shootingLine, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point; //punto donde golpea el rayo
             
            Vector3 direction = (targetPosition - _weaponPosition.position).normalized; //direccion desde la posicion del arma

            if (PlayerBulletPool.Instance != null) //asegurarse de que exista la instancia de bullet pool
            {
                //obtener la bala del pool
                GameObject bullet = PlayerBulletPool.Instance.GetBullet(_weaponPosition.position,Quaternion.LookRotation(direction));

                //pqasar la direccion a la bala
                bullet.GetComponent<PlayerBulletBehavior>().SetDirection(direction);
            }
        }
    }
}
