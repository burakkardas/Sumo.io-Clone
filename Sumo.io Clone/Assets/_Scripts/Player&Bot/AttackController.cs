using UnityEngine;
using NOSurrender;

public class AttackController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform childTransform;
    [SerializeField] private Transform raycastTransform;
    [SerializeField] private GameObject lastAttackingObject;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDistance;
    



    private RaycastHit _hit;
    


    private void FixedUpdate()
    {
        SetSphereCast();
    }
    
    
    
    public void SetLastAttackingObject(GameObject attackingObject)
    {
        lastAttackingObject = attackingObject;
    }



    private void SetSphereCast()
    {
        if (Physics.SphereCast(raycastTransform.position, attackRadius, childTransform.TransformDirection(transform.forward), out _hit, attackDistance, layerMask))
        {
            if (_hit.collider != null && _hit.collider.TryGetComponent(out Rigidbody characterRigidbody))
            {
                characterRigidbody.AddForce(-(transform.position - _hit.collider.transform.position).normalized * 200f);
                _hit.collider.GetComponent<AttackController>().SetLastAttackingObject(gameObject);
                IDamageable damageable = _hit.collider.GetComponent<IDamageable>();
                damageable.OnHit();
            }
        }
    }
    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(raycastTransform.position + childTransform.TransformDirection(transform.forward) * attackDistance, attackRadius);
    }
    
    
    
    public GameObject GetLastAttackingObject()
    {
        return lastAttackingObject;
    }
}
