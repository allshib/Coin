using Coin.Module.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Module.Models
{
    public class MoneyByDate
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset Date {  get; set; }
        public decimal Sum { get; set; }

        //[ForeignKey(nameof(Category))]
        //public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public MoneyOperationType OperationType { get; set; }
        public string? Comment { get; set; }
    }
}
