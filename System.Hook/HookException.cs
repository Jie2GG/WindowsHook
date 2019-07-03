using System.ComponentModel;
using System.Runtime.Serialization;

namespace System.Hooks
{
    /// <summary>
    /// 表示在 <see cref="GlobalHook"/> 执行过程中发生的错误。
    /// </summary>
    public class HookException : Win32Exception
    {
        /// <summary>
        /// 初始化 <see cref="HookException"/> 类的新实例
        /// </summary>
        public HookException () :
            base ()
        { }

        /// <summary>
        /// 新实例初始化 <see cref="HookException"/> 类，具有指定的错误。
        /// </summary>
        /// <param name="error">与此异常关联的 Win32 错误代码。</param>
        public HookException (int error) :
            base (error)
        {
        }

        /// <summary>
        /// 用指定的错误消息初始化 <see cref="HookException"/> 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public HookException (string message)
            : base (message)
        {
        }

        /// <summary>
        /// 新实例初始化 <see cref="HookException"/> 带有指定的错误和指定的类的详细说明。
        /// </summary>
        /// <param name="error">与此异常关联的 Win32 错误代码。</param>
        /// <param name="message">错误的详细的说明。</param>
        public HookException (int error, string message)
            : base (error, message)
        {
        }

        /// <summary>
        /// 使用指定的错误消息和对作为此异常原因的内部异常的引用来初始化 <see cref="HookException"/> 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误消息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 Nothing）。</param>
        public HookException (string message, Exception innerException)
            : base (message, innerException)
        {
        }

        /// <summary>
        /// 用序列化数据初始化 <see cref="HookException"/> 类的新实例。
        /// </summary>
        /// <param name="info">包含有关所引发异常的序列化对象数据的 <see cref="SerializationInfo"/>。</param>
        /// <param name="context"><see cref="StreamingContext"/>，它包含关于源或目标的上下文信息。</param>
        /// <exception cref="ArgumentNullException">info 参数为 null。</exception>
        /// <exception cref="SerializationException">类名为 null 或者 <see cref="Exception.HResult"/> 为零 (0)。</exception>
        protected HookException (SerializationInfo info, StreamingContext context)
            : base (info, context)
        {
        }
    }
}
