using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    private GameObject _bullet;
    private List<GameObject> _bulletList;
    private int _poolSize;

    private static EnemyBulletPool instance;
    public static EnemyBulletPool Instance {get{return instance;}}

    private void Awake(){
        if(instance==null){
            instance=this;
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _bulletList = new List<GameObject>();
        _bullet= Resources.Load<GameObject>("Prefabs/Enemies/EnemyBullet");
        _poolSize = 20;
        
        AddBulletsToPool(_poolSize);
    }

    public void AddBulletsToPool(int amount){
        for (int x=0;x<amount;x++){
            GameObject _enemyBullet = Instantiate(_bullet);
            _enemyBullet.SetActive(false);
            _bulletList.Add(_enemyBullet);
            _enemyBullet.transform.parent = transform;
        }
    }
    
    public GameObject RequestBullet(){
        for (int x=0;x<_bulletList.Count;x++){
            if(!_bulletList[x].activeSelf){
                _bulletList[x].SetActive(true);
                return _bulletList[x];
            }
        }
        AddBulletsToPool(1);
        _bulletList[_bulletList.Count-1].SetActive(true);
        return _bulletList[_bulletList.Count-1];
    }

}
