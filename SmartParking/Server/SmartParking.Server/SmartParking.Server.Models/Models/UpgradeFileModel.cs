using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Server.Models
{
    [Table("upgrade_file")]
    public class UpgradeFileModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("file_id")]
        public int? FileId { get; set; }
        [Column("file_name")]
        public string? FileName { get; set; }
        [Column("file_md5")]
        public string? FileMd5 { get; set; }
        [Column("file_len")]
        public long? FileLen { get; set; }
        [Column("upload_time")]
        public string UploadTime { get; set; }
        [Column("state")]
        public int? State { get; set; }
    }
}