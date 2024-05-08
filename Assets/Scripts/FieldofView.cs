using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey.Utils;

public class FieldofView : MonoBehaviour
{
    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 2;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 50f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

      //  for (int i = 0; i <= rayCount; i++)
      //  {
      //      Vector
      //
      //  }

        vertices[0] = Vector3.zero;
        vertices[1] = new Vector3(50, 0);
        vertices[2] = new Vector3(0, -50);

        triangles[0] = 0;
        //for (int i = 0; i <= rayCount; i++)
        //{
        //    Vector3 vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
        //}


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

}
