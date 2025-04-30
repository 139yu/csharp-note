using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SamrtParking.Server.IService.Service;
using SmartParking.Server.Models;

namespace SmartParking.Server.Service.Impl
{
    public class UpgradeFileService : BaseService, IUpgradeFileService
    {
        public UpgradeFileService(IDBConfig.IDBConfig dbConfig) : base(dbConfig)
        {
        }

        public List<UpgradeFileModel> GetAllUpgradeFiles()
        {
            var queryable = this.Query<UpgradeFileModel>(f => f.State == 0);
            if (queryable != null)
            {
                return queryable.ToList();
            }

            return new List<UpgradeFileModel>();
        }

        public UpgradeFileModel GetUpgradeFileByMD5(string fileMD5)
        {
            var query = this.Query<UpgradeFileModel>(f => f.FileMd5 == fileMD5);
            if (query != null && query.Count() > 0)
            {
                return query.FirstOrDefault();
            }
            return null;
        }
    }
}