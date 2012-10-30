using System;

namespace Cudo.Entities
{
    public class WebSet
    {
        private string _webname = "";
        private string _logo = "";
        private string _weburl = "";
        private string _webtel = "";
        private string _webfax = "";
        private string _webemail = "";
        private string _webaddress = "";
        private string _cookiename = "";
        private string _webkeywords = "";
        private string _webdescription = "";
        private string _webcopyright = "";
        private string _EmailLoginName = "";
        private string _EmailLoginPass;
        private string _SmtpServer;
        private string _ServiceQQ;
        private string _HotDistrict;

        public string HotDistrict
        {
            get { return _HotDistrict; }
            set { _HotDistrict = value; }
        }

        public string ServiceQQ
        {
            get { return _ServiceQQ; }
            set { _ServiceQQ = value; }
        }

        /// <summary>
        ///  
        /// </summary>
        public string WebName
        {
            set { _webname = value; }
            get { return _webname; }
        }

        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        
        public string WebUrl
        {
            set { _weburl = value; }
            get { return _weburl; }
        }
       
        public string WebTel
        {
            set { _webtel = value; }
            get { return _webtel; }
        }
       
        public string WebFax
        {
            set { _webfax = value; }
            get { return _webfax; }
        }

        public string CookieName
        {
            get { return _cookiename; }
            set { _cookiename = value; }
        }
        
        public string WebEmail
        {
            set { _webemail = value; }
            get { return _webemail; }
        }

       
        public string WebAddress
        {
            set { _webaddress = value; }
            get { return _webaddress; }
        }

        
        public string WebKeywords
        {
            set { _webkeywords = value; }
            get { return _webkeywords; }
        }

        
        public string WebDescription
        {
            set { _webdescription = value; }
            get { return _webdescription; }
        }
        
        public string WebCopyright
        {
            set { _webcopyright = value; }
            get { return _webcopyright; }
        }

        public string EmailLoginName
        {
            set { _EmailLoginName = value; }
            get { return _EmailLoginName; }
        }
       
        public string EmailLoginPass
        {
            set { _EmailLoginPass = value; }
            get { return _EmailLoginPass; }
        }
        public string SmtpServer
        {
            set { _SmtpServer = value; }
            get { return _SmtpServer; }
        }

    }
}