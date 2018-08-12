using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexa : MonoBehaviour
{
    public const float outerRadius = 10f;
    public const float innerRadius = outerRadius * 0.866025404f;

    public static Vector3[] corners = {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius)
    };

    private Mesh mesh;
    private MeshRenderer _mr;
    private MeshFilter _mf;

    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();

    private List<Vector2> uvs = new List<Vector2>();

    void Start ()
    {
        _mr = GetComponent<MeshRenderer>();
        _mf = GetComponent<MeshFilter>();

        _mf.mesh = mesh = new Mesh();
        mesh.name = "Hexa";

        CreateTriangle( Vector3.zero, corners[0], corners[1]);

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }

    public void CreateTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = vertices.Count;

        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);

        triangles.Add( vertexIndex );
        triangles.Add( vertexIndex + 1 );
        triangles.Add( vertexIndex + 2 );
    }
}
