using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class playerControl : MonoBehaviour
{
    public float rotationSpeed = 70f;

    private NavMeshAgent playerAgent;
    public Transform playerTransform;


    private Ray ray;
    private RaycastHit hit;
    public LayerMask layerHit;

    private Vector3 dir;

    public GameObject bulletPrefab;
    public Transform shootPoint;

    public float shootForce = 10f;

    void Awake()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(playerTransform.position, playerAgent.destination) > 1.1f) dir = playerAgent.destination - playerTransform.position;
        if (Mouse.current.leftButton.isPressed ) GetMousePosition();
        if (Mouse.current.rightButton.wasPressedThisFrame)  shootBullet();

        Vector3 dirRotation = dir;
        dirRotation.y = 0;

        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.LookRotation(dirRotation), Time.deltaTime * rotationSpeed);
        
        
    }

    void GetMousePosition()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        ray = Camera.main.ScreenPointToRay(mousePosition);
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerHit))
        {
            playerAgent.SetDestination(hit.point);
        }
    
    }

    void shootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);      
    }


}
