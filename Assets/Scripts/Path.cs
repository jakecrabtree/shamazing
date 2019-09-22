using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    private List<TimeDataPoint> _dataPoints = new List<TimeDataPoint>();

    public void AddDataPoint(float dir_x, float dir_y, float time) {
        TimeDataPoint curPoint = new TimeDataPoint
        {
            x_dir = dir_x,
            y_dir = dir_y,
            time = time
        };
        _dataPoints.Add(curPoint);
    }

    public TimeDataPoint Get(int index)
    {
        return _dataPoints[index];
    }

    public int Size()
    {
        return _dataPoints.Count;
    }

    public TimeDataPoint Back()
    {
        return _dataPoints[_dataPoints.Count - 1];
    }

    public IEnumerator GetEnumerator()
    {
        return _dataPoints.GetEnumerator();
    }
}

