using CardProHost.DTOs;
using CardProHost.Utils;
using ServiceStack;
using ServiceStack.Web;

namespace CardProHost.RequestFilters {

    public class DecryptFilterAttribute : RequestFilterAttribute {
        public override void Execute(IRequest req, IResponse res, object requestDto) {
            if (requestDto is DTOSecret) {
                //var userSession = req.SessionAs<AuthUserSession>();
                //((DTOSecret)requestDto).Data = ((DTOSecret) requestDto).Data
                //    .AESCardProDecrypt(userSession?.ClientSessionKey);
            }
        }
           
    }
}