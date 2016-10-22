using System.Collections.Generic;

namespace Pgpg.Submall.Lib
{
    public interface ISender
    {
        /**
	     * Send the request data.
	     * @param data {@link HashMap}contains the request data.Such as
	     * <p>
	     * to->xxx@submail.cn
	     * cc->nnn@submail.cn
	     * text->Hello,world!
	     * </p>
	     * @return If send successfully,return true.Error occurs,return false.
	     **/
        bool Send(Dictionary<string, object> data, out string returnMessage);

        bool XSend(Dictionary<string, object> data, out string returnMessage);

        bool MultiXSend(Dictionary<string, object> data, out string returnMessage);

        bool Subscribe(Dictionary<string, object> data, out string returnMessage);

        bool UnSubscribe(Dictionary<string, object> data, out string returnMessage);

        bool VoiceVerify(Dictionary<string, object> data, out string returnMessage);
    }
}