/****************************************************************************
 * Copyright (c) 2017 liangxie
 * Copyright (c) 2019.4 zhaoliang
 * 
 * http://liangxiegame.com
 * https://github.com/liangxiegame/QFramework
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

namespace ZLMsg
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 需要注册消息必须实现此接口
    /// </summary>
    public interface IMsgReceiver
    {
    }

    /// <summary>
    /// 需要发送消息必须实现此接口
    /// </summary>
    public interface IMsgSender
    {
    }

    /// <summary>
    /// 消息分发器
    /// </summary>
    public static class MsgDispatcher
    {
        /// <summary>
        /// 消息捕捉器
        /// </summary>
        private class LogicMsgHandler
        {
            public readonly IMsgReceiver Receiver;
            public readonly Action<IMsgParam> Callback;

            public LogicMsgHandler(IMsgReceiver receiver, Action<IMsgParam> callback)
            {
                Receiver = receiver;
                Callback = callback;
            }
        }

        /// <summary>
        /// 每个消息名字维护一组消息捕捉器。
        /// </summary>
        static readonly Dictionary<int, List<LogicMsgHandler>> mMsgHandlerDict =
            new Dictionary<int, List<LogicMsgHandler>>();


        /// <summary>
        /// 注册消息,必须实现接口IMsgReceiver
        /// </summary>
        public static void RegisterLogicMsg(this IMsgReceiver self, int msgName, Action<IMsgParam> callback = null)
        {
            if (msgName == 0)
            {
                return;
            }

            if (!mMsgHandlerDict.ContainsKey(msgName))
            {
                mMsgHandlerDict[msgName] = new List<LogicMsgHandler>();
            }

            List<LogicMsgHandler> handlers = mMsgHandlerDict[msgName];
            int handlerCount = handlers.Count;
            // 防止重复注册
            for (int i = 0; i < handlerCount; i++)
            {
                LogicMsgHandler handler = handlers[i];
                if (handler.Receiver == self && handler.Callback == callback)
                {
                    return;
                }
            }

            handlers.Add(new LogicMsgHandler(self, callback));
        }

        /// <summary>
        /// 发送消息,必须实现接口IMsgSender
        /// </summary>
        public static void SendLogicMsg(this IMsgSender sender, int msgName, IMsgParam paramList)
        {
            if (msgName == 0)
            {
                return;
            }

            if (!mMsgHandlerDict.ContainsKey(msgName))
            {
                return;
            }

            List<LogicMsgHandler> handlers = mMsgHandlerDict[msgName];
            int handlerCount = handlers.Count;

            // 之所以是从后向前遍历,是因为从前向后遍历删除后索引值会不断变化
            for (int i = handlerCount - 1; i >= 0; i--)
            {
                LogicMsgHandler handler = handlers[i];

                if (handler.Receiver != null)
                {
                    handler.Callback(paramList);
                }
                else
                {
                    handlers.Remove(handler);
                }
            }
        }

        /// <summary>
        /// 注销消息,必须实现接口IMsgReceiver
        /// </summary>
        public static void UnRegisterLogicMsg(this IMsgReceiver self, int msgName, Action<IMsgParam> callback)
        {
            if (msgName == 0)
            {
                return;
            }

            List<LogicMsgHandler> handlers = mMsgHandlerDict[msgName];

            for (int i = handlers.Count - 1; i >= 0; i--)
            {
                LogicMsgHandler handler = handlers[i];
                if (handler.Receiver == self && handler.Callback == callback)
                {
                    handlers.Remove(handler);
                    break;
                }
            }
        }
    }
}