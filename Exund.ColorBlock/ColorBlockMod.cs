using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuterra.BlockInjector;
using UnityEngine;
using System.IO;

namespace Exund.ColorBlock
{
    public class ColorBlockMod
    {
        public static string TechArtFolder = Path.Combine(Application.dataPath, "../TechArt");

        private static GameObject _holder;
        public static void Load()
        {
            _holder = new GameObject();
            _holder.AddComponent<ImageToTech>();
            _holder.AddComponent<ChangeColor>();
            UnityEngine.Object.DontDestroyOnLoad(_holder);

            var t = new Texture2D(1, 1);
            t.SetPixel(0, 0, Color.white);

            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.GetComponent<MeshRenderer>().material.color = Color.white;
            cube.GetComponent<MeshRenderer>().material.mainTexture = t;
            var color_block = new BlockPrefabBuilder()
                .SetBlockID(7000, "64965b4027b723b16d1c")
                .SetName("Color Block")
                .SetDescription("A block that can change color")
                .SetFaction(FactionSubTypes.SPE)
                .SetCategory(BlockCategories.Standard)
                .SetGrade()
                .SetHP(250)
                .SetMass(1)
                .SetModel(cube.GetComponent<MeshFilter>().sharedMesh, cube.GetComponent<MeshFilter>().sharedMesh, true, cube.GetComponent<MeshRenderer>().material)
                .SetSize(IntVector3.one,BlockPrefabBuilder.AttachmentPoints.All)
                .AddComponent<ModuleColor>();
            color_block.RegisterLater();

            if (!Directory.Exists(TechArtFolder)) Directory.CreateDirectory(TechArtFolder);
        }
    }
}
