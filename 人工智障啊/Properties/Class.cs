using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AI.Properties
{
    public class Textclass : IEnumerable<string>
    {
        private string _filePath;
        public Textclass(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public class StreamReaderEnumerable : IEnumerable<string>
    {
        private string _filePath;
        public StreamReaderEnumerable(string filePath)
        {
            _filePath = filePath;
        }

        // 必须实现 GetEnumerator，用于返回一个新的 StreamReaderEnumerator.
        public IEnumerator<string> GetEnumerator() => new StreamReaderEnumerator(_filePath);

        // 同时必须实现 IEnumerable.GetEnumerator，但当成一个私有方法实现
        private IEnumerator GetEnumerator1() => this.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();

        /// <summary>
        /// 在实现 IEnumerable<T> 时，必须实现IEnumerator<T>，范例代码中，遍历文件内容时，每一行一次
        /// 实现 IEnumerable<T> 还需要实现 IEnumerator 和析构函数 IDisposable
        /// </summary>
        public class StreamReaderEnumerator : IEnumerator<string>
        {
            private StreamReader _sr;
            public StreamReaderEnumerator(string filePath)
            {/*D:\下载\早期作业\Reposiyory-master\AI\Properties\tempFile.txt*/
                _sr = new StreamReader(filePath);
            }
            private string _current;
            // 实现 IEnumerator<T>().Current 公开属性，但实现所必须的 IEnumerator.Current 则为私有属性.
            public string Current
            {
                get
                {
                    if (_sr == null || _current == null)
                        throw new InvalidOperationException();
                    return _current;
                }
            }
            private object Current1 => this.Current;
            object IEnumerator.Current => Current1;
            // 实现 IEnumerator 所必须的 MoveNext 和 Reset。
            public bool MoveNext()
            {
                _current = _sr.ReadLine();
                if (_current == null)
                    return false;
                return true;
            }
            public void Reset()
            {
                _sr.DiscardBufferedData();
                _sr.BaseStream.Seek(0, SeekOrigin.Begin);
                _current = null;
            }
            // 实现析构函数，必须的。
            private bool disposedValue = false;
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposedValue)
                {
                    if (disposing) { } // 析构所需要的资源
                    _current = null;
                    if (_sr != null)
                    {
                        _sr.Close();
                        _sr.Dispose();
                    }
                }
                this.disposedValue = true;
            }
            ~StreamReaderEnumerator() { Dispose(false); }
        }
    }

}
