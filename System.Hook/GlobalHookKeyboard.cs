using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Hooks
{
    /// <summary>
    /// 表示键盘钩子的实例类型
    /// </summary>
    public class GlobalHookKeyboard : GlobalHook
    {
        #region --常量--
        private const int KEY_STATE_SIZE = 256;
        private const int KEY_BUFFER_SIZE = 2;
        private const int WM_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x0105;
        #endregion

        #region --属性--
        /// <summary>
        /// 指定安装钩子的类型
        /// </summary>
        protected override int HookType { get { return WM_KEYBOARD_LL; } }
        #endregion

        #region --事件--
        /// <summary>
        /// 按下键时发生。
        /// </summary>
        public event KeyEventHandler KeyDown;
        /// <summary>
        /// 释放键时发生。
        /// </summary>
        public event KeyEventHandler KeyUp;
        /// <summary>
        /// 按下 字符、空格或退格键时发生。
        /// </summary>
        public event KeyPressEventHandler KeyPress;
        #endregion

        #region --构造函数--
        /// <summary>
        /// 初始化 <see cref="GlobalHookKeyboard"/> 类的新实例
        /// </summary>
        public GlobalHookKeyboard ()
            : base ()
        {

        }

        /// <summary>
        /// 初始化 <see cref="GlobalHookKeyboard"/> 使用指定的进程对象 <see cref="Process"/>
        /// </summary>
        /// <param name="process">进程的 <see cref="Process"/> 对象</param>
        public GlobalHookKeyboard (Process process)
            : base (process)
        { }
        #endregion

        #region --公开方法--
        /// <summary>
        /// 处理当前实例收到来自操作系统的消息
        /// </summary>
        /// <param name="nCode">包含有关消息本身的信息</param>
        /// <param name="wParam">消息标示，用于判断该消息是那种消息</param>
        /// <param name="lParam">包含所钩消息的信息指针</param>
        /// <returns></returns>
        protected internal override int HookCallback (int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KeyboardInfo inputInfo = (KeyboardInfo)Marshal.PtrToStructure (lParam, typeof (KeyboardInfo));

                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                {
                    if (OnKeyDown (AppendModifierStates ((Keys)inputInfo.wVk)) == true)
                    {
                        return 1;
                    }
                }

                if (wParam == WM_KEYDOWN)
                {
                    byte[] keyState = new byte[KEY_STATE_SIZE];
                    User32.GetKeyboardState (keyState);

                    byte[] inBuffer = new byte[KEY_BUFFER_SIZE];
                    if (User32.ToAscii (inputInfo.wVk, inputInfo.wScan, keyState, inBuffer, inputInfo.dwFlags) == 1)
                    {
                        if (OnKeyPress ((char)inBuffer[0]) == true)
                        {
                            return 1;
                        }
                    }
                }

                if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP)
                {
                    if (OnKeyUp (AppendModifierStates ((Keys)inputInfo.wVk)) == true)
                    {
                        return 1;
                    }
                }
            }

            return base.HookCallback (nCode, wParam, lParam);
        }
        #endregion

        #region --私有方法--
        private bool OnKeyDown (Keys keyDatas)
        {
            if (this.KeyDown != null)
            {
                KeyEventArgs args = new KeyEventArgs (keyDatas);
                this.KeyDown (this, args);

                return args.Handled && args.SuppressKeyPress;
            }
            return false;
        }
        private bool OnKeyUp (Keys keyDatas)
        {
            if (this.KeyUp != null)
            {
                KeyEventArgs args = new KeyEventArgs (keyDatas);
                this.KeyUp (this, args);

                return args.Handled && args.SuppressKeyPress;
            }
            return false;
        }
        private bool OnKeyPress (char keyChar)
        {
            if (this.KeyPress != null)
            {
                KeyPressEventArgs args = new KeyPressEventArgs (keyChar);
                this.KeyPress (this, args);

                return args.Handled;
            }
            return false;
        }
        private static Keys AppendModifierStates (Keys keyData)
        {
            if (User32.GetKeyState (16) < 0)
            {
                keyData |= Keys.Shift;
            }
            if (User32.GetKeyState (17) < 0)
            {
                keyData |= Keys.Control;
            }
            if (User32.GetKeyState (18) < 0)
            {
                keyData |= Keys.Alt;
            }
            return keyData;
        }
        #endregion
    }
}
