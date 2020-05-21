using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;

    //SPECIFIC CODE
    private static Queue<GameObject> patients;
    private static Queue<GameObject> cubicles;

    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
        
    }
    
    public GameObject RemovePatient()
    {
        if (patients.Count == 0) return null;
        return patients.Dequeue();
    }

    public void AddCubicle(GameObject p)
    {
        cubicles.Enqueue(p);

    }

    public GameObject RemoveCubicle()
    {
        if (patients.Count == 0) return null;
        return cubicles.Dequeue();
    }

    //END OF SPECIFIC CODE

    static GWorld()
    {
        world = new WorldStates();

        //SPECIFIC CODE vv
        patients = new Queue<GameObject>();

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach(GameObject cubicle in cubes)
        {
            cubicles.Enqueue(cubicle);
        }

        if (cubes.Length > 0)
            world.ModifyState("FreeCubicle", cubes.Length);
    }
    
    private GWorld()
    {

    }

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
