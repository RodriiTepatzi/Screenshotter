using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace GlobalHotkeys
{
    class GetVirtualHexKey
    {
        VirtualHexKeyCodes KeyCodes = new VirtualHexKeyCodes();
        public int GetVirtualKey(Key key)
        {
            switch (key)
            {
                case Key.A:
                    return KeyCodes.aKey;
                case Key.B:
                    return KeyCodes.bKey;
                case Key.C:
                    return KeyCodes.cKey;
                case Key.D:
                    return KeyCodes.dKey;
                case Key.E:
                    return KeyCodes.eKey;
                case Key.F:
                    return KeyCodes.fKey;
                case Key.G:
                    return KeyCodes.gKey;
                case Key.H:
                    return KeyCodes.hKey;
                case Key.I:
                    return KeyCodes.iKey;
                case Key.J:
                    return KeyCodes.jKey;
                case Key.K:
                    return KeyCodes.kKey;
                case Key.L:
                    return KeyCodes.lKey;
                case Key.M:
                    return KeyCodes.mKey;
                case Key.N:
                    return KeyCodes.nKey;
                case Key.O:
                    return KeyCodes.oKey;
                case Key.P:
                    return KeyCodes.pKey;
                case Key.Q:
                    return KeyCodes.qKey;
                case Key.R:
                    return KeyCodes.rKey;
                case Key.S:
                    return KeyCodes.sKey;
                case Key.T:
                    return KeyCodes.tKey;
                case Key.U:
                    return KeyCodes.uKey;
                case Key.V:
                    return KeyCodes.vKey;
                case Key.W:
                    return KeyCodes.wKey;
                case Key.X:
                    return KeyCodes.xKey;
                case Key.Y:
                    return KeyCodes.wKey;
                case Key.Z:
                    return KeyCodes.zKey;
                case Key.D0:
                    return KeyCodes.n0Key;
                case Key.D1:
                    return KeyCodes.n1Key;
                case Key.D2:
                    return KeyCodes.n2Key;
                case Key.D3:
                    return KeyCodes.n3Key;
                case Key.D4:
                    return KeyCodes.n4Key;
                case Key.D5:
                    return KeyCodes.n5Key;
                case Key.D6:
                    return KeyCodes.n6Key;
                case Key.D7:
                    return KeyCodes.n7Key;
                case Key.D8:
                    return KeyCodes.n8Key;
                case Key.D9:
                    return KeyCodes.n9Key;
                case Key.NumPad0:
                    return KeyCodes.numPad0Key;
                case Key.NumPad1:
                    return KeyCodes.numPad1Key;
                case Key.NumPad2:
                    return KeyCodes.numPad2Key;
                case Key.NumPad3:
                    return KeyCodes.numPad3Key;
                case Key.NumPad4:
                    return KeyCodes.numPad4Key;
                case Key.NumPad5:
                    return KeyCodes.numPad5Key;
                case Key.NumPad6:
                    return KeyCodes.numPad6Key;
                case Key.NumPad7:
                    return KeyCodes.numPad7Key;
                case Key.NumPad8:
                    return KeyCodes.numPad8Key;
                case Key.NumPad9:
                    return KeyCodes.numPad9Key;
                default: return 0x0;
            }
        }
    }
}
