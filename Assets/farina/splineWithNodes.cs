using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CorgiSpline;

public class splineWithNodes : MonoBehaviour
{

    Spline MySpline;
    SplinePoint nodeOne;
    SplinePoint nodeTwo;
    SplinePoint nodeThree;
    public GameObject node1;
    public GameObject node2;
    public GameObject node3;
    


    // Start is called before the first frame update
    void Start()

    {
        MySpline = GetComponent<Spline>();
        MySpline.EditorAlwaysDraw = true;
        MySpline.SetSplineMode(SplineMode.BSpline);
        MySpline.AppendPoint(node1.transform.position,node1.transform.rotation,node1.transform.localScale);
        MySpline.AppendPoint(node2.transform.position, node2.transform.rotation, node2.transform.localScale);
        MySpline.AppendPoint(node3.transform.position, node3.transform.rotation, node3.transform.localScale);

    }

    // Update is called once per frame
    void Update()
    {
        nodeOne.position = node1.transform.position;
        nodeOne.rotation = node1.transform.rotation;
        nodeOne.scale = node1.transform.localScale;
        MySpline.UpdateNative();
       // MySpline.EditorAlwaysDraw = true;
      //  MySpline.DrawAsHandles();
    }
}
