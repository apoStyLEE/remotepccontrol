using System;
using NUnit.Framework;

namespace RemotePcControl.Tests
{
    [TestFixture]
    public class RemoteMediaGeneralTests
    {
        [Test]
        public void PlayerPlayPause()
        {
            RemoteSender.PlayPause();
        }
        
        
        [Test]
        public void PlayerVolumeUp()
        {
            RemoteSender.VolumeUp();
        }
        
        [Test]
        public void PlayerVolumeDown()
        {
            RemoteSender.VolumeDown();
        }
        
        [Test]
        public void PlayerMute()
        {
            RemoteSender.Mute();
        }     
        
        
        [Test]
        public void PlayerGetVolume()
        {
            var volume = RemoteSender.GetVolume();
            Console.WriteLine(volume);
        }
    }
}
