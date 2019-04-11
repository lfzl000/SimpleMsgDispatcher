/****************************************************************************
 * Copyright (c) 2019.4 zhaoliang
 * 
 * https://github.com/lfzl000/SimpleMsgDispatcher
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

    //可以根据项目需要自由定义
    public interface IMsgParam
    {
    }

    public class MsgParam<T>: IMsgParam
    {
        public T param;
        public void SetParam(T _param)
        {
            param = _param;
        }
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