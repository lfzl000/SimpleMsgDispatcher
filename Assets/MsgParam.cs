namespace QFramework
{
    using System;

    //可以根据项目需要自由定义
    public interface IMsgParam
    {
    }

    public class MsgParamObject : IMsgParam
    {
        public object[] param;
        public void SetParam(params object[] _param)
        {
            param = _param;
        }
    }

    public class MsgParamAction : IMsgParam
    {
        public Action[] param;
        public void SetParam(params Action[] _param)
        {
            param = _param;
        }
    }
}