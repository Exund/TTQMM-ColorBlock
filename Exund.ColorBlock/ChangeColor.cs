using System;
using UnityEngine;

namespace Exund.ColorBlock
{
    class ChangeColor : MonoBehaviour
    {
        private int ID = 7786;

        private bool visible = false;

        private ModuleColor module;

        private byte r = 0, g = 0, b = 0;

        private Rect win;

        private void Update()
        {          
            if (!Singleton.Manager<ManPointer>.inst.DraggingItem && Input.GetMouseButtonDown(1))
            {
                win = new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y - 200f, 200f, 200f);
                try
                {
                    module = Singleton.Manager<ManPointer>.inst.targetVisible.block.GetComponent<ModuleColor>();
                    r = (byte)(module.Color.r * 255);
                    g = (byte)(module.Color.g * 255);
                    b = (byte)(module.Color.b * 255);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    module = null;
                }
                visible = module;
            }
        }

        private void OnGUI()
        {
            if (!visible || !module) return;
            
            try
            {
                win = GUI.Window(ID, win, new GUI.WindowFunction(DoWindow), "Block Color");
                module.Color = new Color32(r, g, b, 255);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void DoWindow(int id)
        {
            GUILayout.Label("Red : "+r);
            r = (byte)GUILayout.HorizontalSlider(r, 0f, 255f);

            GUILayout.Label("Green : "+g);
            g = (byte)GUILayout.HorizontalSlider(g, 0f, 255f);

            GUILayout.Label("Blue : "+b);
            b = (byte)GUILayout.HorizontalSlider(b, 0f, 255f);

            if (GUILayout.Button("Close"))
            {
                visible = false;
                module = null;
            }
            GUI.DragWindow();
        }
    }
}
