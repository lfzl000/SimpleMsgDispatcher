# 简易消息机制

## 使用说明

### 注册消息

步骤:

1. 引入命名空间 ZLMsg
2. 实现接口 IMsgReceiver
3. 在 MsgName 定义一个消息名

注册消息代码示例:

``` csharp
using ZLMsg;
using UnityEngine;

public class Receiver : MonoBehaviour, IMsgReceiver
{
    private void Awake()
    {
        this.RegisterLogicMsg(MsgName.MSG_TESTMSGNAME, ReceiveMsg);
    }

    private void ReceiveMsg(IMsgParam args)
    {
        MsgParam<string> msgParam = args as MsgParam<string>;
        Debug.Log(msgParam.param);
    }

    private void OnDestroy()
    {
        this.UnRegisterLogicMsg(MsgName.MSG_TESTMSGNAME, ReceiveMsg);
    }
}
```

定义消息名称:

``` csharp
namespace ZLMsg
{
    //不要用0
    public class MsgName
    {
        public const int MSG_TESTMSGNAME = 1000;
    }
}
```

### 发送消息

步骤:

1. 引入命名空间 ZLMsg
2. 实现接口 IMsgSender

发送消息代码示例:

``` csharp
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
}
```

## 版权说明

> 本项目核心逻辑参考[https://github.com/liangxiegame/QFramework](https://github.com/liangxiegame/QFramework)
> 在此源码基础上进行本地化修改并保留版权信息
