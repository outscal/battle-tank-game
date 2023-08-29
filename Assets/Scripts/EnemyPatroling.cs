using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// GenericSingleton<EnemyPatroling>
public class EnemyPatroling : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;
    public GameObject target;
    public GameObject parent;   
    float turnSpeed = 2;
    float distance;
    TankView tankView;
    public GameObject ShellPrefab;
    public GameObject ShellSpawnpos;
    // Start is called before the first frame update
    void Start()
    {
       current = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed*Time.deltaTime);
        }
        else
        {
            current=(current+1)%points.Length;
            }
        Rotation();
        distance = Dist();  
        if(distance<3f){
            Debug.Log(distance);
            tankView.Fire(ShellPrefab ,ShellSpawnpos);
        }
    }
    float Dist(){
        distance = Vector3.Distance(this.transform.position,target.transform.position);
        return distance; 
    }

    void Rotation(){
        Vector3 direction = (points[current].position - parent.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z)); 
        parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}

