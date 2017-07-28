using CardProHost.DTOs;
using CardProHost.Utils;
using ServiceStack;
using ServiceStack.Web;

namespace CardProHost.RequestFilters {
    public class DecryptFilterAttribute : RequestFilterAttribute {
        public override void Execute(IRequest req, IResponse res, object requestDto) {
            if (requestDto is DTOSecret) {
                // TODO: Get private key from session
                ((DTOSecret) requestDto).Data.CardProDecrypt();
            }
        }
           
    }
}