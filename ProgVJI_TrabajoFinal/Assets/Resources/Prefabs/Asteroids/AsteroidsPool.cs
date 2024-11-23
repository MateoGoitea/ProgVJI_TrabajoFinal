using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsPool : MonoBehaviour
{
    private GameObject _big1;
    private GameObject _big2;
    private GameObject _huge1;
    private GameObject _huge2;
    private GameObject _huge3;
    private GameObject _med1;
    private GameObject _med2;
    private List<GameObject> _asteroidTypeList;
    private List<GameObject> _asteroidList;
    private int _poolSize;

    private static AsteroidsPool instance;
    public static AsteroidsPool Instance {get{return instance;}}

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
        _asteroidList = new List<GameObject>();
        
        _big1= Resources.Load<GameObject>("Prefabs/Asteroids/Prefabs/AsterBig1");
        _big2= Resources.Load<GameObject>("Prefabs/Asteroids/Prefabs/AsterBig2");
        _huge1= Resources.Load<GameObject>("Prefabs/Asteroids/Prefabs/AsterHuge1");
        _huge2= Resources.Load<GameObject>("Prefabs/Asteroids/Prefabs/AsterHuge2");
        _huge3= Resources.Load<GameObject>("Prefabs/Asteroids/Prefabs/AsterHuge3");
        _med1= Resources.Load<GameObject>("Prefabs/Asteroids/Prefabs/AsterMed1");
        _med2= Resources.Load<GameObject>("Prefabs/Asteroids/Prefabs/AsterMed2");

        _asteroidTypeList = new List<GameObject>();
        _asteroidTypeList.Add(_big1);
        _asteroidTypeList.Add(_big2);
        _asteroidTypeList.Add(_huge1);
        _asteroidTypeList.Add(_huge2);
        _asteroidTypeList.Add(_huge3);
        _asteroidTypeList.Add(_med1);
        _asteroidTypeList.Add(_med2);

        _poolSize = 30;
        
        AddAsteroidsToPool(_poolSize);
    }

    public void AddAsteroidsToPool(int amount){
        for (int x=0;x<amount;x++){
            int type = Random.Range(1,8);
            GameObject _asteroid = Instantiate(_asteroidTypeList[type-1]);
            _asteroid.SetActive(false);
            _asteroidList.Add(_asteroid);
            _asteroid.transform.parent = transform;
        }
    }
    
    public GameObject RequestAsteroid(){
        for (int x=0;x<_asteroidList.Count;x++){
            if(!_asteroidList[x].activeSelf){
                _asteroidList[x].SetActive(true);
                return _asteroidList[x];
            }
        }
        AddAsteroidsToPool(1);
        _asteroidList[_asteroidList.Count-1].SetActive(true);
        return _asteroidList[_asteroidList.Count-1];
    }
}
