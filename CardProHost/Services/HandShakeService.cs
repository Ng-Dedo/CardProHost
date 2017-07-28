using CardProHost.DTOs;
using ServiceStack;
using System.Net;

namespace CardProHost.Services {
    public class HandShakeService : Service {
        public object Post(HandShake handshake) {
            return new { token = handshake?.Key  };
        }   
    }
}