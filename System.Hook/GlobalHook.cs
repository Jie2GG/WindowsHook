using System.Diagnostics;

namespace System.Hooks
{
    /// <summary>
    /// 表示系统钩子的操作类, 该类是抽象的
    /// </summary>
    public abstract class GlobalHook : IDisposable
    {
        #region --字段--
        private bool _isInstall;
        private bool _isDispose;
        private IntPtr _hhook;
        private HookProc _hookProc;
        private readonly Process _process;
        #endregion

        #region --属性--
        /// <summary>
        /// 当在派生类中重写时, 指定安装钩子的类型
        /// </summary>
        protected abstract int HookType { get; }
        #endregion

        #region --构造函数--
        /// <summary>
        /// 初始化 <see cref="GlobalHook"/> 类的新实例
        /// </summary>
        public GlobalHook ()
            : this (Process.GetCurrentProcess ())
        { }

        /// <summary>
        /// 初始化 <see cref="GlobalHook"/> 使用指定的进程对象 <see cref="Process"/>
        /// </summary>
        /// <param name="process">进程的 <see cref="Process"/> 对象</param>
        public GlobalHook (Process process)
        {
            this._hhook = IntPtr.Zero;
            this._process = process;
        }

        /// <summary>
        /// 释放由 <see cref="GlobalHook"/> 类所占用的操作系统资源
        /// </summary>
        ~GlobalHook ()
        {
            this.Dispose ();
        }
        #endregion

        #region --公开方法--
        /// <summary>
        /// 将当前实例安装到操作系统
        /// </summary>
        public void Install ()
        {
            CheckingDispose ();

            if (this._isInstall == false && this._hhook == IntPtr.Zero)
            {
                // 初始化回调函数
                if (this._hookProc == null)
                {
                    this._hookProc = new HookProc (HookCallback);
                }

                // 获取进程的实例指针
                IntPtr instance = Kernel32.GetModuleHandle (this._process.MainModule.ModuleName);

                // 根据当前进程安装全局 Hook
                this._hhook = User32.SetWindowsHookEx (this.HookType, this._hookProc, instance, 0);

                // 判断是否安装成功
                if (this._hhook == IntPtr.Zero)
                {
                    // TODO: 引发异常
                    throw new HookInstallException ();
                }

                this._isInstall = true;
            }
        }

        /// <summary>
        /// 将当实例从操作系统中移除
        /// </summary>
        public void UnInstall ()
        {
            CheckingDispose ();

            if (this._isInstall == true && this._hhook != IntPtr.Zero)
            {
                if (User32.UnhookWindowsHookEx (this._hhook))
                {
                    this._isInstall = false;
                }
                else
                {
                    // 释放掉指针
                    Kernel32.CloseHandle (this._hhook);

                    // TODO: 引发异常
                    throw new HookUnInstallException ();
                }
            }
        }

        /// <summary>
        /// 当在派生类中重写时, 处理当前实例收到来自操作系统的消息
        /// </summary>
        /// <param name="nCode">包含有关消息本身的信息</param>
        /// <param name="wParam">消息标示，用于判断该消息是那种消息</param>
        /// <param name="lParam">包含所钩消息的信息指针</param>
        /// <returns></returns>
        protected internal virtual int HookCallback (int nCode, int wParam, IntPtr lParam)
        {
            return User32.CallNextHookEx (this._hhook, nCode, wParam, lParam);
        }

        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务。
        /// </summary>
        public void Dispose ()
        {
            if (_isDispose == false)
            {
                this.UnInstall ();
                GC.SuppressFinalize (this);
                this._isDispose = true;
            }
        }
        #endregion

        #region --私有方法--
        private void CheckingDispose ()
        {
            if (this._isDispose == true)
            {
                throw new ObjectDisposedException (typeof (GlobalHook).Name);
            }
        }
        #endregion
    }
}
