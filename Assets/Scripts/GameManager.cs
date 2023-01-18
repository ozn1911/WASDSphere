using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField]UIManager UI;
    [SerializeField] GameObject _ball;
    Transform _ballPos;
    [SerializeField] Maps[] _maps;
    Maps _activeMap;
    int _currentMap = 0;
    Vector3 _check;
    [SerializeField]Vector3 _playerStartPosition;
    [SerializeField]TextMeshProUGUI _text;
    // Start is called before the first frame update
    private void Awake()
    {
        _ballPos = _ball.transform;
    }
    void Start()
    {
        NullCheck();
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
    }



    #region Functions

    #region Game
    public void PlayerDeath()
    {
        _ballPos.position = _check;
        _ball.SendMessage("ResetBall");
    }

    public void Checkpoint(Vector3 position)
    {
        _check = position;
    }
    void DeathCheck()
    {
        if(_ballPos.position.y < -10)
        {
            PlayerDeath();
        }
    }
    public void End()
    {
        _currentMap++;
        if (_currentMap >= _maps.Length)
        {
            UI.WinScreen();
        }
        else
        {
            //_currentMap = _currentMap % _maps.Length;
            GenerateMap();
        }
    }
    
    #endregion
    #region NullCheck
    void NullCheck()
    {
        if (_ball == null)
        {
            //while (true)
            //{
            //    Debug.LogError("Lmao");
            //}

            Debug.LogError("ERROR: null reference in ball");
        }
    }
    #endregion
    #region MapCreation


    void GenerateMap()
    {
        DeleteMap(_activeMap);
        _activeMap = CreateMap();
        _ballPos.position = _playerStartPosition;
        _ball.SendMessage("ResetBall");
        Checkpoint(_playerStartPosition);
    }

    Maps CreateMap()
    {
        
        Maps map = _maps[_currentMap];
        _text.text = (_currentMap + 1).ToString();

        map.map = Instantiate(map.map);
        map.checkpoints = Instantiate(map.checkpoints);
        //map.ending = Instantiate(map.ending);
        
        return map;
    }

    void DeleteMap(Maps map)
    {
        Destroy(map.map);
        Destroy(map.checkpoints);
        //Destroy(map.ending);

        
        
    }
    #endregion
    #endregion
}


[System.Serializable]
public struct Maps
{
    public GameObject map;
    public GameObject checkpoints;
    public GameObject ending;
}