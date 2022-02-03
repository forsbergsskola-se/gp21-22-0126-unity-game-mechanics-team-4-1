using UnityEngine;

public class ThrowHook : MonoBehaviour{
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float swingSpeed = 1f;
    [SerializeField] GameObject hookPrefab;

    GameObject curHook;
    Vector3 cameraPoint;

    bool ropeActive;
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (!ropeActive){
                cameraPoint.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                cameraPoint.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                cameraPoint.z = this.transform.position.z;

                var destination = cameraPoint;

                curHook = Instantiate(hookPrefab, transform.position, Quaternion.identity);
                curHook.GetComponent<RopeController>().Destination = destination;
                ropeActive = true;
            }
            else{
                Destroy(curHook);
                ropeActive = false;
            }
        }
        Debug.DrawRay(transform.position,cameraPoint , Color.magenta);
    }
}
