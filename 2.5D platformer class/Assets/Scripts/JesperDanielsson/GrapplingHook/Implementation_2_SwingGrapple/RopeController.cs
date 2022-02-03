using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour{
    [SerializeField] float ropeSpeed = 0.5f;
    [SerializeField] float nodeDistance = 0.5f;

    [SerializeField] GameObject nodePrefab;
    [SerializeField] LineRenderer lineRenderer;
    
    List<GameObject> Nodes = new ();

    GameObject player;
    GameObject lastNode;

    bool done;
    int vertexCount = 2;
    public Vector3 Destination{ get; set; }

    void Start(){
        player = GameObject.FindWithTag("Player");
        lastNode = this.gameObject;
        Nodes.Add(gameObject);
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, Destination, ropeSpeed);

        if (transform.position != Destination){
            if (Vector3.Distance(player.transform.position, lastNode.transform.position) > nodeDistance){
                CreateNode();
            }
        }else if (!done){
            done = true;
            while (Vector3.Distance(player.transform.position, lastNode.transform.position) > nodeDistance){
                CreateNode();
            }
            lastNode.GetComponent<HingeJoint>().connectedBody = player.GetComponent<Rigidbody>();
        }
        RenderLine();
    }

    void CreateNode(){
        var pos2Create = player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= nodeDistance;
        pos2Create += lastNode.transform.position;

        var node = Instantiate(nodePrefab, pos2Create, Quaternion.identity);
        node.transform.SetParent(transform);

        lastNode.GetComponent<HingeJoint>().connectedBody = node.GetComponent<Rigidbody>();
        lastNode = node;
        
        Nodes.Add(lastNode);
        vertexCount++;
    }

    void RenderLine(){
        lineRenderer.positionCount = vertexCount;
        int i;
        for ( i = 0; i < Nodes.Count; i++){
            lineRenderer.SetPosition(i,Nodes[i].transform.position);
        }
        lineRenderer.SetPosition(i, player.transform.position);
    }
}
