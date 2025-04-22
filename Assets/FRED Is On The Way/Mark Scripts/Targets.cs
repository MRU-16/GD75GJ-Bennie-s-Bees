using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [field: SerializeField] public int Team { get; private set; } = 1;
    [field: SerializeField] public bool IsTargetable { get; set; } = true;
}