namespace System.Hooks
{
    /// <summary>
    /// 表示将处理的方法 MouseDown, ，MouseUp, ，或 MouseMove 的事件。
    /// </summary>
    /// <param name="sender">事件源。</param>
    /// <param name="e">包含事件数据的 <see cref="MouseEventArgs"/>。</param>
    public delegate void MouseEventHandler (object sender, MouseEventArgs e);
}
