namespace System.Hooks
{
    /// <summary>
    /// 表示在 <see cref="GlobalHook"/> 执行卸载过程中发生的错误。
    /// </summary>
    public class HookUnInstallException : HookException
    {
        /// <summary>
        /// 初始化 <see cref="HookUnInstallException"/> 类的新实例
        /// </summary>
        public HookUnInstallException ()
            : base (Kernel32.GetLastError ())
        {
        }
    }
}
