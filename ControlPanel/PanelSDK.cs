using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

// 1 - check button for down
// Command example => 1/{button id}

// 0 - check button for up      
// Command example => 0/{button id}

// 2 - activate light           
// Command example => 2/{light id}

// 3 - off light                
// Command example => 3/{light id}

// 4 - off all lights           
// Command example => 4

// 5 - activate all lights
// Command example => 5

namespace ControlPanel
{
    public class PanelSDK
    {
        private SerialPort Port;
        private int BaundRate = 9600;
        private int DataBits = 8;

        public enum Buttons
        {
            Wlaczanie = 51,
            Switcher = 39,
            WozekDoPrzodu = 40,
            WozekDoTylu = 42,
            SuwnicaWPrawo = 46,
            SuwnicaWLewo = 44,
            TestKontrolek = 41,
            Start = 43,
            Trawersa = 45,
            ZezwNaDemagnetyz = 47,
            Odhamowanie = 49,
            TestAkumulatora = 38,
            Opuszczanie = 11,
            Podnoszenie = 10,
            WylacznikAwaryjny = 2,
            KabinaDoPrzodu = 13,
            KabinaDoTylu = 12,
            DemagnetKontrolowana = 3,
            DemagnetCalkowita = 4,
            Magnetuzacja = 6
        }

        public enum Lights
        {
            Magnesy = 24,
            Hak = 22,
            Zasilanie = 35,
            GotowJazdyWozka = 33,
            BladJazdyWozka = 34,
            GotowJazdySuwnicy = 36,
            BladJazdySuwnicy = 32,
            GotowMechPodnoszenia = 26,
            BladMechPodnoszenia = 28,
            PrzekroczenieUdzwigu = 29,
            Przeciazenie = 27,
            GotowJazdyKabiny = 25,
            BladJazdyKabiny = 23
        }

        public PanelSDK(string Port = "COM1")
        {
            this.SerialInit(Port);
        }

        public bool GetButtonDown(int numButton)
        {
            CheckPort();

            Port.WriteLine(String.Format("1/{0}", numButton));

            string data = Port.ReadLine();
            
            if (data.Length >= 2)
            {
                if (data[1] == 'y')
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonUp(int numButton)
        {
            CheckPort();

            Port.WriteLine(String.Format("0/{0}", numButton));

            string data = Port.ReadLine();

            if (data[1] == 'y')
                return true;

            return false;
        }

        public void ActivateLight(int numLight, bool active)
        {
            CheckPort();

            if (active)
            {
                Port.WriteLine(String.Format("2/{0}", numLight));
            }
            else if (!active)
            {
                Port.WriteLine(String.Format("3/{0}", numLight));
            }
        }
        
        public void SwitchOnAllLights(bool active)
        {
            CheckPort();

            if (active)
            {
                Port.WriteLine(String.Format("{0}", 5));
            }
            else if (!active)
            {
                Port.WriteLine(String.Format("{0}", 4));
            }
        }

        private void CheckPort()
        {
            if (!Port.IsOpen)
                Port.Open();
        }

        private void SerialInit(string Port)
        {
            this.Port = new SerialPort(Port);
            this.Port.BaudRate = this.BaundRate;
            this.Port.Parity = Parity.None;
            this.Port.StopBits = StopBits.One;
            this.Port.DataBits = DataBits;
            this.Port.Handshake = Handshake.None;
            this.Port.Encoding = Encoding.UTF8;
            this.Port.Open();
        }      
    }
}
