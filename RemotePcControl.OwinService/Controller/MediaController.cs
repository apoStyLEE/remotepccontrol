using System.Web.Http;

namespace RemotePcControl.OwinService.Controller
{
    [RoutePrefix("api/media")]    
    public class MediaController : ApiController
    {
        [Route("playPause")]
        [HttpGet]
        public bool PlayPause()
        {
            RemoteSender.PlayPause();
            return true;
        }
        
        [Route("volumeUp")]
        [HttpGet]
        public bool VolumeUp()
        {
            RemoteSender.VolumeUp();
            return true;
        }

        [Route("volumeDown")]
        [HttpGet]
        public bool VolumeDown()
        {
            RemoteSender.VolumeDown();
            return true;
        }

        [Route("volumeMute")]
        [HttpGet]
        public bool VolumeMute()
        {
            RemoteSender.Mute();
            return true;
        }
    } 
}