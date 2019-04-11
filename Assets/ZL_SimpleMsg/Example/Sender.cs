using ZLMsg;
using UnityEngine;

public class Sender : MonoBehaviour, IMsgSender
{
    void Update()
    {
        //MsgParamObject msgParamObject = new MsgParamObject();
        MsgParamAction msgParamObject = new MsgParamAction();
        msgParamObject.SetParam(TestAction);

        if (Input.GetMouseButtonDown(0))
            this.SendLogicMsg(MsgName.MSG_TESTMSGNAME, msgParamObject);
    }

    private void TestAction()
    {
        Debug.Log("Hello World");
    }
}