using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Hooks
{
    /// <summary>
    /// 表示鼠标钩子的操作类
    /// </summary>
    public class GlobalHookMouse : GlobalHook
    {
        #region --常量--
        private const int WH_MOUSE_LL = 14;
        private const int WM_MOUSEMOVE = 512;
        private const int WM_LBUTTONDOWN = 513;
        private const int WM_RBUTTONDOWN = 516;
        private const int WM_MBUTTONDOWN = 519;
        private const int WM_LBUTTONUP = 514;
        private const int WM_RBUTTONUP = 517;
        private const int WM_MBUTTONUP = 520;
        private const int WM_LBUTTONDBLCLK = 515;
        private const int WM_RBUTTONDBLCLK = 518;
        private const int WM_MBUTTONDBLCLK = 521;
        private const int WM_MOUSEWHEEL = 522;
        private const int WM_XBUTTONDOWN = 523;
        private const int WM_XBUTTONUP = 524;
        private const int WM_XBUTTONDBLCLK = 525;
        #endregion

        #region --属性--
        /// <summary>
        /// 指定安装钩子的类型
        /// </summary>
        protected override int HookType { get { return WH_MOUSE_LL; } }
        #endregion

        #region --事件--
        /// <summary>
        /// 当鼠标指针按下鼠标键时发生
        /// </summary>
        public event MouseEventHandler MouseDown;
        /// <summary>
        /// 当鼠标指针释放鼠标键时发生
        /// </summary>
        public event MouseEventHandler MouseUp;
        /// <summary>
        /// 当鼠标指针移动时发生
        /// </summary>
        public event MouseEventHandler MouseMove;
        /// <summary>
        /// 当鼠标滚轮移动时发生
        /// </summary>
        public event MouseEventHandler MouseWheel;
        /// <summary>
        /// 鼠标单击时发生
        /// </summary>
        public event MouseEventHandler MouseClick;
        /// <summary>
        /// 鼠标双击时发生
        /// </summary>
        public event MouseEventHandler MouseDoubleClick;

        #endregion

        #region --构造函数--
        /// <summary>
        /// 初始化 <see cref="GlobalHookMouse"/> 类的新实例
        /// </summary>
        public GlobalHookMouse ()
            : base ()
        {
        }

        /// <summary>
        /// 初始化 <see cref="GlobalHookMouse"/> 使用指定的进程对象 <see cref="Process"/>
        /// </summary>
        /// <param name="process"></param>
        public GlobalHookMouse (Process process)
            : base (process)
        {
        }
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
                MouseInfo inputInfo = (MouseInfo)Marshal.PtrToStructure (lParam, typeof (MouseInfo));
                int delta = (short)((lParam.ToInt32 () >> 16) & 0xFFFF);

                switch (wParam)
                {
                    case WM_LBUTTONDOWN:
                        if (OnMouseDown (MouseButtons.Left, 1, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_LBUTTONUP:
                        if (OnMouseUp (MouseButtons.Left, 1, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        if (OnMouseClick (MouseButtons.Left, 1, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_LBUTTONDBLCLK:
                        if (OnMouseDoubleClick (MouseButtons.Left, 2, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_RBUTTONDOWN:
                        if (OnMouseDown (MouseButtons.Right, 1, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_RBUTTONUP:
                        if (OnMouseUp (MouseButtons.Right, 1, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        if (OnMouseClick (MouseButtons.Right, 1, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_RBUTTONDBLCLK:
                        if (OnMouseDoubleClick (MouseButtons.Right, 2, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_MBUTTONDOWN:
                        if (OnMouseDown (MouseButtons.Middle, 1, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_MBUTTONUP:
                        if (OnMouseUp (MouseButtons.Middle, 1, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        if (OnMouseClick (MouseButtons.Right, 1, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_MBUTTONDBLCLK:
                        if (OnMouseDoubleClick (MouseButtons.Right, 2, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_XBUTTONDOWN:
                        if (inputInfo.mouseData == 1)
                        {
                            if (OnMouseDown (MouseButtons.XButton1, 1, inputInfo.pt, delta))
                            {
                                return 1;
                            }
                        }
                        else
                        {
                            if (OnMouseDown (MouseButtons.XButton2, 1, inputInfo.pt, delta))
                            {
                                return 1;
                            }
                        }
                        break;
                    case WM_XBUTTONUP:
                        if (inputInfo.mouseData == 1)
                        {
                            if (OnMouseUp (MouseButtons.XButton1, 1, inputInfo.pt, delta))
                            {
                                return 1;
                            }
                            if (OnMouseClick (MouseButtons.XButton1, 1, inputInfo.pt, delta))
                            {
                                return 1;
                            }
                        }
                        else
                        {
                            if (OnMouseUp (MouseButtons.XButton2, 1, inputInfo.pt, delta))
                            {
                                return 1;
                            }
                            if (OnMouseClick (MouseButtons.XButton1, 1, inputInfo.pt, delta))
                            {
                                return 1;
                            }
                        }
                        break;
                    case WM_XBUTTONDBLCLK:
                        if (inputInfo.mouseData == 1)
                        {
                            if (OnMouseDoubleClick (MouseButtons.XButton1, 2, inputInfo.pt, delta))
                            {
                                return 1;
                            }
                        }
                        else
                        {
                            if (OnMouseDoubleClick (MouseButtons.XButton2, 2, inputInfo.pt, delta))
                            {
                                return 1;
                            }
                        }
                        break;
                    case WM_MOUSEMOVE:
                        if (OnMouseMove (MouseButtons.None, 0, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                    case WM_MOUSEWHEEL:
                        if (OnMouseWheel (MouseButtons.Middle, 0, inputInfo.pt, delta))
                        {
                            return 1;
                        }
                        break;
                }
            }

            return base.HookCallback (nCode, wParam, lParam);
        }
        #endregion

        #region --私有方法--
        private bool OnMouseDown (MouseButtons button, int clicks, POINT pt, int delta)
        {
            if (this.MouseDown != null)
            {
                MouseEventArgs args = new MouseEventArgs (button, clicks, pt.x, pt.y, delta);
                this.MouseDown (this, args);

                return args.Handled && args.SuppressMousePress;
            }
            return false;
        }
        private bool OnMouseUp (MouseButtons button, int clicks, POINT pt, int delta)
        {
            if (this.MouseUp != null)
            {
                MouseEventArgs args = new MouseEventArgs (button, clicks, pt.x, pt.y, delta);
                this.MouseUp (this, args);

                return args.Handled && args.SuppressMousePress;
            }
            return false;
        }
        private bool OnMouseMove (MouseButtons button, int clicks, POINT pt, int delta)
        {
            if (this.MouseMove != null)
            {
                MouseEventArgs args = new MouseEventArgs (button, clicks, pt.x, pt.y, delta);
                this.MouseMove (this, args);

                return args.Handled && args.SuppressMousePress;
            }
            return false;
        }
        private bool OnMouseWheel (MouseButtons button, int clicks, POINT pt, int delta)
        {
            if (this.MouseWheel != null)
            {
                MouseEventArgs args = new MouseEventArgs (button, clicks, pt.x, pt.y, delta);
                this.MouseWheel (this, args);

                return args.Handled && args.SuppressMousePress;
            }
            return false;
        }
        private bool OnMouseClick (MouseButtons button, int clicks, POINT pt, int delta)
        {
            if (this.MouseClick != null)
            {
                MouseEventArgs args = new MouseEventArgs (button, clicks, pt.x, pt.y, delta);
                this.MouseClick (this, args);

                return args.Handled && args.SuppressMousePress;
            }
            return false;
        }
        private bool OnMouseDoubleClick (MouseButtons button, int clicks, POINT pt, int delta)
        {
            if (this.MouseDoubleClick != null)
            {
                MouseEventArgs args = new MouseEventArgs (button, clicks, pt.x, pt.y, delta);
                this.MouseDoubleClick (this, args);

                return args.Handled && args.SuppressMousePress;
            }
            return false;
        }
        #endregion
    }
}
