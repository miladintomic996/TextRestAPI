using NetCoreRepositoryAndUnitOfWorkPattern.Data.Models;
using NetCoreRepositoryAndUnitOfWorkPattern.Service.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using TextRestAPI.Model;

namespace TextRestAPI.Service
{
    public class TextService : ITextService
    {
        private IDbTextService _dbTextService;

        public TextService(IDbTextService dbTextService)
        {
            this._dbTextService = dbTextService;
        }

        public TextResponse CountWords(string text)
        {
            try
            {
                char[] delimiters = new char[] { ' ', '\r', '\n' };
                int wordsCount = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

                return new TextResponse { Content = text, WordsCount = wordsCount };
            }
            catch (Exception ex)
            {
                return new TextResponse { Error = String.Format("Can't count words, reason: {0}", ex.Message) };
            }
        }

        public async Task<TextResponse> CountWordsDb(int dbTextId)
        {
            Text textRecord = await _dbTextService.GetTextByIdAsync(dbTextId);
            if (textRecord.Equals(null))
            {
                return new TextResponse { Error = String.Format("Record doesn't exist in db, record id: {0}", dbTextId) };
            }
            return CountWords(textRecord.Content);
        }

        public TextResponse CountWordsFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return new TextResponse { Error = String.Format("File doesn't exist, filename: {0}", filename) };
            }
            string contents = File.ReadAllText(filename);
            return CountWords(contents);
        }
    }
}
