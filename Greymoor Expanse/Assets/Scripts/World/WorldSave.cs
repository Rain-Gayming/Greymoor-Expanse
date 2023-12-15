using System.Collections;
using System.Collections.Generic;
using Greymoor.World.Generation;
using UnityEngine;

namespace Greymoor.Saving.World
{
    [System.Serializable]
    public class WorldSave
    {
        public EWorldType worldType;
        public string worldName;
        public int seed;
    }
}