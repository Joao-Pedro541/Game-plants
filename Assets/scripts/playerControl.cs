using UnityEngine;
using UnityEngine.InputSystem;
public class playerControl : MonoBehaviour
{
    public float rotationSpeed = 70f;
    public Transform playerTransform;


    private Ray ray;
    private RaycastHit hit;
    public LayerMask layerHit;

    private Vector3 dir;

    public GameObject bulletPrefab;
    public Transform shootPoint;

    public float shootForce = 10f;

    public float reloadTime = 1f;
    private float lastShootTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
        

        Vector3 dirRotation = dir;
        dirRotation.y = 0;

        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.LookRotation(dirRotation), Time.deltaTime * rotationSpeed);
        
        if (Mouse.current.leftButton.isPressed && lastShootTime <= 0) shootBullet();

        if (lastShootTime > 0) lastShootTime -= Time.deltaTime;
    }

    void GetMousePosition()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerHit))
        {
            if (Vector3.Distance(playerTransform.position, hit.point) > 1.1f) dir = hit.point - playerTransform.position;
        }

    }
    void shootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.LookRotation(dir));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);      
        lastShootTime = reloadTime;
    }


}
