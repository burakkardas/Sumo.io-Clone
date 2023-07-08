using UnityEngine;
using NOSurrender;

public class PlayerMovementController : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerDataTransmitter playerDataTransmitter = null;
    [SerializeField] private Rigidbody playerRigidbody = null;
    [SerializeField] private FixedJoystick joystick = null;
    [SerializeField] private Transform playerChildTransform = null;
    [SerializeField] private float moveSpeed;


    private float _horizontal = 0;
    private float _vertical = 0;


    private void Update()
    {
        GetInputValues();
    }


    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }



    private void GetInputValues()
    {
        _horizontal = joystick.Horizontal;
        _vertical = joystick.Vertical;
    }



    private void MovePlayer()
    {
        if (CanMove())
        {
            transform.position += GetNewVelocity();
            playerDataTransmitter.SetBoolean(AnimationType.RUN, _horizontal != 0 || _vertical != 0);
        }
    }


    public void OnHit()
    {
        
    }



    private bool CanMove()
    {
        return GameManager.Instance.IsStart && !GameManager.Instance.IsGameEnd;
    }
    
    
    



    private Vector3 GetNewVelocity()
    {
        return new Vector3(_horizontal,
            0,
            _vertical) * moveSpeed * Time.fixedDeltaTime;   
    }
    
    
    
    private void RotatePlayer()
    {
        if (_horizontal != 0 || _vertical != 0)
        {
            playerChildTransform.rotation = Quaternion.LookRotation(GetNewVelocity());
        }
    }
}
