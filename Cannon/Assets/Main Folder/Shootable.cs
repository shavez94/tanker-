using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shootable : MonoBehaviour {

    public Image crosshair;
    private GameObject target;
    public Transform gunpoint;
    public GameObject gunprefab;
    public GameObject bulletprefab;
    public LayerMask mask;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
               if(hit.collider.tag=="enemy")
                {
                    target = hit.collider.gameObject;
                    Vector3 vo = Calculateveloctiy(hit.point, gunpoint.position, 1f);
                    GameObject obj = Instantiate(bulletprefab, gunpoint.position,Quaternion.identity);
                    obj.transform.LookAt(target.transform);
                    Rigidbody rb = obj.GetComponent<Rigidbody>();
                    rb.velocity = vo;
                }


            }
        }
        if (target != null)
        {
            crosshair.transform.position = Camera.main.WorldToScreenPoint(target.transform.position);
            gunprefab.transform.LookAt(target.transform);
        }
    }

    Vector3 Calculateveloctiy(Vector3 target,Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 10f;

        float disy = distance.y;
        float disXZ = distanceXZ.magnitude;

        float VeloctiyX = disXZ / time;
        float VelocityY = disy / time + .5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= VeloctiyX;
        result.y = VelocityY;

        return result;
    }
}
