namespace System.Hooks
{
    /// <summary>
    /// 表示在 <see cref="GlobalHook"/> 执行安装过程中发生的错误。
    /// </summary>
    public class HookInstallException : HookException
    {
        /// <summary>
        /// 初始化 <see cref="HookInstallException"/> 类的新实例
        /// </summary>
        public HookInstallException ()
            : base (Kernel32.GetLastError ())
        {
        }
    }
}
