using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class levelGenerator : MonoBehaviour
{
    public NavMeshSurface surfaceHumanoid;
    public NavMeshSurface surfaceGuard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        surfaceHumanoid.BuildNavMesh();
        surfaceGuard.BuildNavMesh();
    }
}
