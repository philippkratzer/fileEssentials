using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEssentials.Model
{
    class PictureScaler
    {
        private string _pathPictures;
        private string _pathDestination;
        private List<string> _blacklist;
        private int _longSideLengt;

        public event EventHandler<int> FileAddedEvent;
        public event EventHandler<int> FileSkippedEvent;

        public PictureScaler(string pathPictures, string pathDestination, List<string> blacklist, int longSideLength)
        {
            _pathPictures = pathPictures;
            _pathDestination = pathDestination;
            _blacklist = blacklist;
            _longSideLengt = longSideLength;
        }

        public void Start()
        {

        }
    }
}
