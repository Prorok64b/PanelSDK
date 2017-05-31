using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace ControlPanel
{
    class Program
    {

        static void Main()
        {
            
            PanelSDK panel = new PanelSDK("COM10");

            //panel.SwitchOnAllLights(false);

            while (true)
            {

                if (panel.GetButtonUp(Convert.ToInt32(PanelSDK.Buttons.Start)))
                {
                    //panel.ActivateLight(Convert.ToInt32(PanelSDK.Lights.BladJazdyKabiny), true);
                    panel.SwitchOnAllLights(true);
                }

                if (!panel.GetButtonUp(Convert.ToInt32(PanelSDK.Buttons.Start)))
                {
                    //panel.ActivateLight(Convert.ToInt32(PanelSDK.Lights.BladJazdyKabiny), false);
                    panel.SwitchOnAllLights(false);
                }
                
            }
        }   
    }
}