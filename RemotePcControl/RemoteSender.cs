using System;
using System.Runtime.InteropServices;

namespace RemotePcControl
{
    public class RemoteSender
    {
        private static void SendKeyStroke(Vk sendEvent)
        {
            SendKeyDown(sendEvent);
            SendKeyUp(sendEvent);
        }

        private static void SendKeyDown(Vk sendEvent)
        {
            uint intReturn; // ersin was here!
            NativeMethods.INPUT structInput;
            structInput = new NativeMethods.INPUT();
            structInput.type = NativeMethods.INPUT_KEYBOARD;

            // Key down shift, ctrl, and/or alt
            structInput.ki.wScan = 0;
            structInput.ki.time = 0;
            structInput.ki.dwFlags = 0;
            structInput.ki.dwExtraInfo = NativeMethods.GetMessageExtraInfo();
            structInput.ki.wVk = (ushort)sendEvent;

            intReturn = NativeMethods.SendInput(1, ref structInput, Marshal.SizeOf(structInput));
        }

        private static void SendKeyUp(Vk sendEvent)
        {
            uint intReturn; // ersin was here!
            NativeMethods.INPUT structInput;
            structInput = new NativeMethods.INPUT();
            structInput.type = NativeMethods.INPUT_KEYBOARD;

            // Key down shift, ctrl, and/or alt
            structInput.ki.wScan = 0;
            structInput.ki.time = 0;
            structInput.ki.dwExtraInfo = NativeMethods.GetMessageExtraInfo();
            structInput.ki.wVk = (ushort)sendEvent;

            structInput.ki.dwFlags = NativeMethods.KEYEVENTF_KEYUP;
            intReturn = NativeMethods.SendInput(1, ref structInput, Marshal.SizeOf(structInput));
        }

        public static void ChannelUp()
        {
            SendKeyStroke(Vk.VK_UP);
        }

        public static void ChannelDown()
        {
            SendKeyStroke(Vk.VK_DOWN);
        }

        public static void VolumeUp()
        {
            SendKeyStroke(Vk.VK_VOLUME_UP);
        }

        public static void VolumeDown()
        {
            SendKeyStroke(Vk.VK_VOLUME_DOWN);
        }

        public static void Mute()
        {
            SendKeyStroke(Vk.VK_VOLUME_MUTE);
        }


        public static int GetVolume()
        {
            throw new NotImplementedException();
        }

        public static void PlayPause()
        {
            SendKeyStroke(Vk.VK_MEDIA_PLAY_PAUSE);
        }

        public static void Left()
        {
            SendKeyStroke(Vk.VK_LEFT);
        }

        public static void Right()
        {
            SendKeyStroke(Vk.VK_RIGHT);
        }
        
        public static void Enter()
        {
            SendKeyStroke(Vk.VK_RETURN);
        }

        public static void BackSpace()
        {
            SendKeyStroke(Vk.VK_BACK);
        }
    }
}