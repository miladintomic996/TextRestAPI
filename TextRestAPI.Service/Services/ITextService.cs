using System;
using System.Threading.Tasks;
using TextRestAPI.Model;

namespace TextRestAPI.Service
{
    public interface ITextService
    {

        TextResponse CountWords(String text);

        Task<TextResponse> CountWordsDb(int dbTextId);

        TextResponse CountWordsFile(string filename);
    }
}
