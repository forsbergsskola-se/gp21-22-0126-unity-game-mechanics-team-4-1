using UnityEngine;

public class ThrowHook : MonoBehaviour{
    [SerializeField] GameObject hookPrefab;
    [SerializeField] LayerMask hookLayer;

    GameObject curHook;
    Vector3 cameraPoint;

    bool ropeActive;
    Ray ray;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (!ropeActive){
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray.origin,ray.direction*100, out var hit,100, hookLayer)){
                    cameraPoint = hit.point;
                }
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
    }
}
