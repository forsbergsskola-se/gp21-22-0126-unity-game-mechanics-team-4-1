using UnityEngine;

public class Implementation_1_DragToPointGrapple : MonoBehaviour{
    [SerializeField] float grappleSpeed;
    [SerializeField] float maxGrappleDistance;
    [SerializeField] LayerMask grappleLayer;

    new Rigidbody rigidbody;
    Transform player;

    Vector2 grapplePoint;
    Vector2 grappleDistance;

    bool hasGrapplePoint;
    float startTime;

    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        player = this.transform;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            SetGrapplePoint();
        }
        if (Input.GetKey(KeyCode.RightShift)){
            rigidbody.useGravity = false;
            GrappleToDestination();
            hasGrapplePoint = false;
        }

        if (Input.GetKeyUp(KeyCode.RightShift)){
            rigidbody.useGravity = true;
        }
        Grapple();
    }

    void Grapple(){
        if (hasGrapplePoint){
            startTime = Time.time;
            rigidbody.useGravity = true;
        }
    }

    void GrappleToDestination(){
        var distCovered = (Time.time - startTime) * grappleSpeed;
        var fractalDist = distCovered / Vector2.Distance(grapplePoint, player.position);
        transform.position = Vector2.Lerp(player.position, grapplePoint, fractalDist);
    }

    void SetGrapplePoint(){
        var distanceVector = Input.mousePosition - player.position;
        if (Physics.Raycast(player.position, distanceVector, out var hit, maxGrappleDistance, grappleLayer)){
            if (Vector2.Distance(hit.point, player.position) <= maxGrappleDistance){
                grapplePoint = hit.point;
                grappleDistance = grapplePoint - (Vector2) player.position;
                hasGrapplePoint = true;
            }
        }
    }
    
}
