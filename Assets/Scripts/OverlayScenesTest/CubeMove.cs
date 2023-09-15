//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour
{
    public int MoveSpeed;
    private Rigidbody2D unitRb;
    private GameObject unit;
    private bool flag=false;

    void Start()
    {
        unit = this.gameObject;
        unitRb = this.gameObject.GetComponent<Rigidbody2D>();
        unitRb.velocity = new Vector3(MoveSpeed,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Cube());
    }

    IEnumerator Cube()
    {
        if(flag==false)
        {
            if(unit.transform.localPosition.x >= 215f){
            unitRb.velocity = new Vector3(-1*MoveSpeed,0,0);
            flag=true;
            //Debug.Log("hidari");
            }
        }
        else if(flag==true)
        {
            if(unit.transform.localPosition.x <= -215f){
            unitRb.velocity = new Vector3(MoveSpeed,0,0);
            flag=false;
            //Debug.Log("migi");
            }
        }
        yield return null;
    }
}
