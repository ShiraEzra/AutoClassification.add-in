using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SimilarWords
    {
        const int numOfSimiliarWords = 10;

        /// <summary>
        /// Extract similar words from the Html code.
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>list of similiar words</returns>
        public static List<string> GetSimilarWords(string word)
        {
            string html_ans = GetDataFromSimilarWordsSite(word);
            if (html_ans.Contains("<h1>האם התכוונת ל-</h1>"))
                return null;
            List<string> similarWords = new List<string>();
            int start = html_ans.IndexOf("data-word");
            html_ans = html_ans.Substring(start);
            start = 0;
            int end;
            while (similarWords.Count() <= numOfSimiliarWords && start != -1)
            {
                start = html_ans.IndexOf("\"", start) + 1;
                end = html_ans.IndexOf("\"", start);
                string sim_word = html_ans.Substring(start, end - start);
                similarWords.Add(sim_word);
                start = html_ans.IndexOf("data-word", end);
            }
            similarWords.RemoveAt(0);  //הראשון זה המילה בעצמה
            return similarWords;
        }


        /// <summary>
        /// Gets html code with the similiar words to the word wich sent.
        /// </summary>
        /// <param name="word">word</param>
        /// <returns>html code as string</returns>
        public static string GetDataFromSimilarWordsSite(string word)
        {
            string html_ans;
            using (WebClient client = new WebClient())
            {
                var data = client.DownloadData("https://synonyms.reverso.net/%D7%9E%D7%9C%D7%99%D7%9D-%D7%A0%D7%A8%D7%93%D7%A4%D7%95%D7%AA/he/" + word);
                html_ans = Encoding.UTF8.GetString(data);
            }
            return html_ans;
        }
    }
}
