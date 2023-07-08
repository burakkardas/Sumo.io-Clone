using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using NOSurrender;


public class BotMovementController : MonoBehaviour, IDamageable
{
    [SerializeField] private BotDataTransmitter botDataTransmitter = null;
    [SerializeField] private Rigidbody botRigidbody = null;
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform childTransform = null;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius;
    [SerializeField] private float distanceOffset;
    [SerializeField] private float attackRadius;
    [SerializeField] private float moveSpeed;
        
    
    [SerializeField] private Collider[] _colliders;
    private Transform _targetSumoTransform;
    private Vector3 _targetPosition;
    private WaitForSeconds _wait = new WaitForSeconds(1f);
    private bool _lockTarget;
    private bool _onHit;



    private void Start()
    {
        GetRandomTargetPosition();
        botDataTransmitter.SetBoolean(AnimationType.RUN, true);
    }


    private void Update()
    {
        CheckDistance();
    }


    private void FixedUpdate()
    {
        CheckAttackZone();
        Move();
    }



    public void OnHit()
    {
        _onHit = true;
        botDataTransmitter.SetBoolean(AnimationType.RUN, false);
        
        StartCoroutine(nameof(SetActiveAgent));
    }



    private void Move()
    {
        if (GameManager.Instance.IsStart && !_lockTarget && !_onHit && !GameManager.Instance.IsGameEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
            childTransform.LookAt(_targetPosition);
        }
    }



    private void GetRandomTargetPosition()
    {
        _targetPosition = UnityEngine.Random.insideUnitSphere * radius;
        _targetPosition.y = transform.position.y;
    }



    private void CheckAttackZone()
    {
        if (GameManager.Instance.IsStart && !_onHit && !GameManager.Instance.IsGameEnd)
        {
            _colliders = Physics.OverlapSphere(transform.position, attackRadius,layerMask);

            foreach (var sumo in _colliders)
            {
                if (sumo != null && _colliders.Length > 1)
                {
                    _lockTarget = true;
                    _targetPosition = sumo.transform.position;
                    transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
                }
            }
        
            if (_colliders.Length <= 1)
            {
                _lockTarget = false;
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
            }
        }
    }




    private void CheckDistance()
    {
        if(Vector3.Distance(transform.position, _targetPosition) <= distanceOffset)
            GetRandomTargetPosition();
    }


    
    private IEnumerator SetActiveAgent()
    {
        yield return _wait;
        //agent.enabled = true;
        _onHit = false;
        botDataTransmitter.SetBoolean(AnimationType.RUN, true);
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
