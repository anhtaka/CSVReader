using System;
using System.Collections.Generic;
using System.IO;

namespace csv_output
{
    public class CSVReader<T> : IEnumerable<T>, IDisposable
            where T : LineData, new()
    {
        private StreamReader reader;
        private string filepath;
        private bool skip;

        public CSVReader(string filepath, bool skip = true)
        {
            if (!filepath.EndsWith(".csv", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new FormatException("拡張子が.csvではないファイル名が指定されました。");
            }
            this.filepath = filepath;
            this.skip = skip;
            reader = new StreamReader(filepath);
            if (skip) reader.ReadLine();
        }

        public void Dispose()
        {
            reader.Dispose();
        }

        public IEnumerator<T> GetEnumerator()
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var data = new T();
                data.SetDataFrom(line.Split(','));
                yield return data;
            }
            reader = new StreamReader(filepath);
            if (skip) reader.ReadLine();
            yield break;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
