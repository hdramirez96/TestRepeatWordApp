using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Core.DTOs;

namespace TestApp.Core.Services.Interfaces
{
    public interface IRepeatWordService
    {
        public RepeatWordDTO Get(RepeatWordDTO repeatWordDto);
        public IEnumerable<RepeatWordDTO> GetAll(RepeatWordDTO repeatWordDto);
    }
}
