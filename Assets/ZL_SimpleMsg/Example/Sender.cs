using ZLMsg;
using UnityEngine;

public class Sender : MonoBehaviour, IMsgSender
{
    void Update()
    {
        //MsgParamObject msgParamObject = new MsgParamObject();
        MsgParam<string> msgParam = new MsgParam<string>();
        msgParam.SetParam("Hello World");

        if (Input.GetMouseButtonDown(0))
            this.SendLogicMsg(MsgName.MSG_TESTMSGNAME, msgParam);
    }

    private void TestAction()
    {
        Debug.Log("Hello World");
    }
}