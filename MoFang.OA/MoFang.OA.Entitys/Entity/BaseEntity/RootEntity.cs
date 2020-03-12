using System;
using System.Collections.Generic;
using System.Text;

namespace MoFang.OA.Entity.Entity.BaseEntity
{
    public class RootEntity
    {
        /// <summary>
        /// 标识Id
        /// </summary>
        public int RId { get; set; }
        /// <summary>
        /// 是否被删除 软删除使用
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
