using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideaway : MonoBehaviour
{
    Vector3 _StartPos;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _sway;
    [SerializeField] float _speed;
    [SerializeField] bool _axis;
    float _sway2;
    float _sway3;
    // Start is called before the first frame update
    private void Awake()
    {
        _StartPos = transform.position;
        _sway2 = _sway / 2f;
        _sway3 = _sway / 4f;
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_StartPos + Calculation(_axis));
    }

    #region Functions
    Vector3 Calculation(bool right)
    {
        float temp =  (_speed * Time.time) % _sway;
        
        if ( temp > _sway2)
        {
            temp = _sway - temp;
        }
        temp -= _sway3;
        return temp * (right ? Vector3.right :  Vector3.forward);
    }

    #endregion
}
