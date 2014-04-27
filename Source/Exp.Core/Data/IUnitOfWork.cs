namespace Exp.Core.Data
{
    /// <summary>
    ///     业务单元操作接口
    /// </summary>
    public interface IUnitOfWork
    {
        #region 属性

        /// <summary>
        ///     获取 当前单元操作是否已被提交
        /// </summary>
        bool IsCommitted { get; }

        #endregion

        #region 方法
    
        int Commit();

        
        void Rollback();

        #endregion
    }
}