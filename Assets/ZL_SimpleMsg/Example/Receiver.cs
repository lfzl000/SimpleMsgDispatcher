using QFramework;
using UnityEngine;

public class Receiver : MonoBehaviour, IMsgReceiver
{
    private void Awake()
    {
        this.RegisterLogicMsg(MsgName.MSG_TESTMSGNAME, ReceiveMsg);
    }

    private void ReceiveMsg(IMsgParam args)
    {
        //MsgParamObject msgParamObject = args as MsgParamObject;
        MsgParamAction msgParamObject = args as MsgParamAction;
        foreach (var arg in msgParamObject.param)
        {
            //Debug.Log(arg);
            arg.Invoke();
        }
    }

    private void OnDestroy()
    {
        this.UnRegisterLogicMsg(MsgName.MSG_TESTMSGNAME, ReceiveMsg);
    }
}