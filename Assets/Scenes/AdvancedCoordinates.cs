using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedCoordinates
{
    public Vector3 ProjectionToSpherical(Vector3 coord)
    {
        var yAngle = coord.x * Mathf.PI; // theta
        var zAngle = coord.y * Mathf.PI;
        return new Vector3(Mathf.Sin(yAngle) * Mathf.Cos(zAngle), Mathf.Cos(zAngle), Mathf.Sin(yAngle) * Mathf.Cos(zAngle));
        /*
         * x=?sin?cos? [x] 
            y=?sin?sin? [z]
            z=?cos? [y]
        */
    }
}
