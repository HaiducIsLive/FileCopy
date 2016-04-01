namespace FileCopy
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tFiles
    {
        public long Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string FileName { get; set; }

        [Required]
        [StringLength(1024)]
        public string Destination { get; set; }

        public long FileSize { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [NotMapped]
        public TimeSpan CopyTime { get { return EndTime - StartTime; } }
    }
}
