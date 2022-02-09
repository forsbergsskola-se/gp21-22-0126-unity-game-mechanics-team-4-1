using System.Collections;
using UnityEngine;

public class Implementation_1_DragToPointGrapple : MonoBehaviour{
    [SerializeField] float grappleSpeed;
    [SerializeField] LayerMask grappleLayer;
    [SerializeField] GameObject grapplePointPrefab;

    new Rigidbody rigidbody;
    Transform player;
    Vector3 grapplePoint;

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
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin,ray.direction*100, out var hit,100, grappleLayer)){
            grapplePoint = hit.point;
            StartCoroutine(VisualizeGrapplePoint());
        }
    }

    IEnumerator VisualizeGrapplePoint(){
        var grapplePointVisual =Instantiate(grapplePointPrefab, grapplePoint, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(grapplePointVisual);
    }
}
