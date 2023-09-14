using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGun
{
    private Gun _gun;

    public Gun Gun => _gun;

    public CellGun(Gun gun)
    {
        _gun = gun;
    }
}
