using System;
using System.Collections.Generic;
using ZeroStack.DeviceCenter.Domain.Entities;

namespace ZeroStack.DeviceCenter.Domain.Aggregates.ProductAggregate
{
    public class Product : BaseAggregateRoot<Guid>, ISoftDelete, IMultiTenant
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// 所属项目
        /// </summary>
        public int? ProjectId { get; set; }

        /// <summary>
        /// 设备列表
        /// </summary>
        public List<Device>? Devices { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string? Remark { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// 租户标识
        /// </summary>
        public Guid? TenantId { get; set; }
    }
}
