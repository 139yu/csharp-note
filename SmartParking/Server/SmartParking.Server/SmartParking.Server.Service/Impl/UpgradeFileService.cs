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

        public List<UpgradeFileModel> GetUpgradeFiles(string keyword)
        {
            var queryable = this.Query<UpgradeFileModel>(f => f.State == 0);
            if (!string.IsNullOrEmpty(keyword))
            {
                queryable = from f in queryable where f.FileName.Contains(keyword) select f;

            }
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

        public void DeleteFile(int fileId)
        {
            this.Delete<UpgradeFileModel>(fileId);
        }

        public void saveFile(UpgradeFileModel fileModel)
        {
            this.Insert(fileModel);
        }
    }
}