using ZLMsg;
using UnityEngine;

public class Sender : MonoBehaviour, IMsgSender
{
    private MsgParam<string> msgParam;
    private void Start()
    {
        msgParam = new MsgParam<string>();
        msgParam.SetParam("Hello World");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.SendLogicMsg(MsgName.MSG_TESTMSGNAME, msgParam);
        }
    }

    private void TestAction()
    {
        Debug.Log("Hello World");
    }
}