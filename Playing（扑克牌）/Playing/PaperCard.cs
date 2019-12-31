using System;

namespace Playing
{
    class PaperCard
    {

        public string Type { get; set; }
        public string Number { get; set; }
        public PaperCard(string strType, string strNumber)
        {
            this.Type = strType;
            this.Number = strNumber;
        }

        public string Name
        {
            get
            {
                return string.Format("{0}{1}", this.Type, this.Number);
            }

            private set { }



        }
    }


}

