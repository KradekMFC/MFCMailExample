using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MFCMailExample
{
    class MFCMailMessage
    {
        private readonly HtmlNode _node;
        public MFCMailMessage(HtmlNode mailRow)
        {
            _node = mailRow;
        }
        /* Commenting this out for now--MFC is doing something tricky
         * with their From and Subject fields
        private String _from;
        public String From 
        {
            get
            {
                if (null == _from)
                    _from = _node.SelectSingleNode(".//td[2]").InnerText;
                return _from;
            }
        }
        private String _date;
        public String Date { get; set; }
        private String _subject;
        public String Subject { get; set; }
        */
        public Boolean IsNew 
        {
            get
            {
                return _node.InnerHtml.Contains("(New!)");
            }
        }
    }
}
