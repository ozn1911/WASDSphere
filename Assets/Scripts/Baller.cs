using UnityEngine;



public class Baller : MonoBehaviour
{
    public float Speed = 5;
    private Vector3 _move;
    private Rigidbody _rb;
    [SerializeField] private Transform _camera;
    bool _instantCamera;
    void Awake()
    {
        GetComp(out _rb);
    }

    // Update is called once per frame
    void Update()
    {
        Calculate(out _move);
    }

    private void FixedUpdate()
    {
        MoveBall();
    }
    private void LateUpdate()
    {
        MoveCamera();
    }



    #region Functions


    #region CameraFunctions
    void MoveCamera()
    {
        Vector3[] temp = { _camera.position, transform.position };
        _camera.position = Vector3.MoveTowards(temp[0], temp[1], Time.deltaTime * Vector3.Distance(temp[0], temp[1]) * 2);
        TurnCamera();
    }

    void TurnCamera()
    {
        var veloc = _rb.velocity;
        Vector3 temp = veloc;
        temp += transform.position;
        if (veloc.magnitude > 2)
        {
            temp.y = _camera.position.y;
            //temp.Normalize();
            //Debug.Log(temp);
            float angle = Vector3.Angle(temp, transform.forward);
            //Debug.Log(angle);
            //_camera.rotation = Quaternion.FromToRotation(_camera.position, temp);
            _camera.LookAt(temp);
            Debug.DrawLine(_camera.position, _camera.position + temp, Color.red);
            //_camera.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
    }

    void Calculate(out Vector3 calc)
    {
        Vector3 temp;
        temp = _camera.right * Input.GetAxis("Horizontal") + _camera.forward * Input.GetAxis("Vertical");
        temp *= Time.deltaTime * Speed;
        calc = temp;
    }

    #endregion

    #region GameFunctions
    void MoveBall()
    {
        _rb.AddForce(_move, ForceMode.Acceleration);
    }


    public void ResetBall()
    {
        _rb.velocity = Vector3.zero;
        //_rb.rotation = Quaternion.Euler(0,0,0);
        //_rb.AddTorque(Vector3.zero,ForceMode.VelocityChange);
        //forgot how to reset torque
        _rb.angularVelocity = Vector3.zero;//ok
        _camera.position = transform.position;
    }
    #endregion

    #region Get Component
    void GetComp(out Rigidbody response)
    {
        Rigidbody temp;
        if ((temp = GetComponent<Rigidbody>()) == null)
        {
            temp = new Rigidbody();
            temp.constraints = RigidbodyConstraints.FreezeRotationZ;
            temp.constraints = RigidbodyConstraints.FreezeRotationY;
        }
        response = temp;
    }
    #endregion
    #endregion
}
