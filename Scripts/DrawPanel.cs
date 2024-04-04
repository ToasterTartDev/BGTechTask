using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script draw visualizer
public class DrawPanel : MonoBehaviour
{
    [SerializeField]
    private Camera cameraDraw;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private float resolution = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isDraw)
        {
            AddPointDraw(GetMousePosition());
        }
    }

    // get world mouse position
    Vector3 pos;
    public Vector3 GetMousePosition()
    {
        pos = Input.mousePosition;
        pos.z = 1f;
        pos = cameraDraw.ScreenToWorldPoint(pos);
        return pos;
    }

    // click start draw
    public void StartDraw(Vector3 startPoint)
    {
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, startPoint);
    }

    // click end draw
    public void EndDraw()
    {
        lineRenderer.positionCount = 0;
    }

    // if distance between points > resolution - add new point linerenderer
    private void AddPointDraw(Vector3 point)
    {
        if (lineRenderer.positionCount >= 1)
        {
            if (Vector3.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), point) > resolution)
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, point);
            }
        }
    }

    // offset between canvas_position and world_position
    public List<Vector3> GetPoints()
    {
        List<Vector3> points = new List<Vector3>();
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = lineRenderer.GetPosition(i);
            pos = new Vector3(pos.x * 10f, 0f, pos.y * 15f + 6f);
            points.Add(pos);
        }
        return points;
    }

}
