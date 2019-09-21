using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    public List<timeDataPoint> dataPoints = new List<timeDataPoint>();
    timeDataPoint curPoint;

    public void addDataPoint(float dir_x, float dir_y, float x, float y, float time) {
        curPoint = new timeDataPoint();
        curPoint.pos_x = x;
        curPoint.pos_y = y;
        curPoint.x_dir = dir_x;
        curPoint.y_dir = dir_y;
        curPoint.time = time;
        dataPoints.Add(curPoint);
        //Debug.Log(x + " " + y + " " + dir_x + " " + dir_y + " " + time);
    }
}
