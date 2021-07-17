using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestApp.Core.DTOs;
using TestApp.Core.Services.Interfaces;

namespace TestApp.Core.Services
{
    public class RepeatWordService : IRepeatWordService
    {
        public RepeatWordDTO Get(RepeatWordDTO repeatWordDto)
        {
            if (string.IsNullOrEmpty(repeatWordDto.Word))
            {
                throw new ArgumentException("Word is required");
            }

            var text = Regex.Replace(repeatWordDto.Text, "[,\\.]", string.Empty);
            var words = text.Split(" ");
            var count = 0;
            foreach (var word in words)
            {
                if (word.Equals(repeatWordDto.Word, StringComparison.InvariantCultureIgnoreCase)) count++;
            }

            return new RepeatWordDTO
            {
                Text = text,
                Word = repeatWordDto.Word,
                Count = count
            };
        }

        public IEnumerable<RepeatWordDTO> GetAll(RepeatWordDTO repeatWordDto)
        {
            List<RepeatWordDTO> repeatWordList = new List<RepeatWordDTO>();
            var text = Regex.Replace(repeatWordDto.Text, "[,\\.]", string.Empty);
            var words = text.Split(" ");

            foreach (var mainWord in words)
            {
                var count = 0;
                foreach (var iterationWord in words)
                {
                    if (iterationWord.Equals(mainWord, StringComparison.InvariantCultureIgnoreCase)) count++;
                }

                repeatWordList.Add(new RepeatWordDTO
                {
                    Text = text,
                    Word = mainWord,
                    Count = count
                });
            }

            repeatWordList = (from item in repeatWordList
                              group item by new { item.Word, item.Count } into g
                              select new RepeatWordDTO()
                              {
                                  Text = text,
                                  Word = g.Key.Word,
                                  Count = g.Key.Count,
                              }).ToList();

            return repeatWordList;
        }
    }
}
